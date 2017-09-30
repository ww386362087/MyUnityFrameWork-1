using UnityEngine;
using UnityEditor;
using System;

namespace Assets.GameEngineEditor
{
    [InitializeOnLoad()]
    public class ScriptsComplied
    {
        static ScriptsComplied()
        {
            EditorApplication.update += delegate ()
            {
                if (EditorApplication.isCompiling)
                {
                    if (EditorApplication.isPlaying)
                    {
                        Debug.Log("Compiled...");
                        EditorApplication.isPlaying = false;
                    }
                }
            };
        }
    }
}