using UnityEngine;
using UnityEditor;
using System.IO;

public class SeperateAlphaTools
{
		[MenuItem ("Tools/Seperate Alpha")]
		public static void SeperateAlpha ()
		{
				var obs = Selection.GetFiltered (typeof(Object), SelectionMode.Deep);
				foreach (var ie in obs) {
						var tx = ie as Texture2D;
						if (tx == null)
								continue;

						var tp1 = AssetDatabase.GetAssetPath (tx);
						var tp2 = Path.GetFullPath (tp1);
						var ex = Path.GetExtension (tp1);


						if (!NGUIEditorTools.MakeTextureReadable (tp1, false))
								continue;
						int width = tx.width;
						int height = tx.height;
						var txa = new Texture2D (width, height, TextureFormat.RGB24, false);
//
//						var cs = tx.GetPixels (0, 0, tx.width, tx.height);
//						for (int i = 0, count = cs.Length; i < count; ++i) {
//								Color c = cs [i];
//								c = new Color (c.a, c.a, c.a, c.a);
//								cs [i] = c;
//						}
//						txa.SetPixels (cs);
						for (int i =0; i<width; ++i) {
							for (int j =0; j<height; ++j) {
								Color c = tx.GetPixel (i, j);
								c = new Color (c.a, c.a, c.a, c.a);
								txa.SetPixel (i, j, c);
							}
						}
						txa.Apply ();

						var bytes = txa.EncodeToPNG ();
						tp2 = tp2.Insert (tp2.Length - ex.Length, "_A");
						File.WriteAllBytes (tp2, bytes);

						NGUIEditorTools.MakeTextureAnAtlas (tp1, false, false);
						tp1 = tp1.Insert (tp1.Length - ex.Length, "_A");
						AssetDatabase.ImportAsset (tp1);
						NGUIEditorTools.MakeTextureAnAtlas (tp1, false,false);
				}
		}

	[MenuItem ("Tools/Seperate  Small Alpha")]
	static void SeperateSmallAlpha ()
	{
		var obs = Selection.GetFiltered (typeof(Object), SelectionMode.Deep);
		foreach (var ie in obs) {
			var tx = ie as Texture2D;
			if (tx == null)
				continue;
			
			var tp1 = AssetDatabase.GetAssetPath (tx);
			var tp2 = Path.GetFullPath (tp1);
			var ex = Path.GetExtension (tp1);
			
			
			if (!NGUIEditorTools.MakeTextureReadable (tp1, false))
				continue;
			int width = tx.width/2;
			int height = tx.height/2;
			var txa = new Texture2D (width, height);

			for (int i =0; i<width; ++i) {
				for (int j =0; j<height; ++j) {
					Color c = tx.GetPixel (2 * i, 2 * j);
					c = new Color (c.a, c.a, c.a, c.a);
					txa.SetPixel (i, j, c);
				}
			}
			txa.Apply ();
			var bytes = txa.EncodeToPNG ();
			tp2 = tp2.Insert (tp2.Length - ex.Length, "_A");
			File.WriteAllBytes (tp2, bytes);
			
			NGUIEditorTools.MakeTextureAnAtlas (tp1, false,false);
			tp1 = tp1.Insert (tp1.Length - ex.Length, "_A");
			AssetDatabase.ImportAsset (tp1);
			NGUIEditorTools.MakeTextureAnAtlas (tp1, false, false);
		}
	}
}




