using System;
using _Watchm1.Helpers.Logger;
using UnityEngine;

namespace _Watchm1.GamePlay.Movement.IdleMovement
{
    public class AnimController : MonoBehaviour, IAnimHandler
    {
        [SerializeField] private Animator animator;
        private float _verticalMovement;
        private static readonly int CanPlay = Animator.StringToHash("CanPlay");

        private void Start()
        {
        }

        private void Update()
        {
            HandleAnimation(animator);
        }

        public void HandleAnimation(Animator animator)
        {
            animator.SetBool(CanPlay, JoystickController.CanPlay);
        }
    }
}
