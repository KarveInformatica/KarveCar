using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Prism.Mvvm;
using KarveDataServices;
namespace KarveCommon.Generic
{
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
