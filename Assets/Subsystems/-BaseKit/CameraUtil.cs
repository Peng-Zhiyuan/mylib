using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class CameraUtil
{
    // 获得摄像机正在渲染的区域的尺寸
    // 其比值与设备分辨率相同
    public static Vector2 GetRanderingSize()
    {
        float leftBorder;
        float rightBorder;
        float topBorder;
        float downBorder;
        //the up right corner
        Vector3 cornerPos=Camera.main.ViewportToWorldPoint(new Vector3(1f,1f,Mathf.Abs(Camera.main.transform.position.z)));

        leftBorder=Camera.main.transform.position.x-(cornerPos.x-Camera.main.transform.position.x);
        rightBorder=cornerPos.x;
        topBorder=cornerPos.y;
        downBorder=Camera.main.transform.position.y-(cornerPos.y-Camera.main.transform.position.y);

        var width=rightBorder-leftBorder;
        var height=topBorder-downBorder;

        return new Vector2(width, height);
    }

    // 设置摄像机渲染尺寸
    // 根据一个设计渲染区域，并且宽度适配实际设备，高度自动变动
    // 返回高度实际渲染区域和设计渲染区域的比值
    public static float SetCameraSizeByDecisionRevelutionAndFixAtWidth(int width, int height)
    {
        var hvw = Screen.height / (float)Screen.width;
		var cameraHeight = 1080 * hvw;
		var halfCameraHeight = cameraHeight / 2;
		Camera.main.orthographicSize = halfCameraHeight;
		var scaled = cameraHeight / 1920f;
        return scaled;
    }
}