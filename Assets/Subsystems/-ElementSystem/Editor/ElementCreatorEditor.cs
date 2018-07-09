using UnityEngine;
using System.Collections;
using UnityEditor;
using System.Collections.Generic;


namespace ElementSystem
{
    [CustomEditor(typeof(ElementCreator))]
    public class ElementCreatorEditor : Editor {

        private ElementCreator creator
        {
            get
            {
                return target as ElementCreator;
            }
        }


        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();

            if (creator.HasPreview)
            {
                if (NGUIEditorTools.DrawHeader("Params"))
                {
                    NGUIEditorTools.BeginContents();
                    RemoveUnusedParams();
  
                    var type = creator.PreviewElement.GetType();
                    var list = type.GetProperties(System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.Public);
                    foreach (var p in list)
                    {
                        if (!p.IsDefined(typeof(CreatorWriteAttribute), true))
                        {
                            continue;
                        }
                        var key = p.Name;
                        var value = creator.param.Get(key);
                        string newValue;
                        if (p.PropertyType == typeof(bool))
                        {
                            bool boolValue;
                            var success = bool.TryParse(value, out boolValue);
                            if (!success)
                            {
                                boolValue = false;
                            }
                            boolValue = EditorGUILayout.Toggle(key, boolValue);
                            newValue = boolValue.ToString();
                        }
                        else if (p.PropertyType == typeof(Vector2))
                        {
                            if (value == null)
                            {
                                value = "";
                            }
                            float x;
                            float y;
                            var parts = value.Split(',');
                            if (parts.Length >= 2)
                            {
                                x = float.Parse(parts[0]);
                                y = float.Parse(parts[1]);
                            }
                            else
                            {
                                x = 0f;
                                y = 0f;
                            }
                            var vector2 = new Vector2(x, y);
                            var newVector2 = EditorGUILayout.Vector2Field(key, vector2);
                            if (newVector2 != vector2)
                            {
                                newValue = newVector2.x + "," + newVector2.y;
                            }
                            else
                            {
                                newValue = value;
                            }

                        }
                        else
                        {
                            newValue = EditorGUILayout.TextField(key, value);
                        }
                        creator.param.Set(key, newValue);
                    }

                    NGUIEditorTools.EndContents();
                }
            }

            DrawSelector();
        }

        public static Dictionary<string, bool> tempDic = new Dictionary<string, bool>();
        private void RemoveUnusedParams()
        {
            if (creator.HasPreview)
            {
                tempDic.Clear();
                var usedDic = tempDic;
                var type = creator.PreviewElement.GetType();
                var list = type.GetProperties(System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.Public);
                foreach (var p in list)
                {
                    if (p.IsDefined(typeof(CreatorWriteAttribute), true))
                    {
                        usedDic.Add(p.Name, true);
                    }
                }
                var keys = creator.param.Keys;
                var unused = new List<string>();
                foreach (var key in keys)
                {
                    if (!usedDic.ContainsKey(key))
                    {
                        unused.Add(key);
                    }
                }
                foreach (var key in unused)
                {
                    creator.param.Remove(key);
                }
            }
        }

        private string[] GetAllElmentPrefabList()
        {
            var list = AssetDatabase.FindAssets("t:prefab", new string[]{"Assets/Resources/Element"});
            return list;
        }


        List<string> list = new List<string>();
        void OnEnable()
        {
            var guidList = GetAllElmentPrefabList();
            list.Clear();
            foreach (var guid in guidList)
            {
                var path = AssetDatabase.GUIDToAssetPath(guid);
                var name = System.IO.Path.GetFileNameWithoutExtension(path);
                list.Add(name);
            }
            //Debug.Log(string.Join(",", list.ToArray()));
        }

        private void DrawSelector()
        {
            GUILayout.Space(6f);
            NGUIEditorTools.SetLabelWidth(80f);

            GUILayout.BeginHorizontal();
            // Key not found in the localization file -- draw it as a text field
            //SerializedProperty sp = NGUIEditorTools.DrawProperty("Key", serializedObject, "key");

            string myKey = creator.elementName;
            var mKeys = list;
            bool isPresent = (mKeys != null) && mKeys.Contains(myKey);
            GUI.color = isPresent ? Color.green : Color.red;
            GUILayout.BeginVertical(GUILayout.Width(22f));
            GUILayout.Space(2f);
            GUILayout.Label(isPresent? "\u2714" : "\u2718", "TL SelectionButtonNew", GUILayout.Height(20f));
            GUILayout.EndVertical();
            GUI.color = Color.white;
            GUILayout.EndHorizontal();

            if (isPresent)
            {
                /*
                if (NGUIEditorTools.DrawHeader("Preview"))
                {
                    NGUIEditorTools.BeginContents();



                    NGUIEditorTools.EndContents();
                }*/
            }
            else if (mKeys != null && !string.IsNullOrEmpty(myKey))
            {
                GUILayout.BeginHorizontal();
                GUILayout.Space(80f);
                GUILayout.BeginVertical();
                GUI.backgroundColor = new Color(1f, 1f, 1f, 0.35f);

                int matches = 0;

                for (int i = 0, imax = mKeys.Count; i < imax; ++i)
                {
                    if (mKeys[i].StartsWith(myKey, System.StringComparison.OrdinalIgnoreCase) || mKeys[i].Contains(myKey))
                    {
                        if (GUILayout.Button(mKeys[i] + " \u25B2", "CN CountBadge"))
                        {
                            //sp.stringValue = mKeys[i];
                            creator.elementName = mKeys[i];
                            GUIUtility.hotControl = 0;
                            GUIUtility.keyboardControl = 0;
                        }

                        if (++matches == 8)
                        {
                            GUILayout.Label("...and more");
                            break;
                        }
                    }
                }
                GUI.backgroundColor = Color.white;
                GUILayout.EndVertical();
                GUILayout.Space(22f);
                GUILayout.EndHorizontal();
            }
        }
    }

}

