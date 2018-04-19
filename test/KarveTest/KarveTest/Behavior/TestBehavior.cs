using DataAccessLayer.DataObjects;
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
        [OneTimeSetUp]
        public void Setup()
        {
        }
        public void Should_AttachDetach_ComboAdvBehaviourCorrently()
        {
            var path = @"../test/KarveTest/KarveTest/Behavior/Xaml/TestButtonBehavior.xaml";
            XamlUnitTestHelper.LoadXaml(path);
            ComboBoxAdv adv = XamlUnitTestHelper.GetObject<ComboBoxAdv>("ComboTest");
            Assert.NotNull(adv);
        }
        [Test]
        public void Should_Enforce_ChangeRuleBehaviour()
        {
            PROVEE1 dataObject = new PROVEE1();
            dataObject.CP = "082788";
            dataObject.PROV = "38";
            var changeRule = new ChangeRuleBehavior();
            changeRule.DataObject = dataObject;
            var result = changeRule.DataObject;
            Assert.AreEqual(dataObject.PROV, "08");
        }
       
       
    }
}
