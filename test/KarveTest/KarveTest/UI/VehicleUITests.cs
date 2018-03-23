using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MasterModule.Views;
using NUnit.Framework;
using Prism;
/*
//Opens the app
    var app = Application.Launch("MyApp.exe");

//Finds the main window (this and above line should be in [TestInitialize])
    var window = app.GetWindow("My App Window Title", InitializeOption.NoCache);

//Finds the button (see other Get...() methods for options)
    var btnMyButton = window.Get<Button>("btnMyButtonWPFname");

//Simulate clicking
    btnMyButton.Click();

    //Gets the result text box 
    //Note: TextBox/Button is in TestStack.White.UIItems namespace
    var txtMyTextBox = window.Get<TextBox>("txtMyTextBox");

//Check for the result
    Assert.IsTrue(txtMyTextBox.Text == "my expected result");

    //Close the main window and the app (preferably in [TestCleanup])
    app.Close();
    */
namespace KarveTest.UI
{
    [TestFixture]
    public class VehicleUiTests
    {
        [OneTimeSetUp]
        public void SetupTestUi()
        {
            TestBootStrapper bootstrapper = new TestBootStrapper();
            VehicleInfoView vehicleInfoView = new VehicleInfoView();

        }
        [OneTimeTearDown]
        public void TearDownTestUi()
        {
            
        }
        [Test]
        public void Should_Load_Correctly_Vehicle_View()
        {
            Assert.Fail();
        }
    }
}
