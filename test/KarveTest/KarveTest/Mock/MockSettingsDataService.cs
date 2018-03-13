using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Runtime.Serialization;
using System.Threading.Tasks;
using KarveDataServices;
using KarveDataServices.DataTransferObject;

namespace KarveTest.Mock
{
    [Serializable]
    internal class MockSettingsDataService : ISettingsDataServices
    {
        public MockSettingsDataService()
        {
        }

        public Task<ObservableCollection<GridSettingsDto>> GetMagnifierSettingByIds(List<long> registeredGridIds)
        {
            throw new NotImplementedException();
        }

        public Task<GridSettingsDto> GetMagnifierSettings(long idValue)
        {
            throw new NotImplementedException();
        }

        public Task<bool> SaveMagnifierSettings(GridSettingsDto settingsDto)
        {
            throw new NotImplementedException();
        }
    }
}