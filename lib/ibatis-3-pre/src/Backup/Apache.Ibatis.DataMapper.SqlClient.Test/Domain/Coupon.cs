

using System.Collections;
using System.Collections.Generic;

namespace Apache.Ibatis.DataMapper.SqlClient.Test.Domain
{
    public class Coupon
    {
        private int id;
        private string _code;

        public virtual int Id
        {
            get { return id; }
            set { id = value; }
        }

        public string Code
        {
            get { return _code; }
            set { _code = value; }
        }

        private IList<int> _brandIds = new List<int>();
         
        public IList<int> BrandIds
        {
            get { return _brandIds; }
            set { _brandIds = value; }
        }

    }
}
