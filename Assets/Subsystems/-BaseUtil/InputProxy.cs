using UnityEngine;
using System.Collections;
namespace GameCore
{
	public class InputProxy
	{

	    public static bool BlockInput = false;
	    public static bool TouchDown(int index = 0)
		{ 
			if (BlockInput) return false;
	#if UNITY_EDITOR || UNITY_STANDALONE
	        return Input.GetMouseButtonDown(index);
	#else 
			return InputWrapper.touchCount >index && InputWrapper.GetTouch (index).phase == TouchPhase.Began;
	#endif

	    }

		public static int TouchIndex
		{
		
			get
			{
				#if UNITY_EDITOR || UNITY_STANDALONE
				return 0;
				#else 
				if(Input.touchCount>1)
				{
					if(InputWrapper.GetTouch(0).position.x>InputWrapper.GetTouch(1).position.x)
					{
						return 1;
					}
				}
				return 0;
				#endif

//				if(InputWrapper.touchCount==1)return 0;
//				int index = 0;
//				float x = InputWrapper.GetTouch(0).position.x;
//				for(int i = 1; i< InputWrapper.touchCount ;i++)
//				{
//					if(InputWrapper.GetTouch(i).position.x < x)
//					{
//						x = InputWrapper.GetTouch(i).position.x;
//						index = i;
//					}
//				}
//				return index;
			}
		}

	    public static bool TouchUp(int index = 0)
	    {
	        if (BlockInput) return false;
	#if UNITY_EDITOR || UNITY_STANDALONE
	        return Input.GetMouseButtonUp(index);
	#else 
			return (InputWrapper.touchCount >index && InputWrapper.GetTouch (index).phase == TouchPhase.Ended) || InputWrapper.touchCount == 0;
	#endif

	    }

	    public static bool TouchMove(int index = 0)
	    {
	        if (BlockInput) return false;
	#if UNITY_EDITOR || UNITY_STANDALONE
			return Input.GetMouseButton(0);
	#else 
			return InputWrapper.touchCount >index && InputWrapper.GetTouch (index).phase == TouchPhase.Moved;
	#endif
	    }

		public static bool Touch(int index = 0)
		{
			if (BlockInput) return false;
			#if UNITY_EDITOR || UNITY_STANDALONE
			return Input.GetMouseButton(0);
			#else 
			return InputWrapper.touchCount >index && (InputWrapper.GetTouch (index).phase == TouchPhase.Stationary || InputWrapper.GetTouch (index).phase == TouchPhase.Moved);
			#endif
		}

	    public static Vector3 TouchPosition(int index = 0)
	    {
	#if UNITY_EDITOR || UNITY_STANDALONE
	        return Input.mousePosition;

	#else 
			if(InputWrapper.touchCount==0)return Vector3.zero;
			return InputWrapper.GetTouch (index).position;
	#endif
	    }

		public static bool IsUIRaycast(int _index=0)
		{
			return UICamera.Raycast(TouchPosition(_index));
		}

		public static bool Raycast(Ray ray, out RaycastHit hit,int _index=0)
		{
			return Physics.Raycast(ray, out hit);
		}
			
	}
	public class InputWrapper
	{
		public static int touchCount
		{
			get
			{
				#if UNITY_WP8
				return UIManager.UIHandler.Instance.MainCamera.GetComponent<UICamera>().TouchCount;
				#else
				return Input.touchCount;
				#endif
			}
		}
		
		public static Touch GetTouch(int i)
		{
			#if UNITY_WP8
			return UIManager.UIHandler.Instance.MainCamera.GetComponent<UICamera>().GetInputTouch(i);
			#else
			return Input.GetTouch(i);
			#endif
		}
		
		public static bool GetMouseButtonDown(int i)
		{
			#if UNITY_WP8
			TouchPhase touchPhase = UIManager.UIHandler.Instance.MainCamera.GetComponent<UICamera>().GetInputTouch(i).phase;
			return touchPhase == TouchPhase.Stationary || touchPhase == TouchPhase.Began || touchPhase == TouchPhase.Moved;
			#else
			return Input.GetMouseButtonDown(i);
			#endif
		}
	}
}