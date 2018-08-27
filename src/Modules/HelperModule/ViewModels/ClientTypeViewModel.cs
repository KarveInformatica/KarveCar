using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer.DataObjects;
using KarveCommon.Services;
using KarveCommonInterfaces;
using KarveDataServices;
using KarveDataServices.ViewObjects;
using Prism.Regions;

namespace HelperModule.ViewModels
{
    /// <summary>
    ///  ClientTypeViewModel.
    /// </summary>
    class ClientTypeViewModel : GenericHelperViewModel<ClientTypeViewObject, TIPOCLI>
    {
       

        /// <summary>
        ///  Set the code.
        /// </summary>
        /// <param name="payLoad">DataPayLoad</param>
        /// <param name="dataServices">DataServices</param>
        /// <returns></returns>
        public override async Task<DataPayLoad> SetCode(DataPayLoad payLoad, IDataServices dataServices)
        {
            IHelperDataServices helperDal = DataServices.GetHelperDataServices();
            ClientTypeViewObject viewObject = payLoad.DataObject as ClientTypeViewObject;
            if (viewObject != null)
            {
                string codeId = await helperDal.GetMappedUniqueId<ClientTypeViewObject, TIPOCLI>(viewObject);
                viewObject.Code = codeId.Substring(0, 4);
                payLoad.DataObject = viewObject;
            }
            
            return payLoad;
        }

    

        /// <summary>
        /// Client data services.
        /// </summary>
        /// <param name="dataServices">DataServices</param>
        /// <param name="region">Region</param>
        /// <param name="manager">Manager</param>
        public ClientTypeViewModel(IDataServices dataServices, IRegionManager region, IEventManager manager, IDialogService dialogService) : base(String.Empty, dataServices, region, manager, dialogService)
        {
            GridIdentifier = KarveCommon.Generic.GridIdentifiers.HelperClientType;
        }
    }
}
