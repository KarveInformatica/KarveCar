using KarveControls.Behaviour;
using NUnit.Framework;
using Syncfusion.Windows.Tools.Controls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace KarveTest.Behavior
{
    [TestFixture]
    public class TestBehavior
    {
       
        private ComboAdvChangeBehavior comboAdvChangeBehavior;
        public void Setup()
        {
        }
        [Test, Apartment(System.Threading.ApartmentState.STA)]
        public void Should_AttachDetach_ComboAdvBehaviourCorrently()
        {
            var path = @"../test/KarveTest/KarveTest/Behavior/Xaml/TestButtonBehavior.xaml";
            XamlUnitTestHelper.LoadXaml(path);
            ComboBoxAdv adv = XamlUnitTestHelper.GetObject<ComboBoxAdv>("ComboTest");
            Assert.NotNull(adv);
        }
       
       
    }
}
