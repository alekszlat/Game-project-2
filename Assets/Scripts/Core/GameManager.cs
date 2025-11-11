using UnityEngine;
using Game.Core.EventSystem;
using Game.Core.TimeSystem;

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
    public class ExampleDayEndHandler : IEventHandler<OnDayEndEvent>
    {
        public void Handle(OnDayEndEvent @event)
        {
            Debug.Log($"Day {@event.DayNumber} ended. Tasks: {@event.TasksCompleted}");
        }
    }

    /// <summary>
    /// Coordinates initialization of core systems and global event subscriptions.
    /// </summary>
   public class GameManager : MonoBehaviour
    {
        private static GameManager _instance;
        public static GameManager Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = FindFirstObjectByType<GameManager>();
                    if (_instance == null)
                    {
                        var go = new GameObject("GameManager");
                        _instance = go.AddComponent<GameManager>();
                    }
                }
                return _instance;
            }
            private set => _instance = value;
        }

        protected virtual void Awake()
        {
            if (_instance != null && _instance != this)
            {
                Destroy(gameObject);
                return;
            }

            _instance = this;
            DontDestroyOnLoad(gameObject);

            InitializeSystems();
        }

        private void InitializeSystems()
        {
            // Ensure they exist before subscribing or it bugs.
            _ = TimeManager.Instance;
            _ = EventManager.Instance;

            EventManager.Instance.Subscribe<OnDayEndEvent, ExampleDayEndHandler>();

            Debug.Log("Initialized core systems.");
        }

        private void OnDestroy()
        {
            if (_instance == this)
            {
                EventManager.Instance.Unsubscribe<OnDayEndEvent, ExampleDayEndHandler>();
                _instance = null;
            }
        }
    }
}