using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MasterModule.ViewModels.MocksViewModel
{
    public class VehicleRevisionMockViewModel: BindableBase
    {
        /// <summary>
        ///  DataExpire value.
        /// </summary>
        public class DataExpire
        {
            // value in data
            public DateTime Value { set; get; }
        }
        /// <summary>
        ///  Revision Object liast
        /// </summary>
        
        public class RevisionObject
        {
            /// <summary>
            ///  text string of the revision object
            /// </summary>
            public string Text { set; get; }
            /// <summary>
            ///  Data expire of the revision object
            /// </summary>
            public DataExpire Expire { set; get; }
            /// <summary>
            ///  Summary data expire path of the revision object
            /// </summary>
            public string DataExpirePath { set; get; }
        };

        public List<RevisionObject> _revisionListObject = new List<RevisionObject>();
        /// <summary>
        ///  View model mock.
        /// </summary>
        public VehicleRevisionMockViewModel()
        {
            DataExpire expire = new DataExpire();
            expire.Value = DateTime.Now;
            RevisionObject list0 = new RevisionObject()
            {
                Text = "Revision 1",
                Expire = expire,
                DataExpirePath = "Value"

            };

            RevisionObject list1 = new RevisionObject()
            {
                Text = "Revision 2",
                Expire = expire,
                DataExpirePath = "Value"

            };
            RevisionObject list2 = new RevisionObject()
            {
                Text = "Revision 3",
                Expire = expire,
                DataExpirePath = "Value"

            };
            _revisionListObject.Add(list0);
            _revisionListObject.Add(list1);
            _revisionListObject.Add(list2);
        }

        /// <summary>
        ///  MetadataObject list.
        /// </summary>
        public object MetaDataObject {
            set
            {
                _revisionListObject = (List<RevisionObject>)value;
                RaisePropertyChanged();
            }
            get
            {
                return _revisionListObject;
            }
        }
    }
}
