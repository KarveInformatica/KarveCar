using System;
using KarveDapper.Extensions;

namespace DataAccessLayer.DataObjects
{

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
        /// 
        /// </summary>
        public string VisitTypeId { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string VisitOrder { get; set; }
        /// <summary>
        /// ContactId.
        /// </summary>
        public string ContactId { get; set; }
        /// <summary>
        ///  Code visit.
        /// </summary>
        public int VisitCode { get; set; }
        /// <summary>
        ///  ResellerId
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
        public string VisitContactId { get; internal set; }
        public DateTime? VisitMembershipDate { get; internal set; }
        public string VisitText { get; internal set; }
    }
}