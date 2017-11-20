using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MasterModule.ViewModels.MocksViewModel
{
    /// <summary>
    ///  Expire assurance data control vm.
    /// 
    /// 
    /// </summary>
    public class AssuranceType
    {
        public AssuranceType()
        {

        }
        public DateTime DataExpire { set; get; }
        public string DataExpirePath;
        public string AmountData { set; get; }
        public string AmountDataPath { set; get; }
        public bool IsDataChecked { set; get; }
    }
    public class AssuranceTestList
    {
        private List<AssuranceType> _assuranceType = new List<AssuranceType>();
        public AssuranceTestList()
        {
            AssuranceType type1 = new AssuranceType()
            {
                DataExpire = DateTime.Now,
                DataExpirePath = "PATH",
                AmountData = "398338",
                AmountDataPath = "PATH2",
                IsDataChecked = true
            };
            AssuranceType type2 = new AssuranceType()
            {
                DataExpire = DateTime.Now,
                DataExpirePath = "PATH",
                AmountData = "398338",
                AmountDataPath = "PATH2",
                IsDataChecked = true
            };
            AssuranceType type3 = new AssuranceType()
            {
                DataExpire = DateTime.Now,
                DataExpirePath = "PATH",
                AmountData = "398338",
                AmountDataPath = "PATH2",
                IsDataChecked = true
            };
            _assuranceType.Add(type1);
            _assuranceType.Add(type2);
            _assuranceType.Add(type3);

        }
        public List<AssuranceType> AssuranceTypeTestItems
        {
            set { _assuranceType = value; }
            get { return _assuranceType; }
        }
    }

    public class ExpireAssuranceDataControlMockVM
    {
        public AssuranceTestList list = new AssuranceTestList();
        public object MetaDataObject {
                                       set { list.AssuranceTypeTestItems = (List< AssuranceType>) value; }
                                       get { return list.AssuranceTypeTestItems; }
                                     }
    }
}
