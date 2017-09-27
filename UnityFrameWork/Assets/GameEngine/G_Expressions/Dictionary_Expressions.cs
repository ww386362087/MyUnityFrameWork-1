using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Dictionary_Expressions
{
    public static bool IsNullOrEmpty<T1, T2>(this Dictionary<T1, T2> dictionary)
    {
        return dictionary == null || dictionary.Count == 0;
    }
    public static T TryGetValue<T, T1>(this Dictionary<T1, T> dictionary, T1 key)
    {
        T t = default(T);
        if (dictionary.ContainsKey(key))
        {
            if (dictionary.TryGetValue(key, out t))
            {
                return t;
            }
        }
        return t;
    }
    public static void AddOrSet<T, T1>(this Dictionary<T, T1> dictionary, T key, T1 value)
    {
        if (!dictionary.ContainsKey(key))
        {
            dictionary.Add(key, value);
        }
        dictionary[key] = value;
    }
}
