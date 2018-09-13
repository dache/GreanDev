
using System.Data.Entity.ModelConfiguration;
using ExclusiveGym.WinForms.Models;

public class MemberConfiguration : EntityTypeConfiguration<Member>
{
    public MemberConfiguration()
    {
        Property(p => p.Name).IsRequired();
        Property(p => p.LastName).IsRequired();
        Property(p => p.FingerPrint).IsRequired();
    }
}

public class MedicalProblemConfiguration : EntityTypeConfiguration<MedicalProblem>
{
    public MedicalProblemConfiguration()
    {
        Property(p => p.ProblemName).IsRequired();
    }
}

public class CourseConfiguration : EntityTypeConfiguration<Course>
{
    public CourseConfiguration()
    {
        Property(c => c.CourseName).IsRequired();
        Property(c => c.CoursePrice).IsRequired();
    }
}

public class ApplyCourseLogConfiguration : EntityTypeConfiguration<ApplyCourseLog>
{
    public ApplyCourseLogConfiguration()
    {
        Property(c => c.CourseID).IsRequired();
        Property(c => c.CoursePrice).IsRequired();
        Property(c => c.MemberId).IsRequired();
        Property(c => c.ApplyDate).IsRequired();
    }
}

public class AccessLogConfiguration : EntityTypeConfiguration<AccessLog>
{
    public AccessLogConfiguration()
    {
        Property(c => c.MemberID).IsRequired();
        Property(c => c.AccessDate).IsRequired();
        Property(c => c.AccessType).IsRequired();
    }
}