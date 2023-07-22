using System;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.UI;

namespace Code.PresentationModel
{
    public class HpBar : MonoBehaviour
    {
        [SerializeField] protected Image _value;
        protected float _currentValue;

        public void SetValue(float current, float max)
        {
            _currentValue = current / max;
            _value.fillAmount = _currentValue;
        }
    }
}