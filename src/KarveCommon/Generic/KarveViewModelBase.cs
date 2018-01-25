using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Security.Cryptography;
using System.Threading.Tasks;
using System.Windows.Input;
using KarveCommonInterfaces;
using KarveDataServices;
using KarveDataServices.DataTransferObject;
using Prism.Mvvm;
namespace KarveCommon.Generic
{
    /// <summary>
    /// View model base.
    /// </summary>
    public class KarveViewModelBase: BindableBase, IDisposeEvents
    {
        /// <summary>
        ///  SqlQuery. This is an assist query.
        /// </summary>
        private string _sqlQuery;
        /// <summary>
        ///  GridParameters.
        /// </summary>
        private GridSettingsDto _gridParameters;
        /// <summary>
        ///  Handler to load all grid of all
        /// </summary>
        protected INotifyTaskCompletion<ObservableCollection<GridSettingsDto>> MagnifierInitializationNotifier;
        /// <summary>
        /// DataServices about grid parameters.
        /// </summary>
        protected IDataServices DataServices;
        /// <summary>
        ///  Registered grid list.
        /// </summary>
        protected static SortedSet<long> RegisteredGridIds = new SortedSet<long>();
        /// <summary>
        ///  Current grid settings.
        /// </summary>
        private ObservableCollection<GridSettingsDto> _currentGridSettings = new ObservableCollection<GridSettingsDto>();

        protected Guid Guid;
        private KarveGridParameters _gridParm = new KarveGridParameters();
        private long _gridIdentifer = long.MinValue;

        /// <summary>
        /// KarveViewModelBase. Base view model of the all structure
        /// </summary>
        /// <param name="services">DataServices to be used.</param>
        public KarveViewModelBase(IDataServices services)
        {
            DataServices = services;
            Guid = Guid.NewGuid();
            GridResizeCommand = new Prism.Commands.DelegateCommand<object>(OnGridResize);
            GridRegisterCommand = new Prism.Commands.DelegateCommand<object>(OnGridRegister);
        }

        /// <summary>
        ///  Unique Id for the helpers.
        /// </summary>
        protected string UniqueId
        {
            get => Guid.ToString();
            set
            {
                Guid = Guid.Parse(value);
            }
        }
        /// <summary>
        ///  GeneratedGridId. This generate a grid identifier.
        /// </summary>
        /// <returns></returns>
        protected long GenerateGridId()
        {
            RNGCryptoServiceProvider rng = new RNGCryptoServiceProvider();
            // Buffer storage.
            byte[] data = new byte[8];
            long value;
            int maxTries = 10;
            do
            {
                // Fill buffer.
                rng.GetBytes(data);
                // Convert to int 32.
                value = Math.Abs(BitConverter.ToInt64(data, 0));
                maxTries--;
                if (maxTries == 0)
                {
                    break;
                }
            } while (RegisteredGridIds.Contains(value));
            // in case we have a minvalue.
            if (value == long.MinValue)
            {
                maxTries = 0;
            }
            if (maxTries == 0)
            {
                value = RegisteredGridIds.Max + 1;
                RegisteredGridIds.Add(value);
            }
            return value;
        }
        /// <summary>
        ///  Grid register command
        /// </summary>
        public ICommand GridRegisterCommand { get; set; }
        /// <summary>
        /// CurrentGrid Settings
        /// </summary>
        public ObservableCollection<GridSettingsDto>  CurrentGridSettings
        {
            set
            {
                _currentGridSettings = value;
                RaisePropertyChanged();
            }
            get { return _currentGridSettings; }
            
        }

        void InitGridSettings(IDataServices services, long id)
        {
            MagnifierInitializationNotifier =
                NotifyTaskCompletion.Create<ObservableCollection<GridSettingsDto>>(LoadSettings(services, id),
                    InitializationNotifierOnSettingsChanged);
        }

