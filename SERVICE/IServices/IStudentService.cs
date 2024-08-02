using CORE.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SERVICE.IServices
{
    public interface IStudentService
    {
        Task InsertAsync(Student obj);
        Task UpdateAsync(Student obj);
        Task DeleteAsync(Student obj);
        Task SaveChangesAsync();
        Task<IEnumerable<Student>> GetAllAsync();
        Task<Student> GetIdAsync(int id);
    }
}
