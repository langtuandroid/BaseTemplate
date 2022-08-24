using System;
using _Watchm1.InputManagment;
using _Watchm1.SceneManagment.Manager;
using _Watchm1.SceneManagment.Settings;
using UnityEngine;

namespace _Watchm1.GamePlay.Movement.RunnerMovement
{
    public class PlayerRotationController : MonoBehaviour
    {
        #region Fields

        private Transform _childModel;
        [SerializeField] private bool ignoreRotate;
        private float _rotationAngle;
        private float _rotateSpeed;
        [HideInInspector]
        public GameSettings Settings
        {
            get
            {
                if (GameSettings.Current != null)
                {
                    return GameSettings.Current;
                }
                else
                {
                    return null;
                }
            }
        }

        #endregion

        #region LifeCycle

        private void Start()
        {
            _childModel = transform.GetChild(0);
            _rotationAngle = Settings.playerRotateAngle;
            _rotateSpeed = Settings.playerRotateSpeed;
            Time.timeScale = 0.5f;
        }

        private void Update()
        {
            if (!LevelManager.Instance.PlayModeActive())
            {
                return;
            }

            if (!ignoreRotate)
            {
                HandlePlayerRotate();
            }
        }

        private void HandlePlayerRotate()
        {
            // parmak çekilirse önüne bak veya // parmağım basılıysa fakat hareket ettirmiyorsam önüne bak

            if (TouchManager.Instance.currentState == TouchState.TouchEnded || TouchManager.Instance.currentState == TouchState.TouchStationary || TouchManager.Instance.currentState == TouchState.NoInput)
            {
                _childModel.localRotation = Quaternion.Lerp(_childModel.localRotation,
                    Quaternion.Euler(0,0,0),(_rotateSpeed* Time.deltaTime));
            }

            if (TouchManager.Instance.currentState == TouchState.TouchMoved)
            {
                if (TouchManager.Instance.currentHorizontalState == HorizontalMoveState.Left)
                {
                    _childModel.localRotation = Quaternion.Lerp(_childModel.localRotation,
                        Quaternion.Euler(0,-_rotationAngle, 0), _rotateSpeed* Time.deltaTime);
                }

                if (TouchManager.Instance.currentHorizontalState == HorizontalMoveState.Right)
                {
                    _childModel.localRotation = Quaternion.Lerp(_childModel.localRotation,
                        Quaternion.Euler(0,_rotationAngle, 0), _rotateSpeed* Time.deltaTime);
                }
            }
        }

        #endregion
    }
}
