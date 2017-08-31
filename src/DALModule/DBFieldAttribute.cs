using System;

namespace DataAccessLayer.DataObjects
{
    internal class DBFieldAttribute : Attribute
    {
        private string v;
        private DBFieldType integer;
        private NullPolicy allowed;
        private UniquePolicy no1;
        private PrimaryKey no2;

        public DBFieldAttribute(string v, DBFieldType integer)
        {
            this.v = v;
            this.integer = integer;
        }

        public DBFieldAttribute(string v, DBFieldType integer, NullPolicy allowed, UniquePolicy no1, PrimaryKey no2)
        {
            this.v = v;
            this.integer = integer;
            this.allowed = allowed;
            this.no1 = no1;
            this.no2 = no2;
        }
    }
}