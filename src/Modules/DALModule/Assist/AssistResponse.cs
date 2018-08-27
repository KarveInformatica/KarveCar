using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KarveDataServices;
using KarveDataServices.Assist;
using KarveDataServices.ViewObjects;
using Syncfusion.UI.Xaml.Grid;
using KarveCommon.Generic;
using DataAccessLayer.Logic;
using AutoMapper;

namespace DataAccessLayer.Assist
{
    /// <summary>
    ///  AssistResponse.
    /// </summary>
    public class AssistResponse: AssistResponseBase, IAssistHandler
    {
        IMapper _mapper;
        /// <summary>
        /// CompanyAssistResponse
        /// </summary>
        /// <param name="helper"></param>
        public AssistResponse(IHelperDataServices helper) : base(helper)
        {
            _mapper = MapperField.GetMapper();
        }
        public async Task<IAssistResult<T1>> HandleAssist<T, T1>(IAssist assist) where T : class where T1: class
        {
            var list = await HelperDataServices.GetPagedQueryDoAsync<T>(assist.Query, 1, 100);
            var count = await HelperDataServices.GetItemsCount<T>();
            var resultMapped = _mapper.Map<IEnumerable<T>, IEnumerable<T1>>(list);
            IncrementalList<T1> valueList = new IncrementalList<T1>(LoadItems);
            valueList.LoadItems(resultMapped);

            valueList = new IncrementalList<T1>((x, index)=> {

                NotifyTaskCompletion.Create(HelperDataServices.GetPagedQueryDoAsync<T>(assist.Query, index, 100), (sender, arg) =>
                {
                   if (sender is INotifyTaskCompletion<IEnumerable<T>> taskCompleted)
                    {
                        
                        if (taskCompleted.IsSuccessfullyCompleted)
                        {
                            var resultValue = _mapper.Map<IEnumerable<T>, IEnumerable<T1>>(taskCompleted.Result);
                            valueList.LoadItems(resultValue);
                        }
                    }
                });
             }) { MaxItemCount = count };

            
            T1 assistResult =valueList.FirstOrDefault();
            IAssistResult<T1> result = new AssistResult<T1>(assistResult, valueList);
            return result;
        }

        private void LoadItems(uint arg1, int arg2)
        {
         
        }
    }
}
