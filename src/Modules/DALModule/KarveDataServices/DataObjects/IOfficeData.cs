using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KarveDataServices.DataTransferObject;

namespace KarveDataServices.DataObjects
{
    /// <summary>
    ///  Value of the OfficeData.
    /// </summary>
    public interface IOfficeData : IHelperBase
    {
        /// <summary>
        ///  Vale of the data transfer object.
        /// <summary>
        /// OfficeDto Data.
        /// </summary>
        OfficeDtos Value { set; get; }
        /// <summary>
        ///  This tells us if the data is valid or not.
        /// </summary>
        bool Valid { get; set; }
        /// <summary>
        ///   CurrenciesDto.
        /// </summary>
        IEnumerable<CurrenciesDto> CurrenciesDto { get ; set ; }

    }
}
