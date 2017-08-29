using PaymentTypeModule.ChargeClients.View;
using Prism.Commands;
using Prism.Interactivity.InteractionRequest;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Data;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using KarveCommon.Services;
using Prism.Regions;
using KarveDataServices;

namespace PaymentTypeModule.ChargeClients.ViewModel
{
    /// <summary>
    ///  This view model has the resposability of manage the kind of payment that we can afford.
    /// </summary>
    public class ClientChargeViewModel : BindableBase, IPaymentViewModule
    {
        /// <summary>
        ///  Internal fields of the view
        /// </summary>
        private bool _askedCreditCard;
        private string _chargeStateProperties;
        private string _lastUser;
        private string _chargeNumber;
        private string _lastModificationTime;
        private bool _dependencyOnCash;
        private string _chargeName;
        private string _chargeAccount1;
        private string _chargeAccount2;
        private string _chargeCommissionAccount;
        private string _chargeCommissionAccount2;
        private string _commissionPercentage;
        private string _commissionBank;
        private string _office;
        private string _office2;
        private string _swiftValue;
        private string _ibanValue;
        private string _chargeBank1;
        private string _chargeBank2;
        private string _billing1;
        private string _billing2;
        private bool _isClientAccountChecked;
        private bool _isTeleCheck;
        private bool _isAllShowerChecked;
        private bool _isPortfolioEffectChecked;
        private bool _isRemittableChecked;
        private bool _isMultiSeatCommissionChecked;
        private bool _isNoAutoListChecked;
        private string _dataGridColName1;
        private string _dataGridColName2;
        /// <summary>
        ///  Set of delegate commands.
        /// </summary>
        private IDictionary<string, DelegateCommand> _currentClickCommand = new Dictionary<string, DelegateCommand>();
        private GridPopUpViewModel viewModel = new GridPopUpViewModel();
        private GridQuery _queryControl = new GridQuery();
        /// <summary>
        /// Data services interace
        /// </summary>
        private IDataServices _dataServices;
        /// <summary>
        ///  Type of payment data services.
        /// </summary>
        private IPaymentDataServices _paymentDataServices;

        private DataTable _sourceDataTable;
        // interaction requests are of two types: Notification and Confirmation requests.

        public InteractionRequest<INotification> ErrorDialog { get; private set; }
        private DelegateCommand ErrorDialogCommand;
        private DelegateCommand<object> _regionSelectedAction;
        private bool _isVisible = false;
        private IRegionManager _regionManager;
        private DataTable _bankDataTable;
        private int _selectedIndex;
        private bool movedSelection = false;

        public bool IsVisible
        {
            get { return _isVisible; }
            set
            {
                _isVisible = value;
                RaisePropertyChanged("IsVisible");
            }

        }
        public ClientChargeViewModel(ICareKeeperService careKeeperService,
            IDataServices dataServices,
            IConfigurationService configurationService, IRegionManager regionManager)
        {
            _dataServices = dataServices;
            _regionManager = regionManager;
            _selectedIndex = 0;
            _regionSelectedAction = new DelegateCommand<object>(RegionSelection);
            this.ClickCommand = new DelegateCommand<string>(OnClickCommand);
            this.DataGridChangedSelection = new DelegateCommand<object>(OnSelectedRow);
            this.NumberTextChanged = new DelegateCommand<string>(OnTextChanged);
           
            _currentClickCommand.Add("FindChargeAccount", new DelegateCommand(ChargeAccountPopUp));
            _currentClickCommand.Add("FindChargeCommissionAccount", new DelegateCommand(ChargeCommisionAccountPopUp));
            _currentClickCommand.Add("FindCommissionBank", new DelegateCommand(ChargeCommissionBankPopUp));
            _currentClickCommand.Add("FindOffice", new DelegateCommand(ChargeOfficePopUp));
            _currentClickCommand.Add("FindChargeBank", new DelegateCommand(ChargeBankPopUp));
            _currentClickCommand.Add("FindBillingAccount", new DelegateCommand(ChargeBillingAccountPopUp));
            InitDataLayer();
        }

