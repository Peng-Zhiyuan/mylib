using UnityEngine;
using System.Collections;

public abstract partial class UIBasicSprite : UIWidget
{
    public enum Type
    {
        Simple,
        Sliced,
        Tiled,
        Filled,
        SlicedFilled,
        Advanced,
    }

    [HideInInspector][SerializeField]protected float mVertexOffset = 0.0f;

    /// <summary>
    /// Minimum allowed width for this widget.
    /// </summary>

    override public int minWidth
    {
        get
        {
            if (type == Type.Sliced || type == Type.Advanced || type == Type.SlicedFilled)
            {
                Vector4 b = border * pixelSize;
                int min = Mathf.RoundToInt(b.x + b.z);
                return Mathf.Max(base.minWidth, ((min & 1) == 1) ? min + 1 : min);
            }
            return base.minWidth;
        }
    }

    /// <summary>
    /// Minimum allowed height for this widget.
    /// </summary>

    override public int minHeight
    {
        get
        {
            if (type == Type.Sliced || type == Type.Advanced || type == Type.SlicedFilled)
            {
                Vector4 b = border * pixelSize;
                int min = Mathf.RoundToInt(b.y + b.w);
                return Mathf.Max(base.minHeight, ((min & 1) == 1) ? min + 1 : min);
            }
            return base.minHeight;
        }
    }

    protected void UpdateUV(Rect outer, Rect inner)
    {
        mOuterUV = outer;
        mInnerUV = inner;
    }

    /// <summary>
    /// Fill the draw buffers.
    /// </summary>

    protected void Fill(BetterList<Vector3> verts, BetterList<Vector2> uvs, BetterList<Color32> cols, Rect outer, Rect inner)
    {
        mOuterUV = outer;
        mInnerUV = inner;

        switch (type)
        {
        case Type.Simple:
            SimpleFill(verts, uvs, cols);
            break;

        case Type.Sliced:
            SlicedFill(verts, uvs, cols);
            break;

        case Type.Filled:
            FilledFill(verts, uvs, cols);
            break;

        case Type.Tiled:
            TiledFill(verts, uvs, cols);
            break;

        case Type.SlicedFilled:
            SlicedFilledFill(verts, uvs, cols);
            break;

        case Type.Advanced:
            AdvancedFill(verts, uvs, cols);
            break;
        }
    }

