using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer.DataObjects;
using KarveCommon.Services;
using KarveDataServices;
using KarveDataServices.DataTransferObject;
using Prism.Regions;

namespace HelperModule.ViewModels
{
    /// <summary>
    /// VisitTypeViewModel.
    /// </summary>
    class VisitTypeViewModel : GenericHelperViewModel<VisitTypeDto, TIPOVISITAS>
    {
        /// <summary>
        ///  VisitType view model
        /// </summary>
        /// <param name="dataServices">Tipo de visita</param>
        /// <param name="region">Region</param>
        /// <param name="manager">Manager</param>
        public VisitTypeViewModel(IDataServices dataServices, IRegionManager region, IEventManager manager) : base(String.Empty, dataServices, region, manager)
        {
            GridIdentifier = KarveCommon.Generic.GridIdentifiers.VisitType;
        }
        /// <summary>
        ///  Codigo 
        /// </summary>
        /// <param name="payLoad">payload</param>
        /// <param name="dataServices">dataservice</param>
        /// <returns></returns>
        public override async Task<DataPayLoad> SetCode(DataPayLoad payLoad, IDataServices dataServices)
        {
            IHelperDataServices helperDal = DataServices.GetHelperDataServices();
            VisitTypeDto dto = payLoad.DataObject as VisitTypeDto;
            if (dto != null)
            {
                string codeId = await helperDal.GetMappedUniqueId<VisitTypeDto, TIPOVISITAS>(dto);
                dto.Code = codeId.Substring(0, 4);
                payLoad.DataObject = dto;
            }
            return payLoad;
        }
    }
}