        private void emptyFields()
        {
            this.ChargeName = "";
            this.ChargeAccount1 = "";
            this.ChargeAccount2 = "";
            this.Billing1 = "";
            this.Billing2 = "";
            this.ChargeBank1 = "";
            this.ChargeBank2 = "";
            this.ChargeCommissionAccount1 = "";
            this.ChargeCommissionAccount2 = "";
            this.CommissionBank = "";
            this.CommissionPercentage = "";
            this.IbanValue = "";
            this.SwiftValue = "";
            this.Office = "";
            this.Office2 = "";

        }
        private void OnTextChanged(string value)
        {
            int candidateIndex;
            bool found = false;
            if ((Int32.TryParse(value, out candidateIndex)) && (!movedSelection))
            {

                var rows = _sourceDataTable.AsEnumerable().Where(dr => dr.Field<string>("Numero") == value);
                foreach (var row in rows)
                {
                    found = true;
                    DataRow tmp = row as DataRow;
                    this.ChargeNumber = tmp.ItemArray[0] as string;
                    this.ChargeName = tmp.ItemArray[1] as string;
                    this.ChargeAccount1 = tmp.ItemArray[2] as string;
                    this.ChargeAccount2 = _paymentDataServices.GetAccountDefinitionByCode(this.ChargeAccount1);
                    break;
                }
            }
            if (!found)
            {
                emptyFields();
            }
            movedSelection = false;

        }
        private void InitDataLayer()
        {
            try
            {

                _paymentDataServices = _dataServices.GetPaymentDataService();
                if (_paymentDataServices != null)
                {
                    _sourceDataTable = _paymentDataServices.GetChargeObjects();
                }
                _bankDataTable = _dataServices.GetAllBanks();
                viewModel.QueryTable = _bankDataTable;
            }
            catch (Exception e)
            {

                ShowError(e, "Error during data loading");
            }
        }

        private void OnSelectedRow(object param)
        {
            DataRowView local = param as DataRowView;
            if (local != null)
            {
                movedSelection = true;
                this.ChargeNumber = local.Row.ItemArray[0] as string;
                this.ChargeName = local.Row.ItemArray[1] as string;
                this.ChargeAccount1 = local.Row.ItemArray[2] as string;
                this.ChargeAccount2 = _paymentDataServices.GetAccountDefinitionByCode(this.ChargeAccount1);
                try
                {
                    GetChargeAccountPropertiesByCode(Int32.Parse(this.ChargeNumber));
                } catch (Exception e)
                {
                    MessageBox.Show(e.StackTrace);
                }
            }
        }

        private void GetChargeAccountPropertiesByCode(int pos)
        {

            IDictionary<string, bool> paymentProperties = _paymentDataServices.GetChargeOptions(pos);
            this.IsClientAccountChecked = paymentProperties["IsClientAccountChecked"];
            this.IsRemittableChecked = paymentProperties["IsNoRemittableChecked"];
            this.IsPortfolioEffectChecked = paymentProperties["IsPorfolioEffectsChecked"];
            this.IsMultiSeatCommission = paymentProperties["IsSeatingFeeChecked"];
            this.IsAllShowerChecked = paymentProperties["IsShowerChecked"];
            this.IsTeleCheckChecked = paymentProperties["IsTeleChequeChecked"];
        }

        private void ChargeBillingAccountPopUp()
        {
            viewModel.Title = "Formas Cobro e Facturacion";
            viewModel.QueryTable = null;
            viewModel.QueryType = GridPopUpViewModel.QueryTypeEnum.BillingAccount;
            DataTable invoice = null;
            try
            {
                invoice = _paymentDataServices.GetAllInvoiceTypeDataTable();
            }
            catch (Exception e)
            {
                ShowError(e, "Error during data later loading");
            }
            viewModel.QueryTable = invoice;
            ShowRegion(viewModel, false, _regionSelectedAction);
        }

