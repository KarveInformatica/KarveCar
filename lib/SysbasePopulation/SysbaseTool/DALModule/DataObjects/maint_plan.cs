using System;
 
namespace DataAccessLayer.DataObjects
{
	/// <summary>
	/// Represents a maint_plan.
	/// NOTE: This class is generated from a T4 template - you should not modify it manually.
	/// </summary>
	public class maint_plan 
	{
	
	/// <summary>
    ///  Set or get the plan_id property.
    /// </summary>
    
		public UInt32 plan_id { get; set; }
 
	/// <summary>
    ///  Set or get the plan_name property.
    /// </summary>
    
		public string plan_name { get; set; }
 
	/// <summary>
    ///  Set or get the event_name property.
    /// </summary>
    
		public string event_name { get; set; }
 
	/// <summary>
    ///  Set or get the disable_new_connections property.
    /// </summary>
    
		public Boolean disable_new_connections { get; set; }
 
	/// <summary>
    ///  Set or get the disconnect_all_users property.
    /// </summary>
    
		public Boolean disconnect_all_users { get; set; }
 
	/// <summary>
    ///  Set or get the do_validate property.
    /// </summary>
    
		public Boolean do_validate { get; set; }
 
	/// <summary>
    ///  Set or get the validate_database_check property.
    /// </summary>
    
		public Boolean validate_database_check { get; set; }
 
	/// <summary>
    ///  Set or get the validate_checksum_check property.
    /// </summary>
    
		public Boolean validate_checksum_check { get; set; }
 
	/// <summary>
    ///  Set or get the validate_express_check property.
    /// </summary>
    
		public Boolean validate_express_check { get; set; }
 
	/// <summary>
    ///  Set or get the validate_normal_check property.
    /// </summary>
    
		public Boolean validate_normal_check { get; set; }
 
	/// <summary>
    ///  Set or get the do_backup property.
    /// </summary>
    
		public Boolean do_backup { get; set; }
 
	/// <summary>
    ///  Set or get the disk_backup property.
    /// </summary>
    
		public Boolean disk_backup { get; set; }
 
	/// <summary>
    ///  Set or get the full_backup property.
    /// </summary>
    
		public Boolean full_backup { get; set; }
 
	/// <summary>
    ///  Set or get the archive_backup property.
    /// </summary>
    
		public Boolean archive_backup { get; set; }
 
	/// <summary>
    ///  Set or get the backup_path property.
    /// </summary>
    
		public string backup_path { get; set; }
 
	/// <summary>
    ///  Set or get the tape_backup_prompt property.
    /// </summary>
    
		public Boolean tape_backup_prompt { get; set; }
 
	/// <summary>
    ///  Set or get the tape_backup_comment property.
    /// </summary>
    
		public string tape_backup_comment { get; set; }
 
	/// <summary>
    ///  Set or get the save_report_count property.
    /// </summary>
    
		public Int32? save_report_count { get; set; }
 
	/// <summary>
    ///  Set or get the report_to_console property.
    /// </summary>
    
		public Boolean report_to_console { get; set; }
 
	/// <summary>
    ///  Set or get the email_success property.
    /// </summary>
    
		public Boolean email_success { get; set; }
 
	/// <summary>
    ///  Set or get the email_failure property.
    /// </summary>
    
		public Boolean email_failure { get; set; }
 
	/// <summary>
    ///  Set or get the email_recipients property.
    /// </summary>
    
		public string email_recipients { get; set; }
 
	/// <summary>
    ///  Set or get the email_smtp_server_name property.
    /// </summary>
    
		public string email_smtp_server_name { get; set; }
 
	/// <summary>
    ///  Set or get the email_smtp_port property.
    /// </summary>
    
		public Int32? email_smtp_port { get; set; }
 
	/// <summary>
    ///  Set or get the email_smtp_sender_name property.
    /// </summary>
    
		public string email_smtp_sender_name { get; set; }
 
	/// <summary>
    ///  Set or get the email_smtp_sender_address property.
    /// </summary>
    
		public string email_smtp_sender_address { get; set; }
 
	/// <summary>
    ///  Set or get the email_smtp_auth_user_name property.
    /// </summary>
    
		public string email_smtp_auth_user_name { get; set; }
 
	/// <summary>
    ///  Set or get the email_smtp_auth_password property.
    /// </summary>
    
		public string email_smtp_auth_password { get; set; }
 
	/// <summary>
    ///  Set or get the email_user_id property.
    /// </summary>
    
		public string email_user_id { get; set; }
 
	/// <summary>
    ///  Set or get the email_user_password property.
    /// </summary>
    
		public string email_user_password { get; set; }
 
	/// <summary>
    ///  Set or get the email_smtp_trusted_certificates property.
    /// </summary>
    
		public string email_smtp_trusted_certificates { get; set; }
 
	/// <summary>
    ///  Set or get the email_smtp_certificate_company property.
    /// </summary>
    
		public string email_smtp_certificate_company { get; set; }
 
	/// <summary>
    ///  Set or get the email_smtp_certificate_unit property.
    /// </summary>
    
		public string email_smtp_certificate_unit { get; set; }
 
	/// <summary>
    ///  Set or get the email_smtp_certificate_name property.
    /// </summary>
    
		public string email_smtp_certificate_name { get; set; }
 
	/// <summary>
    ///  Set or get the custom_prevalidation_sql property.
    /// </summary>
    
		public string custom_prevalidation_sql { get; set; }
 
	/// <summary>
    ///  Set or get the custom_postbackup_sql property.
    /// </summary>
    
		public string custom_postbackup_sql { get; set; }
 
	/// <summary>
    ///  Set or get the email_smtp_trusted_cert_in_db property.
    /// </summary>
    
		public string email_smtp_trusted_cert_in_db { get; set; }
	}
}
