using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using KarveCommon.Services;

namespace KarveCommon.Services
{
    public class EventManager : IEventManager
    {

        IList<IEventObserver> _observers = new List<IEventObserver>();
        // This are events for the each subsystem, module wide.
        IDictionary<string, IList<IEventObserver>> _subsystemObserver = new Dictionary<string, IList<IEventObserver>>();
        IDictionary<string, IList<IEventObserver>> _notificationDisabled = new Dictionary<string, IList<IEventObserver>>();
        // This are events that notify the toolbar. Each view module can notify the toolbar
        IList<IEventObserver> _toolBar = new List<IEventObserver>();
        // This are direct events, each view module has a mailbox for receiving messages.
        private IDictionary<string, MailBoxMessageHandler> _mailBox = new ConcurrentDictionary<string, MailBoxMessageHandler>();

        public void SendMessage(string viewModuleId, DataPayLoad payLoad)
        {
            MailBoxMessageHandler messageHandler = _mailBox[viewModuleId];
            messageHandler?.Invoke(payLoad);
        }
        private void notifyObserver(DataPayLoad payload, IList<IEventObserver> eoList)
        {
            foreach (IEventObserver eo in eoList)
            {
                eo.incomingPayload(payload);
            }
        }
        public void notifyObserver(DataPayLoad payload)
        {
            notifyObserver(payload, _observers);
        }
        public void notifyObserverSubsystem(string v, DataPayLoad dataPayload)
        {
            if (_subsystemObserver.ContainsKey(v))
            {
                IList<IEventObserver> value = null;
                IList<IEventObserver> disabledItemList = null;
                if (_subsystemObserver.TryGetValue(v, out value))
                {
                    // ok we get the disabled
                    _notificationDisabled.TryGetValue(v, out disabledItemList);
                    if ((disabledItemList == null))
                    {
                        notifyObserver(dataPayload, value);
                    }
                    else
                    {
                        // the item are not disabled.
                        foreach (IEventObserver eo in value)
                        {
                            if (!disabledItemList.Contains(eo))
                            {
                                eo.incomingPayload(dataPayload);
                            }
                        }
                    }

                }
            }
        }

        public void NotifyToolBar(DataPayLoad payload)
        {
            notifyObserver(payload, _toolBar);
        }

        public void registerObserver(IEventObserver obs)
        {
            _observers.Add(obs);
        }

        public void registerObserverSubsystem(string id, IEventObserver obs)
        {
            if (_subsystemObserver.ContainsKey(id))
            {
                IList<IEventObserver> value = null;
                if (_subsystemObserver.TryGetValue(id, out value))
                {
                    value.Add(obs);
                    _subsystemObserver[id] = value;
                }
            }
            else
            {
                IList<IEventObserver> value = new List<IEventObserver>();
                value.Add(obs);
                _subsystemObserver[id] = value;
            }

        }

        public void RegisterObserverToolBar(IEventObserver obs)
        {
            _toolBar.Add(obs);
        }

        public void deleteObserverSubSystem(string id, IEventObserver obs)
        {
            if (_subsystemObserver.ContainsKey(id))
            {
                IList<IEventObserver> value = null;
                if (_subsystemObserver.TryGetValue(id, out value))
                {
                    value.Remove(obs);
                    
                }
            }
        }

        public void disableNotify(string id, IEventObserver obs)
        {

            if (_notificationDisabled.ContainsKey(id))
            {
                IList<IEventObserver> value = null;
                if (_notificationDisabled.TryGetValue(id, out value))
                {
                    value.Add(obs);
                    _notificationDisabled[id] = value;
                }
            }
            else
            {
                IList<IEventObserver> value = new List<IEventObserver>();
                value.Add(obs);
                _notificationDisabled[id] = value;
            }
        }
        public void enableNotify(string id, IEventObserver obs)
        {
            if (_notificationDisabled.ContainsKey(id))
            {
                IList<IEventObserver> value = null;
                if (_notificationDisabled.TryGetValue(id, out value))
                {
                    if (value.Contains(obs))
                    {
                      value.Remove(obs);
                    }
                }
            }
        }

        public void RegisterMailBox(string id, MailBoxMessageHandler messageHandler)
        {
            _mailBox[id] = messageHandler;
        }
    }
}