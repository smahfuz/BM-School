using CORE.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace REPO.IRepositories
{
    public interface IStudentRepository : IRepository<Student>
    {
        Task<List<Student>> GetStudentByClassIdAsync(int id);
    }
}
