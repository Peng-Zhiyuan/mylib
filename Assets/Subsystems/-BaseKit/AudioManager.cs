using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public static class AudioManager
{
    private static GameObject root;

    public static float Volume
    {
        get
        {
            return AudioListener.volume;
        }
        set
        {
            AudioListener.volume = value;
        }
    }

	static AudioManager()
	{
		root = new GameObject("AudioServiceRoot");
        root.AddComponent<AudioListener>();
        CoroutineManager.Create(UpdateAsyn());
        GameObject.DontDestroyOnLoad(root);
	}


    static AudioSource bgmPlayer;
    static List<AudioTask> audioTasks = new List<AudioTask>();

    static AudioSource BgmPlayer
	{
		get
		{
			if (bgmPlayer == null) bgmPlayer = TakePlayer("BgmPlayer");
			return bgmPlayer;
		}
	}

	class AudioTask
	{
        public Parameter parameter;
        public AudioClip clip;
		public AudioSource player;
		public float deadTime;
        public bool registerInSingleDic;
        public bool destroy;
	}

    static IEnumerator UpdateAsyn()
	{
        while(true)
        {
            yield return null;
            frameOnceDic.Clear();
            for (int i = audioTasks.Count - 1; i >= 0; i--)
            {
                var task = audioTasks[i];
                if (Time.time > task.deadTime || task.destroy)
                {
                    task.player.gameObject.SetActive(false);
                    PutPlayer(task.player);
                    audioTasks.RemoveAt(i);
                    if(task.registerInSingleDic)
                    {
                        singleDic.Remove(task.clip);
                    }
                    PutAudioTask(task);
                }
            }
        }
	}
	public static void PlaySe(string se, float volume = 1)
	{
		var clip = Resources.Load<AudioClip>("audio-manager/se/" + se);
        Play(clip, 1.0f, Parameter.FrameOnce);
	}
	public static void PlayBgm(string bgm, float volume = 1)
	{
		var clip = Resources.Load<AudioClip>("audio-manager/bgm/" + bgm);
        PlayBgm(clip, 1.0f);
	}
	public static void PlayBgm(AudioClip clip, float volume = 1)
	{
		var player = BgmPlayer;
		player.clip = clip;
		player.volume = volume;
		player.loop = true;
		player.Play();
	}
    
    public static void StopBgm()
    {
        BgmPlayer.Stop();
    }
	
    public static void PauseBgm()
    {
        BgmPlayer.Pause();
    }

    public static void ResumeBgm()
    {
        BgmPlayer.UnPause();
    }


    static Dictionary<AudioClip, AudioTask> singleDic = new Dictionary<AudioClip, AudioTask>();
    static Dictionary<AudioClip, AudioTask> frameOnceDic = new Dictionary<AudioClip, AudioTask>();

    public static void Play(AudioClip clip, float volume, Parameter parameter = Parameter.MutiTask)
    {
        if (clip == null) return;
        // 检查要播放的clip是否已经存在一个播放任务，如果存在，则不再播放新的
        if (parameter == Parameter.SingleTaskEarly)
        {
            AudioTask task2;
            singleDic.TryGetValue(clip, out task2);
            if (task2 != null) return;
        }
        else if(parameter == Parameter.SingleTaskLater)
        {
            AudioTask task2;
            singleDic.TryGetValue(clip, out task2);
            if (task2 != null)
            {
                task2.player.Stop();
                task2.registerInSingleDic = false;
                task2.destroy = true;
            }
        }
        else if(parameter == Parameter.FrameOnce)
        {
            AudioTask task2;
            frameOnceDic.TryGetValue(clip, out task2);
            if (task2 != null) return;
        }

        var player = TakePlayer(clip.name);
        player.clip = clip;
        player.volume = volume;
        player.Play();

        var task = TakeAudioTask();
        task.player = player;
        task.clip = clip;
        task.deadTime = Time.time + clip.length;
        task.destroy = false;
        task.registerInSingleDic = false;

        audioTasks.Add(task);

        if(parameter == Parameter.SingleTaskEarly || parameter == Parameter.SingleTaskLater)
        {
            task.registerInSingleDic = true;
            singleDic[clip] = task;
        }
        else if(parameter == Parameter.FrameOnce)
        {
            frameOnceDic[clip] = task;
        }
    }

    public enum Parameter
    {
        /// <summary>
        /// 允许多实例播放
        /// </summary>
        MutiTask,

        /// <summary>
        /// 只允许单一实例播放，如果正在播放时再次请求播放，请求会被无视
        /// </summary>
        SingleTaskEarly,

        /// <summary>
        /// 只允许单一实例播放，如果正在播放时再次请求播放，会先停止已播放的实例
        /// </summary>
        SingleTaskLater,

        /// <summary>
        /// 每一帧只允许一个实例播放
        /// </summary>
        FrameOnce,
    }

    static AudioSource NewPlayer(string name)
	{
        var obj = new GameObject();
        var player = obj.AddComponent<AudioSource>();
        obj.transform.parent = root.transform;
		player.name = name;
		return player;
	}

    static Queue<AudioTask> audioTaskPool = new Queue<AudioTask>();
    static AudioTask TakeAudioTask()
    {
        if(audioTaskPool.Count > 0)
        {
            return audioTaskPool.Dequeue();
        }
        else
        {
            return new AudioTask();
        }
    }

    static void PutAudioTask(AudioTask task)
    {
        audioTaskPool.Enqueue(task);
    }

    static Queue<AudioSource> playerPool = new Queue<AudioSource>();
    static AudioSource TakePlayer(string name)
    {
        if (playerPool.Count > 0)
        {
            var p = playerPool.Dequeue();
            p.name = name;
            p.gameObject.SetActive(true);
            return p;
        }
        else
        {
            return NewPlayer(name);
        }
    }

    static void PutPlayer(AudioSource player)
    {
        playerPool.Enqueue(player);
    }
}
