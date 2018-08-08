using System;
using System.Linq;
using System.Collections.Concurrent;
using System.Collections.Generic;

namespace KarveCommon.Services
{
    /// <summary>
    /// Dispatcher of messages between different parts of the application.
    /// This makes the application and communication between view models loosely coupled.
    /// ViewModel are not coupled to one another. Each talks to the EventDispatcher using a DataPayload. 
    /// Each view model might subscribe direct or broadcast communication to the event dispatcher.
    /// - In case of broadcast communication shall provide the id of the group to comunicate with.
    /// - In case of direct communication it shall provide the uri of the view model for sending to the message.
    /// Notification can be enabled or disabled.
    /// </summary>
    public class EventDispatcher : IEventManager, IDisposable
    {

        IList<WeakReference<IEventObserver>> _observers = new List<WeakReference<IEventObserver>>();
        // This are events for the each subsystem, module wide.
        IDictionary<string, IList<WeakReference<IEventObserver>>> _subsystemObserver = new Dictionary<string, IList<WeakReference<IEventObserver>>>();
        IDictionary<string, IList<WeakReference<IEventObserver>>> _notificationDisabled = new Dictionary<string, IList<WeakReference<IEventObserver>>>();
        // This are events that notify the toolbar. Each view module can notify the toolbar
        IList<WeakReference<IEventObserver>> _toolBar = new List<WeakReference<IEventObserver>>();
        // This are direct events, each view module has a mailbox for receiving messages.
        private IDictionary<string, MailBoxMessageHandler> _mailBox = new ConcurrentDictionary<string, MailBoxMessageHandler>();
        /// <summary>
        ///  Get the current notified state.
        /// </summary>
        public bool IsNotified
        {
            private set; get;
        }

        public EventDispatcher()
        {
            IsNotified = false;
        }
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
                if (payLoad.PayloadType == DataPayLoad.Type.Delete)
                {
                    NotifyObserverSubsystem(viewModuleId, payLoad);
                    return;
                }
                if (payLoad.PrimaryKeyValue == null)
                {
                    NotifyObserverSubsystem(viewModuleId, payLoad);
                    return;
                }
                // second chance
                string primaryKeyValue = viewModuleId + "." + payLoad.PrimaryKeyValue;
                if (_mailBox.ContainsKey(primaryKeyValue))
                {
                    MailBoxMessageHandler messageHandler = _mailBox[primaryKeyValue];
                    messageHandler?.Invoke(payLoad);
                }
            }
        }
        private void NotifyObserver(DataPayLoad payload, IList<WeakReference<IEventObserver>> eoList)
        {

            IsNotified = true;
            for (int i = 0; i < eoList.Count; ++i)
            {
                IEventObserver eo = null;
                if (eoList[i].TryGetTarget(out eo))
                {
                    eo.IncomingPayload(payload);
                }
            }
        }
        /// <summary>
        ///  Summary. Registered mailbox.
        /// </summary>
        /// <param name="id">Identifier.</param>
        /// <param name="payLoad">Payload.</param>
        /// <returns></returns>
        public bool IsRegisteredMailbox(string id, DataPayLoad payLoad)
        {
            string primaryKeyValue = id + "." + payLoad.PrimaryKeyValue;
            if (_mailBox.ContainsKey(primaryKeyValue))
                return true;
            return  _mailBox.ContainsKey(id);
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
                if (_subsystemObserver.TryGetValue(id, out IList<WeakReference<IEventObserver>> value))
                {
                        NotifyObserver(dataPayload, value);
                }
            }
        }
        private void Notify(DataPayLoad dataPayLoad, IList<WeakReference<IEventObserver>> values, IList<WeakReference<IEventObserver>> disabled)
        {
            // the item are not disabled.
            foreach (WeakReference<IEventObserver> eo in values)
            {
                // I need a sender addres.
                if (!string.IsNullOrEmpty(dataPayLoad.Sender))
                {
                        string  sender = dataPayLoad.Sender;
                        if (!disabled.Contains(eo))
                        {
                            IEventObserver observerEvent = null;
                            if (eo.TryGetTarget(out observerEvent))
                            {
                                observerEvent.IncomingPayload(dataPayLoad);
                            }
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

        private bool ContainsReference<T>(T observer, IList<WeakReference<T>> observerList) where T: class
        {
            if (observer == null)
            {
                return false;
            }
            foreach (var current in observerList)
            {
                T currentObserver = null;
                if (current.TryGetTarget(out currentObserver))
                {
                    if (object.ReferenceEquals(currentObserver, observer))
                    {
                        return true;
                    }
                }
            }
            return false;
        }
        /// <summary>
        /// Register an observer
        /// </summary>
        /// <param name="obs">Observer</param>
        public void RegisterObserver(IEventObserver obs)
        {            
            if (!ContainsReference<IEventObserver>(obs, _observers))
            {
                _observers.Add(new WeakReference<IEventObserver>(obs));
            }
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
                if (_subsystemObserver.TryGetValue(id, out IList<WeakReference<IEventObserver>> value))
                {
                    var myReference = new WeakReference<IEventObserver>(obs);
                    value.Add(myReference);
                    _subsystemObserver[id] = value;
                }
            }
            else
            {
                IList<WeakReference<IEventObserver>> value = new List<WeakReference<IEventObserver>>
                {
                    new WeakReference<IEventObserver>(obs)
                };
                _subsystemObserver[id] = value;
            }

        }

        public void RegisterObserverToolBar(IEventObserver obs)
        {
            if (!ContainsReference<IEventObserver>(obs, _toolBar))
            {
                _toolBar.Add(new WeakReference<IEventObserver>(obs));
            }
        }

        private void RemoveReference<T>(T reference, IList<WeakReference<T>> referenceList) where T: class
        {
            WeakReference<T> toRemove = null;
            foreach (var v in referenceList)
            {
                T currentReference = null;
                if (v.TryGetTarget(out currentReference))
                {
                    
                    if (object.ReferenceEquals(currentReference, reference))
                    {
                        toRemove = v;
                    }
                }
            }
            if (toRemove != null)
            {
                referenceList.Remove(toRemove);
            }

        }
        public void DeleteObserverSubSystem(string id, IEventObserver obs)
        {
            if (_subsystemObserver.ContainsKey(id))
            {
                if (_subsystemObserver.TryGetValue(id, out IList<WeakReference<IEventObserver>> value))
                {


                    RemoveReference<IEventObserver>(obs, value);
                    
                }
            }
            RemoveReference<IEventObserver>(obs, _observers);
          
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

            RemoveReference<IEventObserver>(observer, _observers);
        }

        public void Dispose()
        {
            _observers.Clear();
            _toolBar.Clear();
        }
    }
}