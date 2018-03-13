using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using TestStack.White;
using TestStack.White.UIItems.WindowItems;

namespace TestUIComponents
{
    [TestFixture]
    class UIControlTest
    {
        string UIAppPath
        {
            get
            {

                var baseTest = Path.Combine(TestContext.CurrentContext.TestDirectory, "TestUIComponents.exe");
                return baseTest;
            }
        }
        
        [Test]
        public void TestCalendarSelection()
        {
            var application = Application.Launch(UIAppPath);
            Window window = application.GetWindow("TestWindow");
          ///  var value = window.Get<KarveControls.HolidayCalendar>();
            //  var currentObject = window.Get<>
           // var currentObj = "1";
            application.Close();

        }
    }
}
