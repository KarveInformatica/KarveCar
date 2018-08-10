using KarveControls.Interactivity.ViewModels;
using KarveControls.Interactivity.Views;
using Microsoft.Practices.Unity;
using System.Collections.Generic;
using KarveCommonInterfaces;
using System.IO;
using Prism.Regions;
using System.Windows.Controls;
using KarveCommon.Generic;

namespace KarveControls.Interactivity
{
    public class RequestController : IInteractionRequestController
    {
        private IUnityContainer _unityContainter;
        private IRegionManager _regionManager;

        public SelectionState SelectionState { set; get;}

        /// <summary>
        ///  This controller will trigger the popup for each view.
        /// </summary>
        /// <param name="container">A container for resolving the view model.</param>
        /// <param name="regionManager">A regionManager for resolving the region.</param>
        public RequestController(IUnityContainer container, IRegionManager regionManager)
        {
            _unityContainter = container;
            _regionManager = regionManager;
        }
        /// <summary>
        ///  Set or Get the selected item.
        /// </summary>
        public object SelectedItem { get; set; }

        /// <summary>
        ///  Show a grid with provided interacion object and assist properties. 
        ///  The assist properties are the columns to be shown in the grid.
        /// </summary>
        /// <typeparam name="T">Type of the object collection to be shown. It is typically a data transfer object.</typeparam>
        /// <param name="title">A title to be shown for the window</param>
        /// <param name="dataObjects">A collection of object to be shown.</param>
        /// <param name="assistProperties">The comma separated value of the assist properties to be shown.</param>
        public void ShowAssistView<T>(string title, IEnumerable<T> dataObjects, string assistProperties = "")
        {
            if (_unityContainter != null)
            {
                InteractionRequestView modalView = _unityContainter.Resolve<InteractionRequestView>();

                if (modalView.DataContext is InteractionRequestViewModel vm)
                {
                    vm.OnSelectedItem += Vm_OnSelectedItem;
                    vm.DataSource = dataObjects;
                    vm.Title = title;
                    vm.AssistProperties = assistProperties;
                    vm.RaiseItemSelectionCommand.Execute(null);
                }
            }
        }
       
        /// <summary>
        /// This show an interaction view, aka popup windows action with a confirmation.
        /// The user shall confirm the action performed in the popup. We retrieve the view and 
        /// the view model to be shown directly from the container.
        /// </summary>
        /// <typeparam name="ViewModelType">View model type to be shown.</typeparam>
        /// <typeparam name="ViewType">View type to be shown.</typeparam>
        public void ShowView<ViewModelType, ViewType>(ViewModelType viewModel)  where ViewModelType: ICommandInteraction
        {
            if (_unityContainter != null)
            {
                var modalView = _unityContainter.Resolve<ViewType>();
                var viewModelView = viewModel;
                if ( (modalView != null) && (viewModelView != null))
                {
                    var view = modalView as UserControl;
                    if (view != null)
                    {
                        view.DataContext = viewModelView;
                    }
                    InteractionView mainWindow = _unityContainter.Resolve<InteractionView>();
                    var detailsRegionManager = mainWindow.CurrentRegionManager;
                  //  var popupRegion = detailsRegionManager.Regions[RegionNames.PopUpContent];
                   // popupRegion.Add(modalView);
                    mainWindow.Focus();
                    
                }
            }
        }
        private void Vm_OnSelectedItem(SelectionState state, object value)
        {
            SelectionState = state;
            if (state == SelectionState.OK)
            {
                SelectedItem = value;
            }
        }

    }
}
