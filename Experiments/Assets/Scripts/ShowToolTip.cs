using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEngine.UI;

public class ShowToolTip : MonoBehaviour
{
    public bool MouseOver = false;
    public string ToolTipMessage;

    // Use this for initialization
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
    }
    private void OnMouseEnter()
    {
        ToolTip.ShowToolTip_Static(ToolTipMessage);
    }

    private void OnMouseExit()
    {
        ToolTip.HideToolTip_Static();
    }
}