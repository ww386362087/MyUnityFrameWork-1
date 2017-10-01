using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
namespace Assets.GameEngineEditor
{
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
}

