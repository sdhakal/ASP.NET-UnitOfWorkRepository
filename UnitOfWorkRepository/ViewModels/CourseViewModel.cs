using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using UnitOfWorkRepository.Models;

namespace UnitOfWorkRepository.ViewModels
{
    public class CourseViewModel
    {
        public Course Course { get; set; }
        public IEnumerable<Author> Authors { get; set; }
        public List<TagViewModel> TagViewModels { get; set; }
    }
}