using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class String_Expressions
{
    public static bool IsNullOrEmpty(this string s)
    {
        return s == null || s.Length == 0;
    }
}
