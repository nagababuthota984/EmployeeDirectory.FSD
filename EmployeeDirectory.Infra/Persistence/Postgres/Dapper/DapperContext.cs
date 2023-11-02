using EmployeeDirectory.Application.Contracts;
using Microsoft.Extensions.Configuration;
using Npgsql;
using System.Data;

namespace EmployeeDirectory.Infra.Persistence.Postgres.Dapper
{
    public class DapperContext : IDapperContext
    {
        private readonly IConfigurationRoot _config;
        private readonly string _connectionString;
        public IDbConnection Connection { get; set; }
        public DapperContext(IConfigurationRoot config)
        {
            _config = config;
            _connectionString = _config.GetConnectionString("Postgres") ?? string.Empty;
            Connection = CreateConnection();
        }
        public IDbConnection CreateConnection()
        {
            try
            {
                if (Connection == null && !string.IsNullOrEmpty(_connectionString))
                    return new NpgsqlConnection(_connectionString);
                return Connection;
            }
            catch (Exception)
            {
                throw new ArgumentException("Invalid Connection String");
            }
        }
    }
}
