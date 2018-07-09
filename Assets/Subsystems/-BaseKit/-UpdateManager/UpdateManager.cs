using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 安装：
/// 每一帧调用 UpdateManager.Update()
/// </summary>
public static class UpdateManager
{
    private readonly static List<IUpdatable> list = new List<IUpdatable>();
    private readonly static List<IUpdatable> newAdd = new List<IUpdatable>();
    private readonly static List<IUpdatable> newRemove = new List<IUpdatable>();

    public static void Add(IUpdatable updatable)
    {
        newAdd.Add(updatable);
    }

    public static void Remove(IUpdatable updatable)
    {
		newRemove.Add(updatable);
    }

    public static void Update()
    {
        foreach (var u in list)
        {
            u.Update();
        }
        
        if (newRemove.Count > 0)
        {
            foreach (var r in newRemove)
            {
                list.Remove(r);
            }
            newRemove.Clear();
        }

        if (newAdd.Count > 0)
        {
            foreach (var r in newAdd)
            {
                if (!list.Contains(r))
                {
                    list.Add(r);
                }
            }
            newAdd.Clear();
        }
    }

}

public interface IUpdatable
{
    void Update();
}