using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System;

public class SystemGraphWindow : EditorWindow
{
    private static Dictionary<string, SystemNodeInfo> nameToInfo = new Dictionary<string, SystemNodeInfo>();
    private static Dictionary<string, DRect> nameToRect = new Dictionary<string, DRect>();

    private static int XStart = 70;
    private static int YStart = 70;
    private static int Width = 140;
    private static int Height = 30;
    private static int XStep = 160;
    private static int YStep = 90;

    public static void Show(Dictionary<string, SystemNodeInfo> dic)
    {
        nameToInfo = dic;
        nameToRect.Clear();
        var max = FindMaxLayer();
        int x = XStart;
        int y = YStart;
        for(var i = max ; i >= 0 ; i--)
        {
            var nameList = FindInfoByLayer(i);
            foreach (var name in nameList)
            {
                nameToRect[name] = new DRect(x - Width/2, y - Height/2, Width, Height);
                x += XStep;
            }
            y += YStep;
            x = XStart;
        }


        var window = EditorWindow.CreateInstance<SystemGraphWindow>();
        window.Show();
    }

    private static int FindMaxLayer()
    {
        var max = 0;
        foreach (var kv in nameToInfo)
        {
            var info = kv.Value;
            if (info.cachedLayer > max)
            {
                max = info.cachedLayer;
            }
        }
        return max;
    }

    private static List<string> FindInfoByLayer(int layer)
    {
        var ret = new List<string>();
        foreach (var kv in nameToInfo)
        {
            var name = kv.Key;
            var info = kv.Value;
            if (info.cachedLayer == layer)
            {
                ret.Add(name);
            }
        }
        return ret;
    }

    void OnGUI()
    {
        // draw rect
        foreach (var kv in nameToRect)
        {
            var name = kv.Key;
            var rect = kv.Value;
            EditorGUI.DrawRect(rect.ToRect(), Color.gray);
        }

        // draw dependency
        foreach (var kv in nameToInfo)
        {
            var name = kv.Key;
            var info = kv.Value;
            var rect = nameToRect[name];
            var color = GetLayerColor(info.cachedLayer);
            GUI.color = color;
           // Graphics.draw
           // EditorGUI.DrawRect(rect, Color.cyan);
            foreach (var d in info.dependency)
            {
                var startX = rect.CenterX;
                var startY = rect.CenterY;
                var drect = nameToRect[d];
                var endX = drect.CenterX;
                var endY = drect.CenterY;
                DrawLine(startX, startY, endX, endY);
            }
        }

        // draw system name
        var save = GUI.skin.label.fontSize;
        GUI.skin.label.fontSize = 18;
        foreach (var kv in nameToRect)
        {
            var name = kv.Key;
            var rect = kv.Value;
            GUI.color = Color.white;
            GUI.Label(rect.ToRect(), name);
        }
        GUI.skin.label.fontSize = save;

    }

    private Color GetLayerColor(int layer)
    {
        if (layer == 1)
        {
            return new Color(152 / 350f , 251 / 350f, 152 / 350f);
        }
        if (layer == 2)
        {
            return new Color(255 / 350f, 255 / 350f, 0 / 350f);
        }
        if (layer == 3)
        {
            return new Color(205 / 350f, 92 / 350f, 92 / 350f);
        }
        return new Color(139 / 350f, 101 / 350f, 8 / 350f);
    }


         
    private void DrawLine(float x, float y, float x2, float y2)
    {
        var deltaY = y2 - y;
        var deltaX = x2 - x;
        if (deltaX != 0)
        {
            var k = deltaY / deltaX;
            var xStep = Normalize(deltaX);
            var hotX = x;
            var hotY = y;
            var death = 3000;
            var deathTimer = 0;
            while (true)
            {
                EditorGUI.DrawRect(new Rect(hotX, hotY, 1, 1), Color.white);
                hotX += xStep;
                hotY += xStep * k;
                if (DiffrentSymbol(deltaX, x2 - hotX))
                {
                    break;
                }
                deathTimer++;
                if (deathTimer >= death)
                {
                    break;
                }
            }
        }
        else
        {
            var yStep = Normalize(deltaY);
            var hotX = x;
            var hotY = y;
            var death = 1000;
            var deathTimer = 0;
            while (true)
            {
                EditorGUI.DrawRect(new Rect(hotX, hotY, 1, 1), Color.white);
                hotY += yStep;
                if (DiffrentSymbol(deltaY, y2 - hotY))
                {
                    break;
                }
                deathTimer++;
                if (deathTimer >= death)
                {
                    break;
                }
            }
        }
    }

    private bool DiffrentSymbol(float a, float b)
    {
        if (a > 0 && b <= 0)
        {
            return true;
        }
        else if (a < 0 && b >= 0)
        {
            return true;
        }
        return false;
    }

    private float Normalize(float a)
    {
        if (a > 0)
        {
            return 1;
        }
        else
        {
            return -1;
        }
    }
}

public class DRect
{
    public float leftTopX;
    public float leftTopY;
    public float width;
    public float height;

    public float CenterX
    {
        get
        {
            return leftTopX + width / 2;
        }
    }

    public float CenterY
    {
        get
        {
            return leftTopY + height / 2;
        }
    }

    public Rect ToRect()
    {
        return new Rect(leftTopX, leftTopY, width, height);
    }

    public DRect(float leftTopX, float leftTopY, float width, float height)
    {
        this.leftTopX = leftTopX;
        this.leftTopY = leftTopY;
        this.width = width;
        this.height = height;
    }


}
