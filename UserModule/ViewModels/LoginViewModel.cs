using System.Windows;
using KarveCommon.Services;
using KarveDataServices.DataObjects;

namespace UserModule.ViewModels
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Windows.Input;
    using global::UserModule.Service;
    using KarveCar.Model;
    using KarveCommon.Generic;
    using KarveCommonInterfaces;
    using KarveDataServices;
    using KarveDataServices.ViewObjects;
    using Prism.Commands;
    using Prism.Mvvm;

    /// <summary>
    /// The login view model has the responsibility to mediate
    /// between the view model and the view.
    /// </summary>
    public class LoginViewModel : KarveViewModelBase
    {
        /// <summary>
        /// The data services.
        /// </summary>
        private IDataServices dataServices;

        /// <summary>
        /// The assist service.
        /// </summary>
        private IAssistDataService assistService;

        /// <summary>
        /// The auth service.
        /// </summary>
        private IAuthorizationService authService;

        /// <summary>
        /// The interaction request controller.
        /// </summary>
        private IInteractionRequestController interactionRequestController;

        /// <summary>
        /// The users.
        /// </summary>
        private IList<UserSummaryViewObject> users;

        /// <summary>
        /// The configuration service.
        /// </summary>
        private IConfigurationService configurationService;
        
        /// <summary>
        ///  Error message.
        /// </summary>
        private string _loginError;

        /// <summary>
        /// List of offices.
        /// </summary>
        private IEnumerable<OfficeViewObject> _offices;

        private string _greet;

        private string _office;
        private string _user;

        private UserViewObject _dataObject;


        /// <summary>
        /// Initializes a new instance of the <see cref="LoginViewModel"/> class. 
        ///  Login view model.
        /// </summary>
        /// <param name="configurationService">
        /// System configuration service
        /// </param>
        /// <param name="services">
        /// Data services
        /// </param>
        /// <param name="assistService">
        /// Magnifier request answer
        /// </param>
        /// <param name="interactionRequestController">
        /// Interaction controller.
        /// </param>
        /// <param name="service">
        /// Authentication service
        /// </param>

        public LoginViewModel(IConfigurationService configurationService,
                              IDataServices services,
                              IAssistDataService assistService,
                              IInteractionRequestController interactionRequestController,          
                              IAuthorizationService service)
        {
            InitializeViewModel();
            LoginCommand = new DelegateCommand<object>(this.OnLogin);
            MagnifierCommand = new DelegateCommand<object>(this.OnAssistCommand);
            ItemChangedCommand = new DelegateCommand<object>(this.OnChanged);
            this.dataServices = services;
            this.authService = service;
            this.assistService = assistService;
            this.AssistMapper = assistService.Mapper;
            this.configurationService = configurationService;
            Salutation = string.Empty;
            DataObject = new UserViewObject();
            InitVisibleOffice();
        }


        /// <summary>
        /// Gets or sets the data object.
        /// </summary>
        public UserViewObject DataObject
        {
            get { return _dataObject; }
            set
            {
                _dataObject = value; 
                RaisePropertyChanged();
            }
        }

        /// <summary>
        /// Gets or sets the login command.
        /// </summary>
        public ICommand LoginCommand { get; set; }

        /// <summary>
        /// Gets or sets the assist command.
        /// </summary>

        public ICommand MagnifierCommand { get; set; }

        /// <summary>
        /// Gets or sets the item changed command.
        /// </summary>
       
        public ICommand ItemChangedCommand { set; get; }


        /// <summary>
        /// Gets or sets a value indicating whether is visible office.
        /// </summary>
        public bool IsVisibleOffice { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether is logged.
        /// </summary>
        public bool IsLogged
        {
            get;set;
        }


        /// <summary>
        /// Gets or sets the login error.
        /// </summary>
        public string LoginError
        {
            set
            {
                _loginError = value;
                RaisePropertyChanged();
            }
            get { return _loginError; }

        }

        /// <summary>
        /// Gets or sets the salutation.
        /// </summary>
        public string Salutation
        {
            set
            {
                _greet = value;
                RaisePropertyChanged("Salutation");
            }
            get { return _greet; }
        }

        public void InitializeViewModel()
        {

        }

        /// <summary>
        ///  Initialize the office visible.
        /// </summary>
        private void InitVisibleOffice()
        {
            NotifyTaskCompletion.Create<bool>(authService.IsLoginAuth(), (task, ev) =>
            {
                if (task is INotifyTaskCompletion<bool> taskCompletion)
                {
                    if (taskCompletion.IsSuccessfullyCompleted)
                    {
                        this.IsVisibleOffice = taskCompletion.Result;
                    }
                }
            });
        }

        /// <summary>
        ///  This command has been executed when the login is 
        /// </summary>
        /// <param name="viewObject">UserViewObject to be visualized.</param>
        private void OnLogin(object viewObject)
        {
            var currentData = DataObject;
            var user = new User
            {
                Name = currentData.USUARIO,
                Office = new Office {Code = currentData.OFI_COD},
                Password = currentData.PASS
            };
            NotifyTaskCompletion.Create<bool>(authService.CanAccess(user, this.configurationService),
                (task, ev) =>
                {
                    if (task is INotifyTaskCompletion<bool> taskCompletion)
                    {
                        if (taskCompletion.IsSuccessfullyCompleted)
                        {
                            if (taskCompletion.Result)
                            {
                                IsLogged = true;
                                View?.Close();
                            }
                            else
                            {
                                IsLogged = false;
                                LoginError = KarveLocale.Properties.Resources.linvalidpass;
                            }
                        }
                    }
                });
        }


        /// <summary>
        /// OnChanged command
        /// </summary>
        /// <param name="eventDictionary">event dictionary</param>
        private async void OnChanged(object eventDictionary)
        {
            if (eventDictionary is IDictionary<string, object> eventData)
            {
                if (eventData.ContainsKey("DataSourcePath"))
                {
                    var key = eventData["DataSourcePath"] as string;
                    if ((key!=null) && (key == "USUARIO"))
                    {
                       var userValue = eventData["ChangedValue"] as string;
                        _user = userValue;
                        // Salutation = await FetchSalutation(userValue).ConfigureAwait(false);
                    }
                   
                }
            }
        }

        public Window View { set; get; }
        
        /// <summary>
        ///  Salutation.
        /// </summary>
        /// <param name="value">Value to be used a salutation</param>
        /// <returns>A name of an user.</returns>

        private async Task<string> FetchSalutation(string value)
        {
            var userService = DataServices.GetUserDataService();
            IUserData name;
            try
            {
                name = await userService.GetUserByName(value).ConfigureAwait(false);
            }
            catch (Exception ex)
            {
                return string.Empty;
            }

            return name.Value.NOMBRE;
        }
        /// <summary>
        /// The on assist command.
        /// </summary>
        /// <param name="param">
         /// The param.
          /// </param>
        private void OnAssistCommand(object param)
        {
            IDictionary<string, string> values = (Dictionary<string, string>)param;
            var assistTableName = values.ContainsKey("AssistTable") ? values["AssistTable"] as string : null;
            var assistQuery = values.ContainsKey("AssistQuery") ? values["AssistQuery"] as string : null;
            this.AssistNotifierInitialized = NotifyTaskCompletion.Create<bool>(this.AssistQueryRequestHandler(assistTableName, assistQuery), this.AssistExecuted);
        }


        private async Task<bool> AssistQueryRequestHandler(string assistTableName, string assistQuery)
        {
            var collection = await AssistMapper.ExecuteAssistGeneric(assistTableName, assistQuery);
            switch (assistTableName)
            {
                case "OFFICE_ASSIST":
                {
                    Offices = (IEnumerable<OfficeViewObject>) collection;
                    break;
                }
            }
            return false;
        }

        /// <summary>
        /// Gets or sets the offices.
        /// </summary>
        public IEnumerable<OfficeViewObject> Offices
        {
            set
            {
                _offices = value;
                RaisePropertyChanged("Offices");
            }
            get { return _offices; }
        }
    }
}
