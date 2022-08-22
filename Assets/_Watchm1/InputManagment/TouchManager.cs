using System;
using _Watchm1.Helpers.Singleton;
using _Watchm1.SceneManagment.Manager;
using _Watchm1.SceneManagment.Settings;
using Sirenix.Serialization;
using UnityEngine;

namespace _Watchm1.InputManagment
{
    public enum TouchState
    {
        NoInput,
        TouchBegan,
        TouchMoved,
        TouchEnded,
        TouchStationary,
    }

    public enum HorizontalMoveState
    {
        Left,
        Right,
        Forward,
    }
    public class TouchManager : Singleton<TouchManager>
    {
        public TouchState currentState;
        public HorizontalMoveState currentHorizontalState;
        public float LastDeltaPos { get; private set; }
        private void Start()
        {
            currentState = TouchState.NoInput;
            currentHorizontalState = HorizontalMoveState.Forward;
        }

        private void Update()
        {
            if (LevelManager.Instance.currentState == LevelState.Fail ||
                LevelManager.Instance.currentState == LevelState.loading ||
                LevelManager.Instance.currentState == LevelState.Finished
                || LevelManager.Instance.currentState == LevelState.Success ||
                LevelManager.Instance.currentState == LevelState.waitingOnfirstTouch)
            {
                return;
            }
            HandleInput();
        }
        private void HandleInput()
        {
            if (Input.touchCount <= 0)
            {
                currentState = TouchState.NoInput;
                currentHorizontalState = HorizontalMoveState.Forward;
                return;
            };
            var touch = Input.GetTouch(0);
            if (touch.phase == TouchPhase.Began)
            {
                LastDeltaPos = touch.deltaPosition.x;
                currentState = TouchState.TouchBegan;
            }
            if (touch.phase == TouchPhase.Canceled)
            {
                currentState = TouchState.NoInput;
            }
            if (touch.phase == TouchPhase.Ended)
            {
                currentState = TouchState.TouchEnded;
            }
            if (touch.phase == TouchPhase.Moved)
            {
                if (LastDeltaPos - touch.deltaPosition.x < 0)
                {
                    currentHorizontalState = HorizontalMoveState.Left;
                }

                if (LastDeltaPos - touch.deltaPosition.x > 0)
                {
                    currentHorizontalState = HorizontalMoveState.Right;
                }
                currentState = TouchState.TouchMoved;
            }
            if (touch.phase == TouchPhase.Stationary)
            {
                currentState = TouchState.TouchStationary;
                if (Math.Abs(LastDeltaPos - touch.deltaPosition.x) < 0.1f)
                {
                    currentHorizontalState = HorizontalMoveState.Forward;
                }
            }
        }
    }
}
