using UnityEngine;
using System.Collections;

public class UILoopDragAnimation : MonoBehaviour
{
	//public
    public bool isVertical = false;
	public bool sorted = false;
	public float momentumAmount = 40f;
	public float radius = 350f;
	public Vector3 rotate = new Vector3 (25f, 0f, 0f);
	public float totalTime = 0.2f;
	public AnimationCurve positionCurve;
	public bool controlScale = false;
	public Vector3 fromScale = new Vector3 (0.8f, 0.8f, 0.8f);
	public Vector3 toScale = new Vector3 (4.8f, 4.8f, 4.8f);
	public AnimationCurve scaleCurve;
	public float ignoreAngle = 0;
	public GameObject target;
	public GameObject clone;

	//private
	private BetterList<Transform> elements = new BetterList<Transform> ();
	private float lastAngle;
	private float curAngle;
	private float tweenOffset;
	private int lastIndex;
	private int curIndex;
	private Vector3 beginMousePos;
	private bool locked;
	private float curTime;

	void Start ()
	{
		target.SendMessage ("SetIndex", curIndex, SendMessageOptions.DontRequireReceiver);
		lastIndex = curIndex;

		Scroll (0);
	}

	void Update ()
	{
		if (Application.isPlaying) {
			if (locked) {
				Debug.Log(">>>>>>>>>>locked");
				curTime += Time.deltaTime;
				if (curTime > totalTime) {
					//Scroll(Mathf.Lerp(0, tweenOffset, 1));
					Scroll (tweenOffset);
					lastAngle = curAngle;
					locked = false;
				} else {
					Scroll (Mathf.Lerp (0, tweenOffset, curTime / totalTime));
				}
			}
		} else {
			Scroll (0);
		}
	}

	void OnPress (bool pressed)
	{
		Debug.Log(">>>>>>>>>>onpress");
		if (enabled && NGUITools.GetActive (gameObject) && !locked) {
			if (pressed) {
				beginMousePos = UICamera.lastHit.point;
			} else {
				lastAngle = curAngle;
				CalculateIndexAndOffset ();
				locked = true;
				Debug.Log(">>>>>>>>>>onpress locked");
				curTime = 0f;
			}
		}
	}

	void OnDrag (Vector2 delta)
	{
		Debug.Log(">>>>>>>>>>OnDrag");
		if (enabled && NGUITools.GetActive (gameObject) && !locked) {
			if (UICamera.lastHit.point == Vector3.zero) 
				return;

            if (!isVertical)
                Scroll ((beginMousePos - UICamera.lastHit.point).x * momentumAmount);
            else
    			Scroll (-(beginMousePos - UICamera.lastHit.point).y * momentumAmount);

			CalculateIndexAndOffset ();
		}
	}

	public void TurnLeft ()
	{
		if (!locked) {
			lastAngle = curAngle;
			curIndex = curIndex >= elements.size - 1 ? 0 : curIndex + 1;
			if (lastIndex != curIndex) {
				target.SendMessage ("SetIndex", curIndex, SendMessageOptions.DontRequireReceiver);
				lastIndex = curIndex;
			}
			tweenOffset = - 360f / elements.size;
			locked = true;
			curTime = 0f;
		}
	}

	public void TurnRight ()
	{
		if (!locked) {
			lastAngle = curAngle;
			curIndex = curIndex <= 0 ? elements.size - 1 : curIndex - 1;
			if (lastIndex != curIndex) {
				target.SendMessage ("SetIndex", curIndex, SendMessageOptions.DontRequireReceiver);
				lastIndex = curIndex;
			}
			tweenOffset = 360f / elements.size;
			locked = true;
			curTime = 0f;
		}
	}

	public void Init (int size, int index)
	{
		if (elements.size == size)
			return;

		foreach(Transform ie in elements){
			GameObject.Destroy(ie.gameObject);
		}
		elements.Clear ();

		for (int i = 0; i < size; ++i) {
			GameObject obj = GameObject.Instantiate(clone) as GameObject;
			obj.SetActive(true);
			Transform t = obj.transform;
			t.parent = transform;
			elements.Add (t);
		}
		if (sorted)
			elements.Sort (SortByName);

		curIndex = index;
		lastAngle = - 360f / (float)elements.size * (float)curIndex;
	}

	public BetterList<Transform> GetElements ()
	{
		return elements;
	}

	public int GetCurrentIndex ()
	{
		return curIndex;
	}

	private int SortByName (Transform a, Transform b)
	{ 
		return string.Compare (a.name, b.name);
	}

	private void Scroll (float offset)
	{
		Debug.Log(">>>>>>>>>Scroll offset:"+offset);
		int c = elements.size;
		if (c == 0)
			return;
		
		float f0 = 360f / (float)c;
		Vector3 v0 = Vector3.forward * radius;
		Quaternion q0 = Quaternion.Euler (rotate);
		
		for (int i =0; i< c; ++i) {
			Transform g = elements [i];
			if (g == null)
				continue;
			//Debug.Log(">>>>>>>>>g");
			curAngle = lastAngle + offset;
			float f1 = (curAngle + f0 * i) % 360f + 180;
			f1 = f1 < 0 ? f1 + 360f : f1;
			f1 = f1 >= 360f ? f1 - 360f : f1;

			if (ignoreAngle > 0 && (f1 < ignoreAngle || 360 - f1 < ignoreAngle)) {
				g.gameObject.SetActive (false);
				//Debug.Log(">>>>>>>>>g1");
			} else {
				g.gameObject.SetActive (true);
				//Debug.Log(">>>>>>>>>g2");
				float f2 = f1 / 360f;
				Quaternion q1 = Quaternion.AngleAxis (Mathf.Lerp (0f, 360f, positionCurve.Evaluate (f2)), Vector3.up);
				Vector3 v1 = q0 * q1 * v0;
				g.localPosition = new Vector3 (v1.x, v1.y, v1.z / radius);
	
				Vector3 v2 = controlScale ? Vector3.Lerp (fromScale, toScale, scaleCurve.Evaluate (f2)) : Vector3.one;
				g.localScale = v2;
			}
		}
	}

	private void CalculateIndexAndOffset ()
	{
		int c = elements.size;
		if (c == 0) {
			tweenOffset = 0;
			curIndex = -1;
		}

		float f0 = 360f / (float)c;
		tweenOffset = float.MaxValue;

		for (int i =0; i< c; ++i) {
			Transform g = elements [i];
			if (g == null)
				continue;

			float f1 = (curAngle + f0 * i) % 360f;
			f1 = f1 < 0 ? f1 + 360f : f1;
			float f2 = f1 - 360;

			if (Mathf.Abs (f1) < Mathf.Abs (tweenOffset)) {
				curIndex = i;
				tweenOffset = -f1;
			}
			if (Mathf.Abs (f2) < Mathf.Abs (tweenOffset)) {
				curIndex = i;
				tweenOffset = -f2;
			}
		}
		if (lastIndex != curIndex) {
			target.SendMessage ("SetIndex", curIndex, SendMessageOptions.DontRequireReceiver);
			lastIndex = curIndex;
		}
	}
}
