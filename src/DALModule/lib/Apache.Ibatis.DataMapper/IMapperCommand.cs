using System.Threading.Tasks;
using System.Data;
using Apache.Ibatis.DataMapper.Session;
namespace Apache.Ibatis.DataMapper
{
    /// <summary>
    ///  This simple interface is for batching multiple commands to a single connection.
    /// </summary>
    public interface IMapperCommand
    {
        /// <summary>
        /// Executing the command asynchrounsly
        /// </summary>
        /// <returns></returns>
        Task<DataTable> ExecuteAsync();
        DataMapper Mapper { set; get; }
        ISessionScope Scope { set; get; }
    }
}
