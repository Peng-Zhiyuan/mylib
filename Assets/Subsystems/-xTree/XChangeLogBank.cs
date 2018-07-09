using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public static class XChangeLogBank
{
    public static Queue<XChangeLog> queue = new Queue<XChangeLog>();

    public static XChangeLog Take()
    {
        if(queue.Count > 0)
        {
            return queue.Dequeue();
        }
        return new XChangeLog();
    }

    public static void GiveBack(XChangeLog change)
    {
        queue.Enqueue(change);
    }
}
