using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Assets.GameEngine;
public class UILoginPage : AppBasePages
{
    public UILoginPage()
        : base(UIType.Normal, UIMode.NeedBack, "UIPrefabs/UILoginPage")
    {

    }
    public override void OnInitUI()
    {
        base.OnInitUI();
        Debug.Log("OnInitUI -> UILoginPage");
    }
    public override void OnRefresh()
    {
        base.OnRefresh();
        Debug.Log("OnRefresh -> UILoginPage");
    }
    public override void OnExit()
    {
        base.OnExit();
        Debug.Log("OnExit -> UILoginPage");
    }
}