        private void ChargeBankPopUp()
        {
            viewModel.Title = "Consulta de Bancos";
            viewModel.QueryTable = _bankDataTable; ;
            viewModel.QueryType = GridPopUpViewModel.QueryTypeEnum.Banks;
            ShowRegion(viewModel, false, _regionSelectedAction);
        }
        private void RegionSelection(object param)
        {
            DataRowView selectedItem = param as DataRowView;
            if (selectedItem != null)
            {
                switch (viewModel.QueryType)
                {
                    case GridPopUpViewModel.QueryTypeEnum.Account:
                    {
                        this.ChargeAccount1 = selectedItem.Row.ItemArray[0] as string;
                            this.ChargeAccount2 = selectedItem.Row.ItemArray[1] as string;

                        }
                        break;
                    case GridPopUpViewModel.QueryTypeEnum.CommissionAccount:

                    {
                        this.ChargeCommissionAccount1 = selectedItem.Row.ItemArray[0] as string;
                        this.ChargeCommissionAccount2 = selectedItem.Row.ItemArray[1] as string;

                        }
                        break;
                    case GridPopUpViewModel.QueryTypeEnum.CommissionBank:
                    {
                        this.CommissionBank = selectedItem.Row.ItemArray[0] as string;
                            
                    }
                    
                    break;
                    case GridPopUpViewModel.QueryTypeEnum.Banks:
                    {
                        this.ChargeBank1  = selectedItem.Row.ItemArray[0] as string;
                        this.ChargeBank2 = selectedItem.Row.ItemArray[1] as string;

                    }
                    break;
                    case GridPopUpViewModel.QueryTypeEnum.BillingAccount:
                    {
                        this.Billing1 = selectedItem.Row.ItemArray[0] as string;
                        this.Billing2 = selectedItem.Row.ItemArray[1] as string;
                    }
                   break;
                    case GridPopUpViewModel.QueryTypeEnum.OfficeAccount:
                    {
                        this.Office = selectedItem.Row.ItemArray[0] as string;
                        this.Office2 = selectedItem.Row.ItemArray[1] as string;
                    }
                    break;
                }
            }
        }
        private void ChargeOfficePopUp()
        {
            viewModel.Title = "Consulta Cuenta de Oficinas";
            viewModel.QueryType = GridPopUpViewModel.QueryTypeEnum.OfficeAccount; 
            try
            {
                DataTable offices = _paymentDataServices.GetAllInvoiceOfficesDataTable();
                viewModel.QueryTable = offices;
                ShowRegion(viewModel, true, _regionSelectedAction);
            }
            catch (Exception e)
            {
                ShowError(e, "Error during data layer loading");
            }

        }

        private void ChargeCommissionBankPopUp()
        {
            viewModel.Title = "Consulta de Bancos";
            viewModel.QueryType = GridPopUpViewModel.QueryTypeEnum.CommissionBank; 
            viewModel.QueryTable = _bankDataTable;
            ShowRegion(viewModel, false, _regionSelectedAction);

        }

        private void ChargeCommisionAccountPopUp()
        {
            viewModel.Title = "Consulta de Cuentas Commision";
            viewModel.QueryType = GridPopUpViewModel.QueryTypeEnum.CommissionAccount; 
            viewModel.QueryTable = null;
            DataTable table = null;

            try
            {
                table = _paymentDataServices.GetAllAccountsDataTable();
            }
            catch (Exception e)
            {
                ShowError(e, "Error during data layer loading");
            }
            viewModel.QueryTable = table;
            ShowRegion(viewModel, false, _regionSelectedAction);
        } 

        private void ChargeAccountPopUp()
        {
            viewModel.Title = "Consulta de Cuentas Contables";
            viewModel.QueryType = GridPopUpViewModel.QueryTypeEnum.Account; 
            DataTable table = null;
            try
            {
                table = _paymentDataServices.GetAllAccountsDataTable();
            }
            catch (Exception e)
            {
                ShowError(e, "Error during data layer loading");
            }
            viewModel.QueryTable = table;
            ShowRegion(viewModel, false, _regionSelectedAction);
        }
        private void ShowError(Exception e, string error)
        {
            this.ErrorDialog = new InteractionRequest<INotification>();
            this.ErrorDialogCommand = new DelegateCommand(() =>
            {
                this.ErrorDialog.Raise(
                    new Notification
                    {
                        Title = error,
                        Content = e.Message
                    },
                    (dialog) =>
                    {

                    });

            });
        }

        public ICommand DataGridChangedSelection { get; set; }

        public ICommand NumberTextChanged { get; set; }


        /// <summary>
        ///  Generic command from the UI. It is a delegate command.
        /// </summary>
        public ICommand ClickCommand { get; set; }

        /// <summary>
        ///  Change of the state of the form.
        /// </summary>
        public string ChargeStateProperties
        {
            get { return _chargeStateProperties; }
            set
            {
                _chargeStateProperties = value;
                RaisePropertyChanged("ChargeStateProperties");
            }
        }



        /// <summary>
        ///  Last user that has done the modification in this table
        /// </summary>
        public string LastUser
        {
            get { return _lastUser; }
            set
            {
                _lastUser = value;
                RaisePropertyChanged("LastUser");
            }
        }

