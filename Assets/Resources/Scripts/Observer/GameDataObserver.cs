using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Amaya
{
    public static class GameDataObserver
    {
        private static Action<GameDataEvent> _listeners;

        public static void AddListener(Action<GameDataEvent> action)
        {
            _listeners += action;
        }

        public static void RemoveListener(Action<GameDataEvent> action)
        {
            _listeners -= action;
        }

        public static void ThrowEvent(GameDataEvent e)
        {
            _listeners.Invoke(e);
        }
    }
}
