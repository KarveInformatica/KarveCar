using System.Collections.Generic;
using System.Windows.Controls;
using KarveCommon.Generic;
using KarveControls.UIObjects;
using MasterModule.Interfaces;
using MasterModule.ViewModels;

namespace MasterModule.Views
{
    /// <summary>
    /// Interaction logic for CommissionAgentInfoView.xaml
    /// </summary>
    public partial class CommissionAgentInfoView : UserControl, ICommissionAgentView
    {
        private bool loaded = false;

        private delegate void DiscoverField();

        private event DiscoverField FieldLoad;

        public CommissionAgentInfoView()
        {
            var obj = this.DataContext;
            InitializeComponent();
           // Loaded += OnLoad;
            FieldLoad += OnUpdate;

            LayoutUpdated += (o, e) =>
            {
                if (!loaded && (this.ActualHeight > 0 || this.ActualWidth > 0))
                {
                    // You can also unsubscribe event here.
                    loaded = true;
                    FieldLoad?.Invoke();
                }
            };
        }
        
    /// <summary>
        ///  In this point i can get all the item for the visual tree.
        /// </summary>
        /// <param name="sender">Value sent for the layout</param>
        /// <param name="eventArgs">Arguments to be sent</param>
        private void OnUpdate()
        {
            // at this point i can get all the item for the visual tree.
            var allDataFields = this.Descendants();
            IDictionary<string,string> tableFields = new Dictionary<string, string>();
            IDictionary<string,string> assistTableFields = new Dictionary<string, string>();
            CommissionAgentInfoViewModel vm = (CommissionAgentInfoViewModel) this.DataContext;
            // ok i aspect a property.
           // SqlBuilder.SqlGetFields(allDataFields, ref tableFields, ref assistTableFields);
            vm.AssistQueryDictionary = assistTableFields;
            vm.QueryDictionary = tableFields;
           
        }

        public string Header
        { set; get; }
    }
}
