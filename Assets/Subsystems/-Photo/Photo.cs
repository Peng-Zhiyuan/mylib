using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading.Tasks;
using System;

public static class Photo 
{
    // 选取照片
    // 当任务解决时返回照片的 base64 数据
    // 当用户取消时抛出异常
    public static Task<string> SelectAsync()
    {
        var tcs = new TaskCompletionSource<string>();
        NativeBridge.InvokeCall("NativePhoto", "Select", null, base64 => {
            if(!string.IsNullOrEmpty(base64))
            {
                // 选取了照片
                tcs.SetResult(base64);
            }
            else
            {
                // 没有选取照片
                var e = new Exception("user canceled");
                tcs.SetException(e);
            }
        });
        return tcs.Task;
    }


    // 保存照片
    // 当任务解决时返回照片的 base64 数据
    // 当用户取消时抛出异常
    public static Task<bool> SaveAsync(string base64)
    {
        var tcs = new TaskCompletionSource<bool>();
        NativeBridge.InvokeCall("NativePhoto", "Save", base64, success => {
            if(success == "true")
            {
                // 选取了照片
                tcs.SetResult(true);
            }
            else
            {
                // 没有选取照片
                var e = new Exception("save photo error");
                tcs.SetException(e);
            }
        });
        return tcs.Task;
    }
}
