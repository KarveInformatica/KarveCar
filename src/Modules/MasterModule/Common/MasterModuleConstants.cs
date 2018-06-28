using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MasterModule.Common
{
    /// <summary>
    ///  Common constants for the master module
    /// </summary>
    public class MasterModuleConstants
    {
        public MasterModuleConstants()
        {
        }

        internal const string ProviderSubsystemName = "ProviderSystem";
        private const string _companyDrivers = "/MasterModule;component/Images/companyDrivers.png";
        private const string _imagePath = "/MasterModule;component/Images/search.png";
        private const string _copyCool = "/MasterModule;component/Images/copycool.png";
        private const string emailImagePath = "/MasterModule;component/Images/email.png";
        // TODO: remove this
        internal const string UiUpperPart = "UpperPartPageBuilder";
        // TODO: remove this
        internal const string UiMiddlePartPage = "UiMiddlePartPageBuilder";
        // TODO: remove this
        internal const string UiLeftPartPage = "UiLeftPartPageBuilder";
        // TODO: remove this
        internal const string UiRightPartPage = "UiRightPartPageBuilder";
        internal const string CommissionAgentInfoView = "CommissionAgentInfoView";
        public const string VehiclesSystemInfoView = "CommissionAgentInfoView";
        public const string FareSystemInfoView = "CommissionAgentInfoView";
        public const string CompanyInfoView = "CompanyInfoView";
        public const string OfficeInfoView = "OfficeInfoView";
        public const string CommissionAgentControlVm = "CommissionAgentControlViewModel";
        public const string VehiclesSystemName = "VehiclesSystemName";
        public const string FareSystemName = "FareSystemName";
        public const string CommissionAgentSystemName = "CommissionAgentSystem";
        public const string ClientSubSystemName = "ClientSystemName";
        public const string CompanySubSystemName = "CompanySystemName";
        internal const string OfficeSubSytemName = "OfficeSubSystemName";
        internal const string FareSubsystem = "FareSubSystemName";

        public static string CompanyDrivers => _companyDrivers;
        public static string ImagePath => _imagePath;
        public static string CopyPath => _copyCool;
        public static string EmailImagePath => emailImagePath;
    }
}
