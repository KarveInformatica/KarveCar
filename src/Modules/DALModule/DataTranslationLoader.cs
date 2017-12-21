using System;
using KarveDataServices;

namespace DataAccessLayer
{
    /// <summary>
    ///  Loader of a data translations.
    /// </summary>
    public class DataTranslationLoader
    {
        private ISqlExecutor _sqlExecutor;
        public DataTranslationLoader(ISqlExecutor executor)
        {
            _sqlExecutor = executor;
        }
    }

}