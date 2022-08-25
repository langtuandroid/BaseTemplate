using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using _Watchm1.Config;
using _Watchm1.EventSystem.Events;
using _Watchm1.Helpers.Logger;
using _Watchm1.SceneManagment.Manager;
using _Watchm1.SceneManagment.Settings;
using Sirenix.OdinInspector;
using Sirenix.Serialization;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace _Watchm1.SceneManagment.Loader
{
    public class SceneLoader : Helpers.Singleton.Singleton<SceneLoader>
    {
        [SerializeField] private SceneEvent onSceneLoaded;
        [SerializeField] private SceneEvent onSceneUnLoaded;
        [SerializeField] private List<DefaultScene> defaultSceneToLoad;

        public delegate void SceneLoaderEvent(float progress, bool isDone);

        public static Scene ActiveScene => SceneManager.GetActiveScene();
        public static Scene LastScene => SceneManager.GetSceneAt(SceneManager.sceneCount - 1);
        public static bool IsInitializeSceneLoaded => GetScene(DefaultScene.Initialize.ToString()).isLoaded;
        public static bool IsGameUISceneLoaded => GetScene(DefaultScene.GameUI.ToString()).isLoaded;
        private List<string> _defaultSceneNames = new();

        public void Start()
        {
            _defaultSceneNames = defaultSceneToLoad.Select(s => s.ToString()).ToList();
            StartCoroutine(InitScenes());
        }
        private void OnEnable()
        {
            SceneManager.sceneLoaded += OnSceneLoaded;
            SceneManager.sceneUnloaded += OnSceneUnloaded;
        }

        private void OnDisable()
        {
            SceneManager.sceneLoaded -= OnSceneLoaded;
            SceneManager.sceneUnloaded -= OnSceneUnloaded;
        }

        private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
        {
            onSceneLoaded.SafeInvoke(scene);
        }

        private void OnSceneUnloaded(Scene scene)
        {
            onSceneUnLoaded.SafeInvoke(scene);
        }
        private IEnumerator InitScenes()
        {
            foreach (var sceneName in _defaultSceneNames.Where(s => !ActiveScene.name.Equals(s)))
            {
                yield return LoadSceneRoutine(sceneName, null, LoadSceneMode.Additive, false);
            }

            var currentSceneName = LevelSettings.Current.allLevelSceneName[0];
            LoadSceneAsync(currentSceneName, null, LoadSceneMode.Additive, false);
            if (GetScene(currentSceneName).isLoaded)
            {
                SceneManager.SetActiveScene(SceneManager.GetSceneByName(currentSceneName));
            }

            LevelManager.Instance.currentState = LevelState.waitingOnfirstTouch;
        } public static void LoadSceneAsync(string sceneName, SceneLoaderEvent loadAsyncEvent = null, LoadSceneMode loadSceneMode = LoadSceneMode.Additive, bool allowSceneActivation = true)
        {
            if (GetScene(sceneName).isLoaded)
            {
                WatchmLogger.Warning($"{sceneName} is already loaded");
                return;
            }
            
            Instance.StartCoroutine(LoadSceneRoutine(sceneName, loadAsyncEvent, loadSceneMode, allowSceneActivation));
        }
        public static IEnumerator LoadSceneRoutine(string sceneName, SceneLoaderEvent loaderEvent = null, LoadSceneMode mode = LoadSceneMode.Additive, bool allowSceneActivation = true)
        {
            if (GetScene(sceneName).isLoaded)
            {
                WatchmLogger.Warning($"{sceneName}  already loaded");
                yield break;
            }

            if (!GetScene(sceneName).isLoaded)
            {
                WatchmLogger.Warning($"{sceneName} not loaded");
            }

            var op = SceneManager.LoadSceneAsync(sceneName, mode);
            op.allowSceneActivation = allowSceneActivation;

            while (!op.isDone)
            {
                loaderEvent?.Invoke(op.progress, false);
                if (op.progress >= 0.9f)
                {
                    loaderEvent?.Invoke(op.progress, true);
                    op.allowSceneActivation = true;
                }

                yield return null;
            }
        }
        public static void UnloadSceneAsync(string sceneName)
        {
            if (!GetScene(sceneName).isLoaded)
            {
                WatchmLogger.Warning($"{sceneName} is not loaded to be unload");
                return;
            }
            Instance.StartCoroutine(UnloadSceneRoutine(sceneName));
        }
        public static Scene GetScene(string sceneName)
        {
            return SceneManager.GetSceneByName(sceneName);
        }
        public static IEnumerator UnloadSceneRoutine(string sceneName)
        {
            if (!GetScene(sceneName).isLoaded)
            {
                WatchmLogger.Warning($"{sceneName} is not loaded to be unload");
                yield break;
            }
            
            var op = SceneManager.UnloadSceneAsync(sceneName);

            while (op is { isDone: false })
            {
                yield return null;
            }
        }
    }
}
