using UnityEngine;
using UnityEditor;
using System.Collections.Generic;

public partial class UIBasicSpriteEditor : UIWidgetInspector
{
    /// <summary>
    /// Draw all the custom properties such as sprite type, flip setting, fill direction, etc.
    /// </summary>

    protected override void DrawCustomProperties()
    {
        GUILayout.Space(6f);

        SerializedProperty sp = NGUIEditorTools.DrawProperty("Type", serializedObject, "mType", GUILayout.MinWidth(20f));

        UISprite.Type type = (UISprite.Type)sp.intValue;

        if (type == UISprite.Type.Simple)
        {
            NGUIEditorTools.DrawProperty("Flip", serializedObject, "mFlip");
        }
        else if (type == UISprite.Type.Tiled)
        {
            NGUIEditorTools.DrawBorderProperty("Trim", serializedObject, "mBorder");
            NGUIEditorTools.DrawProperty("Flip", serializedObject, "mFlip");
        }
        else if (type == UISprite.Type.Sliced)
        {
            NGUIEditorTools.DrawBorderProperty("Border", serializedObject, "mBorder");
            NGUIEditorTools.DrawProperty("Flip", serializedObject, "mFlip");

            EditorGUI.BeginDisabledGroup(sp.hasMultipleDifferentValues);
            {
                sp = serializedObject.FindProperty("centerType");
                bool val = (sp.intValue != (int)UISprite.AdvancedType.Invisible);

                if (val != EditorGUILayout.Toggle("Fill Center", val))
                {
                    sp.intValue = val ? (int)UISprite.AdvancedType.Invisible : (int)UISprite.AdvancedType.Sliced;
                }
            }
            EditorGUI.EndDisabledGroup();
        }
        else if (type == UISprite.Type.Filled)
        {
            NGUIEditorTools.DrawProperty("Flip", serializedObject, "mFlip");
            NGUIEditorTools.DrawProperty("Fill Dir", serializedObject, "mFillDirection", GUILayout.MinWidth(20f));
            GUILayout.BeginHorizontal();
            GUILayout.Space(4f);
            NGUIEditorTools.DrawProperty("Fill Amount", serializedObject, "mFillAmount", GUILayout.MinWidth(20f));
            GUILayout.Space(4f);
            GUILayout.EndHorizontal();
            NGUIEditorTools.DrawProperty("Invert Fill", serializedObject, "mInvert", GUILayout.MinWidth(20f));
        }
        else if (type == UIBasicSprite.Type.SlicedFilled)
        {
            NGUIEditorTools.DrawBorderProperty("Border", serializedObject, "mBorder");
            NGUIEditorTools.DrawProperty("Flip", serializedObject, "mFlip");
            NGUIEditorTools.DrawProperty("Fill Dir", serializedObject, "mFillDirection", GUILayout.MinWidth(20f));
            GUILayout.BeginHorizontal();
            GUILayout.Space(4f);
            NGUIEditorTools.DrawProperty("Fill Amount", serializedObject, "mFillAmount", GUILayout.MinWidth(20f));
            GUILayout.Space(4f);
            GUILayout.EndHorizontal();
            GUILayout.BeginHorizontal();
            GUILayout.Space(4f);
            NGUIEditorTools.DrawProperty("Vertex Offset", serializedObject, "mVertexOffset", GUILayout.MinWidth(20f));
            GUILayout.Space(4f);
            GUILayout.EndHorizontal();
            NGUIEditorTools.DrawProperty("Invert Fill", serializedObject, "mInvert", GUILayout.MinWidth(20f));
        }
        else if (type == UISprite.Type.Advanced)
        {
            NGUIEditorTools.DrawBorderProperty("Border", serializedObject, "mBorder");
            NGUIEditorTools.DrawProperty("  Left", serializedObject, "leftType");
            NGUIEditorTools.DrawProperty("  Right", serializedObject, "rightType");
            NGUIEditorTools.DrawProperty("  Top", serializedObject, "topType");
            NGUIEditorTools.DrawProperty("  Bottom", serializedObject, "bottomType");
            NGUIEditorTools.DrawProperty("  Center", serializedObject, "centerType");
            NGUIEditorTools.DrawProperty("Flip", serializedObject, "mFlip");
        }

        GUI.changed = false;
        Vector4 draw = EditorGUILayout.Vector4Field("Draw Region", mWidget.drawRegion);

        if (GUI.changed)
        {
            NGUIEditorTools.RegisterUndo("Draw Region", mWidget);
            mWidget.drawRegion = draw;
        }

		GUI.changed = false;
		var basicSprite = mWidget as UIBasicSprite;
		Vector4 draw2 = EditorGUILayout.Vector4Field("Edge Cutoff", basicSprite.edgeCutoff);
		
		if (GUI.changed)
		{
			NGUIEditorTools.RegisterUndo("Edge Cutoff", basicSprite);
			basicSprite.edgeCutoff = draw2;
		}

        base.DrawCustomProperties();
    }
}
