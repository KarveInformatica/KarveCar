using KarveDataServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KarveTest.DAL.Mock
{
    class SettingsDataService : ISettingsDataService
    {
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
