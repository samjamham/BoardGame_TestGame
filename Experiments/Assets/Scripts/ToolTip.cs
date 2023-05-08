using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ToolTip : MonoBehaviour {
	private static ToolTip instance;

	// Use this for initialization
	[SerializeField]
	public Text toolTipText;
	public RectTransform BackgroundRectTransform;
	public RectTransform MyRectTransform;
	public RectTransform CanvasRectTransform;

	private void Start()
	{
        ShowToolTip(" ");
        instance = this;
        HideToolTip();

    }

	void Update()
	{
		MyRectTransform.anchoredPosition = Input.mousePosition / CanvasRectTransform.localScale.x;
	}
	private void ShowToolTip(string toolTipString)
	{
		gameObject.SetActive(true);
		toolTipText.text = toolTipString;
		float textPaddingSize = 4f;
		Vector2 backgroundSize = new Vector2(toolTipText.preferredWidth + textPaddingSize * 2f, toolTipText.preferredHeight + textPaddingSize * 2f);
		BackgroundRectTransform.sizeDelta = backgroundSize;
	}

	private void HideToolTip()
	{
		gameObject.SetActive(false);
	}

	public static void ShowToolTip_Static(string toolTipString)
	{
		instance.ShowToolTip(toolTipString);
	}

    public static void HideToolTip_Static()
    { 
		instance.HideToolTip();
	}
}
