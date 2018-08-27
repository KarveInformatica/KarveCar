using KarveDataServices.ViewObjects;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Crud.Clients
{
    internal sealed partial class ClientDataLoader : IDataLoader<ClientViewObject>
    {
        private void SetHelper(dynamic currentValue, Type dtoType)
        {
            switch (dtoType.Name)
            {
                case "CityViewObject":
                {
                        var value = currentValue as CityViewObject;
                        var collectionValue = new ObservableCollection<CityViewObject>();
                        collectionValue.Add(value);
                        Helper.CityDto = collectionValue;
                        break;
                }
                case "ClientTypeViewObject":
                    {
                        var value = currentValue as ClientTypeViewObject;
                        var collectionValue = new ObservableCollection<ClientTypeViewObject>();
                        collectionValue.Add(value);
                        Helper.ClientTypeDto = collectionValue;
                        break;
                    }  

            }
        }


          
    }
}
