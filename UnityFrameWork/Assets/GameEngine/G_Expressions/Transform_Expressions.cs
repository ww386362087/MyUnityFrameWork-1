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
    public static T[] TryGetChildComponent<T>(this Transform t,bool includeInactive, string path = null) where T : MonoBehaviour
    {
        if (path == null || path.Length == 0)
        {
            return t.GetComponentsInChildren<T>(includeInactive);
        }
        return t.Find(path).GetComponentsInChildren<T>(includeInactive);
    }
    public static T AddCompontent<T>(this Transform t) where T : MonoBehaviour
    {
        return t.gameObject.AddComponent<T>();
    }
    public static void SetVisible(this Transform t, bool b)
    {
        t.transform.localScale = b ? Vector3.one : Vector3.zero;
    }
    public static void NodeInitialized(this Transform t)
    {
        t.transform.localPosition = Vector3.zero;
        t.transform.localRotation = Quaternion.Euler(Vector3.zero);
        t.transform.localScale = Vector3.one;
    }
}
