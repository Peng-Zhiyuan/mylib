using UnityEngine;
using System.Collections.Generic;
using System;

public static class UIEngine 
{
    static PagePool pagePool = new PagePool();
    static GameObject root; 
    static GameObject low;
    static GameObject mid;
    static GameObject height;
    static GameObject top;
	static Func<UIResourceType, string, GameObject> externalLoader;

    static Dictionary<string, Floating> createdControl = new Dictionary<string, Floating>();

    public static void Init()
    {
        root = GameObject.Find("Canvas");
        var design = root.transform.Find("Design");
        if(design != null)
        {
            design.gameObject.SetActive(false);
        }
        low = root.transform.Find("Low").gameObject;
        mid = root.transform.Find("Mid").gameObject;
        height = root.transform.Find("Height").gameObject;
        top = root.transform.Find("Top").gameObject;
    }

    public static Canvas Canvas
    {
        get
        {
            return root.GetComponent<Canvas>();
        }
    }

    public static void CleanAdmission()
    {
        AdmissionManager.Remove();
    }

	public static T Forward<T>(object param = null, Admission admission = null) where T : Page
    {
        var name = typeof(T).Name;
		return Forward(name, param, admission) as T;
    }

    private static Page TakeOrCreatePage(string pageName)
    {
        var page = pagePool.Take(pageName);
        if (page == null)
        {
            var prefab = LoadPagePrefab(pageName);

            if(prefab == null)
            {
                throw new Exception("Page prefab: " + pageName + " not found");
            }
            var go_page = GameObject.Instantiate(prefab);
            page = go_page.GetComponent<Page>();
            page.name = prefab.name;
            page.transform.parent = mid.transform;
            page.rectTransform.anchorMax = new Vector2(0, 0);
            page.rectTransform.anchorMax = new Vector2(1, 1);

            page.transform.localScale = Vector2.one;
            page.rectTransform.offsetMin = Vector2.zero;
            page.rectTransform.offsetMax = Vector2.zero;
            //page.transform.localPosition = Vector2.zero;
            //page.rectTransform.parent = root.GetComponent<RectTransform>();
            // page.rectTransform.sizeDelta = Vector2.zero;
            // page.rectTransform.localPosition = Vector2.zero;
            Debug.Log("(new Instance)");
            page.OnCreate();
        }
        else
        {
            page.transform.localScale = Vector2.one;
            page.rectTransform.offsetMin = Vector2.zero;
            page.rectTransform.offsetMax = Vector2.zero;
        }


        return page;
    }

    public static Page Replace(string pageName, string param = null, Admission admision = null)
    {
        if(AdmissionManager.busing)
        {
            return null;
        }
        Debug.Log("Replace to: " + pageName);
        var oldPage = PageStack.Find(pageName);
        if (oldPage != null)
        {
            throw new Exception("page: " + pageName + " already in stack, can't replace, try use Backto");
        }
        var fromPage = PageStack.Peek();
        var page = TakeOrCreatePage(pageName);
        page.param = param;
        PageStack.RelpaceTop(page);
        RepositionMask();
        if(admision != null)
        {
            AdmissionManager.Play(admision, fromPage, page);
        }
        return page;
    }

    public static Page Forward(string pageName, object param = null, Admission admision = null)
	{
        if(AdmissionManager.busing)
        {
            return null;
        }
        Debug.Log("Navigate to: " + pageName);
        var oldPage = PageStack.Find(pageName);
        if (oldPage != null)
        {
            throw new Exception("page: " + pageName + " already in stack, can't navigate, try use Backto");
        }
        var fromPage = PageStack.Peek();
        var page = TakeOrCreatePage(pageName);
        page.param = param;
        page.OnParamChanged();
        PageStack.Push(page);
        RepositionMask();
        if(admision != null)
        {
            AdmissionManager.Play(admision, fromPage, page);
        }
        return page;
	}


    public static void BackTo<T>() where T : Page
    {
        if(AdmissionManager.busing)
        {
            return;
        }
        var top = Top;
        while(typeof(T) != top.GetType())
        {
            UIEngine.Back();
            top = Top;
            if(top == null)
            {
                break;
            }
        }
    }

    public static void Back(object result = null, Admission admision = null)
	{
        if(AdmissionManager.busing)
        {
            return;
        }
        var page = PageStack.Pop();

        if (page != null)
        {
            pagePool.Put(page.name, page);
        }
        if (PageStack.Count > 0)
        {
            var top = PageStack.Peek();
            Debug.Log("Back to: " + top.name);
            top.OnResult(result);
        }
        else
        {
            Debug.Log("All pages poped!");
        }
        if(admision != null)
        {
            AdmissionManager.Play(admision, page, PageStack.Peek());
        }
        RepositionMask();
	}
        
