using CORE.Models;
using Microsoft.EntityFrameworkCore;
using REPO.DATA;
using REPO.IRepositories;
using System.Collections.Generic;
using System.Linq;
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

        public async Task<List<ResultSheet>> GetResultsByStudentIdAsync(int classId)
        {
            return await _dbContext.ResultsSheets
                .Where(x => x.ClassId == classId)
                .Include(r => r.Course)
                .Include(r => r.Student)
                .ToListAsync();
        }

       
        public async Task<string> GetLastRollByClassIdAsync(int classId)
        {
            
            return await _dbContext.Students
                .Where(s => s.ClassId == classId)
                .OrderByDescending(s => s.Roll)         
                .Select(s => s.Roll)                    
                .FirstOrDefaultAsync();
        }
    }
}
