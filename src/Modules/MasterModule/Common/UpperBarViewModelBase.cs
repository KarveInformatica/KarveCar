﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Input;
using KarveCommon.Services;
using KarveDataServices;
using Prism.Mvvm;

namespace MasterModule.Common
{

    public class UpperBarViewModelBase: BindableBase
    {
        private object _sourceView= new object();
        private object _dataObject = new object();
        protected IEventManager EventManager;
        protected IDataServices DataServices;
        protected DataSubSystem _subsystem;
        protected const string AssistQuery = "AssistQuery";
        protected MailBoxMessageHandler MailBoxHandler;


        protected enum UpperBarViewModelState
        {
            Init, Loaded
        };

        protected UpperBarViewModelState _status;
        private ICommand _assistCommand;
        private ICommand _itemChangedHandler;
        private ICommand _itemChangedCommand;

        /// <summary>
        ///  Constructor view model for the upper bar in the tabs of the master registry.
        /// </summary>
        /// <param name="eventManager"></param>
        /// <param name="dataServices"></param>
        public UpperBarViewModelBase(IEventManager eventManager, IDataServices dataServices)
        {

            EventManager = eventManager;
            DataServices = dataServices;
        }

        protected void OnChangedItem(object data)
        {
            object currentObject = data;
            if (data is IDictionary<string, object>)
            {


                IDictionary<string, object> currentData = data as IDictionary<string, object>;
                if (currentData == null)
                    return;
                currentObject = currentData["DataObject"];
            }
            object dataObject = data;
            DataPayLoad payLoad = new DataPayLoad();
            payLoad.DataObject = currentObject;
            DataObject = currentObject;
            payLoad.PayloadType = DataPayLoad.Type.Update;
            payLoad.HasDataObject = true;
            payLoad.Subsystem = _subsystem;
            // send message to the main view model to any item.
            EventManager.NotifyToolBar(payLoad);
        }
    
        /// <summary>
        ///  Data Object
        /// </summary>
        public object DataObject
        {
            set { _dataObject = value
                    ; RaisePropertyChanged(); }
            get { return _dataObject; }
        }

        /// <summary>
        ///  Changed item
        /// </summary>
        public ICommand ItemChangedCommand
        {
            set { _itemChangedCommand = value; RaisePropertyChanged(); }
            get { return _itemChangedCommand; }
        }
    
        /// <summary>
        ///  Changed item
        /// </summary>
        public ICommand ItemChangedHandler {
             set {
            _itemChangedHandler = value;
            RaisePropertyChanged();
            }
        get { return _itemChangedHandler; }
    }

    /// <summary>
        ///  Assist Command
        /// </summary>
        public ICommand AssistCommand
        {
            set { _assistCommand = value; RaisePropertyChanged(); }
            get { return _assistCommand; }
        }

        /// <summary>
        ///  ChangedItem
        /// </summary>
        public ICommand ChangedItem { set; get; }
        /// <summary>
        ///  SourceView
        /// </summary>
        public object SourceView
        {
            set
            {
                _sourceView = value;
                RaisePropertyChanged();
            }
            get { return _sourceView; }
        }
    }

}