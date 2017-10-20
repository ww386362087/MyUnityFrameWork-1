using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonoSingleton<T> : MonoBehaviour where T : class, new()
{
    protected Transform CacheTransform = null;
    protected GameObject CacheGameObject = null;
    private static T instance = null;
    public static readonly object Lock = new object();
    public static T Instance { get { return instance; } }

    public void Awake()
    {
        instance = this as T;
        OnInitialized();
    }

    public virtual void OnInitialized()
    {
        CacheGameObject = this.gameObject;
        CacheTransform = this.transform;
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