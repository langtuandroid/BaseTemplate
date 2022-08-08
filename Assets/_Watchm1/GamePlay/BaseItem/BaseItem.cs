using UnityEngine;
using UnityEngine.Serialization;

namespace _Watchm1.GamePlay.BaseItem
{
    
    public abstract class BaseItem : ScriptableObject
    {
        public GameObject objectPrefab;
        public enum ItemType
        {
            Collectible,
            Obstacle
        }
    }
}
