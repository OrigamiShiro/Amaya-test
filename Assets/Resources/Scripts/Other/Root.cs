using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Amaya
{
    public class Root : MonoBehaviour
    {
        private List<Level> _levels = new List<Level>();
        private Level _activeLevel;
        private int _activeLevelIndex = 0;

        [SerializeField] private Transform levelContent;

        private void Awake()
        {
            LevelCreator levelCreator = new LevelCreator();

            _levels = levelCreator.CreateAll(levelContent);
            _activeLevel = _levels.First();
            _activeLevel.Show();

            GameDataObserver.ThrowEvent(new GameStartEvent
            {
                Id = GameDataEventId.GameStart,
                Level = _activeLevel,
            });
        }

        private void SwitchLevel()
        {
            if (_activeLevelIndex >= _levels.Count)
                return;

            _activeLevel = _levels[++_activeLevelIndex];
            _activeLevel.Show();

            GameDataObserver.ThrowEvent(new LevelSwitchEvent
            {
                Id = GameDataEventId.LevelSwitch,
                Level = _activeLevel,
            });
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
                    Destroy(_activeLevel.gameObject);
                    SwitchLevel();
                    break;
            }
        }
    }
}
