namespace Amaya
{
    public enum GameDataEventId
    {
        AnswerClick,
        CorrectAnswer,
        IncorrectAnswer,
        GameStart,
        LevelSwitch,
    }

    public class GameDataEvent
    {
        public GameDataEventId Id { get; set; }
    }

    public class GameStartEvent : GameDataEvent
    {
        public Level Level { get; set; }
    }

    public class LevelSwitchEvent : GameDataEvent
    {
        public Level Level { get; set; }
    }

    public class AnswerClickAction : GameDataEvent
    {
        public string Answer { get; set; }
    }
}