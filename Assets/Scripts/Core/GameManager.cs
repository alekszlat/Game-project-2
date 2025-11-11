using UnityEngine;
using Game.Core.EventSystem;

namespace Game.Core.GameSystem
{
    /**********************
    * Event Declarations  *
    ***********************/
    public class OnDayEndEvent : GameEvent
    {
        public int DayNumber { get; set; }
        public int TasksCompleted { get; set; }
    }

    /**********************
    *    Event Handlers   *
    ***********************/
    public class ExampleDayEndHandler : IEventHandler<DayEndEvent>
    {
        public void Handle(DayEndEvent @event)
        {
            Debug.Log($"Day {@event.DayNumber} ended. Tasks: {@event.TasksCompleted}");
        }
    }
    
    /**********************
    *    Game Manager     *
    ***********************/
    public class GameManager : MonoBehaviour
    {
        private void Start() {
            EventBus.Instance.Subscribe<OnDayEndEvent, ExampleDayEndHandler>();
        }

        private void OnDestroy() {
            EventBus.Instance.Unsubscribe<OnDayEndEvent, ExampleDayEndHandler>();
        }
    }
}