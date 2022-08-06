using _Watchm1.Generators.MovementGenerator;
using _Watchm1.Generators.TagsGenerator;
using UnityEditor;
using UnityEngine;

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
        
    }
}
