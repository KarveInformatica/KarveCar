using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using KarveDataServices;
using KarveDataServices.DataTransferObject;

namespace DataAccessLayer.MongoDB
{
    internal class SettingsMongoDBServices : ISettingsDataService
    {
        private object _executor;

        public SettingsMongoDBServices(object executor)
        {
            _executor = executor;
        }

        public Task<ObservableCollection<GridSettingsDto>> GetMagnifierSettingByIds(List<long> registeredGridIds)
        {
            throw new System.NotImplementedException();
        }

        public Task<GridSettingsDto> GetMagnifierSettings(long idValue)
        {
            throw new System.NotImplementedException();
        }

        public Task<bool> SaveMagnifierSettings(GridSettingsDto settingsDto)
        {
            throw new System.NotImplementedException();
        }
    }
}