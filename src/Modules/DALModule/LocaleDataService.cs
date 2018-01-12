using System.Collections.Generic;
using System.Globalization;
using System.Threading.Tasks;
using DataAccessLayer.DataObjects;
using KarveDataServices;
using KarveDataServices.DataTransferObject;
using KarveCommon.Generic;
using System.Data;
using Dapper;

namespace DataAccessLayer
{
    /// <summary>
    ///  Idioma supported from the data access layer.
    /// </summary>
    public enum DalSupportedLanguages
    {
        Spanish = 0, English, Portoguese, LatinSpanish, French, German, Catala, ChileanSpanish, Bulgarian, Italian
    }
    /// <summary>
    ///  This is a locale data service.
    /// </summary>
    internal sealed class LocaleDataService: ILocaleDataServices
    {
        
        private ISqlExecutor _sqlExecutor;

        private string _languageQuery = @"select ORIGINAL,TRADUC, IDIOMA from K_TRADUC WHERE IDIOMA='{0}' ORDER BY  ORIGINAL ;";
        // culutre language name.
        private IDictionary<string, int> _cultureDictionary = new Dictionary<string, int>()
        {
            {"es-ES", 0},
            {"en-GB", 1},
            {"en-US", 1},
            {"pt-PT", 2},
            {"pt-BR", 2},
            {"pt-BR", 2},
            {"es-MX", 3},
            {"pt-BR", 3},
            {"fr-FR", 4},
            {"pt-BR", 3},
            {"de-DE", 5}
        };
        private INotifyTaskCompletion<IList<LocaleDataDto>> _initializationNotifier;
        /// <summary>
        ///  Locale data service
        /// </summary>
        /// <param name="executor">Executor of the data service.</param>
        public LocaleDataService(ISqlExecutor executor)
        {
            _sqlExecutor = executor;
         
        }
        private async Task<IEnumerable<K_TRADUC>> LoadAllForThisLanguage(int langId)
        {
            IEnumerable<K_TRADUC> value;
            using (IDbConnection connection = _sqlExecutor.OpenNewDbConnection())
            {
                var query = string.Format(_languageQuery, langId);
                value = await connection.QueryAsync<K_TRADUC>(query);
            }
            return value;
        }
        public IList<LocaleDataDto> GetLocaleData(CultureInfo info)
        {
            int languageId = 1;
            bool value = _cultureDictionary.TryGetValue(info.Name, out languageId);
            IList<LocaleDataDto> localeDataDtos= new List<LocaleDataDto>();
            return localeDataDtos;
        }
    }
}
