using KarveControls.Generic;
using System.Windows;
using KarveDataServices.DataTransferObject;

namespace KarveControls.Behaviour
{
   
    /// <summary>
    ///  ChangeRuleBehavior
    /// </summary>
    public class ChangeRuleBehavior: KarveBehaviorBase<DualFieldSearchBox>
    {
        /// <summary>
        ///  This is a property for the change the behaviour
        /// </summary>
        /// 
        public static readonly DependencyProperty relatedPathProperty =
            DependencyProperty.Register("RelatedPath", typeof(string), typeof(ChangeRuleBehavior));

        /// <summary>
        ///  This is a property for the change the behaviour
        /// </summary>
        /// 
        public static readonly DependencyProperty PathProperty =
            DependencyProperty.Register("Path", typeof(string), typeof(ChangeRuleBehavior));

        /// <summary>
        ///  This is a property for the change the behaviour
        /// </summary>
        /// 
        public static readonly DependencyProperty dataObjectProperty =
            DependencyProperty.Register("DataObject", typeof(object), typeof(ChangeRuleBehavior));

        /// <summary>
        /// 
        /// </summary>
        public static readonly DependencyProperty relatedObjectProperty =
           DependencyProperty.Register("RelatedObject", typeof(FrameworkElement), typeof(ChangeRuleBehavior));



        /// <summary>
        ///  RelatedPath is the related to the properties. 
        /// </summary>
        public string RelatedPath
        {
            set
            {
                SetValue(relatedPathProperty, value);
            }
            get
            {
                return (string) GetValue(relatedPathProperty);
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
        ///  RelatedObject is the related to the properties. 
        /// </summary>
        public object RelatedObject
        {
            set
            {
                SetValue(relatedObjectProperty, value);
            }
            get
            {
                return GetValue(relatedObjectProperty);
            }
        }
        /// <summary>
        ///  DataObject is the object to be used.
        /// </summary>
        public object DataObject
        {
            set
            {
                SetValue(dataObjectProperty, value);
            }
            get
            {
                return GetValue(dataObjectProperty);
            }
        }
       

        protected override void OnSetup()
        {
            this.AssociatedObject.DataSearchTextBoxChanged += AssociatedObject_DataSearchTextBoxChanged;

        }


        private void AssociatedObject_DataSearchTextBoxChanged(object sender, RoutedEventArgs e)
        {
            ExecuteRules(DataObject);
        }

        /// <summary>
        /// Cleanup the behavior.
        /// </summary>
        protected override void OnCleanup()
        {
            this.AssociatedObject.DataSearchTextBoxChanged -= AssociatedObject_DataSearchTextBoxChanged;
            
        }

        private void SetValues(string provinceValue, string provField, string proveExt, object newDataObject)
        {
            var prov = ComponentUtils.GetTextDo(newDataObject, provField, ControlExt.DataType.Any);
            if (!string.IsNullOrEmpty(prov))
            {
                ComponentUtils.SetPropValue(newDataObject, provField, provinceValue);
            }
            else
            {
                var provincia =
                    ComponentUtils.GetTextDo(newDataObject, proveExt, ControlExt.DataType.Any);
                if (!string.IsNullOrEmpty(provincia))
                {
                    ComponentUtils.SetPropValue(newDataObject, proveExt, provinceValue);
                }
            }
        }

        private void ExecuteRuleOnPobla(object newValue)
        {
            var newDataObject = newValue;
            var box = this.RelatedObject as DualFieldSearchBox;


            var cpValue = ComponentUtils.GetTextDo(newDataObject, "POBLACION", ControlExt.DataType.Any);
            if (!string.IsNullOrEmpty(cpValue))
            {
                var provinceValue = cpValue.Substring(0, 2);
                if (newValue is BaseDto)
                {
                    SetValues(provinceValue, "PROV", "PROVINCIA", newDataObject);
                }
                else
                {
                    SetValues(provinceValue, "Value.PROV", "Value.PROVINCIA", newDataObject);
                }

            }
        }
        private void ExecuteRules(object newValue)
        {
            var newDataObject = newValue;
            var box = this.RelatedObject as DualFieldSearchBox;

           
            var cpValue = ComponentUtils.GetTextDo(newDataObject, "CP", ControlExt.DataType.Any);
            if (cpValue != null)
            {
                var provinceValue = cpValue.Substring(0, 2);
                if (newValue is BaseDto)
                {
                    SetValues(provinceValue, "PROV", "PROVINCIA", newDataObject);                    
                }
                else
                {
                    SetValues(provinceValue, "Value.PROV", "Value.PROVINCIA", newDataObject);
                }

            }
            ExecuteRuleOnPobla(newValue);

            /*
             * Basically this does the same as above but with the related paths.
             */
            if (!string.IsNullOrEmpty(RelatedPath))
            {
                var relatedValue = ComponentUtils.GetTextDo(newDataObject, Path, ControlExt.DataType.Any);
                if (!string.IsNullOrEmpty(relatedValue))
                {
                    var provinceValue = relatedValue.Substring(0, 2);
                    string pathStr;
                    if (newDataObject is BaseDto)
                    {
                        pathStr = RelatedPath;
                    }
                    else
                    {
                        pathStr = "Value." + RelatedPath;

                    }
                    ComponentUtils.SetPropValue(newDataObject, pathStr, provinceValue);                    
                }
            }
            if (box != null)
            {
                box.DataView = newDataObject;
            }
        }
    }
}
