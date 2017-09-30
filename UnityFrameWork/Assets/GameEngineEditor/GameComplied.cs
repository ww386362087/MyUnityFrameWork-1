using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
[InitializeOnLoad()]
public class GameComplied
{
    static GameComplied()
    {
        EditorApplication.update += delegate()
        {
            if (EditorApplication.isCompiling)
            {
                if (EditorApplication.isPlaying)
                {
                    EditorApplication.isPlaying = false;
                }
            }
        };
    }
}
