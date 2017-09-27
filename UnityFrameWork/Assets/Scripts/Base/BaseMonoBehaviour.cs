using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseMonoBehaviour : MonoBehaviour 
{
    public GameObject CacheGameObject = null;
    public Transform CacheTransform = null;
    
    public void Awake()
    {
        CacheGameObject = this.gameObject;
        CacheTransform = this.transform;
        OnAwake();
    }
    
    public virtual void OnAwake()
    {

    }
}
