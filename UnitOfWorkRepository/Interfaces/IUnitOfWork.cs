using System;
using UnitOfWorkRepository.Interfaces.Repositories;

namespace UnitOfWorkRepository.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        ICourseRepository Courses { get; }
        IAuthorRepository Authors { get; }
        ITagRepository Tags { get; }
        int Complete();
    }
}