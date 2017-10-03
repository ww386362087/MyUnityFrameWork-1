using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class String_Expressions
{
    public static bool IsNullOrEmpty(this string s)
    {
        return string.IsNullOrEmpty(s);
    }
    public static bool IsNonNullOrEmpty(this string s)
    {
        return !(string.IsNullOrEmpty(s));
    }
}
