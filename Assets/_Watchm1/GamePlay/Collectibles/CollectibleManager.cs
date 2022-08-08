using System.Collections.Generic;
using _Watchm1.Economy;
using _Watchm1.EventSystem.Events;
using _Watchm1.Helpers.Singleton;
using UnityEngine;
using UnityEngine.Serialization;

namespace _Watchm1.GamePlay.Collectibles
{
    public class CollectibleManager : Singleton<CollectibleManager>
    {
        public List<CollectibleItem> allCollectibleItems;
        [SerializeField] internal VoidEvent onCurrenyChange;

        public void AddAmount(int value)
        {
            EconomyManager.Instance.SetToPrefsEconomy(value);
            onCurrenyChange.InvokeEvent();
        }
    }
}
