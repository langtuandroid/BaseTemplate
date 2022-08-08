using _Watchm1.GamePlay.BaseItem;
using UnityEngine;

namespace _Watchm1.GamePlay.Collectibles
{
    [CreateAssetMenu(fileName = "New Collectible Item", menuName = "Wathcm1Extension/Collectible/Item")]
    public class CollectibleItem : BaseItem.BaseItem
    {
        public ItemType type = ItemType.Collectible;
    }

    
}
