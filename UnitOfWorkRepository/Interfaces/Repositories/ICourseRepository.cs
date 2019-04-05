using System.Collections.Generic;
using UnitOfWorkRepository.Models;

namespace UnitOfWorkRepository.Interfaces.Repositories
{
    public interface ICourseRepository : IRepository<Course>
    {
        IEnumerable<Course> GetTopSellingCourses(int count);
        IEnumerable<Course> GetCoursesWithAuthors();
    }
}