using System;
using KarveDapper.Extensions;

namespace DataAccessLayer.DataObjects
{
    /// <summary>
    ///  Plain object clr used to fetch the visits.
    /// </summary>
public class VisitasComiPoco
{
// <summary>
    ///  Set or get the visIdVisita property.
    /// </summary>
        [Key]
        public string VisitId { get; set; }
	/// <summary>
    ///  Set or get the visIdCliente property.
    /// </summary>    
		public string VisitClientId { get; set; }
	/// <summary>
    ///  Set or get the visIdContacto property.
    /// </summary>
		public DateTime VisitDate { get; set; }
        /// <summary>
        ///  Visit reseller id.
        /// </summary>
        public int VisitResellerId { get; set; }
        /// <summary>
        /// flatten visit type identifier.
        /// </summary>
        public string VisitTypeId { get; set; }
        /// <summary>
        ///  visit type name
        /// </summary>
        public string VisitTypeName { get; set; }
        /// <summary>
        ///  visit type user
        /// </summary>
        public string VisitTypeUser { get; set; }
        /// <summary>
        ///  visit type last modification
        /// </summary>
        public string VisitTypeLastModification { get; set; }

        /// </summary>
        public string VisitOrder { get; set; }
        /// <summary>
        /// Reference of the contact.
        /// </summary>
        public string ContactId { get; set; }
        /// <summary>
        ///  Code visit.
        /// </summary>
        public int VisitCode { get; set; }
        /// <summary>
        ///  Reference of the reseller.
        /// </summary>
        public string ResellerId { get; set; }
        /// <summary>
        ///  ContactName
        /// </summary>
        public string ContactName { get; set; }
        /// <summary>
        ///  ResellerName
        /// </summary>
        public string ResellerName { get; set; }
        /// <summary>
        ///  cell phone of teh visit
        /// </summary>
        public string ResellerCellPhone { get; internal set; }
        /// <summary>
        ///  last modification of the visit
        /// </summary>
        public string LastModification { get; internal set; }
        /// <summary>
        ///  last user.
        /// </summary>
        public string User { get; internal set; }
        /// <summary>
        ///  Visit membership date / fecha alta.
        /// </summary>
        public DateTime? VisitMembershipDate { get; internal set; }
        /// <summary>
        ///  Text of the visit.
        /// </summary>
        public string VisitText { get; internal set; }
    }
}