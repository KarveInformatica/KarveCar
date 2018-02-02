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
        private const string _imagePath = "/MasterModule;component/Images/search.png";
        private const string _copyCool = "/MasterModule;component/Images/copycool.png";
        private const string emailImagePath = "/MasterModule;component/Images/email.png";
        internal const string UiUpperPart = "UpperPartPageBuilder";
        internal const string UiMiddlePartPage = "UiMiddlePartPageBuilder";
        internal const string UiLeftPartPage = "UiLeftPartPageBuilder";
        internal const string UiRightPartPage = "UiRightPartPageBuilder";
        internal const string CommissionAgentSystemName = "CommissionAgentSystem";
        internal const string CommissionAgentInfoView = "CommissionAgentInfoView";
        internal const string VehiclesSystemName = "VehiclesSystemName";
        
        internal const string VehiclesSystemInfoView = "CommissionAgentInfoView";
        internal const string FareSystemName = "VehiclesSystemName";
        internal const string FareSystemInfoView = "CommissionAgentInfoView";
        internal const string CommissionAgentControlVm= "CommissionAgentControlViewModel";
        internal static string ClientSubSystemName = "ClientSystemName";

        public static string ImagePath => _imagePath;
        public static string CopyPath => _copyCool;
        public static string EmailImagePath => emailImagePath;
    }
}
