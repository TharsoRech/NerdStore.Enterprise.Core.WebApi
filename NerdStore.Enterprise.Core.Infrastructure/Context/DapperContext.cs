using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using NerdStore.Enterprise.Core.Infrastructure.Context.Interface;

namespace NerdStore.Enterprise.Core.Infrastructure.Context
{
    public class DapperContext: IDapperContext
    {
        private readonly IConfiguration _configuration;
        private readonly string _connectionString;
        public DapperContext(IConfiguration configuration)
        {
            _configuration = configuration;
            _connectionString = _configuration.GetConnectionString("SqlConnection");
        }

        public async Task<int> ExecuteAsync(string sql,object entity)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                return await connection.ExecuteAsync(sql, entity);
            }
        }

        public async Task<dynamic> QuerySingleOrDefaultAsync(string sql, object entity)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                return await connection.QuerySingleOrDefaultAsync(sql, entity);
            }
        }

        public async Task<dynamic> QueryFirstOrDefaultAsync(string sql, object entity)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                return await connection.QueryFirstOrDefaultAsync(sql, entity);
            }
        }

        public async Task<dynamic> QueryFirstAsync(string sql, object entity)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                return await connection.QueryFirstAsync(sql, entity);
            }
        }

        public async Task<IEnumerable<dynamic>> QueryAsync(string sql, object entity)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                return await connection.QueryAsync(sql, entity);
            }
        }
    }
}
