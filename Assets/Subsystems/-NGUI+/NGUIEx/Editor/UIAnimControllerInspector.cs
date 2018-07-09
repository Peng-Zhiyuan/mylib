using UnityEngine;
using UnityEditor;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization;
[CustomEditor(typeof(UIAnimController))]
public class UIAnimControllerInspector : Editor
{
    private UIAnimController m_ctrl;
    private UIAnimController m_other;

    public override void OnInspectorGUI()
    {
        m_ctrl = target as UIAnimController;

        EditorGUILayout.BeginHorizontal();
        {
            //m_other = EditorGUILayout.ObjectField(m_other, typeof(UIAnimController), true) as UIAnimController;
            //if (GUILayout.Button("Load From Existing"))
            //{
            //    if (m_other == null) return;
            //    foreach (UIAnimData animData in m_other.m_animDatas)
            //    {
            //        UIAnimData newAnimData = new UIAnimData();
            //        foreach (UIAnimFrame animFrame in animData.m_frames)
            //        {
            //            newAnimData.m_frames.Add(UIAnimFrame.CreateFrom(animFrame));
            //        }
            //        m_ctrl.m_animDatas.Add(newAnimData);
            //    }
            //}
            if (GUILayout.Button("Copy"))
            {
				SaveTempData<List<UIAnimData>>(m_ctrl.m_animDatas);
            }

            if (GUILayout.Button("Paste"))
            {
				List<UIAnimData> dataList = LoadTempData<List<UIAnimData>>();
                for (int i = 0; i < dataList.Count; i++)
                {
                    if (i < m_ctrl.m_animDatas.Count)
                        m_ctrl.m_animDatas[i].CopyFramesFrom(dataList[i]);
                    else
                        m_ctrl.m_animDatas.Add(dataList[i]);
                }
            }
        }
        EditorGUILayout.EndHorizontal();
        if (GUILayout.Button("Play"))
        {
            if (Application.isPlaying)
            {
                m_ctrl.Play(null);
            }
        }
        if (GUILayout.Button("Log duration"))
        {
            Debug.Log(m_ctrl.GetDuration());
        }
        ListField<UIAnimData>("AnimData", m_ctrl, m_ctrl.m_animDatas, AnimDataEditor, ref m_ctrl.m_extendListView);
    }

    void AnimDataEditor(System.Object animCtrlObj, UIAnimData data)
    {
        EditorGUILayout.BeginVertical();
        {
            EditorGUILayout.BeginHorizontal();
            {
                E_AnimTarget targetType = (E_AnimTarget)EditorGUILayout.EnumPopup(data.m_targetType);
                if (data.m_targetType != targetType)
                {
                    data.m_targetType = targetType;
                }

				if (data.m_targetType == E_AnimTarget.GameObject || data.m_targetType == E_AnimTarget.Children || data.m_targetType == E_AnimTarget.AllChildren)
                {
                    data.m_target = EditorGUILayout.ObjectField(data.m_target, typeof(GameObject), true) as GameObject;
                }

                if (GUILayout.Button("Copy"))
                {
					SaveTempData<UIAnimData>(data);
                }
                if (GUILayout.Button("Paste"))
                {
					data.CopyFramesFrom(LoadTempData<UIAnimData>());
                }
            }
            EditorGUILayout.EndHorizontal();
            ListField<UIAnimFrame>("AnimFrame", data, data.m_frames, AnimFrameEditor, ref data.m_extendListView);
        }
        EditorGUILayout.EndVertical();
    }

