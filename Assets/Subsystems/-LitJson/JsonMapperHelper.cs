using UnityEngine;
using System.Collections;
using System.Threading;
using GameCore;
namespace CustomLitJson
{
	public class JsonMapperHelper : Single<JsonMapperHelper> {
		static  int mainThreadId = System.Threading.Thread.CurrentThread.ManagedThreadId;
		public Thread parameterThread;
		// If called in the non main thread, will return false;
		public static bool IsMainThread
		{
			get { return System.Threading.Thread.CurrentThread.ManagedThreadId == mainThreadId; }
		}

		public   T ToObject<T> (string json)
		{
			if(IsMainThread)
			{
				return JsonMapper.Instance.ToObject<T>(json);
			}
			else
			{
				return JsonThreadMapper.Instance.ToObject<T>(json);
			}
		}
	}
}
