using KarveDataServices;

namespace DataAccessLayer
{
    internal class OfficeDataService: IOfficeDataService
    {
        private ISqlExecutor sqlExecutor;

        public OfficeDataService(ISqlExecutor sqlExecutor)
        {
            this.sqlExecutor = sqlExecutor;
        }
    }
}