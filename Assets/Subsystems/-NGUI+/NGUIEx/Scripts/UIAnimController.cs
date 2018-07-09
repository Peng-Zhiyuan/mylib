using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using GameCore;

public enum E_UIAnimType
{
	Tween = 1,
	Set,
	Empty,
	EnableBehaviour,
	SubAnim,
	SubAnimGroup,
	AddParticle,
	PlaySFX,
	PlayBGM,
	PlayVOX,
	PlayAnimation,
	SendEvent,
}

[System.Flags]
public enum E_TweenType
{
	Position = 1 << 0,
	Rotation = 1 << 1,
	Scale = 1 << 2,
	Color = 1 << 3,
	Alpha = 1 << 4
}

public enum E_AnimTarget
{
	GameObject = 0,
	AllChildren = 1,
	Children = 2,
}

//[ProtoBuf.ProtoContract]
[System.Serializable]
public class UIAnimFrame
{
	// [ProtoBuf.ProtoMember(1)]
	public E_UIAnimType m_type = E_UIAnimType.Empty;
	// [ProtoBuf.ProtoMember(2)]
	public E_TweenType m_tween = (E_TweenType)0;
	// [ProtoBuf.ProtoMember(3)]
	public UITweener.Method m_method = UITweener.Method.Linear;


	//[System.NonSerialized]
	public BaseAnimPlayer m_animPlayer;
	//[System.NonSerialized]
	public GameObject m_animPlayerGroup;
	//[System.NonSerialized]
	public Behaviour m_behaviour;

	//  [ProtoBuf.ProtoMember(4)]
	public float m_duration;
	//[System.NonSerialized]
	public Vector3 m_position;
	//[System.NonSerialized]
	public Vector3 m_rotation;
	//[System.NonSerialized]
	public Vector3 m_scale = Vector3.one;

	//  [ProtoBuf.ProtoMember(5, OverwriteList = true)]
	public float[] m_prsArray {
		get {
			return MonoUtil.Vector3ToArray(new Vector3[] { m_position, m_rotation, m_scale });
		}
		set {
			Vector3[] v = MonoUtil.ArrayToVector3(value);
			m_position = v[0];
			m_rotation = v[1];
			m_scale = v[2];
		}
	}

//	[System.NonSerialized]
	public Color m_color;

	//  [ProtoBuf.ProtoMember(6)]
	public string m_strColor {
		get { return MonoUtil.ColorToString(m_color); }
		set { m_color = MonoUtil.StringToColor(value); }
	}

	//  [ProtoBuf.ProtoMember(7)]
	public float m_alpha;

	//   [ProtoBuf.ProtoMember(8)]
	public string m_audioName;

	//  [ProtoBuf.ProtoMember(9)]
	public string m_particlePath;

	//[System.NonSerialized]
	public Transform m_particleParent;

	//  [ProtoBuf.ProtoMember(10)]
	public bool m_particleDestroyAfterPlay = true;

	public bool HasTween(E_TweenType tweenType)
	{
		return (((int)m_tween) & ((int)tweenType)) != 0;
	}

	public void CopyFrom(UIAnimFrame other)
	{
		if (other == null)
			return;
		m_type = other.m_type;
		m_tween = other.m_tween;
		m_method = other.m_method;
		m_duration = other.m_duration;
		m_position = other.m_position;
		m_rotation = other.m_rotation;
		m_scale = other.m_scale;
		m_color = other.m_color;
		m_alpha = other.m_alpha;
		m_audioName = other.m_audioName;
		m_particlePath = other.m_particlePath;
		//m_particleParent = other.m_particleParent;
		m_particleDestroyAfterPlay = other.m_particleDestroyAfterPlay;
	}

	public static UIAnimFrame CreateFrom(UIAnimFrame other)
	{
		UIAnimFrame frame = new UIAnimFrame();
		frame.CopyFrom(other);
		return frame;
	}
}

//[ProtoBuf.ProtoContract]
[System.Serializable]
public class UIAnimData
{
	public UIAnimData()
	{
	}

	//[System.NonSerialized]
	public E_AnimTarget m_targetType = E_AnimTarget.GameObject;

	//[System.NonSerialized]
	public GameObject m_target;

	public List<UIAnimFrame> m_frames = new List<UIAnimFrame>();

	//[System.NonSerialized]
	public bool m_extendListView = false;

	public GameObject[] GetTargets()
	{
		if (m_target != null) {
			switch (m_targetType) {
				case E_AnimTarget.GameObject:
					return new GameObject[] { m_target };
				case E_AnimTarget.Children:
					return m_target.GetImmediateChildren();
				case E_AnimTarget.AllChildren:
					return m_target.GetChildren();
			}
		}
		return null;
	}

