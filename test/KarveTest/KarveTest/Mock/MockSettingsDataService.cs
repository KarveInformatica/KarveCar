using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Threading.Tasks;
using KarveDataServices;

namespace KarveTest.Mock
{
    [Serializable]
    internal class MockSettingsDataService : ISettingsDataService
    {
        public MockSettingsDataService()
        {
        }

        public Task<int> CreateMagnifierColumn(IMagnifierColumns col)
        {
            throw new NotImplementedException();
        }

        public Task DeleteMagnifier(int i)
        {
            throw new NotImplementedException();
        }

        public Task<IList<IMagnifierSettings>> GetAllMagnifiersSettings()
        {
            throw new NotImplementedException();
        }

        public Task<IMagnifierSettings> GetMagnifierSettings(long idValue)
        {
            throw new NotImplementedException();
        }

        public IMagnifierColumns NewMagnifierColumn()
        {
            throw new NotImplementedException();
        }

        public IMagnifierSettings NewMagnifierSettings()
        {
            throw new NotImplementedException();
        }

        public Task<bool> SaveAllMagnifierSettings(IList<IMagnifierSettings> magnifier)
        {
            throw new NotImplementedException();
        }

        public Task<bool> SaveColumnsSettings(IList<IMagnifierColumns> colums)
        {
            throw new NotImplementedException();
        }

        public Task<bool> SaveMagnifierSettings(IMagnifierSettings value)
        {
            throw new NotImplementedException();
        }
    }
}