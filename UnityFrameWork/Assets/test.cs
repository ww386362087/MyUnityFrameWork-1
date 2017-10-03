using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Assets.GameEngine;
public class test : MonoBehaviour
{
	void Update () {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            AppBasePages.ShowPage<UILoadingPage>();
        }
        if (Input.GetKeyDown(KeyCode.W))
        {
            AppBasePages.ClosePage<UILoadingPage>();
        }
	}
}
