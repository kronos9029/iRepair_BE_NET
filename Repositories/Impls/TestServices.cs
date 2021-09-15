using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Dapper;
using iRepair_BE_NET.Models.Entities;

namespace iRepair_BE_NET.Repositories.Impls
{
    public class TestServices : ITestServices
    {

        private readonly IDbConnection _dbConnection;

        public TestServices(IDbConnection dbConnection){
            _dbConnection = dbConnection;
        }

        public Account GetById(int id)
        {
            const string sql = @"SELECT * FROM Account WHERE AccountId = @Id";
            return _dbConnection.QueryFirst<Account>(sql, new { id });

        }

        public async Task<List<dynamic>> GetAll()
        {
            const string sql = @"SELECT * FROM Account";

            // No need to use using statement. Dapper will automatically
            // open, close and dispose the connection for you.
            var result =  await _dbConnection.QueryAsync<dynamic>(sql);

            return result.ToList();
        }

    }
}