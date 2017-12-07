using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.Entity.Migrations.Model;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using KarveCommon.Services;
using KarveControls;
using KarveDataServices;
using KarveDataServices.DataObjects;
using MasterModule.ViewModels;
using Model;
using Moq;
using NUnit.Framework;
using Prism.Commands;

/*
 *  We will work as arrange,act, assert as we have in http://defragdev.com/blog/?p=783
 */
namespace KarveTest.ViewModels
{
    [TestFixture]
    public class TestVehicleUpperBarViewModel
    {
        private Mock<IEventManager> _eventManager = new Mock<IEventManager>();
        private IEventManager _currentEventManager = new MockEventManager();

        private Mock<IDataServices> _dataServices = new Mock<IDataServices>();
        // message handler.
        private MailBoxMessageHandler _messageHandler;

        private UpperBarViewVehicleViewModel _upperBarViewModel;

        [OneTimeSetUp]
        public void Setup()
        {

            _upperBarViewModel =
                new UpperBarViewVehicleViewModel(_eventManager.Object, _dataServices.Object);

        }

        [Test]
        public void Should_Show_All_Fields()
        {
            // Arrange
            DataPayLoad payLoad = new DataPayLoad();
            payLoad.HasDataObject = true;
            VehiclePoco poco = new VehiclePoco();
            poco.CODIINT = "1828";
            poco.BASTIDOR = "819282989";
            poco.MATRICULA = "893893893";
            poco.COLOR = "BL";
            poco.MARCA = "IVECO ";
            poco.MATRICULA = "81982";
            poco.GRUPO = "9XL";
            payLoad.DataObject = poco;
            _eventManager.Setup(x => x.SendMessage(UpperBarViewVehicleViewModel.Name, payLoad));
            // Act
            _eventManager.Object.SendMessage(UpperBarViewVehicleViewModel.Name, payLoad);
            // Assert
            Assert.AreSame(_upperBarViewModel.DataObject.Value.CODIINT, poco.CODIINT);
            Assert.AreSame(_upperBarViewModel.DataObject.Value.BASTIDOR, poco.BASTIDOR);
            Assert.AreSame(_upperBarViewModel.DataObject.Value.MATRICULA, poco.MATRICULA);
            Assert.AreSame(_upperBarViewModel.DataObject.Value.COLOR, poco.COLOR);
            Assert.AreSame(_upperBarViewModel.DataObject.Value.MARCA, poco.MARCA);
            Assert.AreSame(_upperBarViewModel.DataObject.Value.GRUPO, poco.GRUPO);
        }

