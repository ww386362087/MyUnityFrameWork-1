using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class List_Expressions
{
    public static bool IsNullOrEmpty<T>(this List<T> list)
    {
        return list == null || list.Count == 0;
    }
    public static bool IsNonNullOrEmpty<T>(this List<T> list)
    {
        return list != null && list.Count > 0;
    }
}
