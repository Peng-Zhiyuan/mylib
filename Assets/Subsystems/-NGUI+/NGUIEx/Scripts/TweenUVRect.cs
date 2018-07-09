using UnityEngine;

public class TweenUVRect : UITweener
{
    static Rect IdentityRect = new Rect(0, 0, 1, 1);

    public Rect from = IdentityRect;
    public Rect to = IdentityRect;

    UITexture mTexture;

    void Awake()
    {
        mTexture = GetComponentInChildren<UITexture>();
    }

    public Rect value
    {
        get
        {
            if (mTexture != null) return mTexture.uvRect;
            return IdentityRect;
        }
        set
        {
            if (mTexture != null) mTexture.uvRect = value;
        }
    }

    protected override void OnUpdate(float factor, bool isFinished)
    {
        value = new Rect(
            Mathf.Lerp(from.xMin, to.xMin, factor),
            Mathf.Lerp(from.yMin, to.yMin, factor),
            Mathf.Lerp(from.width, to.width, factor),
            Mathf.Lerp(from.height, to.height, factor));
    }

    static public TweenUVRect Begin(GameObject go, float duration, Rect uvRect)
    {
#if UNITY_EDITOR
        if (!Application.isPlaying) return null;
#endif
        TweenUVRect comp = UITweener.Begin<TweenUVRect>(go, duration);
        comp.from = comp.value;
        comp.to = uvRect;

        if (duration <= 0f)
        {
            comp.Sample(1f, true);
            comp.enabled = false;
        }
        return comp;
    }
}
