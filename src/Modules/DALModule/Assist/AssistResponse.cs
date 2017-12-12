using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KarveDataServices;
using KarveDataServices.Assist;
using KarveDataServices.DataTransferObject;

namespace DataAccessLayer.Assist
{
    /// <summary>
    ///  AssistResponse.
    /// </summary>
    public class AssistResponse: AssistResponseBase, IAssistHandler
    {
        /// <summary>
        /// CompanyAssistResponse
        /// </summary>
        /// <param name="helper"></param>
        public AssistResponse(IHelperDataServices helper) : base(helper)
        {
            
        }
        
        public async Task<IAssistResult<T>> HandleAssist<T>(IAssist assist)
        {
            IEnumerable<T> outEnumerable = await HelperDataServices.GetAsyncHelper<T>(assist.Query);
            IAssistResult<T> result = new AssistResult<T>(outEnumerable.FirstOrDefault(), outEnumerable);
            return result;
        }
    }
}
