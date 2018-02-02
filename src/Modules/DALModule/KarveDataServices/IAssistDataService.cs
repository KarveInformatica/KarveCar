using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KarveDataServices
{
    public interface IAssistDataService
    {
        /// <summary>
        ///  This returns a data service
        /// </summary>
        /// <param name="assistName"></param>
        /// <param name="query"></param>
        /// <returns></returns>
        Task<IValueObject> Serve(string assistName, string query);
    }
}
