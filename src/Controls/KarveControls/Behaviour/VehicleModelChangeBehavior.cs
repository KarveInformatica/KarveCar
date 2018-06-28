using KarveCommon;
using KarveCommon.Generic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using static DualFieldSearchBox.DualFieldSearchBox;
using KarveDataServices.DataTransferObject;

namespace KarveControls.Behaviour
{
    public class VehicleModelChangeBehavior: KarveBehaviorBase<DualFieldSearchBox>
    {

        /// <summary>
        ///  This is a property for the change the behaviour
        /// </summary>
        /// 
        public static readonly DependencyProperty RelatedBrandPathProperty =
            DependencyProperty.Register("RelatedBrandPath", typeof(string), typeof(VehicleModelChangeBehavior));

        /// <summary>
        ///  This is a property for the change the behaviour
        /// </summary>
        /// 
        public static readonly DependencyProperty PathProperty =
            DependencyProperty.Register("Path", typeof(string), typeof(VehicleModelChangeBehavior));

        /// <summary>
        ///  This is a property for the change the behaviour
        /// </summary>
        /// 
        public static readonly DependencyProperty variantPathProperty =
            DependencyProperty.Register("RelateVariantPath", typeof(string), typeof(VehicleModelChangeBehavior));

        /// <summary>
        ///  This is a property for the change the behaviour
        /// </summary>
        /// 
        public static readonly DependencyProperty DataObjectProperty =
            DependencyProperty.Register("DataObject", typeof(object), typeof(VehicleModelChangeBehavior));

        /// <summary>
        /// 
        /// </summary>
        public static readonly DependencyProperty RelatedBrandObjectProperty =
           DependencyProperty.Register("RelatedBrandObject", typeof(FrameworkElement), typeof(VehicleModelChangeBehavior));

        /// <summary>
        /// 
        /// </summary>
        public static readonly DependencyProperty RelatedVariantObjectProperty =
           DependencyProperty.Register("RelatedVariantObject", typeof(FrameworkElement), typeof(VehicleModelChangeBehavior));

        /// <summary>
        ///  RelatedPath is the related to the properties. 
        /// </summary>
        public string RelatedBrandPath
        {
            set
            {
                SetValue(RelatedBrandPathProperty, value);
            }
            get
            {
                return (string)GetValue(RelatedBrandPathProperty);
            }
        }
        /// <summary>
        ///  Path is the related to the properties. 
        /// </summary>
        public string Path
        {
            set
            {
                SetValue(PathProperty, value);
            }
            get
            {
                return (string)GetValue(PathProperty);
            }
        }

        /// <summary>
        ///  OnAttached property. Attach the property to an item.
        /// </summary>
        protected override void OnSetup()
        {
            this.AssociatedObject.DataSearchTextBoxChanged += AssociatedObject_DataSearchTextBoxChanged;
            this.AssociatedObject.SearchBoxResolvedEventHandler += AssociatedObject_SearchBoxResolvedEventHandler;

        }

        private void AssociatedObject_SearchBoxResolvedEventHandler(object sender, RoutedEventArgs e)
        {
            
            if (this.AssociatedObject.SelectedObject is ModelVehicleDto modelVehicleDto)
            {
                ExecuteRuleWithCode(modelVehicleDto.Marca);
            }
            SetVariant();

        }
        private void SetVariant()
        {
            var box = this.RelatedVariantObject as DataField;
            if (box != null)
            {
                var variante = ComponentUtils.GetTextDo(DataObject, "Value.VARIANTE", DataType.Any);

                if (!string.IsNullOrEmpty(variante))
                {
                    box.TextContent = variante;
                }
            }
        }
        private void ExecuteRuleWithCode(string brandCode)
        {
            if (string.IsNullOrEmpty(brandCode))
                return;
            var provinceDto = this.RelatedBrandObject as DualFieldSearchBox;
            if (provinceDto != null)
            {
                provinceDto.TextContentFirst = brandCode;
            }
        }
        private void AssociatedObject_DataSearchTextBoxChanged(object sender, RoutedEventArgs e)
        {
            var value = e;
            var brandValue = ComponentUtils.GetTextDo(DataObject, "Value.MAR", DataType.Any);
            if (!string.IsNullOrEmpty(brandValue))
            {
                var brand = RelatedBrandPath;
                ExecuteRuleWithCode(brandValue);
                SetVariant();
            }
        }
        /// <summary>
        ///  Detach the attached values.
        /// </summary>
        protected override void OnCleanup()
        {
            this.AssociatedObject.DataSearchTextBoxChanged -= AssociatedObject_DataSearchTextBoxChanged;
            this.AssociatedObject.SearchBoxResolvedEventHandler -= AssociatedObject_SearchBoxResolvedEventHandler;
        }


        /// <summary>
        ///  RelatedObject is the related to the properties. 
        /// </summary>
        public object RelatedVariantObject
        {
            set
            {
                SetValue(RelatedVariantObjectProperty, value);
            }
            get
            {
                return GetValue(RelatedVariantObjectProperty);
            }
        }
        /// <summary>
        ///  RelatedObject is the related to the properties. 
        /// </summary>
        public object RelatedBrandObject
        {
            set
            {
                SetValue(RelatedBrandObjectProperty, value);
            }
            get
            {
                return GetValue(RelatedBrandObjectProperty);
            }
        }
        /// <summary>
        ///  DataObject is the object to be used.
        /// </summary>
        public object DataObject
        {
            set
            {
                SetValue(DataObjectProperty, value);
            }
            get
            {
                return GetValue(DataObjectProperty);
            }
        }

    }
}
