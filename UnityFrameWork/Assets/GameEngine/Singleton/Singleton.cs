using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Singleton<T> where T : class,new()
{
    private static T instance = null;
    private static readonly object Lock =new object();
    private Singleton()
    {
        OnInitialized();
    }
    public static T Instance
    {
        get
        {
            lock (Lock)
            {
                if (instance == null)
                {
                    instance = new T();
                }
                return instance;
            }
        }
    }
    protected virtual void OnInitialized()
    {

    }
}
