using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KarveDataServices
{
    class ConstantDataError
    {
        private const string _nameTooLong = "Texto demasiado largo";
        private const string _swiftinvalid = "Swift invalido";
        private const string _agentNamePresent = "Il nombre agente es requerido";
        private const string _agentNameTooLong = "Nombre agente demasiado largo";
        private const string _channelnameTooLong = "Nombre canal demasiado largo";
        private const string _accountValueTooLong = "Valore cuenta no valido";
        private const string _branchNameTooLong= "Nombre delegacion demasiado largo";
        private const string _emailValidate = "Email no validas";
        private const string _invalidRange = "Intervalo no valido";
        private const string _codeNotValid = "Codigo no valido";
        private const string _invalidPhone = "Telefono no valido";
        private const string _nameIsEmpty = "Pon un valore valido y no vacio, por favor";
        private const string _sameHour = "Misma hora de salida y llegada";
        private const string _invalidDate = "Error en las fechas de reserva";
        private const string _invalidWeb = "Web no valida";

        public static string NameTooLong { get { return _nameTooLong; } }
        public static string SwiftInvalid { get { return _swiftinvalid; } }
        public static string AgentNamePresent { get { return _agentNamePresent; } }
        public static string AgentNameTooLong { get { return _agentNameTooLong; } }
        public static string ChannelNameTooLong { get { return _channelnameTooLong; } }
        public static string AccountValueTooLong { get { return _accountValueTooLong; } }
        public static string BranchNameTooLong { get { return _branchNameTooLong; } }
        public static string NameIsEmpty { get { return _nameIsEmpty; } }
        public static string InvalidEmail { get { return _emailValidate; } }
        public static string InvalidRange { get { return _invalidRange; } }
        public static string CodeNotValid { get { return _codeNotValid; } }
        public static string InvalidPhone { get { return _invalidPhone; } }
        public static string SameHourError {  get { return _sameHour; } }
        public static string InvalidDate { get { return _invalidDate; } }
        public static string InvalidWeb {  get { return _invalidWeb;  } }
    }
}
