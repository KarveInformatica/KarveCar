using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Runtime.Serialization;
using System.Threading.Tasks;
using KarveDataServices;
using KarveDataServices.DataTransferObject;

namespace DataAccessLayer.MongoDB
{
    [Serializable]
    internal class MongoSettingsDataAccessLayer : ISettingsDataServices
    {
        public MongoSettingsDataAccessLayer()
        {
        }

        public Task<GridSettingsDto> GetMagnifierSettings(long idValue)
        {
            throw new NotImplementedException();
        }

        public Task<bool> SaveMagnifierSettings(GridSettingsDto settingsDto)
        {
            throw new NotImplementedException();
        }

        public Task<ObservableCollection<GridSettingsDto>> GetMagnifierSettingByIds(List<long> registeredGridIds)
        {
            throw new NotImplementedException();
        }
    }
}