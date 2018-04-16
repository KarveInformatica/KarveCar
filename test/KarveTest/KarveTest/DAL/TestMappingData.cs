using AutoMapper;
using DataAccessLayer.DataObjects;
using DataAccessLayer.Logic;
using KarveDataServices.DataTransferObject;
using NUnit.Framework;
using System;
using System.Linq;
using System.Collections.Generic;

namespace KarveTest.DAL
{

    /// <summary>
    ///  This test fixture unit tests the mapping class MapperField for conversion from 
    ///  entities to data transfer objects
    /// </summary>
    [TestFixture]
    public class TestMappingData 
    {
        private IMapper _mapper;

        public TestMappingData() 
        {
            _mapper = MapperField.GetMapper();
        }
        [Test]
        public void Should_Map_VisitTypeCorrectly()
        {
            // arrange
            PackedEntity<IEnumerable<VisitasComiPoco>, IEnumerable<TIPOVISITAS>> packedEntity = new PackedEntity<IEnumerable<VisitasComiPoco>, IEnumerable<TIPOVISITAS>>();

            packedEntity.PackItem = new List<VisitasComiPoco>()
            {
                new VisitasComiPoco { VisitTypeId = "1" },
                new VisitasComiPoco { VisitTypeId = "2" }
            };
            packedEntity.HelperItem = new List<TIPOVISITAS>()
            {
                new TIPOVISITAS { CODIGO_VIS = "1", NOMBRE_VIS = "Simple" },
                new TIPOVISITAS { CODIGO_VIS = "2", NOMBRE_VIS = "Simple2" },
            };
            // act
            var visits = _mapper.Map<PackedEntity<IEnumerable<VisitasComiPoco>, IEnumerable<TIPOVISITAS> >, IEnumerable<VisitsDto>>(packedEntity);

            // assert
            var simple = visits.Where((x => x.VisitType.Code == "1")).Where((x => x.VisitType.Name == "Simple"));
            var simple2 = visits.Where((x => x.VisitType.Code == "2")).Where((x => x.VisitType.Name == "Simple2"));

            Assert.AreEqual(simple.Count(), 1);
            Assert.AreEqual(simple2.Count(), 2);
        }


    }

}