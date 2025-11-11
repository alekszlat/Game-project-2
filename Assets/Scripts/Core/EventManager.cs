using System;

///<summary>Handles event subscribe-unsubscribe-publish mechanism across the game. </summary>
///<remarks>
/// This EventManager utilizes the <b>Singleton</b> pattern to ensure global access
/// to the event mechanism and a single instance of the manager. 
/// It also uses the <b>Publish/Subscribe</b> pattern, implemented through generic class,
/// to ensure clean and scalable event bus implementation.
///</remarks>
/// Author: H. Hristov
/// Created: 11/10/2025
/// Updated: 11/10/2025
namespace Game.Core.EventSystem
{
    public abstract class GameEvent
    {
        public DateTime Timestamp { get; private set; }
        public string EventId { get; private set; }

        protected GameEvent()
        {
            Timestamp = DateTime.UtcNow;
            EventId = Guid.NewGuid().ToString();
        }
    }


    public interface IEventHandler<in T> where T : GameEvent
    {
        void Handle(T @event);
    }
    
}