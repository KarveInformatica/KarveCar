using System;
using System.Threading.Tasks;
using KarveCommon.Services;
using KarveDataServices;
using DataAccessLayer.DataObjects;
using KarveDataServices.ViewObjects;
using KarveCommonInterfaces;
using Prism.Regions;

namespace HelperModule.ViewModels
{
    /// <summary>
    /// 
    /// </summary>
    public class ClassifierViewModel : GenericHelperViewModel<ClientEvaluationViewObject, CLASIFICACLI>
    {
        public ClassifierViewModel(IDataServices dataServices, IRegionManager region, IEventManager manager, IDialogService dialog): base(
            String.Empty, dataServices, region, manager, dialog)
        {

        }
        public override async Task<DataPayLoad> SetCode(DataPayLoad payLoad, IDataServices dataServices)
        {
            IHelperDataServices helperDal = DataServices.GetHelperDataServices();
            ClientEvaluationViewObject viewObject = payLoad.DataObject as ClientEvaluationViewObject;
            if (viewObject != null)
            {
                string codeId = await helperDal.GetMappedUniqueId<ClientEvaluationViewObject, ClassifierViewModel>(viewObject);
                viewObject.Code = Convert.ToInt32(codeId);
                payLoad.DataObject = viewObject;

            }
            return payLoad;
        }
    }
}
