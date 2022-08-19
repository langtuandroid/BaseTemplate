using System;
using _Watchm1.EventSystem.Events;
using _Watchm1.Helpers.Logger;
using _Watchm1.SceneManagment.Manager;
using UnityEngine;
using UnityEngine.Serialization;

namespace _Watchm1.SceneManagment.Controller
{
    public class UIController : MonoBehaviour
    {
        [FormerlySerializedAs("UICanvas")] [SerializeField] private CanvasGroup uiCanvas;
        [FormerlySerializedAs("GameCanvas")] [SerializeField] private CanvasGroup gameCanvas;
        [SerializeField] private VoidEvent onFirstTouch;
        private void Update()
        {
            if (LevelManager.Instance.currentState != LevelState.waitingOnfirstTouch) return;
            if (Input.touchCount > 0)
            {
                Debug.Log("VAR");
                onFirstTouch.InvokeEvent();
            }
        }
        
        public void OnFirstTouch()
        {
            WatchmLogger.Warning("The game has Started!");
            LevelManager.Instance.currentState = LevelState.onFirstTouchDone;
            uiCanvas.gameObject.SetActive(false);
            gameCanvas.gameObject.SetActive(true);
        }
    }
}
