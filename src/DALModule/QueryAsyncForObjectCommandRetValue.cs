using Apache.Ibatis.DataMapper;

namespace DataAccessLayer
{
    internal class QueryAsyncForObjectCommandRetValue<T> : IMapperCommand
    {
        private string v1;
        private string v2;

        public QueryAsyncForObjectCommandRetValue(string v1, string v2)
        {
            this.v1 = v1;
            this.v2 = v2;
        }
    }
}