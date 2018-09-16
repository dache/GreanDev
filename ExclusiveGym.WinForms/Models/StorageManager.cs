using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ExclusiveGym.WinForms.Models;

class StorageManager
{
    private static StorageManager m_singleton;

    private ExclusiveGymContext m_gymDB;

    public static StorageManager GetSingleton()
    {
        if (m_singleton == null)
            m_singleton = new StorageManager();
        return m_singleton;
    }

    private StorageManager()
    {
        m_gymDB = new ExclusiveGymContext();
    }

    public void SaveDB()
    {
        GetDB().SaveChanges();
    }

    public void SaveObjectChanged(object obj)
    {
        StorageManager.GetSingleton().GetDB().Entry(obj).State = System.Data.Entity.EntityState.Modified;
        StorageManager.GetSingleton().SaveDB();
    }

    public ExclusiveGymContext GetDB()
    {
        return m_gymDB;
    }

    public void AddMember(Member m)
    {
        GetDB().Members.Add(m);
        SaveDB();
    }

    #region MEMBER
    public Member GetMemeberById(int memberId)
    {
        return GetDB().Members.Where(f => f.MemberId == memberId).SingleOrDefault();
    }

    public List<Member> GetMemberList()
    {
        return GetDB().Members.ToList();
    }

    public List<MedicalProblem> GetMedicalProblemsByMemberId(int id)
    {
        return GetDB().MedicalProblems.Where(f => f.MemberId == id).ToList();
    }

    public List<MemberKnow> GetMemberKnowsByMemberId(int id)
    {
        return GetDB().MemberKnows.Where(f => f.MemberId == id).ToList();
    }
    #endregion


    public List<Course> GetCourseList()
    {
        return GetDB().Courses.Select(x => x).ToList();
    }

    public List<Course> GetAllCourses()
    {
        var courses = GetDB().Courses.ToList();
        if (courses.Count == 0)
        {            
            var course = new Course() { CourseID = 1, CourseName = "รายวัน", TotalDay = 1, CoursePrice = 100, CourseType = COURSETYPE.DAILY, CreateDate = DateTime.Now };
            GetDB().Courses.Add(course);
            course = new Course() { CourseID = 2, CourseName = "3 เดือน", TotalDay = 1, CoursePrice = 300, CourseType = COURSETYPE.MONTLY, CreateDate = DateTime.Now };
            GetDB().Courses.Add(course);
            course = new Course() { CourseID = 3, CourseName = "6 เดือน", TotalDay = 1, CoursePrice = 600, CourseType = COURSETYPE.MONTLY, CreateDate = DateTime.Now };
            GetDB().Courses.Add(course);
            course = new Course() { CourseID = 4, CourseName = "12 เดือน", TotalDay = 1, CoursePrice = 1000, CourseType = COURSETYPE.MONTLY, CreateDate = DateTime.Now };
            GetDB().Courses.Add(course);
            GetDB().SaveChanges();
        }
        return GetDB().Courses.ToList();
    }

    public List<AccessLog> GetAccessLogList()
    {
        return GetDB().AccessLog.Select(x => x).ToList();
    }

    public Course GetDailyCourse()
    {
        return GetDB().Courses.Where(x => x.CourseType == COURSETYPE.DAILY).FirstOrDefault();
    }

    public Course GetCourseByID(int id)
    {
        return GetDB().Courses.Where(x => x.CourseID == id).FirstOrDefault();
    }

    public MemberApplyCourse GetMemberApplyCourseByMemberID(int id)
    {
        return GetDB().MemberApplyCourses.Where(x => x.MemberId == id).FirstOrDefault();
    }

    public Member GetSampleMember()
    {
        return GetMemeberById(1);
    }

    public void MemberApplyCourse(Member member, Course course)
    {
        ApplyCourseLog acl = new ApplyCourseLog();
        acl.MemberId = member.MemberId;
        acl.ApplyDate = DateTime.Now;
        acl.CourseID = course.CourseID;
        acl.CoursePrice = course.CoursePrice;
        GetDB().ApplyCourseLog.Add(acl);

        member.ExpireDate = member.ExpireDate.Value.AddDays(course.TotalDay);
        GetDB().Entry(member).State = System.Data.Entity.EntityState.Modified;


        MemberApplyCourse mac = GetMemberApplyCourseByMemberID(member.MemberId);
        if (mac == null)
        {
            mac = new MemberApplyCourse();
            mac.CourseID = course.CourseID;
            mac.ApplyDate = DateTime.Now;
            mac.MemberId = member.MemberId;
            GetDB().MemberApplyCourses.Add(mac);
        }
        else
        {
            mac.CourseID = course.CourseID;
            mac.ApplyDate = DateTime.Now;
            mac.MemberId = member.MemberId;
            GetDB().Entry(mac).State = System.Data.Entity.EntityState.Modified;
        }
        SaveDB();
    }

    public void MemberAccessGym(Member member)
    {
        MemberApplyCourse mac = GetMemberApplyCourseByMemberID(member.MemberId);
        Course course = GetCourseByID(mac.CourseID);
        AccessLog accessLog = new AccessLog();
        accessLog.AccessDate = DateTime.Now;
        accessLog.AccessType = course.CourseType;
        accessLog.MemberID = member.MemberId;
        GetDB().AccessLog.Add(accessLog);
        SaveDB();
    }
    public void CreateSampleMember()
    {
        Member m = new Member();
        m.Name = "wittawas";
        m.LastName = "singlow";
        m.CreateDate = DateTime.Now;
        m.BirthDate = DateTime.Now;
        m.FingerPrint = "xxx";
        m.ExpireDate = DateTime.Now;
        MedicalProblem mp = new MedicalProblem();
        mp.ProblemName = "some problem";
        m.Problems.Add(mp);
        AddMember(m);
    }

    public void CreateSampleCourse()
    {
        Course dailyCourse = new Course();
        dailyCourse.CourseName = "daily";
        dailyCourse.CoursePrice = 100;
        dailyCourse.CourseType = COURSETYPE.DAILY;
        dailyCourse.TotalDay = 1;
        dailyCourse.CreateDate = DateTime.Now;

        GetDB().Courses.Add(dailyCourse);

        Course monthlyCourse = new Course();
        monthlyCourse.CourseName = "ExclusiveCourse";
        monthlyCourse.CoursePrice = 3500;
        monthlyCourse.CourseType = COURSETYPE.MONTLY;
        monthlyCourse.TotalDay = 30;
        monthlyCourse.CreateDate = DateTime.Now;

        GetDB().Courses.Add(monthlyCourse);

        SaveDB();
    }
    public void GetIncomeToday()
    {

    }

    public void GetMemberAccessGymToday()
    {

    }
}
