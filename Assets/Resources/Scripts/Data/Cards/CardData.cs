using System.Collections;
using System.Collections.Generic;
using System.Resources;
using UnityEngine;
using UnityEngine.UI;

namespace Amaya
{
    public class CardData : MonoBehaviour
    {
        private CardBundleData _cardBundleData;
        [SerializeField] private Button _button;
        [SerializeField] private Image _sprite;

        public void SetData(CardBundleData data)
        {
            if (data == null)
                _cardBundleData = data;
        }

        private void Awake()
        {
            _button.onClick.AddListener(ButtonClick);
            _sprite.sprite = _cardBundleData.Sprite;
        }

        private void ButtonClick()
        {

        }

        public static CardData GetInstance(Transform parent) =>
            ResourceLoader.Instantiate<CardData>("UI/Prefabs/Card/Card", parent);
    }
}