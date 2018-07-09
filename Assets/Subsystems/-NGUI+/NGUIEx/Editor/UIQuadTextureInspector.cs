using UnityEngine;
using UnityEditor;
using System.Collections;

[CanEditMultipleObjects]
[CustomEditor(typeof(UIQuadTexture), true)]
public class UIQuadTextureInspector : UIBasicSpriteEditor
{
    UIQuadTexture mTex;

    protected override void OnEnable()
    {
        base.OnEnable();
        mTex = target as UIQuadTexture;
    }

    protected override bool ShouldDrawProperties()
    {
        if (target == null) return false;
        SerializedProperty sp = NGUIEditorTools.DrawProperty("Texture", serializedObject, "mTexture");
        NGUIEditorTools.DrawProperty("Material", serializedObject, "mMat");

        if (sp != null) NGUISettings.texture = sp.objectReferenceValue as Texture;

        if (mTex != null && (mTex.material == null || serializedObject.isEditingMultipleObjects))
        {
            NGUIEditorTools.DrawProperty("Shader", serializedObject, "mShader");
        }

        EditorGUI.BeginDisabledGroup(mTex == null || mTex.mainTexture == null || serializedObject.isEditingMultipleObjects);

        NGUIEditorTools.DrawRectProperty("UV Rect", serializedObject, "mRect");

        sp = serializedObject.FindProperty("mFixedAspect");
        bool before = sp.boolValue;
        NGUIEditorTools.DrawProperty("Fixed Aspect", sp);
        if (sp.boolValue != before) (target as UIWidget).drawRegion = new Vector4(0f, 0f, 1f, 1f);

        EditorGUILayout.PropertyField(serializedObject.FindProperty("mVertexOffsets"), true);

        if (sp.boolValue)
        {
            EditorGUILayout.HelpBox("Note that Fixed Aspect mode is not compatible with Draw Region modifications done by sliders and progress bars.", MessageType.Info);
        }

        EditorGUI.EndDisabledGroup();
        return true;
    }

    public override bool HasPreviewGUI()
    {
        return (Selection.activeGameObject == null || Selection.gameObjects.Length == 1) &&
            (mTex != null) && (mTex.mainTexture as Texture2D != null);
    }

    public override void OnPreviewGUI(Rect rect, GUIStyle background)
    {
        Texture2D tex = mTex.mainTexture as Texture2D;

        if (tex != null)
        {
            Rect tc = mTex.uvRect;
            tc.xMin *= tex.width;
            tc.xMax *= tex.width;
            tc.yMin *= tex.height;
            tc.yMax *= tex.height;
            NGUIEditorTools.DrawSprite(tex, rect, mTex.color, tc, mTex.border);
        }
    }
}