        private async Task<ObservableCollection<GridSettingsDto>> LoadSettings(IDataServices services, long id)
        {
           List<long> numberLists = new List<long>();
           numberLists.Add(id);
           ObservableCollection<GridSettingsDto> settingsDto =
                await services.GetSettingsDataService().GetMagnifierSettingByIds(numberLists);
           return settingsDto;
        }

      
        /// <summary>
        ///  Command happened during the resize.
        /// </summary>
        /// <param name="var"></param>
        private void OnGridResize(object var)
        {
            KarveGridParameters param = var as KarveGridParameters;
            if (param != null)
            {
                ISettingsDataService dataService = DataServices.GetSettingsDataService();
                GridSettingsDto settingsDto = new GridSettingsDto();
                settingsDto.GridName = param.GridName;
                settingsDto.GridIdentifier = param.GridIdentifier;
                settingsDto.XmlBase64 = param.Xml;
                dataService.SaveMagnifierSettings(settingsDto);
            }
        }

        private void OnGridRegister(object var)
        {
            KarveGridParameters param = var as KarveGridParameters;
            if (param != null)
            {
                
                RegisteredGridIds.Add(param.GridIdentifier);
                InitGridSettings(DataServices, param.GridIdentifier);
            }
        }

        /// <summary>
        /// TODO: Handle errors in NotifierOnSettingsChanged.
        /// </summary>
        /// <param name="sender">Sender notifier</param>
        /// <param name="propertyChangedEventArgs">Parameters to be used.</param>
        protected void InitializationNotifierOnSettingsChanged(object sender,
            PropertyChangedEventArgs propertyChangedEventArgs)
        {
            string propertyName = propertyChangedEventArgs.PropertyName;
            if (propertyName.Equals("Status"))
            {
                if (MagnifierInitializationNotifier.IsSuccessfullyCompleted)
                {
                    ObservableCollection<GridSettingsDto> dto = MagnifierInitializationNotifier.Task.Result;
                    CurrentGridSettings = dto; 
                    
                }
            }
            else if (propertyName.Equals("IsSuccessfullyCompleted"))
            {
                INotifyTaskCompletion<ObservableCollection<GridSettingsDto>> task = sender as INotifyTaskCompletion<ObservableCollection<GridSettingsDto>>;
                if (task != null)
                {
                    ObservableCollection<GridSettingsDto> m = task.Result;
                    CurrentGridSettings = m;
                    OnGridChange(m);
                }
            }
        }

        /// <summary>
        ///  This is get invoked by the KarveBaseViewModel
        /// </summary>
        /// <param name="dto"></param>
        protected virtual void OnGridChange(ObservableCollection<GridSettingsDto> dto)
        {
            if (dto != null)
            {
                GridSettingsDto gridSettingsDto = dto.FirstOrDefault();
                if (gridSettingsDto != null)
                {
                    GridParam = new KarveGridParameters(gridSettingsDto.GridIdentifier, gridSettingsDto.GridName,
                        gridSettingsDto.XmlBase64);
                }
            }
        }
        public KarveGridParameters GridParam
        {
            set { _gridParm = value; RaisePropertyChanged(); }
            get { return _gridParm; }
        }

        public long GridIdentifier
        {
            set { _gridIdentifer = value; RaisePropertyChanged(); }
            get { return _gridIdentifer; }
        }
        ///<summary>
        /// When a region get destroyed we can dispose the events.
        /// </summary>
        public virtual void DisposeEvents()
        {
            
        }

        /// <summary>
        /// GridSettings.
        /// </summary>
        public GridSettingsDto GridSettings
        {
            set { _gridParameters = value; RaisePropertyChanged(); }
            get { return _gridParameters; }
        }
      
        /// <summary>
        ///  Each view model can have a grid resize command.
        /// </summary>
        public ICommand GridResizeCommand { set; get; }
        /// <summary>
        ///  Each view model can have an assist query.
        /// </summary>
        public string AssistQuery
        {
            set
            {
                _sqlQuery = value;
                RaisePropertyChanged();
            }
            get { return _sqlQuery; }

        }
    }
}
