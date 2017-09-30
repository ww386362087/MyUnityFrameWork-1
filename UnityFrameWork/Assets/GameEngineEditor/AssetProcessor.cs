using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

namespace Assets.GameEngineEditor
{
    public class AssetProcessor : UnityEditor.AssetPostprocessor
    {
        public static void OnPostprocessAllAssets(string[] importedAssets, string[] deletedAssets, string[] movedAssets, string[] movedFromAssetPaths)
        {
            foreach (var item in importedAssets)
            {
                Debug.Log("imported -> " + item);
            }
            foreach (var item in deletedAssets)
            {
                Debug.Log("deleted -> " + item);
            }
            foreach (var item in movedAssets)
            {
                AssetDatabase.ImportAsset(item);
                Debug.Log("moved -> " + item);
            }
            foreach (var item in movedFromAssetPaths)
            {
                AssetDatabase.ImportAsset(item);
                Debug.Log("moved -> " + item);
            }
        }
    }
}