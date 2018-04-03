using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KarveTest.Services
{
    class TestDtoFactory
    {
        /// <summary>
        ///  Create a list of data transfer object.
        /// </summary>
        /// <returns>Return a list of data trasfer objects</returns>
        public  List<TestDto> CreateDtoList()
        {
            List<TestDto> testDto = new List<TestDto>()
            {
                new TestDto() { Name = "Luke",  Surname="Skywalker"},
                new TestDto() { Name = "Ben",   Surname="Skywalker"},
                new TestDto() { Name = "Leila", Surname="Skywalker"},
                new TestDto() { Name = "Kylo", Surname="Ren"},
                new TestDto() { Name = "Dart", Surname="Vader" }
            };
            return testDto;
        }
    }
}
