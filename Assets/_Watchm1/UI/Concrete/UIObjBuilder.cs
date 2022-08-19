using System;
using _Watchm1.Config;
using _Watchm1.EditorWindows;
using Sirenix.OdinInspector;
using Sirenix.Serialization;
using UnityEngine;
using UnityEngine.UI;

namespace _Watchm1.UI.Concrete
{
   
    public class UIObjBuilder : SerializedMonoBehaviour, IUIBuilder<UISettings>
    {
        
        #region Fields
        public UISettings BuilderConfig { get; set; }
        [OdinSerialize]private UITypes _changeableType; 
        #endregion

        #region LifeCycle

        private void Awake()
        {
            Initialize();
            Build();
        }
        #endregion
        #region Methods
        private void Initialize()
        {
            BuilderConfig = UISettings.Current;
        }
        public void Build()
        {
            GetComponent<Image>().sprite = _changeableType switch
            {
                UITypes.Background => BuilderConfig.gameBackground,
                UITypes.Icon => BuilderConfig.icon,
                _ => GetComponent<Image>().sprite
            };
        }
        #endregion
    }
}
