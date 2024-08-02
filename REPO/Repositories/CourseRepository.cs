using CORE.Models;
using REPO.DATA;
using REPO.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
    }
}
