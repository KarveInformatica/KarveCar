using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KarveCommon.Generic;
using KarveDataServices;

namespace HelperModule.ViewModels
{

    public class HelperSaver<Dto, Entity> where Entity: class
    {
        private IDataServices _services;
       public HelperSaver(IDataServices services)
        {
            _services = services;
        }
     
        public async Task<bool> SaveDto(Dto savedDto)
        {
             bool value = await _services.GetHelperDataServices().ExecuteInsertOrUpdate<Dto,Entity>(savedDto);
            return value;
        }
    }
   }
