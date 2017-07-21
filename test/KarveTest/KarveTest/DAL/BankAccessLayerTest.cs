using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer;
using KarveCommon.Generic;
using NUnit.Framework;
namespace KarveTest.DAL
{
    [TestFixture]
    public class BankAccessLayerTest
    {
        private DalLocator _locator = DalLocator.GetInstance();
        
        [Test]
        public void GetBanks()
        {
          IDalObject dalObject = _locator.FindDalObject(Maestro.rbtnBancosClientes.ToString());
            try
            {
                GenericObservableCollection obsCollection =  dalObject.GetItems();
                Assert.Greater(obsCollection.GenericObsCollection.Count, 0);
            } catch(Exception ex)
            {
                Assert.Fail(ex.Message);
            }
        }
        [Test]
        public void SetBanks()
        {
            IDalObject dalObject = _locator.FindDalObject(Maestro.rbtnBancosClientes.ToString());
            BankDataObject newBank = new BankDataObject();
            newBank.Code = "0001";
            newBank.Name = "INTESA_SANPAOLO";
            newBank.Swift = "BCITITMMFSS";
            try
            {
                GenericObservableCollection obsCollection = dalObject.GetItems();
                obsCollection.GenericObsCollection.Add(((object) newBank));
                Assert.Greater(obsCollection.GenericObsCollection.Count, 0);
                dalObject.SetUniqueItems(obsCollection);
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.Message);
            }
        }
    }
}