    void AnimFrameEditor(System.Object animDataObj, UIAnimFrame frame)
    {
        //EditorGUILayout.BeginHorizontal("box");
        {
            EditorGUILayout.BeginVertical("box");
            {
                //EditorGUILayout.BeginHorizontal();
                //{
                //    if (GUILayout.Button("Copy"))
                //    {
                //        SaveProtoBuff<UIAnimFrame>(frame, TEMP_PATH_ROOT + "AnimFrame.bytes");
                //    }
                //    if (GUILayout.Button("Paste"))
                //    {
                //        frame.CopyFrome(LoadProtoBuff<UIAnimFrame>(TEMP_PATH_ROOT + "AnimFrame.bytes"));
                //    }
                //}
                //EditorGUILayout.EndHorizontal();
                frame.m_type = (E_UIAnimType)EditorGUILayout.EnumPopup("Type", frame.m_type);
                switch (frame.m_type)
                {
                case E_UIAnimType.Empty:
                    {
                        Color gc = GUI.color;
                        GUI.color = Color.green;
                        frame.m_duration = EditorGUILayout.FloatField("Duration", frame.m_duration);
                        GUI.color = gc;
                    }
                    break;
                case E_UIAnimType.Set:
                    frame.m_tween = (E_TweenType)EditorGUILayout.EnumMaskField(frame.m_tween.ToString(), frame.m_tween);
                    FrameFieldEditor((UIAnimData)animDataObj, frame);
                    break;
                case E_UIAnimType.PlaySFX:
                    frame.m_audioName = EditorGUILayout.TextField("Audio Name", frame.m_audioName);
                    frame.m_duration = EditorGUILayout.FloatField("Minimum Delay", frame.m_duration);
                    frame.m_alpha = EditorGUILayout.FloatField("Maximum Delay", frame.m_alpha);
                    frame.m_scale.x = EditorGUILayout.FloatField("Minimum Pitch", frame.m_scale.x);
                    frame.m_scale.y = EditorGUILayout.FloatField("Maximum Pitch", frame.m_scale.y);
                    frame.m_particleParent = EditorGUILayout.ObjectField("Parent", frame.m_particleParent, typeof(Transform), true) as Transform;
                    break;
                case E_UIAnimType.PlayBGM:
                case E_UIAnimType.PlayVOX:
                    frame.m_audioName = EditorGUILayout.TextField("Audio Name", frame.m_audioName);
                    break;
                case E_UIAnimType.AddParticle:
                    frame.m_particlePath = EditorGUILayout.TextField("Path", frame.m_particlePath);
                    frame.m_particleParent = EditorGUILayout.ObjectField("Parent", frame.m_particleParent, typeof(Transform), true) as Transform;
                    frame.m_position = EditorGUILayout.Vector3Field("Position", frame.m_position);
                    frame.m_particleDestroyAfterPlay = EditorGUILayout.Toggle("One Shot", frame.m_particleDestroyAfterPlay);
                    break;
                case E_UIAnimType.Tween:
                    {
                        Color gc = GUI.color;
                        GUI.color = Color.green;
                        frame.m_duration = EditorGUILayout.FloatField("Duration", frame.m_duration);
                        GUI.color = gc;
                        frame.m_tween = (E_TweenType)EditorGUILayout.EnumMaskField(frame.m_tween.ToString(), frame.m_tween);
                        frame.m_method = (UITweener.Method)EditorGUILayout.EnumPopup("Method", frame.m_method);

                        FrameFieldEditor((UIAnimData)animDataObj, frame);
                    }
                    break;
                case E_UIAnimType.SubAnim:
                    {
                        frame.m_animPlayer = EditorGUILayout.ObjectField("Anim Player", frame.m_animPlayer, typeof(BaseAnimPlayer), true) as BaseAnimPlayer;
                        frame.m_particleDestroyAfterPlay = EditorGUILayout.Toggle("Block While Playing", frame.m_particleDestroyAfterPlay);
                        if (frame.m_animPlayer != null)
                        {
                            Color gc = GUI.color;
                            GUI.color = Color.green;
                            GUILayout.Label("Anim Player found.");
                            GUI.color = gc;
                        }
                        else
                        {
                            Color gc = GUI.color;
                            GUI.color = Color.red;
                            GUILayout.Label("Anim Player NOT found!");
                            GUI.color = gc;
                        }
                    }
                    break;
                case E_UIAnimType.SubAnimGroup:
                    frame.m_animPlayerGroup = EditorGUILayout.ObjectField(frame.m_animPlayerGroup, typeof(GameObject), true) as GameObject;
                    frame.m_duration = EditorGUILayout.FloatField("Interval", frame.m_duration);
					frame.m_alpha = EditorGUILayout.IntField("Index", Mathf.FloorToInt (frame.m_alpha));
                    frame.m_particleDestroyAfterPlay = EditorGUILayout.Toggle("Block While Playing", frame.m_particleDestroyAfterPlay);
                    break;
                case E_UIAnimType.EnableBehaviour:
                    //frame.m_behaviour = EditorGUILayout.ObjectField(frame.m_behaviour, typeof(Behaviour), true) as Behaviour;
                    frame.m_behaviour = ComponentField<Behaviour>("Behaviour", frame.m_behaviour);
                    frame.m_particleDestroyAfterPlay = EditorGUILayout.Toggle("Enabled", frame.m_particleDestroyAfterPlay);
                    break;
				case E_UIAnimType.PlayAnimation:
					frame.m_audioName = EditorGUILayout.TextField("AnimationClip", frame.m_audioName);
					Color c = GUI.color;
					GUI.color = Color.green;
					frame.m_duration = EditorGUILayout.FloatField("Duration", frame.m_duration);
					GUI.color = c;
					break;
				case E_UIAnimType.SendEvent:
					frame.m_audioName = EditorGUILayout.TextField("EventName", frame.m_audioName);
					break;
                default: break;
                }
                EditorGUILayout.Separator();
            }
            EditorGUILayout.EndVertical();
        }
        //EditorGUILayout.EndHorizontal();
    }

