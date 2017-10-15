using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public static class List_Expressions
{
    public static bool IsNullOrEmpty<T>(this List<T> list)
    {
        return list == null || !list.Any();
    }

    public static bool IsNonNullOrEmpty<T>(this List<T> list)
    {
        return list != null && list.Any();
    }

    public static List<T> ToList<T>(this T[] array) where T : class
    {
        if (array == null || array.Length > 0)
        {
            return default(List<T>);
        }
        List<T> list = new List<T>();
        Array.ForEach(array, p => list.Add(p));
        return list;
    }
}