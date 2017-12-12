using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KarveDataServices.Assist;

namespace DataAccessLayer.Assist
{
    public class AssistResult<T> : IAssistResult<T>
    {
        private T _result;
        private IEnumerable<T> _resultList;
        /// <summary>
        ///  Assit Result.
        /// </summary>
        /// <param name="result"></param>
        /// <param name="resultList"></param>
        public AssistResult(T result, IEnumerable<T> resultList)
        {
            _result = result;
            _resultList = resultList;
        }
        public T Result()
        {
            return _result;
        }

        public IEnumerable<T> ResultList()
        {
            return _resultList;
        }
    }
}
