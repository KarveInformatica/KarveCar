using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MasterModule.Views.VehicleAssurance.MockViewModels
{
    /// <summary>
    ///  UiComposedMetaObject
    /// </summary>
    public class UiComposedFieldObject
    {
        /// <summary>
        ///  LabelSource 
        /// </summary>
        public string LabelSource { get; set; }
        /// <summary>
        ///  DataSource 1
        /// </summary>
        public object DataSource { get; set; }
        /// <summary>
        ///  DataSource 2
        /// </summary>
        public string DataSourcePath1 { set; get; }

        /// <summary>
        ///  DataSource 2
        /// </summary>
        public string DataSourcePath2 { set; get; }
        /// <summary>
        ///  DataSource 2
        /// </summary>
        public string DataSourcePath3 { set; get; }
        
    }
}
