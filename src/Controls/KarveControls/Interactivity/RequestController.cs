using KarveControls.Interactivity.ViewModels;
using KarveControls.Interactivity.Views;
using Microsoft.Practices.Unity;
using System.Collections.Generic;
using KarveCommonInterfaces;


namespace KarveControls.Interactivity
{
    public class RequestController : IInteractionRequestController
    {
        private IUnityContainer _unityContainter;

        public SelectionState SelectionState { set; get;}

        public RequestController(IUnityContainer container)
        {
            _unityContainter = container;
        }

        public object SelectedItem { get; set; }

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
