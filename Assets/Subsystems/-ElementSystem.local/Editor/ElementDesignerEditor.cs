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
                // 配合 Unity 2018 的嵌套 Prefab 功能，因此不允许嵌套设计器
                if(elementDesigner.ParentDesigner == null)
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
}