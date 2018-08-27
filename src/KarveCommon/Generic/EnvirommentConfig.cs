namespace KarveCommon.Generic
{
    public enum EnvironmentConfig { OfficeConfiguration, CompanyConfiguration, KarveConfiguration };
    /// <summary>
    /// This clas provide some well known configuration variables.
    /// </summary>
    public static class EnvironmentKey
    {
        public const string CurrentUser = "CurrentUser";
        public const string CurrentOffice = "CurrentOffice";
        public const string ConnectedCompany = "EMP_CONNECTADA";
        public const string DataBaseConnectionString = "DataBaseConfiguration";
        public const string DataBaseType = "DataBaseType";
    }
}
