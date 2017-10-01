using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Int32_Expressions
{
    public static int ToInt(this string s)
    {
        return int.Parse(s);
    }
    public static int Convert2Int32(this object o)
    {
        return System.Convert.ToInt32(o);
    }
}
