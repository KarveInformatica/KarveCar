using System;
using System.Collections.Generic;

namespace ProvidersModule
{
    public class EventManager : IEventManager
    {
        IList<IEventObserver> _observers = new List<IEventObserver>();
        public void notifyObserver(ISupplierPayload payload)
        {
            foreach (IEventObserver eo in _observers)
            {
                eo.incomingPayload(payload);
            }
        }

        public void registerObserver(IEventObserver obs)
        {
            _observers.Add(obs);
            
        }
    }
}