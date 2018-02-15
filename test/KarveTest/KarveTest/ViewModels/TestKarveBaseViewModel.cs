using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;
using KarveCommon.Generic;
using KarveDataServices.DataTransferObject;
using KarveTest.Mock;
using NUnit.Framework;
using System.IO;

namespace KarveTest.ViewModels
{
    /// <summary>
    ///  TestKarveBaseViewModel
    /// </summary>
    [TestFixture]
    public class TestKarveBaseViewModel : TestBase
    {
        private MockDataServices _mockDataServices = new MockDataServices();
        private KarveViewModelBase _karveViewModelBase;
        private ICommand _registerCommand;

            /// <summary>
            ///  Ok setup 
            /// </summary>
        [OneTimeSetUp]
        public void Setup()
        {
            _karveViewModelBase = new KarveViewModelBase(_mockDataServices);
          
               
        }

        [Test]
        public void Should_Register_A_New_Grid()
        {
            ICommand registerCommand = _karveViewModelBase.GridRegisterCommand;
            Assert.NotNull(registerCommand);
            KarveGridParameters param = new KarveGridParameters();
            param.GridIdentifier = 1;
            param.GridName = "Supplier_Grid";
            registerCommand.Execute(param);
            // here shall be present all the grids.
            ObservableCollection<GridSettingsDto> settingsDtos = _karveViewModelBase.CurrentGridSettings;
            GridSettingsDto settingsDto = settingsDtos.FirstOrDefault(x => x.GridIdentifier == param.GridIdentifier);
            Assert.NotNull(settingsDto);
        }
        private KarveGridParameters LoadFileFromSettings(string path, int id)
        {
            KarveGridParameters dto = new KarveGridParameters();
            using (FileStream stream = File.OpenRead(path))
            {
                long fSize = stream.Length;
                byte[] fileValue = new byte[fSize];
                stream.Read(fileValue, 0, fileValue.Length);
                // now we save into the setting
                var valueStringEncoded = Convert.ToBase64String(fileValue);
                dto.Xml = valueStringEncoded;
                dto.GridIdentifier = id;
                dto.GridName = "Suppliers";
                
            }
            return dto;
        }
        /// <summary>
        ///  Resize grid command.
        /// </summary>
        [Test]
        public void Should_ResizeGrid_Command()
        {
            ICommand resizeGrid = _karveViewModelBase.GridResizeCommand;
            Assert.NotNull(resizeGrid);
            KarveGridParameters param = LoadFileFromSettings("TestSettings.xml", 1);
            var baseSettings = param.Xml;
            resizeGrid.Execute(param);
            GridSettingsDto dto = _karveViewModelBase.GridSettings;
            var setting = dto.XmlBase64;
            Assert.AreEqual(baseSettings, setting);
        }
    }
}
