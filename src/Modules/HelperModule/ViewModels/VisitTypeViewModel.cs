using System;
using System.Collections.Generic;
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
    /// VisitTypeViewModel.
    /// </summary>
    class VisitTypeViewModel : GenericHelperViewModel<VisitTypeViewObject, TIPOVISITAS>
    {
        /// <summary>
        ///  VisitType view model
        /// </summary>
        /// <param name="dataServices">Tipo de visita</param>
        /// <param name="region">Region</param>
        /// <param name="manager">Manager</param>
        public VisitTypeViewModel(IDataServices dataServices, IRegionManager region, IEventManager manager, IDialogService dialogService) : base(String.Empty, dataServices, region, manager, dialogService)
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
            VisitTypeViewObject viewObject = payLoad.DataObject as VisitTypeViewObject;
            if (viewObject != null)
            {
                string codeId = await helperDal.GetMappedUniqueId<VisitTypeViewObject, TIPOVISITAS>(viewObject);
                viewObject.Code = codeId.Substring(0, 4);
                payLoad.DataObject = viewObject;
            }
            return payLoad;
        }
    }
}
