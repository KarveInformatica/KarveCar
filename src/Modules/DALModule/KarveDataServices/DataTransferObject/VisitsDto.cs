using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KarveDataServices.DataTransferObject
{
    /// <summary>
    ///  Data Transfer object for the visit.
    /// </summary>
    public class VisitsDto
    {
        /// <summary>
        ///  Identifier for the visit.
        /// </summary>
        public string VisitId { get; set; }
        /// <summary>
        ///  Client identifer
        /// </summary>
        public string ClientId { get; set; }
        /// <summary>
        ///  Contact identifier
        /// </summary>
        public string ContactId { get; set; }
        /// <summary>
        ///  Seller identifier
        /// </summary>
        public string SellerId { get; set; }
         /// <summary>
         ///  Type of the visit
         /// </summary>
        public string VisitType { get; set; }
        /// <summary>
        ///  Name of the contact.
        /// </summary>
        public string ContactName { set; get; }
        /// <summary>
        /// Visit date.
        /// </summary>
        public DateTime? Date { set; get; }
     }
}
