using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Transform_Expressions
{
    public static T TryGetComponent<T>(this Transform t, string path = null) where T : MonoBehaviour
    {
        if (path == null || path.Length == 0)
        {
            return t.GetComponent<T>();
        }
        return t.Find(path).GetComponent<T>();
    }
    public static T[] TryGetChildComponent<T>(this Transform t, string path = null) where T : MonoBehaviour
    {
        if (path == null || path.Length == 0)
        {
            return t.GetComponentsInChildren<T>();
        }
        return t.Find(path).GetComponentsInChildren<T>();
    }
    public static T AddCompontent<T>(this Transform t) where T : MonoBehaviour
    {
        return t.gameObject.AddComponent<T>();
    }
}
