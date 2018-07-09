using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using ElementSystem;
using System;

[RequireComponent(typeof(UIScrollView))]
public class ElementScrollView : MonoBehaviour 
{
    public float cellHeight = 100;
    public int depth;
    public string elementName;

    public Action<Element, object> OnSetElement;

    private UIPanel _panel;
    private UIPanel Panel
    {
        get
        {
            if (_panel == null)
            {
                _panel = GetComponent<UIPanel>();
            }
            return _panel;
        }
    }

    private UIScrollView _scrollView;
    private UIScrollView ScrollView
    {
        get
        {
            if (_scrollView == null)
            {
                _scrollView = GetComponent<UIScrollView>();
            }
            return _scrollView;
        }
    }

    private List<object> dataList = new List<object>();
    private Transform head;
    private Transform tail;
    private Queue<Element> queue = new Queue<Element>();

    void Awake()
    {
        CreateHeadTail();

        /*
        var list = new List<object>();
        for (int i = 0; i < 10; i++)
        {
            list.Add(new object());
        }
        ChangeData(list);
        */
    }

    public enum Option
    {
        None,
        MoveToHead,
        MoveToTail,
    }
        
    public void ChangeData(List<object> dataList, Option option = Option.None)
    {
        this.dataList.Clear();
        this.dataList.AddRange(dataList);
        RepositionTail();
        switch (option)
        {
            case Option.None:
                break;
            case Option.MoveToHead:
                MoveToHeadNotRefresh();
                break;
            case Option.MoveToTail:
                MoveToTailNotRefresh();
                break;
        }
        PlaceElement();
    }
        
    public void Move(float deltaY)
    {
        MoveNotRefresh(deltaY);
        RecalculateVisibleElement();
    }

    public void MoveToHead()
    {
        MoveToHead();
        RecalculateVisibleElement();
    }

    public void MoveToTail()
    {
        MoveToTailNotRefresh();
        RecalculateVisibleElement();
    }

    private void MoveToTailNotRefresh()
    {
        var delta = (ClipBottom + cellHeight / 2) - tail.localPosition.y;
        MoveNotRefresh(delta);
    }

    private void MoveToHeadNotRefresh()
    {
        var delta = head.localPosition.y - (ClipTop - cellHeight / 2);
        MoveNotRefresh(-delta);
    }

    private void MoveNotRefresh(float deltaY)
    {
        var p = Panel.transform.localPosition;
        Panel.transform.localPosition = new Vector3(p.x, p.y + deltaY, p.z);
        var offset = Panel.clipOffset;
        Panel.clipOffset = new Vector2(offset.x, offset.y - deltaY);
    }

    private void CreateHeadTail()
    {
        var headY = ClipTop - cellHeight / 2;
        var tailY = ClipBottom + cellHeight / 2;
        {
            var head = new GameObject();
            head.transform.parent = this.transform;
            head.transform.localScale = Vector3.one;
            head.transform.localPosition = new Vector3(ClipCenterX, headY, 0);
            var widget = head.AddComponent<UIWidget>();
            widget.width = (int)Panel.width;
            widget.height = (int)cellHeight;
            this.head = head.transform;
            head.name = "head";
        }
        {
            var tail = new GameObject();
            tail.transform.parent = this.transform;
            tail.transform.localScale = Vector3.one;
            tail.transform.localPosition = head.transform.localPosition;
            var widget = tail.AddComponent<UIWidget>();
            widget.width = (int)Panel.width;
            widget.height = (int)cellHeight;
            this.tail = tail.transform;
            tail.name = "tail";
        }
    }

    private void RepositionTail()
    {
        tail.localPosition = head.localPosition;
        var shift = (dataList.Count - 1) * cellHeight;
        if (shift < 0)
        {
            shift = 0;
        }
        var position = tail.localPosition;
        tail.localPosition = new Vector3(position.x, position.y - shift, position.z);
    }

    private float ClipTop
    {
        get
        {
            var v = Panel.baseClipRegion;
            var centerX = v.x;
            var centerY = v.y;
            var wight = v.z;
            var height = v.w;
            return centerY + height / 2 + Panel.clipOffset.y;
        }
    }

    private float ClipBottom
    {
        get
        {
            var v = Panel.baseClipRegion;
            var centerX = v.x;
            var centerY = v.y;
            var wight = v.z;
            var height = v.w;
            return centerY - height / 2 + Panel.clipOffset.y;
        }
    }

    private float ClipCenterX
    {
        get
        {
            var v = Panel.baseClipRegion;
            var centerX = v.x;
            var centerY = v.y;
            var wight = v.z;
            var height = v.w;
            return centerX + Panel.clipOffset.x;
        }
    }

    private Element CreateElement()
    {
        if (queue.Count == 0)
        {
            var parentDesigner = GetComponentInParent<ElementDesigner>();
            Transform extraPrototypeRoot = null;
            if (parentDesigner != null)
            {
                extraPrototypeRoot = parentDesigner.ProtptypeRoot;
            }
            var element = ElementManager.CreateElement(this.elementName, this.transform, extraPrototypeRoot);
            ShiftDepth(element, depth);
            AddDragScrollView(element, ScrollView);
            return element;
        }
        else
        {
            var element = queue.Dequeue();
            element.gameObject.SetActive(true);
            return element;
        }
    }

