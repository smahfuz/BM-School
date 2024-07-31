using Microsoft.EntityFrameworkCore;
using REPO.DATA;
using REPO.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace REPO.Repositories
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly MyDbContext _context;
        private readonly DbSet<T> _dbSet;

        public Repository(MyDbContext context)
        {
            _context = context;
            _dbSet = _context.Set<T>();
        }

        public async Task InsertAsync(T entity)
        {
            await _dbSet.AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(T entity)
        {
            await Task.Run(() =>
            {
                if (_context.Entry(entity).State == EntityState.Detached)
                {
                    _dbSet.Attach(entity);
                }
                _dbSet.Remove(entity);
            });

            await _context.SaveChangesAsync();
        }


        public async Task UpdateAsync(T entity)
        {
            await Task.Run(() =>
            {
                _dbSet.Attach(entity);
                _context.Entry(entity).State = EntityState.Modified;

                _context.SaveChangesAsync();
            });
        }


        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _dbSet.ToListAsync();
        }
        public async Task<T> GetIdAsync(int id)
        {
            return await _dbSet.FindAsync(id);
        }


    }
}