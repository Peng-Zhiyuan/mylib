using UnityEngine;
using System.Collections;
using UnityEditor;

namespace ElementSystem
{

    [CustomEditor(typeof(ElementDesigner))]
    public class ElementDesignerEditor : Editor 
    {

        ElementDesigner elementDesigner
        {
            get
            {
                return target as ElementDesigner;
            }
        }

        public override void OnInspectorGUI()
        {
            //base.OnInspectorGUI();
            var list = elementDesigner.GetComponentsInChildren<ElementCreator>();
            GUILayout.Label(list.Length + " Creator");
            if (!Application.isPlaying)
            {
                if (GUILayout.Button("Preview"))
                {
                    elementDesigner.Preview();
                }
                if (GUILayout.Button("RemovePreview"))
                {
                    elementDesigner.RemovePreview();
                }
                EditorGUILayout.Separator();
                if (GUILayout.Button("GenerateCode"))
                {
                    ElementEditorUtils.GenerateCodeForTree(elementDesigner.gameObject);
                }
            }
        }
            
    }
}