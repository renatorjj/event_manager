using System.Collections.Generic;
using System;
using UnityEngine;
using RRJJ.EventManager.Collections;

namespace RRJJ.EventManager
{
    public class EventManager
    {
        private Dictionary<Type, EventList> _events = new Dictionary<Type, EventList>();

        private static EventManager _eventManager = new EventManager();

        /// <summary>
        /// Add an eventHandler of the subscribers list of that specific event
        /// </summary>
        /// <param name="eventHandler"></param>
        /// <typeparam name="T">Event type</typeparam>
        /// <exception cref="ArgumentNullException">eventHandler is null</exception>
        public static void Subscribe<T>(Action<T> eventHandler)
        {
            _ = eventHandler ?? throw new ArgumentNullException(nameof(eventHandler));

            var type = typeof(T);
            if (!_eventManager._events.ContainsKey(type))
            {
                _eventManager._events.Add(type, new EventList());
            }

            _eventManager._events[type].Add(eventHandler);
        }

        /// <summary>
        /// Remove an eventHandler of the subscribers list of that specific event
        /// </summary>
        /// <param name="eventHandler">The callback that will be invoked when the event is fired</param>
        /// <typeparam name="T">Event type</typeparam>
        /// <exception cref="ArgumentNullException">eventHandler is null</exception>
        public static void Unsubscribe<T>(Action<T> eventHandler)
        {
            _ = eventHandler ?? throw new ArgumentNullException(nameof(eventHandler));

            var type = typeof(T);
            if (_eventManager._events.ContainsKey(type))
            {
                _eventManager._events[type].Remove(eventHandler);
            }
        }

        /// <summary>
        /// Dispatch an event to all subscribers of that specific event
        /// </summary>
        /// <param name="evt">Event instance</param>
        /// <typeparam name="T">Event type</typeparam>
        /// <exception cref="ArgumentNullException">evt is null</exception>
        public static void FireEvent<T>(T evt)
        {
            _ = evt ?? throw new ArgumentNullException(nameof(evt));

            var type = typeof(T);
            if (!_eventManager._events.ContainsKey(type))
            {
                Debug.LogWarning($"No one registers for event {nameof(T)}");
                return;
            }

            _eventManager._events[type].Fire(evt);
        }

        /// <summary>
        /// Unsubscribe all events
        /// </summary>
        public static void ResetAllEvents()
        {
            _eventManager = new EventManager();
        }
    }
}