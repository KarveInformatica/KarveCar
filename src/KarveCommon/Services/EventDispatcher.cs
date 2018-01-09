using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Configuration;
using KarveCommon.Services;

namespace KarveCommon.Services
{
    /// <summary>
    ///  Dispatcher of messages between different parts of the application.
    /// This makes the application and communication between view models loosely coupled.
    /// </summary>
    public class EventDispatcher : IEventManager
    {

        IList<IEventObserver> _observers = new List<IEventObserver>();
        // This are events for the each subsystem, module wide.
        IDictionary<string, IList<IEventObserver>> _subsystemObserver = new Dictionary<string, IList<IEventObserver>>();
        IDictionary<string, IList<IEventObserver>> _notificationDisabled = new Dictionary<string, IList<IEventObserver>>();
        // This are events that notify the toolbar. Each view module can notify the toolbar
        IList<IEventObserver> _toolBar = new List<IEventObserver>();
        // This are direct events, each view module has a mailbox for receiving messages.
        private IDictionary<string, MailBoxMessageHandler> _mailBox = new ConcurrentDictionary<string, MailBoxMessageHandler>();
        /// <summary>
        ///  Send a message from a view module to another view module.
        /// </summary>
        /// <param name="viewModuleId">Identifier of the view model</param>
        /// <param name="payLoad">Message to be sent directly to the view model</param>
        public void SendMessage(string viewModuleId, DataPayLoad payLoad)
        {
         
            if (_mailBox.ContainsKey(viewModuleId))
            {
                MailBoxMessageHandler messageHandler = _mailBox[viewModuleId];
                messageHandler?.Invoke(payLoad);
            }
            else
            {
                // second chance
                string primaryKeyValue = viewModuleId + "." + payLoad.PrimaryKeyValue;
                if (_mailBox.ContainsKey(primaryKeyValue))
                {
                    MailBoxMessageHandler messageHandler = _mailBox[primaryKeyValue];
                    messageHandler?.Invoke(payLoad);
                }
            }
        }
        private void NotifyObserver(DataPayLoad payload, IList<IEventObserver> eoList)
        {
            for (int i = 0; i < eoList.Count; ++i)
            {
                IEventObserver eo = eoList[i];
               
                    eo.IncomingPayload(payload);
                
            }
            
        }
        /// <summary>
        ///  Notify all the global observer of a new message
        /// </summary>
        /// <param name="payload">Message to be send to all the system</param>
        public void NotifyObserver(DataPayLoad payload)
        {
            NotifyObserver(payload, _observers);
        }
        /// <summary>
        /// Notify Observer subsystem.
        /// </summary>
        /// <param name="id">Identifier of a subsystem</param>
        /// <param name="dataPayload">Message to be sent to the subsystem</param>
        public void NotifyObserverSubsystem(string id, DataPayLoad dataPayload)
        {

            if (id == null)
            {
                return;
            }
            if (_subsystemObserver.ContainsKey(id))
            {
                if (_subsystemObserver.TryGetValue(id, out IList<IEventObserver> value))
                {
                    // ok we get the disabled
                    _notificationDisabled.TryGetValue(id, out IList<IEventObserver> disabledItemList);
                    if ((disabledItemList == null))
                    {
                        NotifyObserver(dataPayload, value);
                    }
                    else
                    {
                        // the item are not disabled.
                        Notify(dataPayload, value, disabledItemList);
                    }

                }
            }
        }
        private void Notify(DataPayLoad dataPayLoad, IList<IEventObserver> values, IList<IEventObserver> disabled)
        {
            // the item are not disabled.
            foreach (IEventObserver eo in values)
            {
                // i dont send the message to myself.
                if (!string.IsNullOrEmpty(dataPayLoad.Sender))
                {
                   string  sender = dataPayLoad.Sender;
                        if (!disabled.Contains(eo))
                        {
                            eo.IncomingPayload(dataPayLoad);
                        }
                    
                }
            }
        }
        /// <summary>
        /// Notify the toolbar
        /// </summary>
        /// <param name="payload">Message to be sent</param>
        public void NotifyToolBar(DataPayLoad payload)
        {
            NotifyObserver(payload, _toolBar);
        }
        /// <summary>
        /// Register an observer
        /// </summary>
        /// <param name="obs">Observer</param>
        public void RegisterObserver(IEventObserver obs)
        {
            _observers.Add(obs);
        }
        /// <summary>
        /// Register observer system.
        /// </summary>
        /// <param name="id">Identifier of the system.</param>
        /// <param name="obs">Event observer to be registered.</param>
        public void RegisterObserverSubsystem(string id, IEventObserver obs)
        {
            if (_subsystemObserver.ContainsKey(id))
            {
                if (_subsystemObserver.TryGetValue(id, out IList<IEventObserver> value))
                {
                    value.Add(obs);
                    _subsystemObserver[id] = value;
                }
            }
            else
            {
                IList<IEventObserver> value = new List<IEventObserver>
                {
                    obs
                };
                _subsystemObserver[id] = value;
            }

        }

        public void RegisterObserverToolBar(IEventObserver obs)
        {
            _toolBar.Add(obs);
        }

        public void DeleteObserverSubSystem(string id, IEventObserver obs)
        {
            if (_subsystemObserver.ContainsKey(id))
            {
                if (_subsystemObserver.TryGetValue(id, out IList<IEventObserver> value))
                {
                    value.Remove(obs);

                }
            }
        }

        public void DisableNotify(string id, IEventObserver obs)
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
                IList<IEventObserver> value = new List<IEventObserver>
                {
                    obs
                };
                _notificationDisabled[id] = value;
            }
        }
        public void EnableNotify(string id, IEventObserver obs)
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
        /// <summary>
        ///  
        /// </summary>
        /// <param name="id"></param>
        /// <param name="messageHandler"></param>
        public void RegisterMailBox(string id, MailBoxMessageHandler messageHandler)
        {
            if (!_mailBox.ContainsKey(id))
            {
                _mailBox[id] = messageHandler;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        public void DeleteMailBoxSubscription(string id)
        {
            
            if (_mailBox.ContainsKey(id))
            {
                _mailBox.Remove(id);
            }
        }

        public void DeleteObserver(IEventObserver observer)
        {
            for (int i = 0; i < _observers.Count; ++i)
            {
                
                IEventObserver eo = _observers[i];
                if (eo == observer)
                {
                    _observers.Remove(eo);
                }
            }
        }
    }
}