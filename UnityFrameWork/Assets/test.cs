using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class test : MonoBehaviour
{
	void Update () {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            TimerMgr.Instance.Sucribe(5f, 
                () => Debug.Log("start"))
                .OnUpdate(p => Debug.Log("11"+p.EscapleTime))
                .OnComplete(() => Debug.Log("OnComplete"));
        }
        if (Input.GetKeyDown(KeyCode.W))
        {
            TimerMgr.Instance.Sucribe(10f,
                () => Debug.Log("tt"))
                .OnUpdate(p => Debug.Log("22"+p.EscapleTime))
                .OnComplete(() => Debug.Log("222"));
        }
	}
}
