using System.Data;

namespace KarveDataServices
{

    public interface IConnectionOpener
    {
        IDbConnection OpenNewDbConnection();
    }
}