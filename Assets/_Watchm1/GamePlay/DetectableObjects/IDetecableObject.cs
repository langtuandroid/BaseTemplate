 using _Watchm1.GamePlay.DetectableObjects.Detectable;
 using UnityEngine;

 namespace _Watchm1.GamePlay.DetectableObjects
{
    public interface IDetecableObject
    {
        public DetectableType DetectableType { get; set; }
        public void DoLogic();

    }
}
