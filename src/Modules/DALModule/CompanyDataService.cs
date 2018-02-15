using KarveDataServices;

namespace DataAccessLayer
{
    internal class CompanyDataService
    {
        private ISqlExecutor sqlExecutor;

        public CompanyDataService(ISqlExecutor sqlExecutor)
        {
            this.sqlExecutor = sqlExecutor;
        }
    }
}