using UnityEngine;

namespace Amaya
{
    public class AnswerComparer : MonoBehaviour
    {
        private Level _level;

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
                case GameDataEventId.AnswerClick:
                    var answerAction = e as AnswerClickAction;
                    var newEvent = new GameDataEvent
                    {
                        Id = _level.Data.Target == answerAction.Answer 
                        ? GameDataEventId.CorrectAnswer 
                        : GameDataEventId.IncorrectAnswer,
                    };
                  
                    GameDataObserver.ThrowEvent(newEvent);
                    break;
                case GameDataEventId.GameStart:
                    _level = (e as GameStartEvent).Level;
                    break;
                case GameDataEventId.LevelSwitch:

                    _level = (e as LevelSwitchEvent).Level;
                    break;
                default:
                    break;
            }
        }
    }
}
