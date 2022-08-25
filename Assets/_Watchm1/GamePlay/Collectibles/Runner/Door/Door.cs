using System;
using System.Collections.Generic;
using _Watchm1.GamePlay.DetectableObjects;
using _Watchm1.GamePlay.DetectableObjects.Detectable;
using _Watchm1.GamePlay.Movement.RunnerMovement;
using _Watchm1.Helpers.Logger;
using _Watchm1.SceneManagment.Loader;
using _Watchm1.SceneManagment.Manager;
using _Watchm1.SceneManagment.Settings;
using Sirenix.OdinInspector;
using Sirenix.Serialization;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Serialization;

namespace _Watchm1.GamePlay.Collectibles.Runner.Door
{
    public enum DoorType
    {
        Replicator,
        ModifierModel,
    }

    public enum ReplicatorType
    {
        multiplier,
        substract,
        increase,
        division,
    }
    public class Door : SerializedMonoBehaviour, IDetecableObject
    {
        [HideInInspector]public DetectableType DetectableType { get; set; }
        [OdinSerialize] private DoorType Type { get; set; }
        [OdinSerialize] [ShowIf("Type", DoorType.Replicator)]private ReplicatorType ReplicatorTypeType { get; set; }
        [OdinSerialize] [ShowIf("Type", DoorType.Replicator)] private int _replicationCount;
        [OdinSerialize] [ShowIf("Type", DoorType.Replicator)] private GameObject _parent;
        [OdinSerialize] [ShowIf("Type", DoorType.Replicator)] private GameObject _prefab;
        [OdinSerialize] [ShowIf("Type", DoorType.Replicator)] private GameObject _textObj;
        
        [OdinSerialize] [ShowIf("Type", DoorType.ModifierModel)] private List<GameObject> _models;
        private bool _touched = false;
        private TextMeshProUGUI _text;
        private void Start()
        {
            DetectableType = DetectableType.Door;
            _text = _textObj.gameObject.GetComponent<TextMeshProUGUI>();
            _text.text = _replicationCount.ToString();
        }
        private void Update()
        {
            if (!LevelManager.Instance.PlayModeActive())
            {
                return;
            }
        }
        private void HandleLogicOfReplicator()
        {
            if (_touched) return;
            switch (ReplicatorTypeType)
            {
                case ReplicatorType.increase:
                {
                    IncreaseObjects(_replicationCount);
                    break;
                }
                case ReplicatorType.multiplier:
                    //todo: in this case we need a list objects of wrappers (for counts)
                    break;
                case ReplicatorType.substract:
                    //todo: in this case we need a list objects of wrappers (for counts)
                    break;
                case ReplicatorType.division:
                    //todo: in this case we need a list objects of wrappers (for counts)
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }

            _touched = true;
        }
        private void HandleLogicOfModifier()
        {
            //todo: think of this logic
        }
        public void DoLogic()
        {
            switch (Type)
            {
                case DoorType.Replicator:
                    HandleLogicOfReplicator();
                    break;
                case DoorType.ModifierModel:
                    HandleLogicOfModifier();
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        private void IncreaseObjects(int number)
        {
            for (int i = 0; i < number; i++)
            {
                var obj= Instantiate(_prefab, transform.position + new Vector3(0,1,0), Quaternion.identity);
                //todo: adding a object for all wrappers and controlling them counts (List<GameObject>)
            }
        }

        private void SubstractionObject(int number)
        {
            for (int i = number; i > 0; i--)
            {
                // example Destroy(list[i].gameObject);
                //example list.remove(list[i]);
                //todo: adding a object for all wrappers and controlling them counts (List<GameObject>)
                
            }
        }
    }
    
    
}
