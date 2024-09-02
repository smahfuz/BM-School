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
    public class ClassLevelRepository : Repository<ClassLevel>, IClasslevelRepository
    {
        private readonly MyDbContext _dbContext;

        public ClassLevelRepository(MyDbContext context) : base(context)
        {
            _dbContext = context;
        }

        public Task<ClassLevel> SearchStudentByClassId(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<ClassLevel> SearchStudentByClassIdAsync(int id)
        {
            //return await _dbContext.Departments.Include(x => x.Patients).FirstOrDefaultAsync(x => x.Id == id);
            return await _dbContext.ClassLevels.Include(x => x.ResultsSheets).FirstOrDefaultAsync(x => x.Id == id);

        }
    }
}
