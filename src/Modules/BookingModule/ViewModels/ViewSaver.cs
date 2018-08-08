using KarveCommon.Generic;
using KarveCommon.Services;
using KarveCommonInterfaces;
using KarveDataServices;
using KarveDataServices.DataTransferObject;
using Prism.Regions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingModule.ViewModels
{
    class ViewSaver<DomainType,SummaryType,DtoType> where DomainType: class
                                                    where SummaryType : class 
                                                    where DtoType: BaseDto
    {
        private IRegionManager _regionManager;
       
        private IDataProvider<DomainType, SummaryType> _dataProvider;
        private IValueObject<DtoType> _valueObject;

        /// <summary>
        /// This helps to save the view and change operational state. 
        /// </summary>
        /// <param name="regionManager"></param>
        /// <param name="dialogService"></param>
        /// <param name="dataProvider"></param>
        /// <param name="valueObject"></param>
        

        public ViewSaver(IRegionManager regionManager,
                         IDataProvider<DomainType, SummaryType> dataProvider,
                         IValueObject<DtoType> valueObject)
        {
            _regionManager = regionManager;
            _dataProvider = dataProvider;
            _valueObject = valueObject;
        }

        public string Message { get; private set; }
        /// <summary>
        /// Save the current view data and changed the operational state of the view model to show.
        /// It might be an insert operational state.
        /// </summary>  
        public bool Save(string primaryKey, 
                         DtoType dataObject, 
                         ref bool changed, ref DataPayLoad.Type operationalState)
        {
            var activeView = _regionManager.Regions[RegionNames.TabRegion].ActiveViews.FirstOrDefault();
            _valueObject.Value = dataObject;
           
            if (dataObject.HasErrors)
            {
                var value = dataObject.Errors.FirstOrDefault();
                Message = "Validation Failed ${value}";
                return false;
            }
            var data = _valueObject as DomainType;
            var currentChanged = changed;
            var currentOperationalState = operationalState;
            var hasErrors = false;
            NotifyTaskCompletion.Create<bool>(_dataProvider.SaveAsync(data), (sender, ev) =>
            {
                if (sender is INotifyTaskCompletion<bool> task)
                {
                    var number = primaryKey;
                    if ((task.IsSuccessfullyCompleted) && (task.Result == true))
                    {
                        currentChanged = true;
                        currentOperationalState = KarveCommon.Services.DataPayLoad.Type.Show;
                    }
                    else
                    {
                        Message = task.ErrorMessage;
                        hasErrors = true;
                    }
                }
            });
            if (!hasErrors)
            {
                changed = currentChanged;
                operationalState = currentOperationalState;
                return true;
            }
            return false;
        }
    }
}
