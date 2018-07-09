using UnityEngine;
using System.Collections.Generic;
using UnityEditor;

public partial class UIAtlasMaker : EditorWindow
{
	public void UpdateAtlas (List<Texture> textures, bool keepSprites)
	{
		// Create a list of sprites using the collected textures
		List<SpriteEntry> sprites = CreateSprites(textures);
		
		if (sprites.Count > 0)
		{
			// Extract sprites from the atlas, filling in the missing pieces
			if (keepSprites) ExtractSprites(NGUISettings.atlas, sprites);
			
			// NOTE: It doesn't seem to be possible to undo writing to disk, and there also seems to be no way of
			// detecting an Undo event. Without either of these it's not possible to restore the texture saved to disk,
			// so the undo process doesn't work right. Because of this I'd rather disable it altogether until a solution is found.
			
			// The ability to undo this action is always useful
			//NGUIEditorTools.RegisterUndo("Update Atlas", UISettings.atlas, UISettings.atlas.texture, UISettings.atlas.material);
			
			// Update the atlas
			UpdateAtlas(NGUISettings.atlas, sprites);
		}
		else if (!keepSprites)
		{
			UpdateAtlas(NGUISettings.atlas, sprites);
		}
	}
}
public static partial class NGUIEditorTools
{


	static public bool MakeTextureReadable (string path, bool force)
	{
		if (string.IsNullOrEmpty(path)) return false;
		TextureImporter ti = AssetImporter.GetAtPath(path) as TextureImporter;
		if (ti == null) return false;
		
		TextureImporterSettings settings = new TextureImporterSettings();
		ti.ReadTextureSettings(settings);
		bool readable = true;
		if (force || !settings.readable || settings.npotScale != TextureImporterNPOTScale.None || settings.alphaIsTransparency)
		{
			readable = false;
		}
		if(readable)
		{
			int maxTextureSize;
			TextureImporterFormat textureFormat;
			#if UNITY_IPHONE
				if (ti.GetPlatformTextureSettings ("iPhone", out maxTextureSize, out textureFormat)) 
					readable = (textureFormat == TextureImporterFormat.ARGB32 || textureFormat == TextureImporterFormat.RGBA32);
				else readable = false;
			#elif UNITY_ANDROID
				if (ti.GetPlatformTextureSettings ("Android", out maxTextureSize, out textureFormat)) 
					readable = (textureFormat == TextureImporterFormat.ARGB32 || textureFormat == TextureImporterFormat.RGBA32);
				else readable = false;
			#elif UNITY_WP8
				if (ti.GetPlatformTextureSettings ("WP8", out maxTextureSize, out textureFormat)) 
					readable = (textureFormat == TextureImporterFormat.ARGB32 || textureFormat == TextureImporterFormat.RGBA32);
				else readable = false;
			#else 
			readable = (settings.textureFormat == TextureImporterFormat.ARGB32 || settings.textureFormat == TextureImporterFormat.RGBA32 || settings.textureFormat == TextureImporterFormat.AutomaticTruecolor);
			#endif
		}

		if(!readable)
		{
			settings.readable = true;
			if (NGUISettings.trueColorAtlas) settings.textureFormat = TextureImporterFormat.AutomaticTruecolor;
			settings.npotScale = TextureImporterNPOTScale.None;
			settings.alphaIsTransparency = false;
			#if UNITY_IPHONE
			ti.SetPlatformTextureSettings("iPhone",4096,TextureImporterFormat.ARGB32);
			#elif UNITY_ANDROID
			ti.SetPlatformTextureSettings("Android",4096,TextureImporterFormat.ARGB32);
			#elif UNITY_WP8
			ti.SetPlatformTextureSettings("WP8",4096,TextureImporterFormat.ARGB32);
			#else
			settings.textureFormat = TextureImporterFormat.AutomaticTruecolor;
			#endif
			ti.SetTextureSettings(settings);
			AssetDatabase.ImportAsset(path, ImportAssetOptions.ForceUpdate | ImportAssetOptions.ForceSynchronousImport);
		}
		return true;
	}
	
	/// <summary>
	/// Change the import settings of the specified texture asset, making it suitable to be used as a texture atlas.
	/// </summary>
	
