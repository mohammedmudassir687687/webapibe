using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.IdentityModel.Protocols;
using ReactWebApi.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;

namespace ReactWebApi.Data
{
    public interface IRepository
    {
        Task<IEnumerable<GarageModel>> GetGarage();

    }

    public class Repository : IRepository
    {
        private readonly IConfiguration _config;
        public Repository(IConfiguration config)
        {
            _config = config;
        }
        public async Task<IEnumerable<GarageModel>> GetGarage()
        {
            var connection = new SqlConnection(_config.GetConnectionString("DefaultConnection"));
            DynamicParameters parameters = new DynamicParameters();
            var garages = await connection.QueryAsync<GarageModel>("GETGARAGES", parameters, commandType: CommandType.StoredProcedure);
            return garages;
            
        }
    }
}
