using System;
using System.Collections.Generic;
using _Watchm1.GamePlay.DetectableObjects;
using _Watchm1.GamePlay.DetectableObjects.Detectable;
using _Watchm1.GamePlay.Movement.RunnerMovement;
using _Watchm1.Helpers.Logger;
using _Watchm1.SceneManagment.Manager;
using _Watchm1.SceneManagment.Settings;
using Sirenix.OdinInspector;
using Sirenix.Serialization;
using TMPro;
using UnityEngine;
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
            switch (ReplicatorTypeType)
            {
                case ReplicatorType.increase:
                {
                    WatchmLogger.Log(_replicationCount);
                    for (int i = 0; i < _replicationCount; i++)
                    {
                        WatchmLogger.Log("içerde");
                        var obj= Instantiate(_prefab, _parent.transform.position, Quaternion.identity);
                        obj.transform.parent = _parent.transform;
                        obj.GetComponent<FollowRelativeObject>().relativeObject =
                            FindObjectOfType<HorizontalMovementController>().gameObject;
                    }
                    
                    break;
                }
                case ReplicatorType.multiplier:
                    break;
                case ReplicatorType.substract:
                    break;
                case ReplicatorType.division:
                    break;
            }
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
            }
        }
    }
    
    
}
