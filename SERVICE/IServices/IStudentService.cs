using CORE.Models;
using System.Collections.Generic;
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
        Task<List<Student>> GetStudentByClassIdAsync(int id);
    }
}
