using KarveDataServices.DataTransferObject;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Crud.Clients
{
    internal sealed partial class ClientDataLoader : IDataLoader<ClientDto>
    {
        private void SetHelper(dynamic currentValue, Type dtoType)
        {
            switch (dtoType.Name)
            {
                case "CityDto":
                {
                        var value = currentValue as CityDto;
                        var collectionValue = new ObservableCollection<CityDto>();
                        collectionValue.Add(value);
                        Helper.CityDto = collectionValue;
                        break;
                }
                case "ClientTypeDto":
                    {
                        var value = currentValue as ClientTypeDto;
                        var collectionValue = new ObservableCollection<ClientTypeDto>();
                        collectionValue.Add(value);
                        Helper.ClientTypeDto = collectionValue;
                        break;
                    }  

            }
        }


          
    }
}
