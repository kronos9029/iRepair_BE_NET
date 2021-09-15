using System.Collections.Generic;
using System.Threading.Tasks;
using iRepair_BE_NET.Models.Entities;

namespace iRepair_BE_NET.Repositories
{
    public interface ITestServices
    {
        Task<List<dynamic>> GetAll();
        public Account GetById(int id);
    }
}