        /// <summary>
        /// The number of the charge from the customer
        /// </summary>
        public string ChargeNumber
        {
            get { return _chargeNumber; }
            set
            {
                _chargeNumber = value;
                RaisePropertyChanged("ChargeNumber");
            }
        }
        /// <summary>
        ///  The last time this record has been modified.
        /// </summary>
        public string LastModificationTime
        {
            get { return _lastModificationTime; }
            set
            {
                _lastModificationTime = value;
                RaisePropertyChanged("LastModificationTime");
            }
        }
        /// <summary>
        ///  The checkbox dependency on cash is active or not
        /// </summary>
        public bool IsDependencyOnCash
        {
            get { return _dependencyOnCash; }
            set
            {
                _dependencyOnCash = value;
                RaisePropertyChanged("IsDependencyOnCash");
            }

        }
        /// <summary>
        ///  The checkbox ask credit card is active or not.
        /// </summary>
        public bool IsAskedCreditCard
        {
            get { return _askedCreditCard; }
            set
            {
                _askedCreditCard = value;
                RaisePropertyChanged("IsAskedCreditCard");
            }
        }
        /// <summary>
        ///  The name of charging
        /// </summary>
        public string ChargeName
        {
            get { return _chargeName; }
            set
            {
                _chargeName = value;
                RaisePropertyChanged("ChargeName");
            }
        }
        /// <summary>
        ///  The account to be charged the first part.
        /// </summary>
        public string ChargeAccount1
        {
            get { return _chargeAccount1; }
            set
            {
                _chargeAccount1 = value;
                RaisePropertyChanged("ChargeAccount1");
            }
        }
        /// <summary>
        ///  The account to be charged the second part
        /// </summary>
        public string ChargeAccount2
        {
            get { return _chargeAccount2; }
            set
            {
                _chargeAccount2 = value;
                RaisePropertyChanged("ChargeAccount2");
            }
        }
        /// <summary>
        ///  The charge commission account, the first part.
        /// </summary>
        public string ChargeCommissionAccount1
        {
            get { return _chargeCommissionAccount; }
            set
            {
                _chargeCommissionAccount = value;
                RaisePropertyChanged("ChargeCommissionAccount1");
            }
        }
        /// <summary>
        ///  The charge commission account, second part.
        /// </summary>
        public string ChargeCommissionAccount2
        {
            get { return _chargeCommissionAccount2; }
            set
            {
                _chargeCommissionAccount2 = value;
                RaisePropertyChanged("ChargeCommissionAccount2");
            }
        }
        /// <summary>
        ///  The commission percentage value
        /// </summary>
        public string CommissionPercentage
        {
            get { return _commissionPercentage; }
            set
            {
                _commissionPercentage = value;
                RaisePropertyChanged("CommissionPercentage");
            }
        }
        /// <summary>
        ///  The commission bank value
        /// </summary>
        public string CommissionBank
        {
            get { return _commissionBank; }
            set
            {
                _commissionBank = value;
                RaisePropertyChanged("CommissionBank");
            }
        }
        /// <summary>
        ///  The commision office value
        /// </summary>
        public string Office
        {
            get { return _office; }
            set
            {
                _office = value;
                RaisePropertyChanged("Office");
            }
        }
        /// <summary>
        ///  The commission office value 2
        /// </summary>
        public string Office2
        {
            get { return _office2; }
            set
            {
                _office2 = value;
                RaisePropertyChanged("Office2");
            }
        }
        /// <summary>
        ///  The iban value
        /// </summary>
        public string IbanValue
        {
            get { return _ibanValue; }
            set
            {
                _ibanValue = value;
                RaisePropertyChanged("IbanValue");
            }
        }
        /// <summary>
        ///  The swift value 
        /// </summary>
        public string SwiftValue
        {
            get { return _swiftValue; }
            set
            {
                _swiftValue = value;
                RaisePropertyChanged("SwiftValue");
            }
        }
        /// <summary>
        ///  The charge bank value 
        /// </summary>
        public string ChargeBank1
        {
            get { return _chargeBank1; }
            set
            {
                _chargeBank1 = value;
                RaisePropertyChanged("ChargeBank1");
            }
        }
        /// <summary>
        ///  The charge bank2 value
        /// </summary>
        public string ChargeBank2
        {
            get { return _chargeBank2; }
            set
            {
                _chargeBank2 = value;
                RaisePropertyChanged("ChargeBank2");
            }
        }

