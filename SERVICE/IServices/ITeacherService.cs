using CORE.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SERVICE.IServices
{
    public interface ITeacherService
    {
        Task InsertAsync(Teacher tea);
        Task UpdateAsync(Teacher tea);
        Task DeleteAsync(Teacher tea);
        Task SaveChangesAsync();
        Task<IList<Teacher>> GetAllAsync();
        Task<Teacher> GetIdAsync(int id);
    }
}