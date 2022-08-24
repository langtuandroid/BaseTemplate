using System;
using _Watchm1.InputManagment;
using _Watchm1.SceneManagment.Manager;
using _Watchm1.SceneManagment.Settings;
using DG.Tweening;
using UnityEngine;

namespace _Watchm1.GamePlay.Movement.RunnerMovement
{
    public class HorizontalMovementController : MonoBehaviour
    {
        #region Fields
        public GameSettings Settings
        {
            get
            {
                if (GameSettings.Current != null)
                {
                    return GameSettings.Current;
                }

                return null;
            }
        }
        
        private Transform _self;
        private float _restrictedValue;
        private float _horizontalSpeed;
        #endregion

        #region LifeCycle

        private void Start()
        {
            _restrictedValue = Settings.restrictedDistance;
            _horizontalSpeed = Settings.playerHorizontalSpeed;
            _self = GetComponent<Transform>();
        }

        private void Update()
        {
            if (!LevelManager.Instance.PlayModeActive())
            {
                return;
            }
            HorizontalMovement();
        }
        
        #endregion

        #region Methods

        private void HorizontalMovement()
        {
            if (TouchManager.Instance.currentHorizontalState == HorizontalMoveState.Left)
            {
                if (_self.localPosition.x >= -1 * _restrictedValue)
                {
                    _self.Translate(_self.right * (Time.deltaTime * -1 * _horizontalSpeed), GetComponentInParent<Transform>());
                }
            }

            if (TouchManager.Instance.currentHorizontalState == HorizontalMoveState.Right)
            {
                if (_self.localPosition.x <= _restrictedValue)
                {
                    _self.Translate(_self.right * (Time.deltaTime * _horizontalSpeed), GetComponentInParent<Transform>());
                }
            }
        }
        

        #endregion
    }
}