    void SlicedFilledFill(BetterList<Vector3> verts, BetterList<Vector2> uvs, BetterList<Color32> cols)
    {
        Vector4 br = border * pixelSize;

        //if (br.x == 0f && br.y == 0f && br.z == 0f && br.w == 0f)
        //{
        //    SimpleFill(verts, uvs, cols);
        //    return;
        //}

        Color32 c = drawingColor;
        Vector4 v = drawingDimensions;

        mTempPos[0].x = v.x;
        mTempPos[0].y = v.y;
        mTempPos[3].x = v.z;
        mTempPos[3].y = v.w;

        if (mFlip == Flip.Horizontally || mFlip == Flip.Both)
        {
            mTempPos[1].x = mTempPos[0].x + br.z;
            mTempPos[2].x = mTempPos[3].x - br.x;

            mTempUVs[3].x = mOuterUV.xMin;
            mTempUVs[2].x = mInnerUV.xMin;
            mTempUVs[1].x = mInnerUV.xMax;
            mTempUVs[0].x = mOuterUV.xMax;
        }
        else
        {
            mTempPos[1].x = mTempPos[0].x + br.x;
            mTempPos[2].x = mTempPos[3].x - br.z;

            mTempUVs[0].x = mOuterUV.xMin;
            mTempUVs[1].x = mInnerUV.xMin;
            mTempUVs[2].x = mInnerUV.xMax;
            mTempUVs[3].x = mOuterUV.xMax;
        }

        if (mFlip == Flip.Vertically || mFlip == Flip.Both)
        {
            mTempPos[1].y = mTempPos[0].y + br.w;
            mTempPos[2].y = mTempPos[3].y - br.y;

            mTempUVs[3].y = mOuterUV.yMin;
            mTempUVs[2].y = mInnerUV.yMin;
            mTempUVs[1].y = mInnerUV.yMax;
            mTempUVs[0].y = mOuterUV.yMax;
        }
        else
        {
            mTempPos[1].y = mTempPos[0].y + br.y;
            mTempPos[2].y = mTempPos[3].y - br.w;

            mTempUVs[0].y = mOuterUV.yMin;
            mTempUVs[1].y = mInnerUV.yMin;
            mTempUVs[2].y = mInnerUV.yMax;
            mTempUVs[3].y = mOuterUV.yMax;
        }

        bool[,] skip = new bool[3, 3]
        {
            {false, false, false},
            {false, false, false},
            {false, false, false}
        };
        if (fillDirection == FillDirection.Horizontal)
        {
            if (invert)
            {
                float dv = (mTempPos[3].x - mTempPos[0].x) * (1 - fillAmount) + mTempPos[0].x;
                if (dv < mTempPos[1].x)
                {
                    float fill = (dv - mTempPos[0].x) / (mTempPos[1].x - mTempPos[0].x);
                    mTempPos[0].x = dv;
                    mTempUVs[0].x = (mTempUVs[1].x - mTempUVs[0].x) * fill + mTempUVs[0].x;
                }
                else if (dv < mTempPos[2].x)
                {
                    float fill = (dv - mTempPos[1].x) / (mTempPos[2].x - mTempPos[1].x);
                    mTempPos[1].x = dv;
                    mTempUVs[1].x = (mTempUVs[2].x - mTempUVs[1].x) * fill + mTempUVs[1].x;
                    skip[0, 0] = skip[0, 1] = skip[0, 2] = true;
                }
                else
                {
                    float fill = (dv - mTempPos[2].x) / (mTempPos[3].x - mTempPos[2].x);
                    mTempPos[2].x = dv;
                    mTempUVs[2].x = (mTempUVs[3].x - mTempUVs[2].x) * fill + mTempUVs[2].x;
                    skip[0, 0] = skip[0, 1] = skip[0, 2] = skip[1, 0] = skip[1, 1] = skip[1, 2] = true;
                }
            }
            else
            {
                float dv = (mTempPos[3].x - mTempPos[0].x) * fillAmount + mTempPos[0].x;
                if (dv > mTempPos[2].x)
                {
                    float fill = (dv - mTempPos[2].x) / (mTempPos[3].x - mTempPos[2].x);
                    mTempPos[3].x = dv;
                    mTempUVs[3].x = (mTempUVs[3].x - mTempUVs[2].x) * fill + mTempUVs[2].x;
                }
                else if (dv > mTempPos[1].x)
                {
                    float fill = (dv - mTempPos[1].x) / (mTempPos[2].x - mTempPos[1].x);
                    mTempPos[2].x = dv;
                    mTempUVs[2].x = (mTempUVs[2].x - mTempUVs[1].x) * fill + mTempUVs[1].x;
                    skip[2, 0] = skip[2, 1] = skip[2, 2] = true;
                }
                else
                {
                    float fill = (dv - mTempPos[0].x) / (mTempPos[1].x - mTempPos[0].x);
                    mTempPos[1].x = dv;
                    mTempUVs[1].x = (mTempUVs[1].x - mTempUVs[0].x) * fill + mTempUVs[0].x;
                    skip[1, 0] = skip[1, 1] = skip[1, 2] = skip[2, 0] = skip[2, 1] = skip[2, 2] = true;
                }
            }
        }
        else if (fillDirection == FillDirection.Vertical)
        {
            if (invert)
            {
                float dv = (mTempPos[3].y - mTempPos[0].y) * (1 - fillAmount) + mTempPos[0].y;
                if (dv < mTempPos[1].y)
                {
                    float fill = (dv - mTempPos[0].y) / (mTempPos[1].y - mTempPos[0].y);
                    mTempPos[0].y = dv;
                    mTempUVs[0].y = (mTempUVs[1].y - mTempUVs[0].y) * fill + mTempUVs[0].y;
                }
                else if (dv < mTempPos[2].y)
                {
                    float fill = (dv - mTempPos[1].y) / (mTempPos[2].y - mTempPos[1].y);
                    mTempPos[1].y = dv;
                    mTempUVs[1].y = (mTempUVs[2].y - mTempUVs[1].y) * fill + mTempUVs[1].y;
                    skip[0, 0] = skip[1, 0] = skip[2, 0] = true;
                }
                else
                {
                    float fill = (dv - mTempPos[2].y) / (mTempPos[3].y - mTempPos[2].y);
                    mTempPos[2].y = dv;
                    mTempUVs[2].y = (mTempUVs[3].y - mTempUVs[2].y) * fill + mTempUVs[2].y;
                    skip[0, 0] = skip[1, 0] = skip[2, 0] = skip[0, 1] = skip[1, 1] = skip[2, 1] = true;
                }
            }
            else
            {
                float dv = (mTempPos[3].y - mTempPos[0].y) * fillAmount + mTempPos[0].y;
                if (dv > mTempPos[2].y)
                {
                    float fill = (dv - mTempPos[2].y) / (mTempPos[3].y - mTempPos[2].y);
                    mTempPos[3].y = dv;
                    mTempUVs[3].y = (mTempUVs[3].y - mTempUVs[2].y) * fill + mTempUVs[2].y;
                }
                else if (dv > mTempPos[1].y)
                {
                    float fill = (dv - mTempPos[1].y) / (mTempPos[2].y - mTempPos[1].y);
                    mTempPos[2].y = dv;
                    mTempUVs[2].y = (mTempUVs[2].y - mTempUVs[1].y) * fill + mTempUVs[1].y;
                    skip[0, 2] = skip[1, 2] = skip[2, 2] = true;
                }
                else
                {
                    float fill = (dv - mTempPos[0].y) / (mTempPos[1].y - mTempPos[0].y);
                    mTempPos[1].y = dv;
                    mTempUVs[1].y = (mTempUVs[1].y - mTempUVs[0].y) * fill + mTempUVs[0].y;
                    skip[0, 1] = skip[1, 1] = skip[2, 1] = skip[0, 2] = skip[1, 2] = skip[2, 2] = true;
                }
            }
        }

        float diffY = mTempPos[3].y - mTempPos[0].y;
        float baseY = mTempPos[0].y;
        float[] offsetXs = new float[] { 0f, 0f, 0f, 0f };
        if (diffY > 0)
        {
            for (int i = 0; i < 3; i++)
            {
                offsetXs[i] = mVertexOffset * (1f - (mTempPos[i].y - baseY) / diffY);
            }
        }

        for (int x = 0; x < 3; ++x)
        {
            int x2 = x + 1;

            for (int y = 0; y < 3; ++y)
            {
                int y2 = y + 1;

                if (skip[x, y]) continue;

                verts.Add(new Vector3(mTempPos[x].x + offsetXs[y], mTempPos[y].y));
                verts.Add(new Vector3(mTempPos[x].x + offsetXs[y2], mTempPos[y2].y));
                verts.Add(new Vector3(mTempPos[x2].x + offsetXs[y2], mTempPos[y2].y));
                verts.Add(new Vector3(mTempPos[x2].x + offsetXs[y], mTempPos[y].y));

                uvs.Add(new Vector2(mTempUVs[x].x, mTempUVs[y].y));
                uvs.Add(new Vector2(mTempUVs[x].x, mTempUVs[y2].y));
                uvs.Add(new Vector2(mTempUVs[x2].x, mTempUVs[y2].y));
                uvs.Add(new Vector2(mTempUVs[x2].x, mTempUVs[y].y));

                cols.Add(c);
                cols.Add(c);
                cols.Add(c);
                cols.Add(c);
            }
        }
    }

