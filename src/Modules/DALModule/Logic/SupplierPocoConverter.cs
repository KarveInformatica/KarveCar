using AutoMapper;
using DataAccessLayer.DtoWrapper;
using KarveDataServices.ViewObjects;

namespace DataAccessLayer.Logic
{
    internal class SupplierPocoConverter: ITypeConverter<SupplierPoco, SupplierViewObject>
    {
        public SupplierPocoConverter()
        {
        }
        public SupplierViewObject Convert(SupplierPoco source, SupplierViewObject destination, ResolutionContext context)
        {
            var gc = new GenericConverter<SupplierPoco, SupplierViewObject>();
            var value = gc.Convert(source, destination, context);
            return value;
        }
    }
}