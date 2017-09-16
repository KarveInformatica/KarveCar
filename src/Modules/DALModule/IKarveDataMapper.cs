using Apache.Ibatis.DataMapper;
using Apache.Ibatis.DataMapper.Session;

namespace DataAccessLayer
{
    public interface IKarveDataMapper
    {
        string ConfigFile { set; get; }
        IDataMapper DataMapper { get; }
        ISessionFactory SessionFactory { get; }
    }
}
