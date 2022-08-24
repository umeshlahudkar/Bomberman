using System;
using Bomberman.Global;

namespace Bomberman.EventSrvice
{
    public class EventService : GenericSingleton<EventService>
    {
        public event Action<string> OnGameOver;
        public event Action<string> OnGameWin;
        public event Action OnDestructableKilled;

        public void InvokeOnGameOverEvent(string info)
        {
            OnGameOver?.Invoke(info);
        }

        public void InvokeOnGameWinEvent(string info)
        {
            OnGameWin?.Invoke(info);
        }

        public void InvokeOnDestructableKilledEvent()
        {
            OnDestructableKilled?.Invoke();
        }
    }
}

