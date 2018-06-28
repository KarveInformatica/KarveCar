using System;
using System.Threading.Tasks;
using KarveCommon.Services;
using KarveDataServices;
using DataAccessLayer.DataObjects;
using KarveDataServices.DataTransferObject;
using KarveCommonInterfaces;
using Prism.Regions;

namespace HelperModule.ViewModels
{
    /// <summary>
    /// 
    /// </summary>
    public class ClassifierViewModel : GenericHelperViewModel<ClientEvaluationDto, CLASIFICACLI>
    {
        public ClassifierViewModel(IDataServices dataServices, IRegionManager region, IEventManager manager, IDialogService dialog): base(
            String.Empty, dataServices, region, manager, dialog)
        {

        }
        public override async Task<DataPayLoad> SetCode(DataPayLoad payLoad, IDataServices dataServices)
        {
            IHelperDataServices helperDal = DataServices.GetHelperDataServices();
            ClientEvaluationDto dto = payLoad.DataObject as ClientEvaluationDto;
            if (dto != null)
            {
                string codeId = await helperDal.GetMappedUniqueId<ClientEvaluationDto, ClassifierViewModel>(dto);
                dto.Code = Convert.ToInt32(codeId);
                payLoad.DataObject = dto;

            }
            return payLoad;
        }
    }
}
