using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class CSharp_Expressions
{
    public static bool IsNull(this object o)
    {
        return o == null;
    }

    public static bool IsNonNull(this object o)
    {
        return o != null;
    }
}