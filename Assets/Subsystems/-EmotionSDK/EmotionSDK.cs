using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CustomLitJson;
using System.Threading.Tasks;

public static class EmotionSDK
{

    // 设置是否检测表情
    // 禁用可提高性能，默认禁用
    public static void SetEmotionCheck(bool b)
    {
        NativeBridge.InvokeCall("NativeEmotion", "SetEmotionCheck", b ? "true" : "false");
    } 

    // 设置是否检脸部朝向
    // 禁用可提高性能，默认禁用
    public static void SetDirectionCheck(bool b)
    {
        NativeBridge.InvokeCall("NativeEmotion", "SetDirectionCheck", b ? "true" : "false");
    } 

    // 检测图片
    // 返回检测到的脸的数组
    public static Task<List<Face>> CheckAsync(string base64Data)
    {
        var tcs = new TaskCompletionSource<List<Face>>();
        NativeBridge.InvokeCall("NativeEmotion", "Check", base64Data, json =>{
            var result = JsonMapper.Instance.ToObject<CheckResult>(json);
            tcs.SetResult(result.list); 
            
        });
        return tcs.Task;
    }

    /// <summary>
    /// 取表情名称
    /// </summary>
    /// <returns>The emotion type name.</returns>
    /// <param name="index">Index.</param>
    public static string GetEmotionTypeNameByIndex (int index) {
        var obj = typeof (EmotionType);
        var members = obj.GetFields ();

        return index >= 0 && index < members.Length ? members[index].GetValue (null).ToString () : string.Empty;
    }
}
