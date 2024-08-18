using CORE.Models;
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
    public class StudentRepository : Repository<Student>, IStudentRepository
    {
        private readonly MyDbContext _dbContext;
        public StudentRepository(MyDbContext context) : base(context)
        {
            _dbContext = context;
        }

        public async Task<List<Student>> GetStudentByClassIdAsync(int id)
        {
            return await _dbContext.Students.Where(x => x.ClassId == id).ToListAsync();
        }
    }
}
