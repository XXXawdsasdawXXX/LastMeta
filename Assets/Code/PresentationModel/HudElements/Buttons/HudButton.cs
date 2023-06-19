using System;
using UnityEngine;
using UnityEngine.UI;

namespace Code.PresentationModel.Buttons
{
    public  class HudButton: HudElement
    {
        [SerializeField] private UnityEngine.UI.Button _button;
        public event Action OnStartTap;

        protected void OnEnable()
        {
            _button.onClick.AddListener(InvokeEvent);
        }
        protected  void OnDisable()
        {
            _button.onClick.RemoveListener(InvokeEvent);
        }

        protected virtual void InvokeEvent()
        {
            OnStartTap?.Invoke();
        }
    }
}