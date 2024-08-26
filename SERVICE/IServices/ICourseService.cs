using CORE.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SERVICE.IServices
{
    public interface ICourseService
    {
        Task InsertAsync(Course obj);
        Task UpdateAsync(Course obj);
        Task DeleteAsync(Course obj);
        Task SaveChangesAsync();
        Task<IEnumerable<Course>> GetAllAsync();
        Task<Course> GetIdAsync(int id);
        Task<List<Course>> GetCourseByClassIdAsync(int id);
    }
}
