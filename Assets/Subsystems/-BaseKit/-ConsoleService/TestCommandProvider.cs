using UnityEngine;
using System.Collections;
using System;
using System.Collections.Generic;

public class TestCommandProvider : CommandProvider {

    #if !RELEASE
    [Command]
	public void hello_console()
    {
        consoleService.Print(LogLevel.Info, "Hello Console!\n");
    }

    [Command]
    public void speed(string arg)
    {
        // float speed= float.Parse(arg);
        // if(speed == 1)
        // {
        //     Println(LogLevel.Info, "Speed has beed reseted.");
        //     TimerMgr.Instance.Remove("speed-deamon");
        //     UnityEngine.Time.timeScale=1;
        // }
        // else
        // {
        //     Println(LogLevel.Info, "Speed set to " + speed + ".");
        //     TimerMgr.Instance.Remove("speed-deamon");
        //     TimerMgr.Instance.GlobalLoop("speed-deamon", 0.1f, () =>
        //         {
        //             UnityEngine.Time.timeScale=speed;
        //         });
        // }
    }
		
    [Command]
    public void set(string key, string value)
    {
        //GameManifestOverrider.Set(key, value);
    }

    [Command]
    public void delete(string key)
    {
        //GameManifestOverrider.Delete(key);
    }

    #endif
}

