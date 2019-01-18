using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class PageStack  
{
    static Stack<Page> stack = new Stack<Page>();

    public static void Push(Page page)
    {
        if(stack.Count > 0)
        {
            var top = stack.Peek(); 
            top.OnNavigatedFrom();
        }
        page.Depth = stack.Count * 10;
        page.transform.localScale = Vector3.one;
        var from = Peek();
        stack.Push(page);
        page.Active = true;
        RecaculateActive();
        page.OnPush();
        page.OnNavigatedTo();

        // set sibling position
        if(from != null)
        {
            var index = from.transform.GetSiblingIndex();
            page.transform.SetSiblingIndex(index + 1);
        }
       // page.ignoreFrameUpdate = true;      // TODO: 做什么的？
    }

    public static Page Pop()
    {
        if(stack.Count == 0) return null;
        var page = stack.Pop();
        page.Active = false;
        page.OnNavigatedFrom();
        page.OnPop();
        RecaculateActive();
        if (stack.Count > 0)
        {
            var top = stack.Peek();
            top.OnNavigatedTo();
      //      top.ignoreFrameUpdate = true;   //TODO: 做什么的？
        }
        return page;
    }

    public static List<Page> PopUtil(Page target)
    {
        var ret = new List<Page>();
        if(stack.Count == 0) return ret;
        if(Peek() == target) return ret;
        var page = stack.Pop();
        page.Active = false;
        page.OnNavigatedFrom();
        page.OnPop();
        ret.Add(page);
        while(stack.Peek() != target)
        {
            var p = stack.Pop();
            page.Active = false;
            page.OnPop();
            ret.Add(p);
        }

        RecaculateActive();
        if (stack.Count > 0)
        {
            var top = stack.Peek();
            top.OnNavigatedTo();
      //      top.ignoreFrameUpdate = true;   //TODO: 做什么的？
        }
        return ret;
    }

	public static Page PopToPool(string name,PagePool pagePool)
	{
		while(stack.Count >0 && !stack.Peek().name.Equals(name))
		{
			var page = stack.Pop();
			page.Active = false;
			page.OnNavigatedFrom();
			page.OnPop();
			pagePool.Put(page.name, page);
		}
		if (stack.Count > 0)
		{
			RecaculateActive();
			var tarPage = stack.Peek();
			tarPage.OnNavigatedTo();
			return tarPage;
		}
		return null;
	}

    public static Page Peek()
    {
        if(stack.Count > 0)
        {
             return stack.Peek();
        }
        else
        {
            return null;
        }
    }

    public static Page Find(string name)
    {
        foreach (var page in stack)
        {
            if (page.name == name)
            {
                return page;
            }
        }
        return null;
    }

    public static int Count
    {
        get
        {
            return stack.Count;
        }
    }

    private static Stack<Page> tempStack = new Stack<Page>();
    public static Page Remove(string name)
    {
        Page ret = null;
        while (stack.Count > 0)
        {
            var page = stack.Pop();
            if (page.name != name)
            {
                tempStack.Push(page);
            }
            else
            {
                ret = page;
                page.Active = false;
                page.OnPop();
                break;
            }
        }
        while (tempStack.Count > 0)
        {
            var page = tempStack.Pop();
            stack.Push(page);
        }
        if (ret != null)
        {
            RecaculateActive();
        }
        return ret;
    }

    public static void RelpaceTop(Page page)
    {
		if(stack.Count==0)return;
        var old = stack.Pop();
        old.Active = false;
        old.OnNavigatedFrom();
        old.OnPop();
	
        stack.Push(page);
        page.Active = true;
        page.OnPush();
        page.OnNavigatedTo();
        RecaculateActive();
    }

    static Page[] tempArray = new Page[50];
    private static void RecaculateActive()
    {
        stack.CopyTo(tempArray, 0);
        var visible = true;
        for (var i = 0; i < stack.Count; i++)
        {
            Page page = tempArray[i];
            page.Active = visible;
            if (!page.Overlay)
            {
                visible = false;
            }
        }
    }

    public static Stack<Page> InnerStack
    {
        get
        {
            return stack;
        }
    }
}
