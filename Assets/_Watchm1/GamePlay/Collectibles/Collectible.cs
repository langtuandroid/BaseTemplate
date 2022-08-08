using System;
using UnityEngine;

namespace _Watchm1.GamePlay.Collectibles
{
    public class Collectible : MonoBehaviour
    {
        [SerializeField] private BaseItem.BaseItem.ItemType type;
        [SerializeField] private int valueOfCollectible;
        [HideInInspector] public CollectibleItem collectibleItem;
        [SerializeField] public int amount;
        private void Start()
        {
            UpdateCollectibleItem();
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Player"))
            {
                //todo: collectibleManager ile ekleme yapılacak
                CollectibleManager.Instance.AddAmount(amount);
                Destroy(gameObject);
            }
        }
        private void UpdateCollectibleItem()
        {
            //todo: collectiblemanager üzerinden çekilecek
        }
    }
}
