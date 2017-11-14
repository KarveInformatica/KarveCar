using System;
using System.Collections.Generic;
using KarveControls.UIObjects;
using System.Threading.Tasks;
using System.Windows.Input;
using KarveControls;
using MasterModule.Common;
using Prism.Commands;

namespace MasterModule.UIObjects.CommissionAgents
{
    /// <summary>
    /// This is the data field search.
    /// </summary>
    public class UiDfSearch: UiDualDfSearchTextObject
    {
        private object _dataObject;
        /// <summary>
        /// UiDfSearch. it is an object more easy to configure for collection objects
        /// </summary>
        public UiDfSearch(): base()
        {
            ButtonImage = MasterModuleConstants.ImagePath;
        }
        public delegate Task OnAssistQueryRequestHandlerDo(string assistTableName, string assistQuery);
        public event OnAssistQueryRequestHandlerDo OnAssistQueryDo;
        private ICommand _assistCommand;
        private object _sourceView;
        private object _assistProperties;

        /// <summary>
        /// UiDfSearch.
        /// </summary>
        /// <param name="labelTxt">Label to be configured.</param>
        public UiDfSearch(string labelTxt) : base(labelTxt,"100")
        {
            ButtonImage = MasterModuleConstants.ImagePath;
            _assistCommand = new DelegateCommand<object>(OnAssistCommand);
        }
        /// <summary>
        /// Assist command.
        /// </summary>
        public new ICommand AssistCommand
        {
            get { return _assistCommand; }
            set { _assistCommand = value; }
        }

        private void OnAssistCommand(object value)
        {
            IDictionary<string, string> valueDictionary = (Dictionary<string, string>)value;
            string assistTable = "";
            string assistQuery = "";

            if (valueDictionary.ContainsKey(DualFieldSearchBox.MagnifierPressEventArgs.ASSISTTABLE))
            {
                assistTable = valueDictionary[DualFieldSearchBox.MagnifierPressEventArgs.ASSISTTABLE] as string;
            }
            if (valueDictionary.ContainsKey(DualFieldSearchBox.MagnifierPressEventArgs.ASSISTQUERY))
            {
                assistQuery = valueDictionary[DualFieldSearchBox.MagnifierPressEventArgs.ASSISTQUERY] as string;
            }
            OnAssistQueryDo?.Invoke(assistTable, assistQuery);
        }
        /// <summary>
        /// Source of the data.
        /// </summary>
        public object DataSource
        {
            set { _dataObject = value; }
            get { return _dataObject; }
        }

        public new object SourceView
        {
            set { _sourceView = value; RaisePropertyChanged(); }
            get { return _sourceView;  }
        }
        public object AssistProperties
        {
            set { _assistProperties = value; RaisePropertyChanged(); }
            get { return _assistProperties; }
        }

    }


}
