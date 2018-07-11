using KarveCommon.Generic;
using KarveCommon.Services;
using KarveCommonInterfaces;
using KarveDataServices;
using KarveDataServices.DataTransferObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingModule.ViewModels
{
    /// <summary>
    /// This class has the single resposability to delete an item view.
    /// </summary>
    /// <typeparam name="Domain"></typeparam>
    /// <typeparam name="SummaryDto"></typeparam>
    class ViewDeleter<Domain, SummaryDto> where Domain : class
                                          where SummaryDto : BaseDto
    {
        private IDataProvider<Domain, SummaryDto> _dataProvider;
        private IDialogService _dialogService;
        private IEventManager _eventManager;
        public ViewDeleter(IDataProvider<Domain, SummaryDto> dataServices, 
                            IDialogService dialogService, IEventManager eventManager)
        {
            _dataProvider = dataServices;
            _dialogService = dialogService;
            _eventManager = eventManager;
        }
        private async Task<bool> DeleteAsync(DataPayLoad payLoad)
        {
            bool retValue = false;
            if (payLoad.DataObject is Domain request)
            {
                try
                {
                    retValue = await _dataProvider.DeleteAsync(request).ConfigureAwait(false);
                }
                catch (Exception ex)
                {
                    var msg = "Error during saving request:" + ex.Message;
                    _dialogService?.ShowErrorMessage(msg);
                }
            }
            return retValue;
        }

        public void Notify(string viewModelUri, string subsystemName)
        {
                var dataPayLoad = new DataPayLoad
                {
                    Sender = viewModelUri,
                    PayloadType = DataPayLoad.Type.UpdateView
                };
                _eventManager.NotifyObserverSubsystem(subsystemName, dataPayLoad);  
        }
        public bool DeleteView(DataPayLoad payLoad)
        {
            bool isDeleted = false;
            NotifyTaskCompletion.Create(DeleteAsync(payLoad),
                (sender, args) =>
                {

                    if (sender is INotifyTaskCompletion<bool> taskCompletion)
                    {
                        if (taskCompletion.IsFaulted)
                        {
                            _dialogService?.ShowErrorMessage("Error during aving: " + taskCompletion.ErrorMessage);
                            isDeleted = false;
                        }

                        if (taskCompletion.IsSuccessfullyCompleted)
                        {
                            _dialogService?.ShowMessage("View deletion","View deleted with success");
                            isDeleted = true;
                        }
                    }
                });
            return isDeleted;
        }
    }
}