	public float GetDuration()
	{
		float duration = 0f;
		for (int i = 0; i < m_frames.Count; i++) {
			UIAnimFrame f = m_frames[i];
			if (f.m_type == E_UIAnimType.Empty ||
			    (f.m_type == E_UIAnimType.Tween && (int)f.m_tween != 0) ||
			    (f.m_type == E_UIAnimType.PlayAnimation && !string.IsNullOrEmpty(f.m_audioName))) {
				duration += f.m_duration;
			} else if (f.m_type == E_UIAnimType.SubAnim && f.m_animPlayer != null && f.m_particleDestroyAfterPlay) {
				duration += f.m_animPlayer.Length;
			}
		}
		return duration;
	}

	public void CopyFramesFrom(UIAnimData other)
	{
		if (other == null)
			return;
		for (int i = 0; i < other.m_frames.Count; i++) {
			if (i < m_frames.Count)
				m_frames[i].CopyFrom(other.m_frames[i]);
			else
				m_frames.Add(other.m_frames[i]);
		}
	}
}

public abstract class BaseAnimPlayer : MonoBehaviour
{
	public abstract void Play(System.Action onPlayEnd, float delay);

	public abstract float Length { get; }
}

public class UIAnimController : BaseAnimPlayer
{
	public List<UIAnimData> m_animDatas = new List<UIAnimData>();
	public bool m_extendListView = false;

	public void Play()
	{
		Play(null, 0f);
	}

	public void Play(System.Action onPlayEnd)
	{
		Play(onPlayEnd, 0f);
	}

	public override float Length { get { return GetDuration(); } }

	private float m_timeStart;

	public float TimeSinceStart { get { return Mathf.Max(0, Time.realtimeSinceStartup - m_timeStart); } }

	public override void Play(System.Action onPlayEnd, float delay)
	{
		if (!gameObject.activeInHierarchy) {
			if (onPlayEnd != null) {
				onPlayEnd();
			}
			//Debug.Log("[AnimEnd] gameObject inactive");
			return;
		}
		int maxLengthIndex = -1;
		if (onPlayEnd != null) {
			float maxLength = -1f;
			for (int i = 0; i < m_animDatas.Count; i++) {
				// if (m_animDatas[i].m_target != null) continue;
				float curDuration = m_animDatas[i].GetDuration();
				if (curDuration > maxLength) {
					maxLength = curDuration;
					maxLengthIndex = i;
				}
			}
			if (maxLengthIndex == -1) {
				if (onPlayEnd != null) {
					onPlayEnd();
				}
				Debug.Log("[AnimEnd] all targets are inactive");
				return;
			}
		}

		for (int i = 0; i < m_animDatas.Count; i++) {
			UIAnimData animData = m_animDatas[i];
			StartCoroutine(PlayAnim(delay, animData, (i == maxLengthIndex) ? onPlayEnd : null));
		}

		m_timeStart = Time.realtimeSinceStartup + delay;
	}

	public void Stop()
	{
		StopAllCoroutines();
		for (int i = 0; i < m_animDatas.Count; i++) {
			UIAnimData animData = m_animDatas[i];
			GameObject[] targets = animData.GetTargets();
			if (targets != null)
				for (int t = 0; t < targets.Length; t++) {
					UITweener[] tweeners = targets[t].GetComponents<UITweener>();
					foreach (UITweener tweener in tweeners) {
						tweener.enabled = false;
					}
					SpringPosition[] springs = targets[t].GetComponents<SpringPosition>();
					foreach (var spring in springs) {
						spring.enabled = false;
					}
				}

			for (int j = 0; j < animData.m_frames.Count; j++) {
				UIAnimFrame curFrame = animData.m_frames[j];
				if (curFrame.m_type == E_UIAnimType.SubAnimGroup) {
					BaseAnimPlayer[] players = curFrame.m_animPlayerGroup.GetComponentsInImmediateChildren<BaseAnimPlayer>(false, Mathf.FloorToInt(curFrame.m_alpha));
					for (int k = 0; k < players.Length; k++)
						(players[k] as UIAnimController).Stop();
				}
			}
		}
	}

	public float GetDuration()
	{
		float maxLength = -1f;
		for (int i = 0; i < m_animDatas.Count; i++) {
			float curDuration = m_animDatas[i].GetDuration();
			if (curDuration > maxLength) {
				maxLength = curDuration;
			}
		}
		return maxLength;
	}

