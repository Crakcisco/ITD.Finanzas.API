using Dapper;
using Microsoft.Extensions.Configuration;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;

namespace ITD.Finanzas.Infraestructure.Services
{
    public class BDServices
    {
        private IDbConnection? _dbConnection { get; set; }
        private string? _connectionString { get; set; }

        public BDServices(IConfiguration configuration)
        {
            _connectionString = configuration?.GetConnectionString("DefaultConnection");
        }

        private IDbConnection CreateConnection()
        {
            return new MySqlConnection(_connectionString);
        }

        public async ValueTask<IEnumerable<T>> ExecuteStoredProcedureQuery<T>(string storedProcedure, DynamicParameters? parameters = null)
        {
            using (var dbConnection = CreateConnection())
            {
                _dbConnection = dbConnection;
                return await dbConnection.QueryAsync<T>(storedProcedure, parameters, commandType: CommandType.StoredProcedure);
            }
        }

        public async ValueTask<T> ExecuteStoredProcedureQueryFirstOrDefault<T>(string storedProcedure, DynamicParameters? parameters = null)
        {
            using (var dbConnection = CreateConnection())
            {
                _dbConnection = dbConnection;
                return await dbConnection.QuerySingleOrDefaultAsync<T>(storedProcedure, parameters, commandType: CommandType.StoredProcedure);
            }
        }
    }
}
