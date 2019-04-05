using UnitOfWorkRepository.Interfaces;
using UnitOfWorkRepository.Interfaces.Repositories;
using UnitOfWorkRepository.Models;
using UnitOfWorkRepository.Persistence.Repositories;

namespace UnitOfWorkRepository.Persistence
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _context;

        public UnitOfWork(ApplicationDbContext context)
        {
            _context = context;
            Courses = new CourseRepository(_context);
            Authors = new AuthorRepository(_context);
            Tags = new TagRepository(_context);
        }

        public ICourseRepository Courses { get; private set; }
        public IAuthorRepository Authors { get; private set; }
        public ITagRepository Tags { get; private set; }

        public int Complete()
        {
            return _context.SaveChanges();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}