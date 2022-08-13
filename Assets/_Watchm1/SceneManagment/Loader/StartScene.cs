using System;
using _Watchm1.Config;
using _Watchm1.Helpers.Logger;
using _Watchm1.SceneManagment.Settings;
using UnityEditor;
using UnityEditor.SceneManagement;
using UnityEngine.SceneManagement;

namespace _Watchm1.SceneManagment.Loader
{
    [InitializeOnLoad]
    public static class StartScene 
    {
        static StartScene()
        {
            EditorApplication.playModeStateChanged += ChangePlayModeState;
            CheckScene();
           
        }

        private static void CheckScene()
        {
            var activeScene = EditorSceneManager.GetActiveScene();
            if (!activeScene.path.Contains("Assets/_Game/Scenes"))
            {
                EditorSceneManager.playModeStartScene = null;
            }

            var scenePath = $"Assets/_Game/Scenes/{DefaultScene.Initialize.ToString()}.unity";
            EditorSceneManager.playModeStartScene = AssetDatabase.LoadAssetAtPath<SceneAsset>(scenePath);
            WatchmLogger.Log("Active scene => "+activeScene.name);
        }
        private static void ChangePlayModeState(PlayModeStateChange state)
        {
            switch (state)
            {
                case PlayModeStateChange.ExitingEditMode:
                    CheckScene();
                    break;
            }
        }
    }
    
    
}
