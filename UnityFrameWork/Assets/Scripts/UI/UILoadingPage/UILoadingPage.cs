using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Assets.GameEngine;
public class UILoadingPage : AppBasePages
{
    public UILoadingPage()
        : base(UIType.Normal, UIMode.NeedBack, "UIPrefabs/UILoadingPage")
    {

    }
    public override void OnInitUI()
    {
        base.OnInitUI();
        Debug.Log("OnInitUI -> UILoadingPage");
    }
    public override void OnRefresh()
    {
        base.OnRefresh();
        Debug.Log("OnRefresh -> UILoadingPage");
    }
    public override void OnExit()
    {
        base.OnExit();
        Debug.Log("OnExit -> UILoadingPage");
    }
}
