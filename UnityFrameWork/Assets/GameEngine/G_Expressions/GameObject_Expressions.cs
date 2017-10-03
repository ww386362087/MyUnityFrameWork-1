using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class GameObject_Expressions
{
    public static void SetActiveSafe(this GameObject go, bool b)
    {
        go.SetVisible(b);
        go.SetActive(b);
    }
    public static void SetVisible(this GameObject go, bool b)
    {
        go.transform.SetVisible(b);
    }
}
