using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using UnitOfWorkRepository.Interfaces.Repositories;
using UnitOfWorkRepository.Models;

namespace UnitOfWorkRepository.Persistence.Repositories
{
    public class TagRepository : Repository<Tag>, ITagRepository
    {
        public TagRepository(ApplicationDbContext context) : base(context)
        {
        }

        //public Tag GetTagWithCourses(int id)
        //{
        //    return ApplicationDbContext.Tags.Include(a => a.Courses).SingleOrDefault(a => a.TagId == id);
        //}

        public ApplicationDbContext ApplicationDbContext
        {
            get { return Context as ApplicationDbContext; }
        }
    }
}