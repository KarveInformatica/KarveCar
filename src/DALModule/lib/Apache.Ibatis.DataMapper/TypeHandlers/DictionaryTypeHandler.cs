using System;
using System.Data;
using Apache.Ibatis.DataMapper.Model.ResultMapping;

namespace Apache.Ibatis.DataMapper.TypeHandlers
{
    public class DictionaryTypeHandler : ITypeHandler
    {
        public bool IsSimpleType { get; set; }

        public object NullValue { get; set; }

        public bool Equals(object obj, string str)
        {
            throw new NotImplementedException();
        }

        public object GetDataBaseValue(object outputValue, Type parameterType)
        {
            throw new NotImplementedException();
        }

        public object GetValueByIndex(ResultProperty mapping, IDataReader dataReader)
        {
            throw new NotImplementedException();
        }

        public object GetValueByName(ResultProperty mapping, IDataReader dataReader)
        {
            throw new NotImplementedException();
        }

        public void SetParameter(IDataParameter dataParameter, object parameterValue, string dbType)
        {
            throw new NotImplementedException();
        }

        public object ValueOf(Type type, string s)
        {
            throw new NotImplementedException();
        }
    }
}