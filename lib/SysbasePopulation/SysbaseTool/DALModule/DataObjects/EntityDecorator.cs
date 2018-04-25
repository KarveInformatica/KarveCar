using System;

namespace DataAccessLayer.DataObjects
{

    public class EntityDecorator
    {
        public Type Type { set; get; }
        public Type DtoType { set; get; }
        public object Value {set; get;}
    }
}