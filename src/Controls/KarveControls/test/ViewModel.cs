using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media.Animation;
using KarveControls.UIObjects;
using Prism.Commands;
using Prism.Mvvm;

namespace KarveControlsTest
{
    /// <summary>
    /// Test ViewModel.
    /// </summary>
    public class ClientData
    {
        public string Zip { get; set; }
    }

    public class ClientName
    {
        public ClientData Value { 
            get; set;
            }
    }
    /// <summary>
    ///  ClientDataView.
    /// </summary>
    public class ClientDataView
    {
        public string Zip { get; set; }
        public string City { get; set; }
    }
    public class ViewModel: BindableBase
    {
        private ObservableCollection<ClientData> _cData = new ObservableCollection<ClientData>()
        {
            new ClientData()
            {
                Zip = "08904"
            },
            new ClientData()
            {
                Zip = "08900"
            },
            new ClientData()
            {
                Zip = "08800"
            },
            new ClientData()
            {
                Zip = "08012"
            }
        };
        private ObservableCollection<ClientDataView> _cDataView = new ObservableCollection<ClientDataView>()
        {
            new ClientDataView()
            {
                Zip = "08904",
                City = "Barcelona"
            },
            new ClientDataView()
            {
                Zip = "08900",
                City = "Barcelona"
            },
            new ClientDataView()
            {
                Zip = "08800",
                City = "Barcelona"
            }
        };

       
        private ObservableCollection<ClientDataView> _dataView = new ObservableCollection<ClientDataView>();
        private string _assistQuery;
        private ClientName _cData1;

        public ViewModel() : base()
        {
            ItemChangedCommand = new DelegateCommand<object>(OnItemChanged);
            MagnifierCommand = new DelegateCommand<object>(OnMagnifierEvent);
            SourceViewDto = _cDataView;
            ClientData data = new ClientData()
            {
                Zip = "08904"
            };
            ClientName cName = new ClientName();
            cName.Value = data;
            DataSource = cName;
            AssistQuery = "Select * FROM Provee1";
            
        }
        private void OnItemChanged(object var)
        {
            MessageBox.Show("Damme che acabo esto");
        }
        private void OnMagnifierEvent(object magnifer)
        {
            ClientDataView clietDataView = new ClientDataView()
            {
                Zip = "08904",
                City = "Barcelona"
            };
            _cDataView.Add(clietDataView);
            SourceViewDto = CraftView();
        }
        /// <summary>
        ///  AssistQuery
        /// </summary>
        public string AssistQuery
        {
            set
            {
                _assistQuery = value; RaisePropertyChanged();
            }
            get
            {
                return _assistQuery;
            }
        }
    
        /// <summary>
        ///  DataSource.
        /// </summary>
        public ClientName DataSource
        {
            get { return _cData1; }
            set { _cData1 = value ; RaisePropertyChanged(); }             
        }
        /// <summary>
        ///  SourceView 
        /// </summary>
        public ObservableCollection<ClientDataView> SourceViewDto
        {
            get { return _dataView; }
            set { _dataView = value; RaisePropertyChanged(); }
        }
        /// <summary>
        ///  Item changed command
        /// </summary>
        public ICommand ItemChangedCommand { set; get; }
        /// <summary>
        ///  Magnifier command.
        /// </summary>
        public ICommand MagnifierCommand { set; get; }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        private ObservableCollection<ClientDataView> CraftView()
        {
            ObservableCollection<ClientDataView> views = new ObservableCollection<ClientDataView>()
            {
                new ClientDataView()
                {
                    Zip = "08904",
                    City = "Barcelona"
                },
                new ClientDataView()
                {
                    Zip = "08900",
                    City = "Barcelona"
                },
                new ClientDataView()
                {
                    Zip = "08800",
                    City = "Barcelona"
                }
            };
            return views;
        }
    }
}