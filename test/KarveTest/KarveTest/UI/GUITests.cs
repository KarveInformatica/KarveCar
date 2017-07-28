using NUnit.Framework;
using System.IO;
using System.Windows;
using TestStack.White.InputDevices;
using TestStack.White.UIItems;
using TestStack.White.UIItems.Finders;
using TestStack.White.UIItems.WindowStripControls;
using Application = TestStack.White.Application;
using Window = TestStack.White.UIItems.WindowItems.Window;

namespace KarveTest.UI
{
    [TestFixture]

    public class GUITests
    {

        private string applicationPath = @"C:\Users\Usuario\Documents\KarveSnapshots\KarveCar\src\bin\Debug\";

        [OneTimeSetUp]
        public void ToolBarTest()
        {
            applicationPath = Path.Combine(applicationPath, "KarveCar.exe");

        }
        [OneTimeTearDown]
        public void GUITestsTearDown() 
        {
        }

        [Test]
        public void Should_Start_and_Close_Correctly()
        {

            Application application = Application.Launch(applicationPath);
            application.Close();
        }

        [Test]
        public void Should_Start_And_Show_Banks_Correctly()
        {
            Application application = Application.Launch(applicationPath);
            Window mainWindow = application.GetWindows()[0];
            MenuBar clients = mainWindow.MenuBars[3];
            clients.Click();
            // here we have to adjust the click;
            Point point = new Point(718,130);
            Mouse.Instance.Click(point);
            application.Close();
        }

        [Test]
        public void Should_Click_ToolBarExitButton_And_Exit()
        {
            Application application = Application.Launch(applicationPath);
            Window mainWindow = application.GetWindows()[0];
            SearchCriteria searchCriteria = SearchCriteria.ByAutomationId("tbAcciones");
            var toolBarTest= mainWindow.Get<ToolStrip>(searchCriteria);
            searchCriteria = SearchCriteria.ByAutomationId("tbbtnSalir");
            Button toolBarExitButton = toolBarTest.Get<Button>(searchCriteria);
            toolBarExitButton.Click();
            application.WaitWhileBusy();
            Assert.AreEqual(true, application.HasExited);
            application.Close();
        }
        [Test]
        public void Should_ToolBarSaveButton_Enabled_AfterAnInsertion()
        {
            Application application = Application.Launch(applicationPath);
            Window mainWindow = application.GetWindows()[0];
            // shall launch the banks for example

            SearchCriteria searchCriteria = SearchCriteria.ByAutomationId("tbAcciones");
            var toolBarTest = mainWindow.Get<ToolStrip>(searchCriteria);
            searchCriteria = SearchCriteria.ByAutomationId("tbbtnGuardar");
        }
        [Test]
        public void Should_ToolBarDeleteButton_Enabled_AfterAnInsertion()
        {
        }
        [Test]
        public void Should_ToolBarNewButton_Enabled_AfterShowingATab()
        {
        }
    }
}
