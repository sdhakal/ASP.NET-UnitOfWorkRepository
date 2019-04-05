using System.Collections.Generic;

namespace UnitOfWorkRepository.Models
{
    public class Tag
    {
        //public Tag()
        //{
        //    Courses = new HashSet<Course>();
        //}

        public int TagId { get; set; }

        public string Name { get; set; }

        public virtual ICollection<Course> Courses { get; set; }
    }
}
