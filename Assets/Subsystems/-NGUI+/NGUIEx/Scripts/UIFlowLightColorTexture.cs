using UnityEngine;
using System.Collections;

[RequireComponent(typeof(UITexture))]
public class UIFlowLightColorTexture : MonoBehaviour
{
    public Texture lightTexture;
    public float speed = 0.5f;
    public float duration = 4f;
    public float delay = 0f;
	public Color c;
    private UITexture m_cachedUITexture;
    private UITexture CachedUITexture { get { return m_cachedUITexture ?? (m_cachedUITexture = GetComponent<UITexture>()); } }

    private Material m_cachedMat;
    private Material CachedMat { get { return m_cachedMat ?? (m_cachedMat = new Material(Shader.Find("Custom/FlowLightColor"))); } }

    void Start()
    {
        UpdateTextureMaterial();
    }

    void UpdateTextureMaterial()
    {
        Material mat = CachedMat;
        if (lightTexture != null)
            mat.SetTexture("_LightTex", lightTexture);
        speed = Mathf.Clamp(speed, 0.1f, 4f);
        duration = Mathf.Clamp(duration, 2f / speed, 100f);
        delay = Mathf.Clamp(delay, 0f, duration);
        mat.SetFloat("_Speed", speed);
        mat.SetFloat("_Duration", duration);
        mat.SetFloat("_Delay", delay);
		mat.SetColor("_Color", c);
        CachedUITexture.material = mat;
    }

	public static UIFlowLightColorTexture AttachTo(UITexture _uiTexture, Texture _lightTexture, float _speed, float _duration, float _delay,Color c)
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
		UIFlowLightColorTexture flowLightTex = _uiTexture.gameObject.GetComponent<UIFlowLightColorTexture>();
        if (flowLightTex == null)
        {
            flowLightTex = _uiTexture.gameObject.AddComponent<UIFlowLightColorTexture>();
            flowLightTex.m_cachedUITexture = _uiTexture;
            flowLightTex.lightTexture = _lightTexture;
            flowLightTex.speed = _speed;
            flowLightTex.duration = _duration;
            flowLightTex.delay = _delay;
			flowLightTex.c = c;
        }
        else
        {
            flowLightTex.lightTexture = _lightTexture;
            flowLightTex.speed = _speed;
            flowLightTex.duration = _duration;
            flowLightTex.delay = _delay;
			flowLightTex.c = c;
            flowLightTex.UpdateTextureMaterial();
        }
        return flowLightTex;
    }
}
