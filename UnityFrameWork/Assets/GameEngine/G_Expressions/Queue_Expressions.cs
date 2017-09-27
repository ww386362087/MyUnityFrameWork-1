using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Queue_Expressions
{
    public static bool IsNullOrEmpty<T>(this Queue<T> queue)
    {
        return queue == null || queue.Count == 0;
    }
}
