using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Prism.Mvvm;
namespace KarveCommon.Generic
{
    /// <summary>
    /// View model base.
    /// </summary>
    public class KarveViewModelBase: BindableBase
    {
        private string _sqlQuery;
        
        public KarveViewModelBase()
        {       
        }
       
        public string Query
        {
            set
            {
                _sqlQuery = value;
                RaisePropertyChanged("Query");
            }
            get { return _sqlQuery; }

        }
    }
}