        /// <summary>
        ///  The billing value first part 
        /// </summary>
        public string Billing1
        {
            get { return _billing1; }
            set
            {
                _billing1 = value;
                RaisePropertyChanged("Billing1");
            }
        }
        /// <summary>
        ///  The billing value second part
        /// </summary>
        public string Billing2
        {
            get { return _billing2; }
            set
            {
                _billing2 = value;
                RaisePropertyChanged("Billing2");
            }
        }
        /// <summary>
        ///  The client account checked.
        /// </summary>
        public bool IsClientAccountChecked
        {
            get { return _isClientAccountChecked; }
            set
            {
                _isClientAccountChecked = value;
                RaisePropertyChanged("IsClientAccountChecked");
            }
        }
        /// <summary>
        ///  The client account checked.
        /// </summary>
        public bool IsAllShowerChecked
        {
            get { return _isAllShowerChecked; }
            set
            {
                _isAllShowerChecked = value;
                RaisePropertyChanged("IsAllShowerChecked");
            }
        }
        /// <summary>
        ///  The client account checked.
        /// </summary>
        public bool IsTeleCheckChecked
        {
            get { return _isTeleCheck; }
            set
            {
                _isTeleCheck = value;
                RaisePropertyChanged("IsTeleCheckChecked");
            }
        }
        // <summary>
        ///  Is portfolio effect checked.
        /// </summary>
        public bool IsPortfolioEffectChecked
        {
            get { return _isPortfolioEffectChecked; }
            set
            {
                _isPortfolioEffectChecked = value;
                RaisePropertyChanged("IsPortfolioEffectChecked");
            }
        }
        // <summary>
        ///  It is remittable checked.
        /// </summary>
        public bool IsRemittableChecked
        {
            get { return _isRemittableChecked; }
            set
            {
                _isRemittableChecked = value;
                RaisePropertyChanged("IsRemittableChecked");
            }
        }

        // <summary>
        ///  It is remittable checked.
        /// </summary>
        public bool IsMultiSeatCommission
        {
            get { return _isMultiSeatCommissionChecked; }
            set
            {
                _isMultiSeatCommissionChecked = value;
                RaisePropertyChanged("IsMultiSeatCommission");
            }
        }
        // <summary>
        ///  It is not auto list
        /// </summary>
        public bool IsNoAutoList
        {
            get { return _isNoAutoListChecked; }
            set
            {
                _isNoAutoListChecked = value;
                RaisePropertyChanged("IsNoAutoList");
            }
        }
        public DataTable SourceTable
        {
            get { return _sourceDataTable; }
            set
            {
                _sourceDataTable = value;
                RaisePropertyChanged("SourceTable");
            }
        }
        /// <summary>
        ///  This is the header of a column
        /// </summary>
        public String HeaderCol1
        {
            get { return _dataGridColName1; }
            set
            {
                _dataGridColName1 = value;
                RaisePropertyChanged("HeaderCol1");
            }
        }
        /// <summary>
        ///  This is the header of a column
        /// </summary>
        public string HeaderCol2
        {
            get { return _dataGridColName2; }
            set
            {
                _dataGridColName2 = value;
                RaisePropertyChanged("HeaderCol2");
            }
        }

        /// <summary>
        ///  The selectedIndex in the datagrid.
        /// </summary>
        public int SelectedIndex
        {
            get { return _selectedIndex; }
            set
            {
                _selectedIndex = value;
                RaisePropertyChanged();
            }
        }
        /// <summary>
        ///  Delegate command to the value.
        /// </summary>
        /// <param name="param"></param>
        public void OnClickCommand(string param)
        {
            if (_currentClickCommand.ContainsKey(param))
            {
                DelegateCommand cmd;
                if (_currentClickCommand.TryGetValue(param, out cmd))
                {
                    cmd.Execute();
                }
            }

        }

        private void ShowRegion(GridPopUpViewModel viewModel, bool gridQueryOffices, DelegateCommand<object> regionSelectionAction)
        {
            UserControl rightRegionView;
            viewModel.RegionSelectionAction = regionSelectionAction;

            if (gridQueryOffices)
            {
                rightRegionView = new GridQueryOffices(viewModel);
            }
            else
            {
                rightRegionView = new GridQuery(viewModel);
            }

            //rightRegionView.DataContext = viewModel;
            IRegion region = _regionManager.Regions["SearchRegion"];
            region.RemoveAll();
            region.Add(rightRegionView);

        }
    }
}
