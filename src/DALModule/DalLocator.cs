﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace DataAccessLayer
{
    public class DalLocator: IDalLocator
    {
        private IDictionary<string, IDalObject> dalObjects = new Dictionary<string, IDalObject>();

        private static DalLocator _locator = null;
        public static DalLocator GetInstance()
        {
            if (_locator == null )
            {
                _locator = new DalLocator();
            }
            return _locator;
        }
        public IDalObject FindDalObject(string name)
        {
            IDalObject result;
            dalObjects.TryGetValue(name, out result);
            return result;
        }
        private void AddLayer(IDalObject dalObject)
        {
            if (dalObject != null)
            {
                 dalObjects.Add(dalObject.Id, dalObject);
            }
        }
        public DalLocator()
        {
            BanksDataAccessLayer banksDataAccessLayer = null;
            ChargeTypeDataAccessLayer chargeTypeDataAccessLayer = null;
            // check if it is working again.
            try
            {
                banksDataAccessLayer = new BanksDataAccessLayer();
                chargeTypeDataAccessLayer = new ChargeTypeDataAccessLayer();
                AddLayer(chargeTypeDataAccessLayer);
				AddLayer(banksDataAccessLayer);
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
         
        }
    }
}
