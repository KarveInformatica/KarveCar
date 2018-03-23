using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using KarveDapper;
using KarveDataServices;
using System.Data;
using KarveDapper.Extensions;
using KarveDataAccessLayer.DataObjects;
using DataAccessLayer.DataObjects;
using KarveDataServices.DataTransferObject;

namespace KarveTest.DAL
{
    [TestFixture]
    class TestEntityDeserializer: TestBase
    {
       private ISqlExecutor _executor;
       private List<EntityDecorator> _output = new List<EntityDecorator>();

        [OneTimeSetUp]
       public void Setup()
       {
          _executor = SetupSqlQueryExecutor();
       }
       [Test]
       public async Task Should_EntityDeserializer_Deserialize_Correctly()
       {
            IList<object> entities = new List<object>()
           {
               new POBLACIONES(),
               new CLIENTES1()
           };
            IList<object> dto = new List<object>()
            {
               new CityDto(),
               new ClientDto()
            };
            var query = "SELECT * from poblaciones; select * from clientes1";
            EntityDeserializer deserializer = new EntityDeserializer(entities, dto);
            int currentPosition = 0;
            _output.Clear();
        
            using (IDbConnection dbConnection = _executor.OpenNewDbConnection())
            {
                // arrange
                var reader = await dbConnection.QueryMultipleAsync(query);
                while (!reader.IsConsumed)
                {
                    var row = reader.Read().FirstOrDefault();
                    var deserialized = deserializer.Deserialize(row);
                    Assert.NotNull(deserializer);
                    //Assert.AreEqual(deserialized.Type.Name, entities[currentPosition].GetType().Name);
                    //Assert.AreEqual(deserialized.DtoType.Name, dto[currentPosition].GetType().Name);
                    currentPosition++;
                    if (deserialized != null)
                    {
                        _output.Add(deserialized);
                    }
                }
                var dtoCount = _output.Where<EntityDecorator>(p => p.DtoType == dto[0].GetType()).Count();
                var entityCount = _output.Where<EntityDecorator>(p => p.Type == entities[0].GetType()).Count();
                var dtoCount1 = _output.Where<EntityDecorator>(p => p.DtoType == dto[1].GetType()).Count();
                var entityCount1 = _output.Where<EntityDecorator>(p => p.Type == entities[1].GetType()).Count();

                Assert.AreEqual(2, _output.Count);
                Assert.AreEqual(1, dtoCount);
                Assert.AreEqual(1, entityCount);
                Assert.AreEqual(1,dtoCount1);
                Assert.AreEqual(1,entityCount1);
            }
        }
    [Test]
        public async Task Should_EntityDeserializer_Deserialize_Correctly_With_One_Empty_Query()
        {
            IList<object> entities = new List<object>()
           {
               new POBLACIONES(),
                new VEHICULO1(),
                new CLIENTES1(),
              
           };
            IList<object> dto = new List<object>()
            {
               new CityDto(),
               new VehicleDto(),
               new ClientDto()
            };
            var query = @"SELECT * from poblaciones;select * from vehiculo1 WHERE CODIINT='0';select * from clientes1";
            EntityDeserializer deserializer = new EntityDeserializer(entities, dto);
            int currentPosition = 0;
            _output.Clear();
            using (IDbConnection dbConnection = _executor.OpenNewDbConnection())
            {
                // arrange
                var reader = await dbConnection.QueryMultipleAsync(query);
                while (!reader.IsConsumed)
                {
                    var row = reader.Read().FirstOrDefault();
                    var deserialized = deserializer.Deserialize(row);
                    if (deserialized != null)
                    {
                        _output.Add(deserialized);
                    }
                    currentPosition++;
                }
                Assert.AreEqual(_output.Count, 2);
            }
        }

    }
}
