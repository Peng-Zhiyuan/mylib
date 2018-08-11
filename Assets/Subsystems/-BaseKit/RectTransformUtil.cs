using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class RectTransformUtil
{
    static private Canvas _canvas;
    static private Canvas Canvas
    {
        get
        {
            if(_canvas == null)
            {
                _canvas = GameObject.Find("Canvas").GetComponent<Canvas>();
            }
            return _canvas;
        }
    } 

    static public Rect GetWorldRect (RectTransform rt) {
         // 这里获得的是 canvans 坐标系下的坐标，canvas 会根据设备自动进行捉摸不定的缩放
         // Convert the rectangle to world corners and grab the top left
         Vector3[] corners = new Vector3[4];
         rt.GetWorldCorners(corners);
         Vector3 topLeft = corners[0];
 
         // 因此，如果要获得真正的世界坐标，这里需要乘以 canvas 的缩放
         // Rescale the size appropriately based on the current Canvas scale
         Vector2 scale = Canvas.transform.localScale;
         Vector2 scaledSize = new Vector2(scale.x * rt.rect.size.x, scale.y * rt.rect.size.y);
         //Vector2 scaledSize = new Vector2(rt.rect.size.x, rt.rect.size.y);

         return new Rect(topLeft, scaledSize);
    }
}