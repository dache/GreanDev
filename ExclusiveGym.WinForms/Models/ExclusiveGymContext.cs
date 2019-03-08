using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExclusiveGym.WinForms.Models
{
    public class ExclusiveGymContext : DbContext
    {
        public ExclusiveGymContext() : base("ExclusiveGymDB")
        {
            Console.WriteLine("ExclusiveGymContext init");
            Database.CreateIfNotExists();
        }

        public DbSet<Member> Members { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<MemberApplyCourse> MemberApplyCourses { get; set; }
        public DbSet<MedicalProblem> MedicalProblems { get; set; }
        public DbSet<MemberKnow> MemberKnows { get; set; }

        public DbSet<AccessLog> AccessLog { get; set; }
        public DbSet<ApplyCourseLog> ApplyCourseLog { get; set; }

        public DbSet<MemberProfile> MemberProfiles { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            Database.SetInitializer<ExclusiveGymContext>(null);
            base.OnModelCreating(modelBuilder);
            modelBuilder.Configurations.Add(new MemberConfiguration());
            modelBuilder.Configurations.Add(new MedicalProblemConfiguration());
            modelBuilder.Configurations.Add(new CourseConfiguration());
            modelBuilder.Configurations.Add(new ApplyCourseLogConfiguration());
            modelBuilder.Configurations.Add(new AccessLogConfiguration());
        }
    }
}
