using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace Amaya
{
    public class Level : MonoBehaviour
    {
        [SerializeField] private Transform _grid;
        [SerializeField] private TextMeshProUGUI _targetTitle;
        private LevelBundleData _data;
        public LevelBundleData Data => _data;

        private void Start()
        {
            InstantiateCards();
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
                case GameDataEventId.CorrectAnswer:
                    Destroy(gameObject);
                    break;
            }
        }

        private void InstantiateCards()
        {
            CardCreator cardCreator = new CardCreator();

            foreach (var card in _data.Cards)
            {
                cardCreator.CreateSingle(card, _grid);
            }
        }

        public void Show() =>
            gameObject.SetActive(true);

        public void Hide() =>
            gameObject.SetActive(false);

        public void SetData(LevelBundleData data)
        {
            if (_data == null)
            {
                _data = data;
                _targetTitle.text = _targetTitle.text.Replace("%target%", _data.Target);
            }
        }

        public static Level GetInstance(Transform parent) =>
            ResourceLoader.Instantiate<Level>("UI/Prefabs/Level/Level", parent);
    }
}
