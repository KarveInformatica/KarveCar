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
        /// Load value
        /// </summary>
        /// <param name="code">Client code primary key</param>
        /// <returns></returns>
        Task<bool> LoadValue(string code);
        /// <summary>
        ///  This returns in case of saving a sigle client.
        /// </summary>
        /// <returns>true if the it has been successfully saved.</returns>
        Task<bool> SaveAll();
        /// <summary>
        /// <summary>
        /// ClientData Data.
        /// </summary>
        ClientesDto Value { set; get; }
        /// <summary>
        ///  This tells us if the data is valid or not.
        /// </summary>
        bool Valid { get; set; }
        /// <summary>
        ///  Delete asynchronous thing.s
        /// </summary>
        /// <returns></returns>
        Task<bool> DeleteAsync();
    }

}