	IEnumerator PlayAnim(float delay, UIAnimData animData, System.Action onPlayEnd)
	{
		if (delay > 0)
			yield return new WaitForSeconds(delay);

		for (int i = 0; i < animData.m_frames.Count; i++) {
			UIAnimFrame curFrame = animData.m_frames[i];
			switch (curFrame.m_type) {
				case E_UIAnimType.Empty:
					{
						yield return new WaitForSeconds(animData.m_frames[i].m_duration);
					}
					break;
				case E_UIAnimType.Set:
					{
						GameObject[] targets = animData.GetTargets();
						for (int t = 0; t < targets.Length; t++) {
							if (curFrame.HasTween(E_TweenType.Position))
								SetPosition(targets[t], curFrame.m_position);
							if (curFrame.HasTween(E_TweenType.Rotation))
								SetRotation(targets[t], Quaternion.Euler(curFrame.m_rotation));
							if (curFrame.HasTween(E_TweenType.Scale))
								SetScale(targets[t], curFrame.m_scale);
							if (curFrame.HasTween(E_TweenType.Color))
								SetColor(targets[t], curFrame.m_color);
							if (curFrame.HasTween(E_TweenType.Alpha))
								SetAlpha(targets[t], curFrame.m_alpha);
						}
					}
					break;
				case E_UIAnimType.PlaySFX:
					{
						//AudioSource audioSrc = AudioManager.ins.PlaySFX(curFrame.m_audioName, Random.Range(curFrame.m_duration, curFrame.m_alpha), curFrame.m_particleParent);
						//if (audioSrc != null)
						//{
						//    float pitch = Random.Range(curFrame.m_scale.x, curFrame.m_scale.y);
						//    audioSrc.pitch = pitch;
						//}
//						if (curFrame.m_audioName != null)
//							SoundMgr.GetSingle().play_se(curFrame.m_audioName);
					}
					break;
				case E_UIAnimType.PlayBGM:
                //if (string.IsNullOrEmpty(curFrame.m_audioName))
                //{
                //    AudioManager.ins.StopBGM();
                //}
                //else
                //{
                //    AudioManager.ins.PlayBGM(curFrame.m_audioName);
                //}
					break;
				case E_UIAnimType.PlayVOX:
					{
						//AudioManager.ins.StopAllVOX();
						//AudioManager.ins.PlayVOX(curFrame.m_audioName);
					}
					break;
				case E_UIAnimType.AddParticle:
					{
						GameObject prefab = Resources.Load(curFrame.m_particlePath) as GameObject;
						Transform particleTrans = MonoUtil.CreatePrefab(prefab, "particle", curFrame.m_particleParent, curFrame.m_position);
						if (curFrame.m_particleDestroyAfterPlay)
							particleTrans.gameObject.AddComponent<OneShotParticle>();
					}
					break;
				case E_UIAnimType.Tween:
					{
						bool isTweening = true;
						bool assignedOnTweenEnd = false;
						EventDelegate.Callback onTweenEnd = () => {
							isTweening = false;
						};
						UITweener tw = null;
						GameObject[] targets = animData.GetTargets();
						for (int t = 0; t < targets.Length; t++) {
							if (curFrame.HasTween(E_TweenType.Position)) {
								tw = TweenPosition.Begin(targets[t], curFrame.m_duration, curFrame.m_position);
								tw.method = curFrame.m_method;
								if (!assignedOnTweenEnd) {
									assignedOnTweenEnd = true;
									tw.SetOnFinished(onTweenEnd);
								}
							}
							if (curFrame.HasTween(E_TweenType.Rotation)) {
								tw = TweenRotation.Begin(targets[t], curFrame.m_duration, Quaternion.Euler(curFrame.m_rotation));
								tw.method = curFrame.m_method;
								if (!assignedOnTweenEnd) {
									assignedOnTweenEnd = true;
									tw.SetOnFinished(onTweenEnd);
								}
							}
							if (curFrame.HasTween(E_TweenType.Scale)) {
								tw = TweenScale.Begin(targets[t], curFrame.m_duration, curFrame.m_scale);
								tw.method = curFrame.m_method;
								if (!assignedOnTweenEnd) {
									assignedOnTweenEnd = true;
									tw.SetOnFinished(onTweenEnd);
								}
							}
							if (curFrame.HasTween(E_TweenType.Color)) {
								tw = TweenColor.Begin(targets[t], curFrame.m_duration, curFrame.m_color);
								tw.method = curFrame.m_method;
								if (!assignedOnTweenEnd) {
									assignedOnTweenEnd = true;
									tw.SetOnFinished(onTweenEnd);
								}
							}
							if (curFrame.HasTween(E_TweenType.Alpha)) {
								tw = TweenAlpha.Begin(targets[t], curFrame.m_duration, curFrame.m_alpha);
								tw.method = curFrame.m_method;
								if (!assignedOnTweenEnd) {
									assignedOnTweenEnd = true;
									tw.SetOnFinished(onTweenEnd);
								}
							}
						}
						while (assignedOnTweenEnd && isTweening)
							yield return null;
					}
					break;
				case E_UIAnimType.SubAnim:
					if (curFrame.m_animPlayer != null) {
						bool isPlaying = true;
						curFrame.m_animPlayer.Play(() => isPlaying = false, 0f);
						while (curFrame.m_particleDestroyAfterPlay && isPlaying)
							yield return null;
					}
					break;
				case E_UIAnimType.SubAnimGroup:
					{
						if (curFrame.m_animPlayerGroup != null) {
							BaseAnimPlayer[] players = curFrame.m_animPlayerGroup.GetComponentsInImmediateChildren<BaseAnimPlayer>(false, Mathf.FloorToInt(curFrame.m_alpha));
							if (players != null && players.Length > 0) {
								if (curFrame.m_duration >= 0f) {
									float duration = curFrame.m_duration;
									bool isPlaying = true;
									float maxLength = 0f;
									int maxLengthIdx = -1;
									for (int j = 0; j < players.Length; j++) {
										if (!players[j].gameObject.activeInHierarchy)
											continue;
										float curLength = players[j].Length + duration * j;
										if (curLength > maxLength) {
											maxLength = curLength;
											maxLengthIdx = j;
										}
									}
									if (maxLengthIdx == -1)
										isPlaying = false;
									for (int j = 0; j < players.Length; j++) {
										if (j == maxLengthIdx)
											players[j].Play(() => isPlaying = false, duration * j);
										else
											players[j].Play(null, duration * j);
									}
									while (curFrame.m_particleDestroyAfterPlay && isPlaying)
										yield return null;
								} else {
									for (int j = 0; j < players.Length; j++) {
										bool isPlaying = true;
										players[j].Play(() => isPlaying = false, 0f);
										while (isPlaying)
											yield return null;
									}
								}
							}
						}
					}
					break;
				case E_UIAnimType.EnableBehaviour:
					if (curFrame.m_behaviour != null) {
						curFrame.m_behaviour.enabled = curFrame.m_particleDestroyAfterPlay;
					} else {
						GameObject[] targets = animData.GetTargets();
						for (int t = 0; t < targets.Length; t++) {
							targets[t].SetActive(curFrame.m_particleDestroyAfterPlay);
						}
					}
					break;
				case E_UIAnimType.PlayAnimation:
					if (!string.IsNullOrEmpty(curFrame.m_audioName)) {
						var animation = animData.m_target.GetComponent<Animation>();
						var animator = animData.m_target.GetComponent<Animator>();
						if (animation != null) {
							var clip = animation[curFrame.m_audioName];
							clip.speed = 1;
							if (clip != null && curFrame.m_duration > 0)
								clip.speed = clip.length / curFrame.m_duration;
							animation.Stop();
							animation.Play(curFrame.m_audioName);
							yield return new WaitForSeconds(curFrame.m_duration);
						}
						if (animator != null)
							animator.Play(curFrame.m_audioName);
					}
					break;
				case E_UIAnimType.SendEvent:
					if (!string.IsNullOrEmpty(curFrame.m_audioName)) {
						EventManager.Instance.SendEvent(curFrame.m_audioName);
					}
					break;
				default:
					break;
			}
		}
		if (onPlayEnd != null)
			onPlayEnd();
	}

	static void SetPosition(GameObject go, Vector3 pos)
	{
		if (go != null)
			go.transform.localPosition = pos;
	}

	static void SetActive(GameObject go, Vector3 pos)
	{
		if (go != null)
			go.transform.localPosition = pos;
	}

	static void SetRotation(GameObject go, Quaternion rot)
	{
		if (go != null)
			go.transform.localRotation = rot;
	}

	static void SetScale(GameObject go, Vector3 scl)
	{
		if (go != null)
			go.transform.localScale = scl;
	}

	static void SetColor(GameObject go, Color c)
	{
		if (go != null) {
			UIWidget widget = go.GetComponent<UIWidget>();
			if (widget != null)
				widget.color = c;
			Renderer ren = go.GetComponent<Renderer>();
			if (ren != null) {
				Material mat = ren.material;
				if (mat != null)
					mat.color = c;
			}
		}
	}

	static void SetAlpha(GameObject go, float a)
	{
		UIWidget widget = go.GetComponent<UIWidget>();
		if (widget != null) {
			widget.alpha = a;
		} else {
			UIPanel panel = go.GetComponent<UIPanel>();
			if (panel != null)
				panel.alpha = a;
		}
	}
}
