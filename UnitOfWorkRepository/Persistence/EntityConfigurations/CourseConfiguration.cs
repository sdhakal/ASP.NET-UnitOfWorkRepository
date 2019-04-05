using System.Data.Entity.ModelConfiguration;
using UnitOfWorkRepository.Models;

namespace UnitOfWorkRepository.Persistence.EntityConfigurations
{
    public class CourseConfiguration : EntityTypeConfiguration<Course>
    {
        public CourseConfiguration()
        {
            HasMany(c => c.Tags)
                .WithMany(t => t.Courses)
                .Map(m =>
                {
                    m.ToTable("TagCourses");
                    m.MapLeftKey("CourseId");
                    m.MapRightKey("TagId");
                });
        }
    }
}