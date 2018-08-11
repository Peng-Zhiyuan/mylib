using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PagePool  {

    Dictionary<string, Queue<Page>> dic = new Dictionary<string, Queue<Page>>();

    public void Put(string name, Page page)
    {
        Queue<Page> queue;
        dic.TryGetValue(name, out queue);
        if (queue == null)
        {
            queue = new Queue<Page>();
            dic[name] = queue;
        }
        queue.Enqueue(page);
    }

    public Page Take(string name)
    {
        Queue<Page> queue;
        dic.TryGetValue(name, out queue);
        if (queue != null)
        {
            return queue.Dequeue();
        }
        return null;
    }

    public void Destroy(string name)
    {
        dic[name] = null;
    }	
}
