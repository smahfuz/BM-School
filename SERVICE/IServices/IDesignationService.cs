using CORE.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SERVICE.IServices
{
    public interface IDesignationService
    {
        Task InsertAsync(Designation obj);
        Task UpdateAsync(Designation obj);
        Task DeleteAsync(Designation obj);
        Task SaveChangesAsync();
        Task<IList<Designation>> GetAllAsync();
        Task<Designation> GetIdAsync(int id);
    }
}
