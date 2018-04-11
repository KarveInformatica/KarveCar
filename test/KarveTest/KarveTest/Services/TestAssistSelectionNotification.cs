using KarveCommonInterfaces;
using Microsoft.Practices.Unity;
using NUnit.Framework;

using System.Linq;
using System.Collections.Generic;
using System.Threading;
using KarveDataServices.DataTransferObject;
using Prism.Interactivity.InteractionRequest;
using System.Windows;
using Prism.Interactivity;
using KarveTest.Mock.UI;
using Prism.Interactivity.DefaultPopupWindows;
using System;

namespace KarveTest.Services
{
    public class TestableTriggerAction : System.Windows.Interactivity.TriggerAction<DependencyObject>
    {
        public int ExecutionCount { get; set; }

        protected override void Invoke(object parameter)
        {
            this.ExecutionCount++;
            if (parameter is InteractionRequestedEventArgs)
            {
                ((InteractionRequestedEventArgs)parameter).Callback();
            }
        }
    }

    public class TestablePopupWindowAction : PopupWindowAction
    {
        public new Window GetWindow(INotification notification)
        {
            return base.GetWindow(notification);
        }
    }
    [TestFixture]
    public class TestAssistSelectionNotification
    {
        [OneTimeSetUp]
        public void Setup()
        {
        }
                    
        [Test, Apartment(ApartmentState.STA)]
        public void Should_AssistExecute_AssitInteractionCallback()
        {
            IList<ProvinciaDto> provinces = new List<ProvinciaDto>()
            {
                    new ProvinciaDto(){ Name = "Italy", Code = "001"},
                    new ProvinciaDto(){ Name= "Spain", Code="002"}
            };
            MockFrameworkElement element = new MockFrameworkElement();
            TestablePopupWindowAction popupWindowAction = new TestablePopupWindowAction();
            popupWindowAction.WindowContent = element;
      
            popupWindowAction.IsModal = true;
            popupWindowAction.CenterOverAssociatedObject = true;
          
        }
    
        public class TestableInteractionRequestTrigger : InteractionRequestTrigger
        {
            public int ExecutionCount { get; set; }

            protected override void OnEvent(EventArgs eventArgs)
            {
                this.ExecutionCount++;
                base.OnEvent(eventArgs);
            }
        }
        
    
      
    }
}
