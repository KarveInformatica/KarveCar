using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KarveCommon;
using KarveCommon.Services;

namespace ToolBarModule
{
    public interface IMessageHandler
    {
        /// <summary>
        ///  This is the payload for the message handling
        /// </summary>
        /// <param name="payload"> Payload from the generic component.</param>
        /// <returns></returns>
        bool incomingMessage(DataPayLoad payload);
    }
}
