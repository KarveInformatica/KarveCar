using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using KarveCommon.Services;
using KarveDataServices;
using MasterModule.Common;
using MasterModule.UIObjects.CommissionAgents;
using Prism.Commands;

namespace MasterModule.ViewModels
{
    public class CommissionAgentInfoViewModel: MasterViewModuleBase,IEventObserver
    {
        private Visibility _visibility;
        private DataTable _commissionDataTable;
        private DataTable _assistDataTable;

        public CommissionAgentInfoViewModel(IConfigurationService configurationService, 
                                            IEventManager eventManager, IDataServices services) : base(configurationService, eventManager, services)
        {
            LoadUserInterfaceObjects();
            ConfigurationService = configurationService;
            MailBoxHandler += MessageHandler;
            _visibility = Visibility.Collapsed;
            _assistDataTable = new DataTable();
            _commissionDataTable= new DataTable();
            EventManager.registerObserverSubsystem(MasterModule.CommissionAgentSystemName, this);
        }
        /// <summary>
        ///  This load the user interface object for the upper part.
        /// </summary>
        private void LoadUserInterfaceObjects()
        {
            UiCommissionAgentUpperPartBuilder builderUpperPart = new UiCommissionAgentUpperPartBuilder();
      //      builderUpperPart.BuildPageObjects()
        }
        /// <summary>
        ///  This returns an assist table.
        /// </summary>
        public DataTable AssistTable
        {
            get { return _assistDataTable; }
            set { _assistDataTable = value; }
        }
        /// <summary>
        ///  This returns a data table for binding the objects.
        /// </summary>
        public DataTable CommissionTable
        {
            get
            {
                return _commissionDataTable;
            }
            set { _commissionDataTable = value; }
            
        }
        /// <summary>
        ///  This return the magnifier button
        /// </summary>
        public string MagnifierButtonImage
        {
            get { return MasterModule.ImagePath; }
        }

        public ICommand MagnifierCommand { set; get; }
        public ICommand ItemChangedCommand { set; get; }
        public Visibility IsVisible
        {
            get { return _visibility; }
            set { _visibility = value; }
        }

        /// <summary>
        ///  Return the commissionist table.
        /// </summary>
        public string TableName
        {
            get { return "COMISIO"; }
        }

        public override void StartAndNotify()
        {
            throw new NotImplementedException();
        }

        public override void NewItem()
        {
            throw new NotImplementedException();
        }

        protected override void SetTable(DataTable table)
        {
            throw new NotImplementedException();
        }

        protected override void SetRegistrationPayLoad(ref DataPayLoad payLoad)
        {
            throw new NotImplementedException();
        }

        protected override string GetRouteName(string name)
        {
            throw new NotImplementedException();
        }

        public void incomingPayload(DataPayLoad payload)
        {
            throw new NotImplementedException();
        }
    }
}
