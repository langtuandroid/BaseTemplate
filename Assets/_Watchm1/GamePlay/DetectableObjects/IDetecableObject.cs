 using _Watchm1.DetectableObjects.Detectable;

namespace _Watchm1.DetectableObjects
{
    public interface IDetecableObject
    {
        public DetectableType DetectableType { get; set; }
    }
}
