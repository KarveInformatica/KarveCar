using Prism.Mvvm;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace BookingModule.ViewModels
{ 

    /// <summary>
    ///  GeneralInfo.
    /// </summary>
    public class GeneralInfo: BindableBase, IEquatable<GeneralInfo>
    {
        private ICommand _createNewCommand;
        private ICommand _assistCommand;
        private string _newLabel;
        private string _dataField;
        private string _assistTableName;
        private string _assistProperties;
        private object _dataSource;
        private ICommand _itemChangedCommand;
        private string _createTag;
        private object _sourceView;

        /// <summary>
        /// Set ot get a command for a new link.
        /// </summary>
        public ICommand CreateNew {
            set
            {
                _createNewCommand = value;
                RaisePropertyChanged();
            }
            get
            {
                return _createNewCommand;
            }
        }


        /// <summary>
        ///  Set or Get the assist command
        /// </summary>
        public string AssistProperties
        {
            set
            {
                _assistProperties = value;
                RaisePropertyChanged();
            }
            get
            {
                return _assistProperties;
            }
        }
        /// <summary>
        ///  Set or Get the assist command
        /// </summary>
        public ICommand AssistCommand {
            set
            {
                _assistCommand = value;
                RaisePropertyChanged();
            }
            get
            {
                return _assistCommand;
            }
        }

        /// <summary>
        ///  Set or Get itemchangedcommand
        /// </summary>
        public ICommand ItemChangedCommand
        {
            set
            {
                _itemChangedCommand = value;
                RaisePropertyChanged();
            }
            get
            {
                return _itemChangedCommand;
            }
        }

        /// <summary>
        /// Set or Get the label associated to the create command
        /// </summary>
        public string CreateNewLabel
        {
            set
            {
                _newLabel = value;
                RaisePropertyChanged();
            }
            get
            {
                return _newLabel;
            }
        }
        /// <summary>
        ///  Set or get the data field associated with the data path.
        /// </summary>
        public string DataField
        {
            set
            {
                _dataField = value;
                RaisePropertyChanged();
            }
            get
            {
                return _dataField;
            }
        }
        /// <summary>
        /// Set or get the assist table name
        /// </summary>
        public string AssistTableName
        {
            set
            {
                _assistTableName = value;
                RaisePropertyChanged();
            }
            get
            {
                return _assistTableName;
            }
        }
        /// <summary>
        /// Set or Get the create tag.
        /// </summary>
        public string CreateTag
        {
            get
            {
                return _createTag;
            }
            set
            {
                _createTag = value;
            }
        }

        /// <summary>
        ///  Set or Get the sourceview
        /// </summary>
        public object SourceView
        {
            get
            {
              return _sourceView;
            }
            set
            {
                _sourceView = value;
                RaisePropertyChanged();
            }
        }

        /// <summary>
        ///  Set or Get the data source
        /// </summary>
        public object DataSource
        {
            set
            {
                _dataSource = value;
                RaisePropertyChanged();
            }
            get
            {
                return _dataSource;
            }
        }

        public string LabelText { get; internal set; }

        /// <summary>
        ///  Compare the two general infos.
        /// </summary>
        /// <param name="other">Another info</param>
        /// <returns></returns>
        public bool Equals(GeneralInfo other)
        {
            return (_dataField == other._dataField);
        }
    }
    /// <summary>
    ///  GeneralInfoCollectionFactory
    /// </summary>
    public class GeneralInfoCollectionBuilder: IEnumerable<GeneralInfo>, IDisposable
    {
        private readonly ICommand _newAssistCommand;
        private readonly ICommand _newCreateCommand;
        private readonly ICommand _newChangedCommand;
        private ObservableCollection<GeneralInfo> _list;
      
        /// <summary>
        /// Builder for the collection. 
        /// </summary>
        /// <param name="assist">Command to trigger the magnifier</param>
        /// <param name="create">Create command to create a new window</param>
        /// <param name="changed">Changed command to be triggered when a change happens</param>
        public GeneralInfoCollectionBuilder(ICommand assist, ICommand create, ICommand changed)
        {
            _newAssistCommand = assist;
            _newCreateCommand = changed;
            _newChangedCommand = changed;
            _list = new ObservableCollection<GeneralInfo>();
        }
        /// <summary>
        /// Add a new item to the collection.
        /// </summary>
        /// <param name="createLabel">Create a new label.</param>
        /// <param name="dataField">Data Field.</param>
        /// <param name="assistTag">Assist Tag.</param>
        /// <param name="properties">Assist Properties.</param>
        public void Add(string labelText, string dataField, string assistTag, string createTag,  string properties="Code,Name")
        {
            var item = new GeneralInfo();
            item.DataField = dataField;
            item.LabelText = labelText;
            item.AssistTableName = assistTag;
            item.AssistProperties = properties;
            item.AssistCommand = _newAssistCommand;
            item.CreateNew = _newCreateCommand;
            item.CreateTag = createTag;
            item.ItemChangedCommand = _newChangedCommand;
            _list.Add(item);

        }
        public GeneralInfo this[int i]
        {
            get { return _list[i]; }
            set { _list[i] = value; }
        }
        public IEnumerator<GeneralInfo> GetEnumerator()
        {
            return _list.GetEnumerator();
        }
        public ObservableCollection<GeneralInfo> AsObservable()
        {
            return new ObservableCollection<GeneralInfo>(_list);
        }
        IEnumerator IEnumerable.GetEnumerator()
        {
            return _list.GetEnumerator();
        }

        public void Dispose()
        {
            _list.Clear();
        }
    }
}
