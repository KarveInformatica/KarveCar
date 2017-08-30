using KarveCommon.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KarveCar.Logic.Generic
{
    public class UserAccessControlList: IUserAccessControlList
    {
        bool hasAllPermission(string userName, string programModuleUri)
        {
            return true;
        }
        bool hasInsertPermission(string userName, string programModuleUri)
        {
            return true;
        }
        bool hasDeletePermission(string userName, string programModuleUri)
        {
            return true;
        }
        bool hasUpdatePermission(string userName, string programModuleUri)
        {
            return true;
        }

        bool IUserAccessControlList.hasAllPermission(string userName, string programModuleUri)
        {
            throw new NotImplementedException();
        }

        bool IUserAccessControlList.hasInsertPermission(string userName, string programModuleUri)
        {
            throw new NotImplementedException();
        }

        bool IUserAccessControlList.hasDeletePermission(string userName, string programModuleUri)
        {
            throw new NotImplementedException();
        }

        bool IUserAccessControlList.hasUpdatePermission(string userName, string programModuleUri)
        {
            throw new NotImplementedException();
        }
    }
}
