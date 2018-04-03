
using System.Collections.Generic;
using Microsoft.Practices.Unity;
using AssistModule.ViewModels;
using AssistModule.Views;
using KarveCommonInterfaces;

namespace AssistModule
{
    /// <summary>
    ///  This service has the responsability of opening a modal window with a grid inside,
    ///  showing the collection of data objects and returning a data object.
    /// </summary>
    public class AssistService : IAssistService
    {
        private IUnityContainer _container;

        /// <summary>
        /// AssistService. This service is like a dialog service.
        /// </summary>
        /// <param name="container">This is a container.</param>
        public AssistService(IUnityContainer container)
        {
            _container = container;
        }
        /// <summary>
        ///  Set or Get the selected item.
        /// </summary>
        public object SelectedItem { set; get; }
        /// <summary>
        /// This is an assist view.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="title">Title to show</param>
        /// <param name="dataObjects">Data Objects</param>
        public void ShowAssistView<T>(string title, IEnumerable<T> dataObjects)
        {
            // This are a set of assist modules.
            // a view model first approach.
            var viewModel = _container.Resolve<AssistServiceViewModel>();
            var view = _container.Resolve<AssistServiceView>();

            // ok a data context is correctly placed.
            view.DataContext = viewModel;

            if (viewModel != null)
            {
                // this open an interaction request.
                viewModel.RaiseItemSelection<T>(title, dataObjects);
                var selection = viewModel.SelectedItem;
                if (selection != null)
                {
                    SelectedItem = selection;
                }
            }
        }
    }
}
