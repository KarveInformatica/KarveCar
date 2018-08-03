using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KarveCommon.Generic
{
   
        /// </summary>
        public enum DataType
        {
            /// <summary>
            ///  Double kind of data.
            /// </summary>
            DoubleField,
            /// <summary>
            /// Integer field of the component.
            /// </summary>
            IntegerField,
            /// <summary>
            ///  Nif field of the component.
            /// </summary>
            NifField,
            /// <summary>
            ///  Iban field of the component.
            /// </summary>
            IbanField,
            /// <summary>
            ///  Any other kind of field control.
            /// </summary>
            Any,
            /// <summary>
            ///  Email kind field of the control.
            /// </summary>
            Email,
            /// <summary>
            ///  Phone field of the control.
            /// </summary>
            Phone,
            /// <summary>
            /// Bank Account of the control.
            /// </summary>
            BankAccount,
            /// <summary>
            ///  Swift field of the control.
            /// </summary>
            Swift,
            /// <summary>
            ///  Datatime field of the contorl.
            /// </summary>
            DateTime,
        WebAddress
    }
    
}
