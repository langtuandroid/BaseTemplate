using System;
using System.IO;
using _Watchm1.Config;
using _Watchm1.Helpers.Logger;
using UnityEngine;
using Sirenix.OdinInspector;

namespace _Watchm1.ScriptableObjects
{
    [System.Serializable]
    public enum GameType
    {
        Other,
        Idle,
        Runner
    } 
    [CreateAssetMenu(fileName = "LevelSettings", menuName = "WATCHMEXTENSION/LevelSettings")]
    public class LevelSettings : BaseSettings<LevelSettings>
    {
        #region Level Setters
        [SerializeField] public int totalLevelCount = -1;
        [SerializeField] private string orderKey = "level_orders";
        [SerializeField, OnValueChanged("OnSceneFolderTypeChanged")] public GameType gameType = GameType.Runner;

        [SerializeField, ShowIf("gameType", GameType.Idle)] private string idleFolder = "Assets/_Game/Scenes/Idle";
        [SerializeField, ShowIf("gameType", GameType.Other)] private string otherFolder = "Assets/_Game/Scenes/Other";
        [SerializeField, ShowIf("gameType", GameType.Runner)] private string runnerFolder = "Assets/_Game/Scenes/Runner";
        
        [ShowInInspector, ReadOnly] private string _levelScenesFolder = $"Assets{Path.DirectorySeparatorChar}_Game{Path.DirectorySeparatorChar}Scenes{Path.DirectorySeparatorChar}";
        #if UNITY_EDITOR
        [SerializeField] public int forceLevel = -1;
        [SerializeField] public bool repeatForceLevel;
        #endif
        #endregion
        
        #region Methods

        private void OnSceneFolderTypeChanged()
        {
            WatchmLogger.Log("Scene Folder changed");
            CheckSceneFolder();
        }

        private void CheckSceneFolder()
        {
            _levelScenesFolder = gameType switch
            {
                GameType.Idle => idleFolder,
                GameType.Other => otherFolder,
                GameType.Runner => runnerFolder,
                _ => _levelScenesFolder
            };
        }
        #endregion


    }

    
}
