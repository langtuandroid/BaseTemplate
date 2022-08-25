using System;
using _Watchm1.GamePlay.Collectibles.Runner.Door;
using _Watchm1.GamePlay.DetectableObjects.Detectable;
using _Watchm1.GamePlay.DetectableObjects.Detector;
using _Watchm1.Helpers.Logger;
using UnityEngine;

namespace _Watchm1.GamePlay.DetectableObjects
{
    public class DetectorController : MonoBehaviour, IDetector
    {
        private void OnTriggerEnter(Collider other)
        {
            if (other.TryGetComponent(out IDetecableObject detectableObj))
            {
                ManageDetection(DetectableType.Door, detectableObj);
            }
        }
        public void ManageDetection(DetectableType type, IDetecableObject detecableObject)
        {
            detecableObject.DoLogic();
        }
        
    }

    
}
