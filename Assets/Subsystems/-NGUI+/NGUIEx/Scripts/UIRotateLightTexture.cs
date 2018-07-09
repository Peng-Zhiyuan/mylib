using UnityEngine;
using System.Collections;

[RequireComponent(typeof(UITexture))]
public class UIRotateLightTexture : MonoBehaviour
{
    public Texture lightTexture;
    public float speed = 0.5f;
    //public float duration = 4f;
    public float lightScale = 1f;

    private UITexture m_cachedUITexture;
    public UITexture CachedUITexture { get { return m_cachedUITexture ?? (m_cachedUITexture = GetComponent<UITexture>()); } }

    private Material m_cachedMat;
    private Material CachedMat { get { return m_cachedMat ?? (m_cachedMat = new Material(Shader.Find("Custom/TextureRotateLight"))); } }

    void Start()
    {
        UpdateTextureMaterial();
    }

    void UpdateTextureMaterial()
    {
        Material mat = CachedMat;
        if (lightTexture != null)
            mat.SetTexture("_LightTex", lightTexture);
        speed = Mathf.Clamp(speed, 0.1f, 10f);
       // duration = Mathf.Clamp(duration, 2f / speed, 100f);
      //  delay = Mathf.Clamp(delay, 0f, duration);
        mat.SetFloat("_Speed", speed);
		mat.SetFloat("_LightScale", lightScale);
       // mat.SetFloat("_Delay", delay);
        CachedUITexture.material = mat;
    }

	public static UIRotateLightTexture AttachTo(UITexture _uiTexture, Texture _lightTexture, float _speed, float _duration, float _delay)
    {
        if (_uiTexture == null)
        {
            Debug.LogError("ArgumentNullException: _uiTexture");
            return null;
        }
        if (_lightTexture == null)
        {
            Debug.LogError("ArgumentNullException: _lightTexture");
            return null;
        }
		UIRotateLightTexture rotateLightTex = _uiTexture.gameObject.GetComponent<UIRotateLightTexture>();
		if (rotateLightTex == null)
        {
			rotateLightTex = _uiTexture.gameObject.AddComponent<UIRotateLightTexture>();
			rotateLightTex.m_cachedUITexture = _uiTexture;
			rotateLightTex.lightTexture = _lightTexture;
			rotateLightTex.speed = _speed;
			//rotateLightTex.duration = _duration;
			//rotateLightTex.delay = _delay;
        }
        else
        {
			rotateLightTex.lightTexture = _lightTexture;
			rotateLightTex.speed = _speed;
			//rotateLightTex.duration = _duration;
			//rotateLightTex.delay = _delay;
			rotateLightTex.UpdateTextureMaterial();
        }
		return rotateLightTex;
    }
}
