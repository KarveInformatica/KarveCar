using KarveDataServices.ViewObjects;
using AutoMapper;
using DataAccessLayer.DataObjects;

namespace DataAccessLayer.Logic
{
    /// <summary>
    /// POCO to Dto converter for the commission branches
    /// </summary>
    public class BranchesConverter : ITypeConverter<ComiDelegaPoco, BranchesViewObject>
    {
        public BranchesViewObject Convert(ComiDelegaPoco source, BranchesViewObject destination, ResolutionContext context)
        {
            BranchesViewObject branchesDto = new BranchesViewObject();
            branchesDto.BranchId = source.cldIdDelega.ToString();
            branchesDto.Code = branchesDto.BranchId;
            branchesDto.Branch = source.cldDelegacion;
            if (source.PROV != null)
            {
                branchesDto.Province = new ProvinceViewObject();
                branchesDto.Province.Code = source.PROV.SIGLAS;
                branchesDto.Province.Name = source.NOM_PROV;
                branchesDto.Province.Country = source.PAIS;
                branchesDto.ProvinceName = source.NOM_PROV;

                branchesDto.Zip = source.PROV.CP;
                // redundundant.
                branchesDto.ProvinceSource = branchesDto.Province;


            }
            branchesDto.Zip = source.cldCP;
            branchesDto.ProvinceId = source.cldIdProvincia;
            branchesDto.Address = source.cldDireccion1;
            branchesDto.Address2 = source.cldDireccion2;
            branchesDto.Phone = source.cldTelefono1;
            branchesDto.Phone2 = source.cldTelefono2;
            branchesDto.Email = source.cldEMail;
            branchesDto.City = source.cldPoblacion;
            branchesDto.Fax = source.cldFax;
            branchesDto.User = source.USUARIO;
            branchesDto.LastModification = source.ULTMODI;
            return branchesDto;
        }
    }
}

