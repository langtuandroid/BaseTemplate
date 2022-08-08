using _Watchm1.DetectableObjects.Detectable;

namespace _Watchm1.DetectableObjects.Detector
{
    public interface IDetector
    {
        void ManageDetection(DetectableType type);
    }
}
