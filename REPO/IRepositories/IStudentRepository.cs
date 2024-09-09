using CORE.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace REPO.IRepositories
{
    public interface IStudentRepository : IRepository<Student>
    {
        Task<List<Student>> GetStudentByClassIdAsync(int id);
        Task<List<ResultSheet>> GetResultsByStudentIdAsync(int id);
        Task<string> GetLastRollByClassIdAsync(int classId);
    }
}
