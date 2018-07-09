using UnityEngine;
using System.Collections.Generic;

public class NGUIHelper 
{
	public enum LABELCOLOR
	{
		NORMAL,
		TOP,
		BOTTOM
	}
	private static NGUIHelper mInstance;
	public static NGUIHelper Instance {
		get {
			if (mInstance == null) {
				mInstance = new NGUIHelper ();
			}
			return mInstance;
		}
	}


	private UIRoot root;
	private UICamera mainCamera;
	public UIRoot Root
	{
		get
		{
			if(root == null)
			{
				root = GameObject.FindObjectOfType<UIRoot>();
			}
			return root;
		}
	}

	public UICamera MainCamera
	{
		get{
			if(mainCamera==null)
			{

				mainCamera = Root.GetComponentInChildren<UICamera>();
			}
			return mainCamera;
		}
	}
	private  Vector2 mViewSize = Vector2.zero;
	public  Vector2 ViewSize
	{
		get
		{
			if(mViewSize == Vector2.zero)
			{
				if (Root != null) {
					var mWorldToUiOffset= (float)Root.activeHeight / Screen.height;
					mViewSize.y =  Mathf.CeilToInt(Screen.height * mWorldToUiOffset);
					mViewSize.x= Mathf.CeilToInt(Screen.width * mWorldToUiOffset);
				}
			}
			return mViewSize;
		}
	}

	public Vector3 GetScreenRatio ()
	{
		return new Vector3 (Screen.width / Root.manualWidth, Root.manualHeight, 1.0f);
	}

	public Vector3 WordToViewPoint(Vector3 pos,Camera _camera=null)
	{	
		if(_camera == null)
		{
			_camera = MainCamera.cachedCamera;
		}
		float mWorldToUiOffset= (float)Root.activeHeight / Screen.height;
		Vector3 _ui_pos =_camera.WorldToScreenPoint(pos);
		_ui_pos.x -= Screen.width/2;
		_ui_pos.y -= Screen.height/2;
		_ui_pos = _ui_pos * mWorldToUiOffset;
		_ui_pos.z= 0;
		return _ui_pos;
	}
	static public void SetGrey(Transform parent,bool active = false)
	{ 
		if(parent == null)return;
		if (!active) {
			Color c = new Color (0, 1f, 1f);
			UISprite[] sprites = parent.GetComponentsInChildren<UISprite> ();
			foreach (UISprite sprite in sprites) {
				sprite.color = c;
			}
			UITexture[] textures = parent.GetComponentsInChildren<UITexture> ();
			foreach (UITexture texture in textures) {
				texture.color = c;
			}
			UILabel[] labels = parent.GetComponentsInChildren<UILabel> ();
			Debug.Log(labels==null);
			foreach (UILabel label in labels) {
				label.color = Color.grey;
			}
		}
		else 
		{
			SetColor(parent, Color.white);
		}
	}
	static public void SetState(GameObject go,bool active)
	{
		BoxCollider bc =go.GetComponent<BoxCollider>();
		bc.enabled = active;
		SetGrey(go.transform,active);
	}

	static public void SetColor(Transform parent,Color color,bool _apply_button_color=false)
	{
		if(parent == null)return;
		UISprite[] sprites = parent.GetComponentsInChildren<UISprite>();
		foreach(UISprite sprite in sprites)
		{
			sprite.color = color;
		}
		UITexture[] textures = parent.GetComponentsInChildren<UITexture>();
		foreach(UITexture texture in textures)
		{
			texture.color = color;
		}
		UILabel[] labels = parent.GetComponentsInChildren<UILabel>();
		foreach(UILabel label in labels)
		{
			label.color = color;
		}

		if(_apply_button_color)
		{
			UIButton[] buttons = parent.GetComponentsInChildren<UIButton>();
			foreach(UIButton button in buttons)
			{
				button.defaultColor=button.hover=button.pressed=button.disabledColor=color;
			}	
		}
	}

	Color mGrayColor = new Color (0.4784f, 0.4784f, 0.4784f);
	Color mBoaderGrayColor = new Color (0.5647f, 0.5647f, 0.5647f);
	Color mFontGreyColor = new Color (0.66f, 0.66f, 0.66f);

	static public void SetBtnState(UIButton btn,bool active,Color normalLabelColor = default(Color), LABELCOLOR color_type = LABELCOLOR.NORMAL)
	{
		if (normalLabelColor ==  default(Color))
			normalLabelColor = Color.white;
		btn.enabled = active;
		btn.GetComponent<Collider>().enabled = active;
		if (active) 
		{
			UISprite[] sprites =  btn.GetComponentsInChildren<UISprite>();
			foreach(UISprite sprite in sprites)
			{
				sprite.color = Color.white;
			}
			UILabel[] labels = btn.GetComponentsInChildren<UILabel>();
			foreach(UILabel label in labels)
			{
				if(color_type ==LABELCOLOR.NORMAL)
				{
					label.applyGradient = false;
					label.color = normalLabelColor;
				}
				else
				{
					label.applyGradient = true;
					label.color = Color.white;
					if(color_type == LABELCOLOR.TOP)
					{
						label.gradientTop = normalLabelColor;
						label.gradientBottom = Color.white;
					}
					else
					{
						label.gradientTop = Color.white; 
						label.gradientBottom = normalLabelColor;
					}

				}
			}
		}
		else 
		{
			UISprite[] sprites =  btn.GetComponentsInChildren<UISprite>();
			foreach(UISprite sprite in sprites)
			{
				if(sprite== btn.normalSprite2D)sprite.color = Instance.mGrayColor;
				else sprite.color =  Instance.mBoaderGrayColor;
			}

			UILabel[] labels = btn.GetComponentsInChildren<UILabel>();
			foreach(UILabel label in labels)
			{
				label.applyGradient = false;
				label.color =  Instance.mFontGreyColor;
			}
		}
	}
}
