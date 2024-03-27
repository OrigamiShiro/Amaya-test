using UnityEngine;
using UnityEngine.UI;

namespace Amaya
{
    public class CardData : MonoBehaviour
    {
        private CardBundleData _data;
        [SerializeField] private Button _button;
        [SerializeField] private Image _sprite;

        private void Awake()
        {
            _button.onClick.AddListener(ButtonClick);
        }

        private void OnEnable()
        {
            GameDataObserver.AddListener(OnGameDataEvent);
        }

        private void OnDisable()
        {
            GameDataObserver.RemoveListener(OnGameDataEvent);
        }

        private void OnGameDataEvent(GameDataEvent e)
        {
            switch (e.Id)
            {
                case GameDataEventId.IncorrectAnswer:
                    Shake();
                    break;
            }
        }

        private void Shake()
        {
            VFX.Shake(transform);
        }

        private void ButtonClick()
        {
            var e = new AnswerClickAction
            {
                Id = GameDataEventId.AnswerClick,
                Answer = _data.Key,
            };

            GameDataObserver.ThrowEvent(e);
        }

        private void Customize()
        {
            _button.onClick.AddListener(ButtonClick);
            _sprite.sprite = _data?.Sprite;
        }

        public void SetData(CardBundleData data)
        {
            if (_data == null)
            {
                _data = data;
                Customize();
            }
        }

        public static CardData GetInstance(Transform parent) =>
            ResourceLoader.Instantiate<CardData>("UI/Prefabs/Card/Card", parent);
    }
}