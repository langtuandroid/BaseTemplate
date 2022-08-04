using System;
using _Watchm1.Helpers.Logger;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

namespace _Watchm1.Generators.TagsGenerator
{
    public class TagGenerator : EditorWindow
    {
        public static void ShowWindow()
        {
            var tagGenerator = (TagGenerator)EditorWindow.GetWindow(typeof(TagGenerator));
            tagGenerator.Show();
            WatchmLogger.Log("Tag generator opened");
        }

        private void OnGUI()
        {
        }

        private void OnDestroy()
        {
            WatchmLogger.Warning("Tag generator closed");
        }
    }
}
