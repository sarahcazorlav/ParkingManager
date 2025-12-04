using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using ParkingManager.Core.Enum;
using ParkingManager.Core.Interfaces;
using System.Data;

namespace ParkingManager.Infrastructure.Repositories
{
    public class DbConnectionFactory : IDbConnectionFactory
    {
        private readonly string _connectionString;
        private readonly DatabaseProvider _provider;

        public DbConnectionFactory(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("DefaultConnection")
                ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found");

            // Por ahora solo SQL Server
            _provider = DatabaseProvider.SqlServer;
        }

        public DatabaseProvider Provider => _provider;

        public IDbConnection CreateConnection()
        {
            return new SqlConnection(_connectionString);
        }
    }
}