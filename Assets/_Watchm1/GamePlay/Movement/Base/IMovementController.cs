using UnityEngine;

namespace _Watchm1.GamePlay.Movement.Base
{
    public enum MovementType
    {
        IdleMovement,
        RunnerMovement,
        Other,
    }
    public interface IMovementController
    {
        public MovementType CurrentType { get; set; }
        public float Speed { get; set; }
        void Initialize();
        void Movement(float horizontal, float vertical);
    }
}
