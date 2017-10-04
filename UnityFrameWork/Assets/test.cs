using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Assets.GameEngine;
public delegate void TestDelegate();
public class test : MonoBehaviour
{
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            EventHandler.Instance.GameEvent.AddEvent("t", test1);
            EventHandler.Instance.GameEvent.AddEvent("t", test2);
        }
        if (Input.GetKeyDown(KeyCode.W))
        {
            EventHandler.Instance.GameEvent.RemoveEvent("t");
        }
    }
    void test1(object obj)
    {
        Debug.Log("test1 test1 test1");
    }
    void test2(object obj)
    {
        Debug.Log("test2 test2 test2");
    }
}
