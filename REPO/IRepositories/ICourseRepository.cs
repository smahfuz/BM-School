using CORE.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace REPO.IRepositories
{
    public interface ICourseRepository : IRepository<Course>
    {
        Task<List<Course>> GetCourseByClassIdAsync(int id);
        
    }
}
