using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class MathUtil
{
    public static float PointDistancePower2(Vector2 p1, Vector2 p2)
    {
        var a = p1.x - p2.x;
        var b = p1.y - p2.y;
        return a * a + b * b;
    }

    public static bool IsRectIntersect(Rect a, Rect b)
    {
        if(a.min.x > b.max.x)
        {
            return false;
        }
        if(a.max.x < b.min.x)
        {
            return false;
        }
        if(a.min.y > b.max.y)
        {
            return false;
        }
        if(a.max.y < b.min.y)
        {
            return false;
        }
        return true;
    }
}