    protected void QuadrilateralFill(BetterList<Vector3> verts, BetterList<Vector2> uvs, BetterList<Color32> cols, Vector3[] vertexOffsets)
    {
        Vector4 v = drawingDimensions;
        Vector4 u = drawingUVs;
        Color32 c = drawingColor;

        bool vertsAdded = false;
        if (vertexOffsets != null && vertexOffsets.Length == 4)
        {
            Vector2[] va = new Vector2[]
            {
                new Vector2(v.x + vertexOffsets[0].x, v.y + vertexOffsets[0].y),
                new Vector2(v.x + vertexOffsets[1].x, v.w + vertexOffsets[1].y),
                new Vector2(v.z + vertexOffsets[2].x, v.w + vertexOffsets[2].y),
                new Vector2(v.z + vertexOffsets[3].x, v.y + vertexOffsets[3].y)
            };
            Vector2 intersection = Vector2.zero;
            if (LineIntersectionPoint(va[0], va[2], va[1], va[3], ref intersection))
            {
                float[] d = new float[]
                {
                    Vector3.Magnitude(intersection - va[0]),
                    Vector3.Magnitude(intersection - va[1]),
                    Vector3.Magnitude(intersection - va[2]),
                    Vector3.Magnitude(intersection - va[3])
                };
                float[] q = new float[]
                {
                    (d[0] + d[2]) / d[2],
                    (d[1] + d[3]) / d[3],
                    (d[2] + d[0]) / d[0],
                    (d[3] + d[1]) / d[1]
                };
                verts.Add(new Vector3(v.x + vertexOffsets[0].x, v.y + vertexOffsets[0].y, q[0]));
                verts.Add(new Vector3(v.x + vertexOffsets[1].x, v.w + vertexOffsets[1].y, q[1]));
                verts.Add(new Vector3(v.z + vertexOffsets[2].x, v.w + vertexOffsets[2].y, q[2]));
                verts.Add(new Vector3(v.z + vertexOffsets[3].x, v.y + vertexOffsets[3].y, q[3]));
                vertsAdded = true;
            }
        }

        if (!vertsAdded)
        {
            verts.Add(new Vector3(v.x, v.y, 1));
            verts.Add(new Vector3(v.x, v.w, 1));
            verts.Add(new Vector3(v.z, v.w, 1));
            verts.Add(new Vector3(v.z, v.y, 1));
        }

        uvs.Add(new Vector2(u.x, u.y));
        uvs.Add(new Vector2(u.x, u.w));
        uvs.Add(new Vector2(u.z, u.w));
        uvs.Add(new Vector2(u.z, u.y));

        cols.Add(c);
        cols.Add(c);
        cols.Add(c);
        cols.Add(c);
    }

    bool LineIntersectionPoint(Vector2 ps1, Vector2 pe1, Vector2 ps2, Vector2 pe2, ref Vector2 intersection)
    {
        float a1 = pe1.y - ps1.y;
        float b1 = ps1.x - pe1.x;
        float c1 = a1 * ps1.x + b1 * ps1.y;

        float a2 = pe2.y - ps2.y;
        float b2 = ps2.x - pe2.x;
        float c2 = a2 * ps2.x + b2 * ps2.y;

        float delta = a1 * b2 - a2 * b1;
        if (delta == 0)
            return false;

        intersection = new Vector2(
            (b2 * c1 - b1 * c2) / delta,
            (a1 * c2 - a2 * c1) / delta
        );
        return true;
    }
}
