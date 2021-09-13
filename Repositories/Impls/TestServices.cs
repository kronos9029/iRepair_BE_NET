using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Dapper;
using iRepair_BE_NET.Models;

namespace iRepair_BE_NET.Repositories.Impls
{
    public class TestServices : ITestServices
    {

        private readonly IDbConnection _dbConnection;

        public TestServices(IDbConnection dbConnection){
            _dbConnection = dbConnection;
        }

        public Admin GetById(int id)
        {
            const string sql = @"SELECT * FROM Admin WHERE AccountId = @Id";
            return _dbConnection.QueryFirst<Admin>(sql, new { id });

        }

        public async Task<List<dynamic>> GetAll()
        {
            const string sql = @"SELECT * FROM admin";

            // No need to use using statement. Dapper will automatically
            // open, close and dispose the connection for you.
            var result =  await _dbConnection.QueryAsync<dynamic>(sql);

            return result.ToList();
        }

    }
}