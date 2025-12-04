using ParkingManager.Core.Enum;
using System.Data;

namespace ParkingManager.Core.Interfaces
{
    public interface IDbConnectionFactory
    {
        DatabaseProvider Provider { get; }
        IDbConnection CreateConnection();
    }
}
