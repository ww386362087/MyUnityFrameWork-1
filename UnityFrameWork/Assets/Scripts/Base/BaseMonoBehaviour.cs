using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseMonoBehaviour : MonoBehaviour ,IOnInitUI
{
    public GameObject CacheGameObject = null;
    public Transform CacheTransform = null;
    
    public void Awake()
    {
        CacheGameObject = this.gameObject;
        CacheTransform = this.transform;
        OnInitUI();
    }

    public virtual void OnInitUI()
    {

    }
}
