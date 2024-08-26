using CORE.Models;
using Microsoft.EntityFrameworkCore;
using REPO.DATA;
using REPO.IRepositories;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace REPO.Repositories
{
    public class CourseRepository : Repository<Course>, ICourseRepository
    {
        private readonly MyDbContext _dbContext;

        public CourseRepository(MyDbContext context) : base(context)
        {
            _dbContext = context;
        }

        public async Task<List<Course>> GetCourseByClassIdAsync(int id)
        {
            return await _dbContext.Courses.Where(x => x.ClassId == id).ToListAsync();
        }


        // auto implemented 

    }
}
