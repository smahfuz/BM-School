using CORE.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace REPO.IRepositories
{
    public interface IResultRepository : IRepository<ResultSheet>
    {
        Task<List<ResultSheet>> GetStudentByClassIdAsync(int id);
        Task<List<ResultSheet>> GetResultsByStudentIdAsync(int id);
    }
}
