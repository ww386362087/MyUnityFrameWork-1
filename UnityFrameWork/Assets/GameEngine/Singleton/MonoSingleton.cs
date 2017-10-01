using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonoSingleton<T> : MonoBehaviour where T : class,new()
{
    private static T instance = null;
    public static readonly object Lock = new object();
    public static T Instance
    {
        get
        {
            return instance;
        }
    }
    public void Awake()
    {
        lock (Lock)
        {
            instance = new T();
            OnInitialized();
        }
    }
    public virtual void OnInitialized()
    {

    }
    public void OnApplicationQuit()
    {
        instance = null;
        OnDestory();
    }
    public virtual void OnDestory()
    {

    }
}
