using System;
using _Watchm1.Helpers.Effects.Abstract;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Serialization;

namespace _Watchm1.UI.Concrete
{
    
    public class UIFadeEffect : MonoBehaviour, IEffecter<UIFadeEffect>
    {
        #region Fields
        public EffectType EffectType { get; set; }
        [SerializeField] private float firstAlphaValue;
        [SerializeField] private float secondAlphaValue;
        [SerializeField] private GameObject uiEffectiableObj;
        private CanvasGroup _uiobj; 
        private bool _fadeIn;
        private bool _fadeOut;        
        #endregion
        #region LifeCycle

        private void Start()
        {
            _fadeIn = false;
            _fadeOut = true;
            _uiobj = uiEffectiableObj.GetComponent <CanvasGroup>();
        }

        private void Update()
        {
            DoEffect();
        }

        #endregion
        
        #region Methods


        public void DoEffect()
        {
            if (_fadeIn)
            {
                if (_uiobj.alpha < 1)
                {
                    _uiobj.alpha += Time.deltaTime;
                    if (_uiobj.alpha >= 1)
                    {
                        _fadeIn = false;
                        _fadeOut = true;
                    }
                }
            }

            if (_fadeOut)
            {
                if (_uiobj.alpha >= 0)
                {
                    _uiobj.alpha -= Time.deltaTime;
                    if (_uiobj.alpha == 0)
                    {
                        _fadeOut = false;
                        _fadeIn = true;
                    }
                }
            }
        }
        #endregion
        
    }
}
