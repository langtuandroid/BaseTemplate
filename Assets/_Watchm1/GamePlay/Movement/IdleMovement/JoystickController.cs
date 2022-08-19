using System;
using _Watchm1.GamePlay.Movement.Base;
using _Watchm1.Helpers.Logger;
using _Watchm1.SceneManagment.Manager;
using UnityEngine;
using UnityEngine.Serialization;

namespace _Watchm1.GamePlay.Movement.IdleMovement
{
    public class JoystickController : MonoBehaviour, IMovementController
    {
        public MovementType CurrentType { get; set; }
        [SerializeField] public float Speed { get; set; }
        [SerializeField] private float speed;
        [FormerlySerializedAs("TurnSpeed")] [SerializeField] private float turnSpeed;
        [FormerlySerializedAs("DynamicJoystick")] [SerializeField]public DynamicJoystick dynamicJoystick;
        public static bool CanPlay;
        private float _horizontal;
        private float _vertical;
        private Vector3 _addedPosition;
        private Vector3 _direction;
        public void Initialize()
        {
            CurrentType = MovementType.IdleMovement;
            Speed = speed;
            dynamicJoystick = FindObjectOfType<DynamicJoystick>();
        }

        private void Start()
        {
            Initialize();
        }

        private void FixedUpdate()
        {
            if (LevelManager.Instance.currentState is LevelState.waitingOnfirstTouch or LevelState.Fail) return;
            //todo: ilk tıklama eventi yayınlanma kontrolünü ekle
            if (Input.touchCount > 0)
            {
                Movement(dynamicJoystick.Horizontal, dynamicJoystick.Vertical);
                CanPlay = true;
            }
            else
            {
                CanPlay = false;
            }
        }

        public void Movement(float horizontal, float vertical)
        {
            _horizontal = horizontal;
            _vertical = vertical;
            _addedPosition = new Vector3(_horizontal * speed *Time.deltaTime,0, vertical * speed*Time.deltaTime);
            transform.position += _addedPosition;
            _direction = Vector3.forward * _vertical + Vector3.right * _horizontal;
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(_direction), turnSpeed * Time.deltaTime );
        }
    }
}
