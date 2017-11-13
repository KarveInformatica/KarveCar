using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestStack.White.Factory;
using NUnit.Framework;

namespace KarveControlsTest
{
    [TestFixture]
    class TestUICode
    {
        /// <summary>
        /// Exectuable source file. 
        /// </summary>
        private string _exeSourceFile;

        [OneTimeSetUp]
        public void Setup()
        {

        }
        /*
        private const string ExeSourceFile = @"C:\Windows\system32\calc.exe";
        //Global Variable to for Application launch
        private static White.Core.Application _application;
        //Global variable to get the Main window of calculator from application.
        private static White.Core.UIItems.WindowItems.Window _mainWindow;

        //start process for the above exe file location
        var psi = new ProcessStartInfo(ExeSourceFile);

        // launch the process through white application
        _application = White.Application.AttachOrLaunch(psi);
        */
    }
}
