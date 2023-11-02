using Microsoft.Extensions.Configuration;
using Npgsql;
using System.Data;

namespace EmployeeDirectory.Infra.Persistence.Postgres.Dapper
{
    public class DapperContext
    {
        private readonly IConfigurationRoot _config;
        private readonly string _connectionString;
        public DapperContext(IConfigurationRoot config)
        {
            _config = config;
            _connectionString = _config.GetConnectionString("Postgres") ?? string.Empty;
        }
        public IDbConnection CreateConnection()
        {
            return new NpgsqlConnection(_connectionString);
        }
    }
}
