using System;
using System.Collections;
using System.Collections.Generic;

namespace Apache.Ibatis.DataMapper.SqlClient.Test.Domain.Petshop
{
    /// <summary>
    /// Business entity used to model category
    /// </summary>
    [Serializable]
    public class Category
    {
        private string _Id;
        private string _name;
        private string _description;
        private IList _products = new ArrayList();

        private IList<Guid> productsId = new List<Guid>();

        public IList<Guid> ProductKeys
        {
            get { return productsId; }
            set { productsId = value; }
        }

        private IList<Product> _genericList;
        public IList<Product> GenericProducts
        {
            get { return _genericList; }
            set { _genericList = value; }
        }


        #region Properties
        public string Id
        {
            get { return _Id; }
            set { _Id = value; }
        }

        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }


        public string Description
        {
            get { return _description; }
            set { _description = value; }
        }

        public IList Products
        {
            get { return _products; }
            set { _products = value; }
        }
        #endregion
    }
}