        /// <summary>
        ///  This tests the view model in isolation when the user has a dto.
        /// </summary>
        public void Should_Retrieve_ColorDto()
        {
            // arrange the data.
            Dictionary<string, string> ev = new Dictionary<string, string>();
            ev.Add("TableName", "COLORFL");
            ev.Add("AssitQuery", "SELECT CODIGO, NOMBRE FROM COLORFL");
            // this is the click form the component.
            ICommand assistColor = _upperBarViewModel.AssistCommand;
            assistColor.Execute(ev);
            IVehicleData vehicleData = _upperBarViewModel.DataObject as IVehicleData;

            IEnumerable<KarveDataServices.DataTransferObject.ColorDto> colorsColorDtos = vehicleData.ColorDtos;

            // assert.
            KarveDataServices.DataTransferObject.ColorDto[] dto = colorsColorDtos.ToArray();
            Assert.Greater(dto.Length,0);
            Assert.AreSame(dto.Length, 4);
            Assert.AreSame(dto[0].Codigo, "A");
            Assert.AreSame(dto[1].Codigo, "BL");
            Assert.AreSame(dto[2].Codigo, "BU");
            Assert.AreSame(dto[3].Codigo, "GR");
            Assert.AreSame(dto[0].Nombre, "AZUL");
            Assert.AreSame(dto[1].Nombre, "BLANCO");
            Assert.AreSame(dto[2].Nombre, "BORDEUS");
            Assert.AreSame(dto[3].Nombre, "GRIS");
        }
        /// <summary>
        ///  This tests the view model in isolation when the user has a dto.
        /// </summary>
        public void Should_Retrieve_ModelDto()
        {
            // arrange the data.
            Dictionary<string, string> ev = new Dictionary<string, string>();
            ev.Add("TableName", "MARCAS");
            ev.Add("AssitQuery", "SELECT CODIGO, NOMBRE FROM MODEL");
            // this is the click form the component.
            ICommand assistColor = _upperBarViewModel.AssistCommand;
            assistColor.Execute(ev);
            IVehicleData vehicleData = _upperBarViewModel.DataObject as IVehicleData;

            IEnumerable<KarveDataServices.DataTransferObject.BrandVehicleDto> brandVehicleDtos = vehicleData.BrandDtos;

            // assert.
          //  IEnumerable<KarveDataServices.DataTransferObject.BrandVehicleDto> brandVehicleDtos = _upperBarViewModel.BrandVehicleDto;
            KarveDataServices.DataTransferObject.BrandVehicleDto[] dto = brandVehicleDtos.ToArray();
            Assert.Greater(dto.Length, 0);
            Assert.AreSame(dto.Length, 4);
            Assert.AreSame(dto[0].Codigo, "A");
            Assert.AreSame(dto[1].Codigo, "BL");
            Assert.AreSame(dto[2].Codigo, "BU");
            Assert.AreSame(dto[3].Codigo, "GR");
            Assert.AreSame(dto[0].Nombre, "AZUL");
            Assert.AreSame(dto[1].Nombre, "BLANCO");
            Assert.AreSame(dto[2].Nombre, "BORDEUS");
            Assert.AreSame(dto[3].Nombre, "GRIS");
        }
        /// <summary>
        ///  This should retrive a vehicle dto.
        /// </summary>
        public void Should_Retrive_GrupoDto()
        {
            Dictionary<string, string> ev = new Dictionary<string, string>();
            ev.Add("TableName", "GRUPOS");
            ev.Add("AssitQuery", "SELECT CODIGO, NOMBRE FROM GRUPOS");
            // this is the click form the component.
            ICommand assistColor = _upperBarViewModel.AssistCommand;
            assistColor.Execute(ev);
            IEnumerable<KarveDataServices.DataTransferObject.VehicleGroupDto> vehicleGroup = _upperBarViewModel.GroupVehicleDto;
            KarveDataServices.DataTransferObject.VehicleGroupDto[] dto = vehicleGroup.ToArray();
            Assert.AreEqual(dto.Length, 2);
            Assert.AreSame(dto[0].Codigo, "09");
            Assert.AreSame(dto[0].Nombre, "9 PLAZA");
            Assert.AreSame(dto[1].Codigo, "9XL");
            Assert.AreSame(dto[1].Nombre, "9 PLAZA LARGO");
        }
        /// <summary>
        ///  Should update data upper bar.
        /// </summary>
        public void Should_UpdateData_UpperBar()
        {
            IDictionary<string,object> fieldChangeDictionary = new Dictionary<string, object>();
            VehiclePoco poco = new VehiclePoco();
            poco.CODIINT = "1828";
            poco.BASTIDOR = "819282989";
            poco.MATRICULA = "893893893";
            poco.COLOR = "BL";
            poco.MARCA = "IVECO ";
            poco.MATRICULA = "81982";
            poco.GRUPO = "9XL";
            fieldChangeDictionary[DataField.TABLENAME] = "VEHICULO1";
            fieldChangeDictionary[DataField.DATAOBJECT] = poco;
            fieldChangeDictionary[DataField.FIELD] = "BASTIDOR";
            fieldChangeDictionary[DataField.CHANGED_VALUE] = "378373";
        }

    }
    /// <summary>
    /// 
    /// </summary>
    internal class MockEventManager : IEventManager
    {

        public void RegisterObserverSubsystem(string id, IEventObserver obs)
        {
            throw new NotImplementedException();
        }

        public void NotifyObserverSubsystem(string id, DataPayLoad dataPayload)
        {
            throw new NotImplementedException();
        }

        public void RegisterObserver(IEventObserver obs)
        {
            throw new NotImplementedException();
        }

        public void NotifyObserver(DataPayLoad payload)
        {
            throw new NotImplementedException();
        }

        public void RegisterObserverToolBar(IEventObserver obs)
        {
            throw new NotImplementedException();
        }

        public void NotifyToolBar(DataPayLoad payload)
        {
            throw new NotImplementedException();
        }

        public void DeleteObserverSubSystem(string id, IEventObserver obs)
        {
            throw new NotImplementedException();
        }

        public void DisableNotify(string id, IEventObserver obs)
        {
            throw new NotImplementedException();
        }

        public void EnableNotify(string id, IEventObserver obs)
        {
            throw new NotImplementedException();
        }

        public void RegisterMailBox(string id, MailBoxMessageHandler messageHandler)
        {
            throw new NotImplementedException();
        }

        public void DeleteMailBoxSubscription(string id)
        {
            throw new NotImplementedException();
        }

        public void SendMessage(string viewModuleId, DataPayLoad payLoad)
        {
            throw new NotImplementedException();
        }
    }
}
