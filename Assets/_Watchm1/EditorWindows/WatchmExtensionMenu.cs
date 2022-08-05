using System;
using System.IO;
using _Watchm1.Generators.MovementGenerator;
using _Watchm1.Generators.TagsGenerator;
using _Watchm1.Helpers.Logger;
using _Watchm1.ScriptableObjects;
using UnityEditor;
using UnityEditor.VersionControl;
using Object = UnityEngine.Object;

namespace _Watchm1.EditorWindows
{
    public class WatchmExtensionMenu : UnityEditor.Editor
    {
        [MenuItem("WATCHMEXTENSION/GENERATOR/TAG GENERATION")]
        public static void OpenTagGenerationWindow()
        {
            TagGenerator.ShowWindow();
        }
        [MenuItem("WATCHMEXTENSION/GENERATOR/MOVEMENT CONTROLLER GENERATION")]
        public static void OpenMovementControllerGenerator()
        {
            MovementGenerator.ShowWindow();
        }
        [MenuItem("WATCHMEXTENSION/LevelSettings")]
        public static void EditLevelSettings()
        {
            var settings = LevelSettings.Current;

            if (settings == null)
            {
                settings = CreateInstance<LevelSettings>();
                CreateAssetIfNotExist(settings, "_Game/Settings");
            }

            EditorUtility.FocusProjectWindow();
            Selection.activeObject = settings;
        }

        private static void CreateAssetIfNotExist<T>(T obj, string folderName) where T : Object
        {
            try
            {
                var path = $"Assets/{folderName}";
                if (!Directory.Exists(path))
                {
                    Directory.CreateDirectory(path);
                }

                var file = $"{path}/{typeof(T).Name}.asset";
                WatchmLogger.Log($"Successfully created {file}");

                string assetPathAndName = AssetDatabase.GenerateUniqueAssetPath(file);
                AssetDatabase.CreateAsset(obj, assetPathAndName);
                AssetDatabase.SaveAssets();
                AssetDatabase.Refresh();
            }
            catch(Exception e)
            {
                WatchmLogger.Error(e);
                throw;
            }
        }
    }
}
