namespace KarveCommon.Services
{
    public interface IUserAccessControlList
    {
        bool hasAllPermission(string userName, string programModuleUri);
        bool hasInsertPermission(string userName, string programModuleUri);
        bool hasDeletePermission(string userName, string programModuleUri);
        bool hasUpdatePermission(string userName, string programModuleUri);
        
    }
}