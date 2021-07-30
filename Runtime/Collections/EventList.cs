using System;

namespace RRJJ.EventManager.Collections
{
    public class EventList
    {
        private object _callback;

        public void Add<T>(Action<T> eventHandler)
        {
            if (_callback == null)
            {
                _callback = eventHandler;
                return;
            }
            
            var action = (Action<T>)_callback;
            action += eventHandler;
            _callback = action;
        }
        
        public void Remove<T>(Action<T> eventHandler) 
        {
            var action = (Action<T>)_callback;
            action -= eventHandler;
            _callback = action;
        }
        
        public void Fire<T>(T evt)
        {
            var action = (Action<T>)_callback;
            action.Invoke(evt);
        }
    }
}