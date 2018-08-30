// --------------------------------------------------------------------------------------------------------------------
// <copyright file="User.cs" company="">
//   
// </copyright>
// <summary>
//   Defines the User type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace DataAccessLayer.DtoWrapper
{
    using KarveDataServices.DataObjects;
    using KarveDataServices.ViewObjects;

    public class User: IUserData
    {
        public bool Valid { get; set; }

        public UserViewObject Value { get; set; }

        public UserViewObject FromDomain(KarveCar.Model.User domainObject)
        {
            var user = new UserViewObject();
            user.NOMBRE = domainObject.Name;
            user.PASS = domainObject.Password;
            user.OFI_COD = domainObject.Office.Code;
            return user;
        }

        public KarveCar.Model.User FromViewType(UserViewObject viewObject)
        {
            var user = new KarveCar.Model.User();
            user.Name = viewObject.Name;
            user.Password = viewObject.PASS;
            user.Office = new KarveCar.Model.Office();
            user.Office.Code = viewObject.CODIGO;
            //user.Office.Company = Office.SUBLICEN;
            return user;
        }
        public OfficeViewObject Office { set; get; }
    }
}
