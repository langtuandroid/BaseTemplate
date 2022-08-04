using _Watchm1.Helpers.Logger;
using UnityEditor;
using UnityEngine;

namespace _Watchm1.Generators.MovementGenerator
{
    public class MovementGenerator : EditorWindow
    {
      
        public static void ShowWindow()
        {
            var movementGenerator = (MovementGenerator)EditorWindow.GetWindow(typeof(MovementGenerator));
            movementGenerator.Show();
            WatchmLogger.Log("movement controller generator opened");
        }
        private void OnDestroy()
        {
            WatchmLogger.Warning("movement controller generator closed");
        }

    }
}
