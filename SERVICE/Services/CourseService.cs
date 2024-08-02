using CORE.Models;
using REPO.IRepositories;
using SERVICE.IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SERVICE.Services
{
    public class CourseService : ICourseService
    {
        private readonly ICourseRepository _courseRepository;
        public CourseService(ICourseRepository courseRepository)
        {
            _courseRepository = courseRepository;
            
        }

        public Task DeleteAsync(Course obj)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Course>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Course> GetIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task InsertAsync(Course obj)
        {
            await _courseRepository.InsertAsync(obj);
        }

        public Task SaveChangesAsync()
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(Course obj)
        {
            throw new NotImplementedException();
        }
    }
}
