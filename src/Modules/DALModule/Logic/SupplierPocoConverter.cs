using AutoMapper;
using DataAccessLayer.Model;
using KarveDataServices.DataTransferObject;

namespace DataAccessLayer.Logic
{
    internal class SupplierPocoConverter: ITypeConverter<SupplierPoco, SupplierDto>
    {
        public SupplierPocoConverter()
        {
        }
        public SupplierDto Convert(SupplierPoco source, SupplierDto destination, ResolutionContext context)
        {
            var gc = new GenericConverter<SupplierPoco, SupplierDto>();
            var value = gc.Convert(source, destination, context);
            return value;
        }
    }
}