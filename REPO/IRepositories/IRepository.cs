using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace REPO.IRepositories
{
    public interface IRepository<T> where T : class
    {
        //void Insert(T entity);
        Task InsertAsync(T entity);

        //void Update(T entity);
        Task UpdateAsync(T entity);

        //void Delete(T entity);
        Task DeleteAsync(T entity);
        //void SaveChanges();
        Task SaveChangesAsync();

        //IEnumerable<T> GetAll();
        Task<IList<T>> GetAllAsync();
        //T GetId(int id);
        Task<T> GetIdAsync(int id);


    }
}