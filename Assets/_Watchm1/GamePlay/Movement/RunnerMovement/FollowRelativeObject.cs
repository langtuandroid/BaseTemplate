using System;
using _Watchm1.SceneManagment.Manager;
using UnityEngine;
using UnityEngine.Serialization;

namespace _Watchm1.GamePlay.Movement.RunnerMovement
{
    public class FollowRelativeObject : MonoBehaviour
    {
        #region Fields
        [SerializeField] public GameObject relativeObject;
        [SerializeField] private bool ignoreHorizontalMovement;
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
            FollowRelative();
        }

        #endregion

        #region Methods

        private void FollowRelative()
        {
            if (!ignoreHorizontalMovement)
            {
                var localPosition = _self.localPosition;
                localPosition = new Vector3(relativeObject.transform.localPosition.x, localPosition.y,
                    localPosition.z);
                _self.localPosition = localPosition;
            }
        }
        

        #endregion
    }
}
