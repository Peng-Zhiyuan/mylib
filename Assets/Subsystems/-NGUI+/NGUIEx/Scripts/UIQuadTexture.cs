using UnityEngine;
using System.Collections;

[ExecuteInEditMode]
public class UIQuadTexture : UIBasicSprite
{
    [HideInInspector][SerializeField] Rect mRect = new Rect(0f, 0f, 1f, 1f);
    [HideInInspector][SerializeField] Texture mTexture;
    [HideInInspector][SerializeField] Material mMat;
    [HideInInspector][SerializeField] Shader mShader;
    [HideInInspector][SerializeField] Vector4 mBorder = Vector4.zero;
    [HideInInspector][SerializeField] bool mFixedAspect = false;
    [SerializeField] protected Vector3[] mVertexOffsets = new Vector3[0];

    [System.NonSerialized]int mPMA = -1;

    public override Texture mainTexture
    {
        get
        {
            if (mTexture != null) return mTexture;
            if (mMat != null) return mMat.mainTexture;
            return null;
        }
        set
        {
            if (mTexture != value)
            {
                if (drawCall != null && drawCall.widgetCount == 1 && mMat == null)
                {
                    mTexture = value;
                    drawCall.mainTexture = value;
                }
                else
                {
                    RemoveFromPanel();
                    mTexture = value;
                    mPMA = -1;
                    MarkAsChanged();
                }
            }
        }
    }

    public override Material material
    {
        get
        {
            return mMat;
        }
        set
        {
            if (mMat != value)
            {
                RemoveFromPanel();
                mShader = null;
                mMat = value;
                mPMA = -1;
                MarkAsChanged();
            }
        }
    }

    public override Shader shader
    {
        get
        {
            if (mMat != null) return mMat.shader;
            if (mShader == null) mShader = Shader.Find("Custom/UIQuadTexture");
            return mShader;
        }
        set
        {
            if (mShader != value)
            {
                if (drawCall != null && drawCall.widgetCount == 1 && mMat == null)
                {
                    mShader = value;
                    drawCall.shader = value;
                }
                else
                {
                    RemoveFromPanel();
                    mShader = value;
                    mPMA = -1;
                    mMat = null;
                    MarkAsChanged();
                }
            }
        }
    }

    public override bool premultipliedAlpha
    {
        get
        {
            if (mPMA == -1)
            {
                Material mat = material;
                mPMA = (mat != null && mat.shader != null && mat.shader.name.Contains("Premultiplied")) ? 1 : 0;
            }
            return (mPMA == 1);
        }
    }

    public override Vector4 border
    {
        get
        {
            return mBorder;
        }
        set
        {
            if (mBorder != value)
            {
                mBorder = value;
                MarkAsChanged();
            }
        }
    }

    public Rect uvRect
    {
        get
        {
            return mRect;
        }
        set
        {
            if (mRect != value)
            {
                mRect = value;
                MarkAsChanged();
            }
        }
    }

    public override Vector4 drawingDimensions
    {
        get
        {
            Vector2 offset = pivotOffset;

            float x0 = -offset.x * mWidth;
            float y0 = -offset.y * mHeight;
            float x1 = x0 + mWidth;
            float y1 = y0 + mHeight;

            if (mTexture != null && mType != UISprite.Type.Tiled)
            {
                int w = mTexture.width;
                int h = mTexture.height;
                int padRight = 0;
                int padTop = 0;

                float px = 1f;
                float py = 1f;

                if (w > 0 && h > 0 && (mType == UISprite.Type.Simple || mType == UISprite.Type.Filled))
                {
                    if ((w & 1) != 0) ++padRight;
                    if ((h & 1) != 0) ++padTop;

                    px = (1f / w) * mWidth;
                    py = (1f / h) * mHeight;
                }

                if (mFlip == UISprite.Flip.Horizontally || mFlip == UISprite.Flip.Both)
                {
                    x0 += padRight * px;
                }
                else x1 -= padRight * px;

                if (mFlip == UISprite.Flip.Vertically || mFlip == UISprite.Flip.Both)
                {
                    y0 += padTop * py;
                }
                else y1 -= padTop * py;
            }

            float fw, fh;

            if (mFixedAspect)
            {
                fw = 0f;
                fh = 0f;
            }
            else
            {
                Vector4 br = border;
                fw = br.x + br.z;
                fh = br.y + br.w;
            }

            float vx = Mathf.Lerp(x0, x1 - fw, mDrawRegion.x);
            float vy = Mathf.Lerp(y0, y1 - fh, mDrawRegion.y);
            float vz = Mathf.Lerp(x0 + fw, x1, mDrawRegion.z);
            float vw = Mathf.Lerp(y0 + fh, y1, mDrawRegion.w);

            return new Vector4(vx, vy, vz, vw);
        }
    }

    public bool fixedAspect
    {
        get
        {
            return mFixedAspect;
        }
        set
        {
            if (mFixedAspect != value)
            {
                mFixedAspect = value;
                mDrawRegion = new Vector4(0f, 0f, 1f, 1f);
                MarkAsChanged();
            }
        }
    }

    public override void MakePixelPerfect()
    {
        base.MakePixelPerfect();
        if (mType == Type.Tiled) return;

        Texture tex = mainTexture;
        if (tex == null) return;

        if (mType == Type.Simple || mType == Type.Filled || !hasBorder)
        {
            if (tex != null)
            {
                int w = tex.width;
                int h = tex.height;

                if ((w & 1) == 1) ++w;
                if ((h & 1) == 1) ++h;

                width = w;
                height = h;
            }
        }
    }

    protected override void OnUpdate()
    {
        base.OnUpdate();

        if (mFixedAspect)
        {
            Texture tex = mainTexture;

            if (tex != null)
            {
                int w = tex.width;
                int h = tex.height;
                if ((w & 1) == 1) ++w;
                if ((h & 1) == 1) ++h;
                float widgetWidth = mWidth;
                float widgetHeight = mHeight;
                float widgetAspect = widgetWidth / widgetHeight;
                float textureAspect = (float)w / h;

                if (textureAspect < widgetAspect)
                {
                    float x = (widgetWidth - widgetHeight * textureAspect) / widgetWidth * 0.5f;
                    drawRegion = new Vector4(x, 0f, 1f - x, 1f);
                }
                else
                {
                    float y = (widgetHeight - widgetWidth / textureAspect) / widgetHeight * 0.5f;
                    drawRegion = new Vector4(0f, y, 1f, 1f - y);
                }
            }
        }
    }

    public override void OnFill(BetterList<Vector3> verts, BetterList<Vector2> uvs, BetterList<Color32> cols)
    {
        Texture tex = mainTexture;
        if (tex == null) return;

        Rect outer = new Rect(mRect.x * tex.width, mRect.y * tex.height, tex.width * mRect.width, tex.height * mRect.height);
        Rect inner = outer;
        Vector4 br = border;
        inner.xMin += br.x;
        inner.yMin += br.y;
        inner.xMax -= br.z;
        inner.yMax -= br.w;

        float w = 1f / tex.width;
        float h = 1f / tex.height;

        outer.xMin *= w;
        outer.xMax *= w;
        outer.yMin *= h;
        outer.yMax *= h;

        inner.xMin *= w;
        inner.xMax *= w;
        inner.yMin *= h;
        inner.yMax *= h;

        int offset = verts.size;
        UpdateUV(outer, inner);
        QuadrilateralFill(verts, uvs, cols, mVertexOffsets);

        if (onPostFill != null)
            onPostFill(this, offset, verts, uvs, cols);
    }
}
