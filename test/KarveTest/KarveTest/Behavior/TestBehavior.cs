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
using KarveCommon.Services;
using KarveDataServices;
using KarveTest.Behavior;

namespace KarveTest.Behavior
{
    public class TriggerChangedRule : ChangeRuleBehavior
    {
        private object _valueObject;
        public TriggerChangedRule(object dataObject) : base()
        {
            _valueObject = dataObject;
        }

        protected override void OnSetup()
        {
           

        }   
    }
        
   
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
            var changeRule = new ChangeRuleBehavior {DataObject = dataObject};
           
            var result = changeRule.DataObject as PROVEE1;
            Assert.AreEqual(result, "08");
        }
       
       
    }
}
