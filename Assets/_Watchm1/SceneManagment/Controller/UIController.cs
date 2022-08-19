using System;
using _Watchm1.SceneManagment.Manager;
using UnityEngine;

namespace _Watchm1.SceneManagment.Controller
{
    public class UIController : MonoBehaviour
    {
        [SerializeField] private CanvasGroup UICanvas;
        [SerializeField] private CanvasGroup GameCanvas;
        
        private void Update()
        {
            if (LevelManager.Instance.currentState != LevelState.waitingOnfirstTouch) return;
            if (Input.touchCount > 0)
            {
                
            }
        }


        public void OnFirstTouch()
        {
            LevelManager.Instance.currentState = LevelState.onFirstTouchDone;
            UICanvas.gameObject.SetActive(false);
            GameCanvas.gameObject.SetActive(true);
        }
    }
}