    private Element CreateElement(int index)
    {
        var element = CreateElement();
        element.transform.localPosition = GetElementPosition(index);
        element.listIndex = index;
        #if UNITY_EDITOR
        element.name = index.ToString();
        #endif
        if (OnSetElement != null)
        {
            var data = dataList[index];
            OnSetElement(element, data);
            element.gameObject.SetActive(false);
            element.gameObject.SetActive(true);
        }
        return element;
    }

    private void DestroyElement(Element element)
    {
        element.gameObject.SetActive(false);
        queue.Enqueue(element);
    }

    List<Element> activeElementList = new List<Element>();

    private void PlaceElement()
    {
        DestroyAllActiveElement();
        if (dataList.Count == 0)
        {
            return;
        }
        int index;
        float y;
        CalculateFirstActiveElementIndex(out index, out y);
        if (!IsIndexValidate(index))
        {
            return;
        }
        int counter = 0;
        while (y >= ClipBottom - cellHeight/2)
        {
            var element = CreateElement(index);
            activeElementList.Add(element);
            index++;
            if (!IsIndexValidate(index))
            {
                break;
            }
            y -= cellHeight;
            counter++;
            if (counter >= 100)
            {
                Debug.LogError("counter more than 100, something wrong!");
                break;
            }
        }
    }

    private void CalculateFirstActiveElementIndex(out int firstIndex, out float firstY)
    {
        var headTop = head.localPosition.y + cellHeight / 2;
        var topDistance = headTop - ClipTop;
        var index = (int)(topDistance / cellHeight);
        var firstActiveElementShift = topDistance % cellHeight;
        var firstActiveElementY = ClipTop - cellHeight / 2 + firstActiveElementShift;
        firstIndex = index;
        firstY = firstActiveElementY;
    }

    private void RecalculateVisibleElement()
    {
        if (!IsBult)
        {
            return;
        }
        // 将出界的element去掉
        for (int i = activeElementList.Count - 1; i >= 0; i--)
        {
            var element = activeElementList[i];
            var index = element.listIndex;
            var visible = IsElementVisible(index);
            if (!visible)
            {
                activeElementList.RemoveAt(i);
                DestroyElement(element);
            }
        }
        if (activeElementList.Count > 0)
        {
            // 尝试从两端创建新element
            var fristActiveElement = activeElementList[0];
            here:
            var preIndex = fristActiveElement.listIndex - 1;
            if (IsElementVisible(preIndex))
            {
                var newElement = CreateElement(preIndex);
                activeElementList.Insert(0, newElement);
                fristActiveElement = newElement;
                goto here;
            }
            // tail
            var lastActiveElement = activeElementList[activeElementList.Count - 1];
            there:
            var nextIndex = lastActiveElement.listIndex + 1;
            if (IsElementVisible(nextIndex))
            {
                var newElement = CreateElement(nextIndex);
                activeElementList.Add(newElement);
                lastActiveElement = newElement;
                goto there;
            }
        }
        else
        {
            PlaceElement();
        }
    }

    void Update()
    {
        RecalculateVisibleElement();
    }

    private bool IsElementVisible(int index)
    {
        if (!IsIndexValidate(index))
        {
            return false;
        }
        float y = head.localPosition.y - index * cellHeight;
        float top = y + cellHeight / 2;
        float bottom = y - cellHeight / 2;
        if (bottom > ClipTop || top < ClipBottom)
        {
            return false;
        }
        return true;
    }

    private bool IsIndexValidate(int index)
    {
        if (index < 0 || index >= dataList.Count)
        {
            return false;
        }
        return true;
    }

    private Vector3 GetElementPosition(int index)
    {
        float y = head.localPosition.y - index * cellHeight;
        float x = ClipCenterX;
        return new Vector3(x, y, 0);
    }

    public float GetMovement()
    {
        return head.localPosition.y - (ClipTop - cellHeight / 2);
    }

    private void DestroyAllActiveElement()
    {
        for (int i = activeElementList.Count - 1; i >= 0; i--)
        {
            var element = activeElementList[i];
            activeElementList.RemoveAt(i);
            DestroyElement(element);
        }
    }

    private bool IsBult
    {
        get
        {
            return head != null;
        }
    }

    private void ShiftDepth(Element element, int delta)
    {
        if (delta == 0)
        {
            return;
        }
        var list = element.GetComponentsInChildren<UIWidget>(true);
        foreach (var w in list)
        {
            w.depth += delta;
        }
    }

    private void AddDragScrollView(Element element, UIScrollView scrollView)
    {
        if (scrollView == null)
        {
            return;
        }
        var list = element.GetComponentsInChildren<UISprite>();
        foreach (var w in list)
        {
            var drag = w.gameObject.AddMissingComponent<UIDragScrollView>();
            drag.scrollView = scrollView;
            var box = w.gameObject.AddMissingComponent<BoxCollider>();
            box.size = new Vector3(w.width, w.height, 0);
        }
        if (list.Length == 0)
        {
            var list2 = element.GetComponentsInChildren<UI2DSprite>();
            foreach (var w in list2)
            {
                var drag = w.gameObject.AddMissingComponent<UIDragScrollView>();
                drag.scrollView = scrollView;
                var box = w.gameObject.AddMissingComponent<BoxCollider>();
                box.size = new Vector3(w.width, w.height, 0);
            }
        }
    }
}
