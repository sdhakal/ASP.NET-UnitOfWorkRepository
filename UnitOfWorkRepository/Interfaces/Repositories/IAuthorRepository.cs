using UnitOfWorkRepository.Models;

namespace UnitOfWorkRepository.Interfaces.Repositories
{
    public interface IAuthorRepository : IRepository<Author>
    {
        Author GetAuthorWithCourses(int id);
    }
}