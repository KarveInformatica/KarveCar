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
    public class TestBehaviors
    {
       
        [OneTimeSetUp]
        public void Setup()
        {
        }
      
        [Test]
        public void Should_Enforce_ChangeRuleBehaviour()
        {
            var dataObject = new PROVEE1();
            dataObject.CP = "082788";
            dataObject.PROV = "39";
            var changeRule = new ChangeRuleBehavior {DataObject = dataObject};
            changeRule.Execute();

            var result = changeRule.DataObject as PROVEE1;
            Assert.AreEqual("08", result.PROV);
        } 
       
    }
}