    void FrameFieldEditor(UIAnimData data, UIAnimFrame frame)
    {
        if (frame.HasTween(E_TweenType.Position))
        {
            EditorGUILayout.BeginHorizontal();
            EditorGUILayout.LabelField("Position");
            if (data != null && data.m_target != null && GUILayout.Button("Current"))
            {
                frame.m_position = data.m_target.transform.localPosition;
            }
            EditorGUILayout.EndHorizontal();
            frame.m_position = EditorGUILayout.Vector3Field("", frame.m_position);
        }
        if (frame.HasTween(E_TweenType.Rotation))
        {
            EditorGUILayout.BeginHorizontal();
            EditorGUILayout.LabelField("Rotation");
            if (data != null && data.m_target != null && GUILayout.Button("Current"))
            {
                frame.m_rotation = data.m_target.transform.localRotation.eulerAngles;
            }
            EditorGUILayout.EndHorizontal();
            frame.m_rotation = EditorGUILayout.Vector3Field("", frame.m_rotation);
        }
        if (frame.HasTween(E_TweenType.Scale))
        {
            EditorGUILayout.BeginHorizontal();
            EditorGUILayout.LabelField("Scale");
            if (data != null && data.m_target != null && GUILayout.Button("Current"))
            {
                frame.m_scale = data.m_target.transform.localScale;
            }
            EditorGUILayout.EndHorizontal();
            frame.m_scale = EditorGUILayout.Vector3Field("", frame.m_scale);
        }
        if (frame.HasTween(E_TweenType.Color)) frame.m_color = EditorGUILayout.ColorField("Color", frame.m_color);
        if (frame.HasTween(E_TweenType.Alpha)) frame.m_alpha = EditorGUILayout.FloatField("Alpha", frame.m_alpha);
    }

    static T ComponentField<T>(string label, T curComponent) where T : Component
    {
        EditorGUILayout.BeginVertical("box");
        GameObject curGO = EditorGUILayout.ObjectField(label, (curComponent != null ? curComponent.gameObject : null), typeof(GameObject), true) as GameObject;

        if (curGO == null)
        {
            GUILayout.Label("Please select GameObject first.");
            EditorGUILayout.EndVertical();
            return null;
        }

        int selectedIndex = -1;
        T[] components = curGO.GetComponents<T>();
        if (components.Length == 0) return curComponent;
        string[] componentNames = new string[components.Length];
        for (int i = 0; i < components.Length; i++)
        {
            componentNames[i] = (components[i].GetType().Name + " [" + components[i].GetInstanceID()) + "]";
            if (curComponent != null && curComponent.GetInstanceID() == components[i].GetInstanceID())
            {
                selectedIndex = i;
            }
        }
        if (selectedIndex == -1)
        {
            selectedIndex = 0;
        }
        T retComponent = components[selectedIndex];

        EditorGUI.BeginChangeCheck();
        selectedIndex = EditorGUILayout.Popup(selectedIndex, componentNames);
        if (EditorGUI.EndChangeCheck())
        {
            retComponent = components[selectedIndex];
        }
        EditorGUILayout.EndVertical();
        return retComponent;
    }

    delegate void ListFieldEditor<in T1, T2>(T1 arg1, T2 arg2);

    static void ListField<T>(string listName, System.Object ownerObject, List<T> list, ListFieldEditor<System.Object, T> nodeEditor, ref bool extended) where T : new()
    {
        GUILayout.BeginVertical();
        {
            extended = EditorGUILayout.Foldout(extended, listName);
            if (extended)
            {
                GUILayoutOption uiWidth = GUILayout.Width(24);
                for (int i = 0; i < list.Count; i++)
                {
                    T node = list[i];
                    GUILayout.BeginHorizontal();
                    {
                        nodeEditor(ownerObject, node);
                        GUILayout.BeginVertical("box");
                        {
                            if (GUILayout.Button("+", uiWidth))
                            {
                                list.Insert(i, new T());
                                break;
                            }
                            if (GUILayout.Button("-", uiWidth))
                            {
                                list.RemoveAt(i);
                                break;
                            }
                        }
                        GUILayout.EndVertical();
                        GUILayout.BeginVertical("box");
                        {
                            if (GUILayout.Button("\u2191", uiWidth)) // up arrow
                            {
                                if (i > 0)
                                {
                                    T t = list[i - 1];
                                    list[i - 1] = list[i];
                                    list[i] = t;
                                    break;
                                }
                            }
                            if (GUILayout.Button("\u2193", uiWidth)) // down arrow
                            {
                                if (i < list.Count - 1)
                                {
                                    T t = list[i + 1];
                                    list[i + 1] = list[i];
                                    list[i] = t;
                                    break;
                                }
                            }
                        }
                        GUILayout.EndVertical();
                    }
                    GUILayout.EndHorizontal();
                }
                if (GUILayout.Button("+"))
                {
                    list.Add(new T());
                }
            }
        }
        GUILayout.EndVertical();
    }

	public static T Copy<T>(T RealObject)  
	{  
		using (Stream objectStream = new MemoryStream())  
		{  
			//利用 System.Runtime.Serialization序列化与反序列化完成引用对象的复制     
			IFormatter formatter = new BinaryFormatter();  
			formatter.Serialize(objectStream, RealObject);  
			objectStream.Seek(0, SeekOrigin.Begin);  
			return (T)formatter.Deserialize(objectStream);  
		}  
	}    

	static object mTempData;

    static void SaveTempData<T>(T obj) where T : class
    {
		mTempData = obj;
    }

//    static T LoadTempData<T>() where T : class
//    {
//		return Copy<T>(mTempData as T);
//    }

	static T LoadTempData<T>() where T : class
	{
		return mTempData as T;
	}
}
