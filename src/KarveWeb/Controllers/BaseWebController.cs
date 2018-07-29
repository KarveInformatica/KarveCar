using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KarveCommon.Generic;
using KarveDataServices;
using KarveDataServices.DataTransferObject;
using Microsoft.AspNetCore.Mvc;
using System.Web.Http;

namespace KarveWeb.Controllers
{

    [Route("api/[controller]")]
    public class BaseController<DomainInterface,SummaryType,DtoType> : Controller where SummaryType: class 
                                                                             where DtoType: class
                                                                            where DomainInterface: IValueObject<DtoType> 
                        
    {
        private IDataProvider<DomainInterface, SummaryType> _storage;
        protected int CurrentIndex = 1;
        protected int DefaultPageSize = 25;
        public BaseController(IDataProvider<DomainInterface, SummaryType> storage)
        {
            _storage = storage;
        }

        [HttpGet]
        public IEnumerable<SummaryType> Get()
        {

            IEnumerable<SummaryType> result = new List<SummaryType>();
            NotifyTaskCompletion.Create<IEnumerable<SummaryType>>(_storage.GetPagedSummaryDoAsync(CurrentIndex, DefaultPageSize), (sender, ev) =>
            {
                var value = sender as INotifyTaskCompletion<IEnumerable<SummaryType>>;
                if (value != null)
                {
                    if (value.IsSuccessfullyCompleted)
                    {
                        result = value.Task.Result;
                    }
                };
            }
            return result;
        }

        [HttpGet("{id}")]
        public async Task<DtoType> Get(string id)
        {
            var client = await _storage.GetDoAsync(id);
            if (client is IValueObject<DtoType> valueObject)
            {
                return valueObject.Value;
            }
            return Activator.CreateInstance<DtoType>();
        }
        [HttpPost("{id}")]
        public async void Post(string id, [FromBody]DtoType value)
        {
            var domainObject = _storage.GetNewDo(id);
            domainObject.Value = value;
            var ret = await _storage.SaveAsync(domainObject);
            if (!ret)
            {
                throw new HttpResponseException("Cannot save identifier", HttpStatusCode.BadRequest);
            }
        }
    }
    
}
