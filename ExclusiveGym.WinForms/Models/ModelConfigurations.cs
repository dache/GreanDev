
using System.Data.Entity.ModelConfiguration;
using ExclusiveGym.WinForms.Models;

public class MemberConfiguration : EntityTypeConfiguration<Member>
{
    public MemberConfiguration()
    {
        HasIndex(p => p.Name);
        Property(p => p.Name).IsRequired();
        Property(p => p.LastName).IsRequired();
        Property(p => p.FingerPrint).IsRequired();
        HasIndex(p => p.FingerPrint);
        HasIndex(p => p.IsActive);
        HasIndex(p => p.Email);
        HasIndex(p => p.ExpireDate);
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
        HasIndex(c => c.CourseType);
        HasIndex(c => c.CreateDate);
    }
}

public class ApplyCourseLogConfiguration : EntityTypeConfiguration<ApplyCourseLog>
{
    public ApplyCourseLogConfiguration()
    {
        HasIndex(c => c.Name);
        HasIndex(c => c.CourseName);
        //Property(c => c.CourseID).IsRequired();
        Property(c => c.CoursePrice).IsRequired();
        Property(c => c.Name).IsRequired();
        Property(c => c.ApplyDate).IsRequired();
        HasIndex(c => c.ApplyDate);
        HasIndex(c => c.MemberId);
    }
}

public class AccessLogConfiguration : EntityTypeConfiguration<AccessLog>
{
    public AccessLogConfiguration()
    {
        HasIndex(c => c.Name);
        Property(c => c.Name).IsRequired();
        Property(c => c.AccessDate).IsRequired();
        Property(c => c.AccessType).IsRequired();
        HasIndex(c => c.MemberID);
        HasIndex(c => c.AccessType);
        HasIndex(c => c.AccessDate);
    }
}