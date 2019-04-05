using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using UnitOfWorkRepository.Models;

namespace UnitOfWorkRepository.Interfaces.Repositories
{
    public interface ITagRepository : IRepository<Tag>
    {
        //Tag GetTagWithCourses(int id);
    }
}