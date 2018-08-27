using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KarveDataServices.ViewObjects
{
    /// <summary>
    ///  Configuration settings data transfer object
    /// </summary>
    public class ConfigurationSettingsDto
    {
        /// <summary>
        ///  Data source name
        /// </summary>
        public string DataSourceName { set; get; }
        /// <summary>
        ///  Description 
        /// </summary>
        public string Description { set; get; }
        /// <summary>
        ///  User identifier
        /// </summary>
        public string UserId { set; get; }
        /// <summary>
        ///  Password
        /// </summary>
        public string Password { set; get; }
        /// <summary>
        ///  Hostname
        /// </summary>
        public string HostName { set; get; }
        /// <summary>
        /// Port
        /// </summary>
        public string Port { set; get; }
        /// <summary>
        ///  Server name
        /// </summary>
        public string ServerName { set; get; }
        /// <summary>
        ///  Database name
        /// </summary>
        public string DataBaseName { set; get; }
    }
}
