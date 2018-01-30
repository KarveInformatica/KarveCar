using KarveDataServices.DataTransferObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KarveDataServices.DataObjects
{
    /// <summary>
    ///  This inteface specifies the interface to a model wrapper 
    ///  that allows to write, save, load all the entities related 
    ///  to a model domain element.
    ///  In this case is the client. 
    /// </summary>
    public interface IClientData
    {
        /// <summary>
        ///  This returns in case of saving a sigle client.
        /// </summary>
        /// <returns>true if the it has been successfully saved.</returns>
        Task<bool> Save();
        /// <summary>
        ///  This saves the changes in case of a client.
        /// </summary>
        /// <returns>true if it has been successfully saved.</returns>
        Task<bool> SaveChanges();

        /// <summary>
        /// Vehicle Data.
        /// </summary>
        ClientesDto Value { set; get; }

        /// <summary>
        ///  This tells us if the data is valid or not.
        /// </summary>
        bool Valid { get; set; }
  
    }

}
