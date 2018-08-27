namespace DataAccessLayer.Logic
{
    using AutoMapper;

    using DataAccessLayer.DataObjects;

    using KarveDataServices.ViewObjects;

    /// <summary>
    ///  POCO to Dto converter.
    /// </summary>
    /// <summary>
    /// POCO to Dto converter for the commission branches
    /// </summary>
    public class ClientBranchesConverter : ITypeConverter<CliDelegaPoco, BranchesViewObject>
    {
        public BranchesViewObject Convert(CliDelegaPoco source, BranchesViewObject destination, ResolutionContext context)
        {
            var branchesDto = new BranchesViewObject
                                  {
                                      Branch = source.cldDelegacion,
                                      BranchId = source.cldIdDelega,
                                      Province = new ProvinceViewObject(),
                                      ProvinceSource = new ProvinceViewObject()
                                  };

            if (source.PROV != null)
            {

                branchesDto.Province.Code = source.PROV.SIGLAS;
                branchesDto.Province.Name = source.PROV.PROV;
                branchesDto.Province.Country = source.PROV.PAIS;
                branchesDto.ProvinceSource = branchesDto.Province;
            }
            branchesDto.Address = source.cldDireccion1;
            branchesDto.Address2 = source.cldDireccion2;
            branchesDto.Phone = source.cldTelefono1;
            branchesDto.Phone2 = source.cldTelefono2;
            branchesDto.Email = source.cldEMail;
            branchesDto.City = source.cldPoblacion;
            return branchesDto;
        }
    }
}