using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using KarveControls.Generic;
using Prism.Commands;

namespace MasterModule.Views.VehicleSelling
{
    /// <summary>
    /// Interaction logic for RoadTaxes.xaml
    /// </summary>
    public partial class RoadTaxes : UserControl
    {
        ComponentFiller.UiMetaObject meta = new ComponentFiller.UiMetaObject();
        public object DataObject
        {
            set
            {
                SetValue(DataObjectDepend, value);
                for (int i = 0; i < list.Count; ++i)
                {
                    list[i].DataSource = DataObject;
                }
            }

            get { return GetValue(DataObjectDepend); }
        }
        public DelegateCommand<object> Command
        {
            set
            {
                SetValue(CommandDependencyProp, value);
                for (int i = 0; i < list.Count; ++i)
                {
                    list[i].ChangedItem = value;
                }
            }
            get { return (DelegateCommand<object>)GetValue(CommandDependencyProp); }
        }
        private List<ComponentFiller.UiMetaObject> list;
        /// <summary>
        ///  Data object depedency properties.
        /// </summary>
        public DependencyProperty DataObjectDepend = DependencyProperty.Register("DataObject",
            typeof(object),
            typeof(RoadTaxes));
        /// <summary>
        ///  Command dependnecy properties.
        /// </summary>
        public DependencyProperty CommandDependencyProp = DependencyProperty.Register("ChangeCommmand",
           typeof(DelegateCommand<object>),
           typeof(RoadTaxes));
        /// <summary>
        ///  Height of the picker
        /// </summary>
      
        
        public RoadTaxes()
        {
            InitializeComponent();
            InitLabels();
        }
        private void InitLabels()
        {
            this.list = new List<ComponentFiller.UiMetaObject>
            {
                   new ComponentFiller.UiMetaObject
                   {
                       DataSource = DataObject,
                       DataSourcePath = "RENUEVA_CIRC_1",
                       LabelText="Renovación 1",
                       ChangedItem = Command
                   },
                   new ComponentFiller.UiMetaObject
                   {
                       DataSource = DataObject,
                       DataSourcePath = "RENUEVA_CIRC_2",
                       LabelText = "Renovación 2",
                       ChangedItem = Command
                   },
                   new ComponentFiller.UiMetaObject
                   {
                        DataSource = DataObject,
                        DataSourcePath = "RENUEVA_CIRC_2",
                        LabelText = "Renovación 3",
                        ChangedItem = Command
                    }
            };
            this.GridTaxLayout.DataContext = this;
           // this.TextBoxCollection.ItemsSource = list;

        }


    }
}
