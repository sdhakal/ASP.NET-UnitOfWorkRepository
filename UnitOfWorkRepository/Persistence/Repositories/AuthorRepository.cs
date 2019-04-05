using System.Data.Entity;
using System.Linq;
using UnitOfWorkRepository.Interfaces.Repositories;
using UnitOfWorkRepository.Models;

namespace UnitOfWorkRepository.Persistence.Repositories
{
    public class AuthorRepository : Repository<Author>, IAuthorRepository
    {
        public AuthorRepository(ApplicationDbContext context) : base(context)
        {
        }

        public Author GetAuthorWithCourses(int id)
        {
            return ApplicationDbContext.Authors.Include(a => a.Courses).SingleOrDefault(a => a.AuthorId == id);
        }

        public ApplicationDbContext ApplicationDbContext
        {
            get { return Context as ApplicationDbContext; }
        }
    }
}