	public static bool MakeTextureAnAtlas (string path, bool force, bool alphaTransparency)
	{
		if (string.IsNullOrEmpty(path)) return false;
		TextureImporter ti = AssetImporter.GetAtPath(path) as TextureImporter;
		if (ti == null) return false;
		
		TextureImporterSettings settings = new TextureImporterSettings();
		ti.ReadTextureSettings(settings);
		bool compressed = true;

		if (force ||
		    settings.readable ||
		    settings.maxTextureSize > 2048 ||
		    settings.wrapMode != TextureWrapMode.Clamp ||
		    settings.npotScale != TextureImporterNPOTScale.ToNearest ||
		    settings.aniso != 1)
		{
			compressed = false;
		}

		int maxTextureSize;
		TextureImporterFormat textureFormat;
		int compressionQuality;
		if (compressed)
		{
			if(ti.GetPlatformTextureSettings("iPhone", out maxTextureSize, out textureFormat, out compressionQuality))
				compressed = maxTextureSize <= 2048 && textureFormat == TextureImporterFormat.PVRTC_RGB4 && compressionQuality == 100;
			else
				compressed = false;
		}
		if (compressed) {
			if(ti.GetPlatformTextureSettings("Android", out maxTextureSize, out textureFormat, out compressionQuality))
				compressed = maxTextureSize <= 2048 && textureFormat == TextureImporterFormat.ETC_RGB4 && compressionQuality == 100;
			else
				compressed = false;
		}
		if (compressed) {
			if(ti.GetPlatformTextureSettings("WP8", out maxTextureSize, out textureFormat))
				compressed = maxTextureSize <= 2048 && textureFormat == TextureImporterFormat.DXT1;
			else
				compressed = false;
		}
		if (compressed) {
			compressed = (settings.textureFormat == TextureImporterFormat.ARGB32 || settings.textureFormat == TextureImporterFormat.RGBA32) && settings.textureFormat == TextureImporterFormat.AutomaticTruecolor;
		}

		if(!compressed)
		{
			settings.ApplyTextureType (TextureImporterType.Default, true);
			settings.readable = false;
			settings.maxTextureSize = 2048;
			settings.wrapMode = TextureWrapMode.Clamp;
			settings.npotScale = TextureImporterNPOTScale.ToNearest;
			if(settings.mipmapEnabled)
				settings.filterMode = FilterMode.Trilinear;
			else
				settings.filterMode = FilterMode.Bilinear;
			settings.aniso = 1;
			settings.alphaIsTransparency = alphaTransparency;
			settings.textureFormat = TextureImporterFormat.AutomaticTruecolor;

			ti.SetTextureSettings(settings);
			ti.SetPlatformTextureSettings("iPhone", 2048, TextureImporterFormat.PVRTC_RGB4, 100, false);
			ti.SetPlatformTextureSettings("Android", 2048, TextureImporterFormat.ETC_RGB4, 100, false);
			ti.SetPlatformTextureSettings("WP8", 2048, TextureImporterFormat.DXT1, false);
			AssetDatabase.ImportAsset(path, ImportAssetOptions.ForceUpdate | ImportAssetOptions.ForceSynchronousImport);
		}
		return true;
	}
	
//	static public bool MakeTextureReadable (string path, bool force)
//	{
//		if (string.IsNullOrEmpty (path))
//			return false;
//		TextureImporter ti = AssetImporter.GetAtPath (path) as TextureImporter;
//		if (ti == null)
//			return false;
//		
//		TextureImporterSettings settings = new TextureImporterSettings ();
//		ti.ReadTextureSettings (settings);
//		
//		bool flag = false;
//		if (force ||
//		    !settings.readable ||
//		    settings.npotScale != TextureImporterNPOTScale.None) {
//			flag = true;
//		}
//		
//		if (!flag) {
//			int maxTextureSize;
//			TextureImporterFormat textureFormat;
//			#if UNITY_IPHONE
//			if (ti.GetPlatformTextureSettings ("iPhone", out maxTextureSize, out textureFormat)) {
//				flag = textureFormat != TextureImporterFormat.ARGB32 && textureFormat != TextureImporterFormat.RGBA32;
//				#elif UNITY_ANDROID
//				if (ti.GetPlatformTextureSettings ("Android", out maxTextureSize, out textureFormat)) {
//					flag = textureFormat != TextureImporterFormat.ARGB32 && textureFormat != TextureImporterFormat.RGBA32;
//					#elif UNITY_WP8
//					if (ti.GetPlatformTextureSettings ("WP8", out maxTextureSize, out textureFormat)) {
//						flag = textureFormat != TextureImporterFormat.ARGB32 && textureFormat != TextureImporterFormat.RGBA32;
//						#else 
//						if(true) {
//							flag = settings.textureFormat != TextureImporterFormat.ARGB32 && settings.textureFormat != TextureImporterFormat.RGBA32 && settings.textureFormat != TextureImporterFormat.AutomaticTruecolor;
//							#endif
//						} else {
//							flag = true;
//						}
//					}
//					//change setting
//					if(flag) {
//						settings.ApplyTextureType (TextureImporterType.Advanced, true);
//						settings.readable = true;
//						settings.npotScale = TextureImporterNPOTScale.None;
//						#if UNITY_IPHONE
//						ti.SetPlatformTextureSettings("iPhone",4096,TextureImporterFormat.ARGB32);
//						#elif UNITY_ANDROID
//						ti.SetPlatformTextureSettings("Android",4096,TextureImporterFormat.ARGB32);
//						#elif UNITY_WP8
//						ti.SetPlatformTextureSettings("WP8",4096,TextureImporterFormat.ARGB32);
//						#else
//						settings.textureFormat = TextureImporterFormat.AutomaticTruecolor;
//						#endif
//						ti.SetTextureSettings (settings);
//						AssetDatabase.ImportAsset (path, ImportAssetOptions.ForceUpdate | ImportAssetOptions.ForceSynchronousImport);
//					}
//					return true;
//				}
//				
//				/// <summary>
//				/// Change the import settings of the specified texture asset, making it suitable to be used as a texture atlas.
//				/// </summary>
//				
//				static public bool MakeTextureAnAtlas (string path, bool force, bool alphaTransparency)
//				{
//					if (string.IsNullOrEmpty (path))
//						return false;
//					TextureImporter ti = AssetImporter.GetAtPath (path) as TextureImporter;
//					if (ti == null)
//						return false;
//					
//					TextureImporterSettings settings = new TextureImporterSettings ();
//					ti.ReadTextureSettings (settings);
//					int maxTextureSize;
//					TextureImporterFormat textureFormat;
//					int compressionQuality;
//					bool flag = false;
//					
//					if (force ||
//					    settings.readable ||
//					    (settings.filterMode == FilterMode.Bilinear && settings.mipmapEnabled) ||
//					    (settings.filterMode == FilterMode.Bilinear && settings.aniso != 1) ||
//					    (settings.filterMode == FilterMode.Trilinear && !settings.mipmapEnabled) ||
//					    (settings.filterMode == FilterMode.Trilinear && settings.aniso != 1) ||
//					    settings.npotScale != TextureImporterNPOTScale.ToNearest) {
//						flag = true;
//					}
//					if (!flag) {
//						if(ti.GetPlatformTextureSettings("iPhone", out maxTextureSize, out textureFormat, out compressionQuality))
//							flag = maxTextureSize > 2048 || textureFormat != TextureImporterFormat.PVRTC_RGB4 || compressionQuality != 100;
//						else
//							flag = true;
//					}
//					if (!flag) {
//						if(ti.GetPlatformTextureSettings("Android", out maxTextureSize, out textureFormat, out compressionQuality))
//							flag = maxTextureSize > 2048 || textureFormat != TextureImporterFormat.ETC_RGB4 || compressionQuality != 100;
//						else
//							flag = true;
//					}
//					if (!flag) {
//						if(ti.GetPlatformTextureSettings("WP8", out maxTextureSize, out textureFormat))
//							flag = maxTextureSize > 2048 || textureFormat != TextureImporterFormat.DXT1;
//						else
//							flag = true;
//					}
//					if (!flag) {
//						flag = settings.textureFormat != TextureImporterFormat.ARGB32 && settings.textureFormat != TextureImporterFormat.RGBA32 && settings.textureFormat != TextureImporterFormat.AutomaticTruecolor;
//					}
//					//change setting
//					if(flag) {
//						settings.ApplyTextureType (TextureImporterType.Advanced, true);
//						settings.readable = false;
//						settings.maxTextureSize = 2048;
//						settings.npotScale = TextureImporterNPOTScale.ToNearest;
//						if(settings.filterMode != FilterMode.Point){
//							if(settings.mipmapEnabled)
//								settings.filterMode = FilterMode.Trilinear;
//							else
//								settings.filterMode = FilterMode.Bilinear;
//							settings.aniso = 1;
//						}
//						ti.SetPlatformTextureSettings("iPhone", 2048, TextureImporterFormat.PVRTC_RGB4, 100);
//						ti.SetPlatformTextureSettings("Android", 2048, TextureImporterFormat.ETC_RGB4, 100);
//						ti.SetPlatformTextureSettings("WP8", 2048, TextureImporterFormat.DXT1);
//						settings.textureFormat = TextureImporterFormat.AutomaticTruecolor;
//						ti.SetTextureSettings (settings);
//						AssetDatabase.ImportAsset (path, ImportAssetOptions.ForceUpdate | ImportAssetOptions.ForceSynchronousImport);
//					}
//					return true;
//				}
}