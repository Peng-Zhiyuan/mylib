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
            if (!Application.isPlaying)
            {
                //EditorGUILayout.Separator();
                if (GUILayout.Button("GenerateCode"))
                {
                    ElementEditorUtils.GenerateCodeForTree(elementDesigner);
                }
            }
        }
            
    }
}