    public static Page Top
    {
        get
        {
            return PageStack.Peek();
        }
    }

    public static int PagesCount
    {
        get
        {
            return PageStack.Count;
        }
    }

    /// <summary>
    /// 控件，是指整个游戏中只有一个实例的视图
    /// 控件由 UIEngine 直接管理，parent 坐标固定为（0，0）
    /// 因此控件的位置，缩放等可以提前设计
    /// </summary>
    /// <param name="name"></param>
    /// <returns></returns>
	public static Floating ShowFlaoting(string name, string param = null, int depth = UIDepth.High)
    {
        Debug.Log("Show Control: " + name);

        Floating control = null;
        createdControl.TryGetValue(name, out control);
        if(control == null)
        {
            var prefab = LoadControlPrefab(name);

            if (prefab == null)
            {
                Debug.LogError("control prefab:" + name + " not found");
                return null;
            }

            var root = GetRootFromDepth(depth);
            var go = GameObject.Instantiate(prefab);
            control = go.GetComponent<Floating>();
            control.name = prefab.name;
			control.transform.parent = root.transform;
            control.transform.localScale = Vector2.one;
            control.rectTransform.anchorMin = Vector2.zero;
            control.rectTransform.anchorMax = Vector2.one;
            control.rectTransform.offsetMin = Vector2.zero;
            control.rectTransform.offsetMax = Vector2.zero;
            
            control.OnCreate();
            createdControl[name] = control;
        }
		control.param = param;
        control.OnParamChanged();
        control.Active = true;
        control.Depth = depth;
        return control;
    }

    public static GameObject GetRootFromDepth(int depth)
    {
        switch(depth)
        {
            case UIDepth.High:
                return height;
            case UIDepth.Middle:
                return mid;
            case UIDepth.Low:
                return low;
            case UIDepth.Top:
                return top;
        }
        return mid;
    }

    public static Floating GetControl<T>()
    {
        var name = typeof(T).ToString();
        return GetControl(name);
    }

    public static Floating GetControl(string name)
    {
        Floating control = null;
        createdControl.TryGetValue(name, out control);
        return control;
    }

    public static void HideFlaoting<T>()
    {
        var name = typeof(T).Name;
        HideFlaoting(name);
    }

    public static void HideFlaoting(string name)
    {
        Debug.Log("Hide Control: " + name);
        Floating control = null;
        createdControl.TryGetValue(name, out control);
        if (control != null)
        {
            control.Active = false;
        }
    }

	public static T ShowFloating<T>(string param=null,int depth = UIDepth.High) where T : Floating
    {
        var name = typeof(T).Name;
		var control = ShowFlaoting(name,param, depth);
        return control as T;
    }

    public static T GetComtrol<T>() where T : Floating
    {
        var name = typeof(T).Name;
        var control = GetControl(name);
        return control as T;
    }

    private static GameObject LoadPagePrefab(string name)
    {
        var prefab = Resources.Load("ui-engine/pages/" + name) as GameObject;
		if (prefab == null && externalLoader != null)
        {
            prefab = externalLoader.Invoke(UIResourceType.Page, name);
        }
        return prefab;
    }

    private static GameObject LoadControlPrefab(string name)
    {
        var prefab = Resources.Load("ui-engine/floatings/" + name) as GameObject;
        if (prefab == null)
        {
			if(externalLoader != null) externalLoader.Invoke(UIResourceType.Control, name);
        }
        return prefab;
    }
        
    public static void RepositionMask()
    {
		Page firstPage = PageStack.Peek();
		if (firstPage.Overlay)
        {
			Floating control = ShowFlaoting("MaskControl", null, firstPage.Depth - 1);
            control.transform.SetAsLastSibling();
            control.transform.SetSiblingIndex(firstPage.transform.GetSiblingIndex());
        }
        else
        {
            Floating c = GetControl("MaskControl");
            if (c != null)
            {
                c.Active = false;
            }
        }
    }   

	public static void RegisterExternalResouceLoader(Func<UIResourceType, string, GameObject> loader)
    {
        externalLoader = loader;
    }

    public static void DestroyFromPool(string name)
    {
        pagePool.Destroy(name);
    }
}

public static class UIDepth
{
    public const int Low = 0;
	public const int Middle = 100;
    public const int High = 200;
    public const int Top = 300;
}

public enum UIResourceType
{
    Page,
    Control,
}