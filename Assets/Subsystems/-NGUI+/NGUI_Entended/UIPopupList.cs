using UnityEngine;
using System.Collections.Generic;
//[ExecuteInEditMode]
//[AddComponentMenu("NGUI/Interaction/Popup List")]
public partial class UIPopupList : UIWidgetContainer
{

	/// <summary>
	/// Manually close the popup list.
	/// </summary>
	public List<EventDelegate> onClose = new List<EventDelegate>(); 
	public List<EventDelegate> onShow = new List<EventDelegate>(); 
	public virtual void CloseSelf ()
	{
        
		Debug.Log("CloseSelf");
		if (mChild != null && current == this)
		{
			StopCoroutine("CloseIfUnselected");
			mSelection = null;

			mLabelList.Clear();

			if (isAnimated)
			{
				UIWidget[] widgets = mChild.GetComponentsInChildren<UIWidget>();

				for (int i = 0, imax = widgets.Length; i < imax; ++i)
				{
					UIWidget w = widgets[i];
					Color c = w.color;
					c.a = 0f;
					TweenColor.Begin(w.gameObject, animSpeed, c).method = UITweener.Method.EaseOut;
				}

				Collider[] cols = mChild.GetComponentsInChildren<Collider>();
				for (int i = 0, imax = cols.Length; i < imax; ++i) cols[i].enabled = false;
				Destroy(mChild, animSpeed);

				mFadeOutComplete = Time.unscaledTime + Mathf.Max(0.1f, animSpeed);
			}
			else
			{
				Destroy(mChild);
				mFadeOutComplete = Time.unscaledTime + 0.1f;
			}

			mBackground = null;
			mHighlight = null;
			mChild = null;
			current = null;
			if(onClose.Count>0)
			{
				if (EventDelegate.IsValid(onClose))
				{
					EventDelegate.Execute(onClose);
				}
			}
		}
	}
	public virtual void Show ()
	{
		if (enabled && NGUITools.GetActive(gameObject) && mChild == null && atlas != null && isValid && items.Count > 0)
		{
			mLabelList.Clear();
			StopCoroutine("CloseIfUnselected");

			// Ensure the popup's source has the selection
			UICamera.selectedObject = (UICamera.hoveredObject ?? gameObject);
			mSelection = UICamera.selectedObject;
			source = UICamera.selectedObject;

			if (source == null)
			{
				Debug.LogError("Popup list needs a source object...");
				return;
			}

			mOpenFrame = Time.frameCount;

			// Automatically locate the panel responsible for this object
			if (mPanel == null)
			{
				mPanel = UIPanel.Find(transform);
				if (mPanel == null) return;
			}

			// Calculate the dimensions of the object triggering the popup list so we can position it below it
			Vector3 min;
			Vector3 max;

			// Create the root object for the list
			mChild = new GameObject("Drop-down List");
			mChild.layer = gameObject.layer;

			if (separatePanel)
			{
				if (GetComponent<Collider>() != null)
				{
					Rigidbody rb = mChild.AddComponent<Rigidbody>();
					rb.isKinematic = true;
				}
				else if (GetComponent<Collider2D>() != null)
				{
					Rigidbody2D rb = mChild.AddComponent<Rigidbody2D>();
					rb.isKinematic = true;
				}
				mChild.AddComponent<UIPanel>().depth = 1000000;
			}
			current = this;

			Transform t = mChild.transform;
			t.parent = mPanel.cachedTransform;
			Vector3 pos;

			// Manually triggered popup list on some other game object
			if (openOn == OpenOn.Manual && mSelection != gameObject)
			{
				pos = UICamera.lastEventPosition;
				min = mPanel.cachedTransform.InverseTransformPoint(mPanel.anchorCamera.ScreenToWorldPoint(pos));
				max = min;
				t.localPosition = min;
				pos = t.position;
			}
			else
			{
				Bounds bounds = NGUIMath.CalculateRelativeWidgetBounds(mPanel.cachedTransform, transform, false, false);
				min = bounds.min;
				max = bounds.max;
				t.localPosition = min;
				pos = t.position;
			}

			StartCoroutine("CloseIfUnselected");

			t.localRotation = Quaternion.identity;
			t.localScale = Vector3.one;

			// Add a sprite for the background
			mBackground = NGUITools.AddSprite(mChild, atlas, backgroundSprite, separatePanel ? 0 : NGUITools.CalculateNextDepth(mPanel.gameObject));
			mBackground.pivot = UIWidget.Pivot.TopLeft;
			mBackground.color = backgroundColor;

			// We need to know the size of the background sprite for padding purposes
			Vector4 bgPadding = mBackground.border;
			mBgBorder = bgPadding.y;
			mBackground.cachedTransform.localPosition = new Vector3(0f, bgPadding.y, 0f);

			// Add a sprite used for the selection
			mHighlight = NGUITools.AddSprite(mChild, atlas, highlightSprite, mBackground.depth + 1);
			mHighlight.pivot = UIWidget.Pivot.TopLeft;
			mHighlight.color = highlightColor;

			UISpriteData hlsp = mHighlight.GetAtlasSprite();
			if (hlsp == null) return;

			float hlspHeight = hlsp.borderTop;
			float fontHeight = activeFontSize;
			float dynScale = activeFontScale;
			float labelHeight = fontHeight * dynScale;
			float x = 0f, y = -padding.y;
			List<UILabel> labels = new List<UILabel>();

			// Clear the selection if it's no longer present
			if (!items.Contains(mSelectedItem))
				mSelectedItem = null;

			// Run through all items and create labels for each one
			for (int i = 0, imax = items.Count; i < imax; ++i)
			{
				string s = items[i];

				UILabel lbl = NGUITools.AddWidget<UILabel>(mChild, mBackground.depth + 2);
				lbl.name = i.ToString();
				lbl.pivot = UIWidget.Pivot.TopLeft;
				lbl.bitmapFont = bitmapFont;
				lbl.trueTypeFont = trueTypeFont;
				lbl.fontSize = fontSize;
				lbl.fontStyle = fontStyle;
				lbl.text = isLocalized ? Localization.Get(s) : s;
				lbl.color = textColor;
				lbl.cachedTransform.localPosition = new Vector3(bgPadding.x + padding.x - lbl.pivotOffset.x, y, -1f);
				lbl.overflowMethod = UILabel.Overflow.ResizeFreely;
				lbl.alignment = alignment;
				labels.Add(lbl);

				y -= labelHeight;
				y -= padding.y;
				x = Mathf.Max(x, lbl.printedSize.x);

				// Add an event listener
				UIEventListener listener = UIEventListener.Get(lbl.gameObject);
				listener.onHover = OnItemHover;
				listener.onPress = OnItemPress;
				listener.parameter = s;

				// Move the selection here if this is the right label
				if (mSelectedItem == s || (i == 0 && string.IsNullOrEmpty(mSelectedItem)))
					Highlight(lbl, true);

				// Add this label to the list
				mLabelList.Add(lbl);
			}

			// The triggering widget's width should be the minimum allowed width
			x = Mathf.Max(x, (max.x - min.x) - (bgPadding.x + padding.x) * 2f);

			float cx = x;
			Vector3 bcCenter = new Vector3(cx * 0.5f, -labelHeight * 0.5f, 0f);
			Vector3 bcSize = new Vector3(cx, (labelHeight + padding.y), 1f);

			// Run through all labels and add colliders
			for (int i = 0, imax = labels.Count; i < imax; ++i)
			{
				UILabel lbl = labels[i];
				NGUITools.AddWidgetCollider(lbl.gameObject);
				lbl.autoResizeBoxCollider = false;
				BoxCollider bc = lbl.GetComponent<BoxCollider>();

				if (bc != null)
				{
					bcCenter.z = bc.center.z;
					bc.center = bcCenter;
					bc.size = bcSize;
				}
				else
				{
					BoxCollider2D b2d = lbl.GetComponent<BoxCollider2D>();
					#if UNITY_4_3 || UNITY_4_5 || UNITY_4_6
					b2d.center = bcCenter;
					#else
					b2d.offset = bcCenter;
					#endif
					b2d.size = bcSize;
				}
			}

			int lblWidth = Mathf.RoundToInt(x);
			x += (bgPadding.x + padding.x) * 2f;
			y -= bgPadding.y;

			// Scale the background sprite to envelop the entire set of items
			mBackground.width = Mathf.RoundToInt(x);
			mBackground.height = Mathf.RoundToInt(-y + bgPadding.y);

			// Set the label width to make alignment work
			for (int i = 0, imax = labels.Count; i < imax; ++i)
			{
				UILabel lbl = labels[i];
				lbl.overflowMethod = UILabel.Overflow.ShrinkContent;
				lbl.width = lblWidth;
			}

			// Scale the highlight sprite to envelop a single item
			float scaleFactor = 2f * atlas.pixelSize;
			float w = x - (bgPadding.x + padding.x) * 2f + hlsp.borderLeft * scaleFactor;
			float h = labelHeight + hlspHeight * scaleFactor;
			mHighlight.width = Mathf.RoundToInt(w);
			mHighlight.height = Mathf.RoundToInt(h);

			bool placeAbove = (position == Position.Above);

			if (position == Position.Auto)
			{
				UICamera cam = UICamera.FindCameraForLayer(mSelection.layer);

				if (cam != null)
				{
					Vector3 viewPos = cam.cachedCamera.WorldToViewportPoint(pos);
					placeAbove = (viewPos.y < 0.5f);
				}
			}

			// If the list should be animated, let's animate it by expanding it
			if (isAnimated)
			{
				AnimateColor(mBackground);

				if (Time.timeScale == 0f || Time.timeScale >= 0.1f)
				{
					float bottom = y + labelHeight;
					Animate(mHighlight, placeAbove, bottom);
					for (int i = 0, imax = labels.Count; i < imax; ++i)
						Animate(labels[i], placeAbove, bottom);
					AnimateScale(mBackground, placeAbove, bottom);
				}
			}

			// If we need to place the popup list above the item, we need to reposition everything by the size of the list
			if (placeAbove)
			{
				min.y = max.y - bgPadding.y;
				max.y = min.y + mBackground.height;
				max.x = min.x + mBackground.width;
				t.localPosition = new Vector3(min.x, max.y - bgPadding.y, min.z);
			}
			else
			{
				max.y = min.y + bgPadding.y;
				min.y = max.y - mBackground.height;
				max.x = min.x + mBackground.width;
			}

			Transform pt = mPanel.cachedTransform.parent;

			if (pt != null)
			{
				min = mPanel.cachedTransform.TransformPoint(min);
				max = mPanel.cachedTransform.TransformPoint(max);
				min = pt.InverseTransformPoint(min);
				max = pt.InverseTransformPoint(max);
			}

			// Ensure that everything fits into the panel's visible range
			Vector3 offset = mPanel.hasClipping ? Vector3.zero : mPanel.CalculateConstrainOffset(min, max);
			pos = t.localPosition + offset;
			pos.x = Mathf.Round(pos.x);
			pos.y = Mathf.Round(pos.y);
			t.localPosition = pos;
			if(onShow.Count>0)
			{
				if (EventDelegate.IsValid(onShow))
				{
					EventDelegate.Execute(onShow);
				}
			}
		}
		else OnSelect(false);
	}
}