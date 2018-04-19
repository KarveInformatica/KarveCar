using KarveDataServices.DataTransferObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;


namespace KarveDataServices.DataObjects
{
    /// <summary>
    ///  This inteface specifies the interface to a model wrapper 
    ///  that allows to write, save, load all the entities related 
    ///  to a model domain element.
    ///  In this case is the client. 
    /// </summary>
    public interface IClientData: IHelperData
    {
       
        /// <summary>
        ///  Vale of the data transfer object.
        /// <summary>
        /// ClientData Data.
        /// </summary>
       ClientDto Value { set; get; }
        /// <summary>
        ///  This tells us if the data is valid or not.
        /// </summary>
        bool Valid { get; set; }
   

    }

   
}
