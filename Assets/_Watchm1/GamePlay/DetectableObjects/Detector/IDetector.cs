using _Watchm1.GamePlay.DetectableObjects.Detectable;
using UnityEngine;

namespace _Watchm1.GamePlay.DetectableObjects.Detector
{
    public interface IDetector
    {
        void ManageDetection(DetectableType type, IDetecableObject detecableObject);
    }
}
