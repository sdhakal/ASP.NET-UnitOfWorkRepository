using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using UnitOfWorkRepository.Interfaces.Repositories;
using UnitOfWorkRepository.Models;

namespace UnitOfWorkRepository.Persistence.Repositories
{
    public class CourseRepository : Repository<Course>, ICourseRepository
    {
        public CourseRepository(ApplicationDbContext context) 
            : base(context)
        {
        }

        public IEnumerable<Course> GetTopSellingCourses(int count)
        {
            return ApplicationDbContext.Courses.OrderByDescending(c => c.FullPrice).Take(count).ToList();
        }

        public IEnumerable<Course> GetCoursesWithAuthors()
        {
            return ApplicationDbContext.Courses
                .Include(c => c.Author)
                .ToList();
        }

        public ApplicationDbContext ApplicationDbContext
        {
            get { return Context as ApplicationDbContext; }
        }
    }
}