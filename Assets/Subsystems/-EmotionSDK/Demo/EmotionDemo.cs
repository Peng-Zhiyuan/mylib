using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading.Tasks;

public class EmotionDemo : MonoBehaviour
{
    void Start()
    {
        // 获得图片的 base64 数据
        var imageBase64Data = GameManifestManager.Get("image");

        EmotionSDK.SetEmotionCheck(true);
        EmotionSDK.SetDirectionCheck(true);
        // 检测表情
        EmotionSDK.CheckAsync(imageBase64Data).ContinueWith(task =>{
            
            // 任务返回一个字典, 使用 task.Result 访问
            // 字典包含 EmotionType.cs 中每一项表情
            // 对应值为各表情的权重
            // * 识别失败时返回 null
            Debug.Log($"[C#] complete");
            // Debug.Log($"Love: {task.Result?["Love"]}");
            var json = CustomLitJson.JsonMapper.Instance.ToJson(task.Result);
            Debug.Log(json);
        });

    }

}
