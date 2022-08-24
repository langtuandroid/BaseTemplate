using System;
using _Watchm1.SceneManagment.Manager;
using _Watchm1.SceneManagment.Settings;
using UnityEngine;

namespace _Watchm1.GamePlay.Movement.RunnerMovement
{
    public class PlayerMovement : MonoBehaviour
    {
        
        #region Fields
        public GameSettings Settings
        {
            get
            {
                return GameSettings.Current != null ? GameSettings.Current : null;
            }
        }

        private Transform _self;
        #endregion
        #region LifeCycle

        private void Start()
        {
            _self = GetComponent<Transform>();
        }

        private void Update()
        {
            if (!LevelManager.Instance.PlayModeActive())
            {
                return;
            }
            MoveJustForward();
        }

        #endregion
        #region Methods

        private void MoveJustForward()
        {
            _self.Translate(_self.forward * (Settings.playerForwardSpeed * Time.deltaTime), Space.World);
        }
        #endregion

        
    }
}
