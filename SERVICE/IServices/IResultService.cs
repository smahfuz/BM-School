using CORE.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SERVICE.IServices
{
    public interface IResultService
    {
        Task InsertAsync(ResultSheet obj);
        Task UpdateAsync(ResultSheet obj);
        Task DeleteAsync(ResultSheet obj);
        Task SaveChangesAsync();
        Task<IEnumerable<ResultSheet>> GetAllAsync();
        Task<ResultSheet> GetIdAsync(int id);
        Task<List<ResultSheet>> GetStudentByClassIdAsync(int id);
        Task<List<ResultSheet>> GetResultsByStudentIdAsync(int id);



    }
}
