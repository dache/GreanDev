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
        GetDB().Entry(obj).State = System.Data.Entity.EntityState.Modified;
        SaveDB();
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

    public MedicalProblem GetMedicalProblemsById(int id)
    {
        return GetDB().MedicalProblems.Where(f => f.MedicalID == id).SingleOrDefault();
    }

    public MemberKnow GetMemberKnowsById(int id)
    {
        return GetDB().MemberKnows.Where(f => f.MemberKnowId == id).SingleOrDefault();
    }
    #endregion


    public List<Course> GetCourseList()
    {
        return GetDB().Courses.Select(x => x).ToList();
    }

    public List<Course> GetAllCourses()
    {
        //var courses = GetDB().Courses.ToList();
        //if (courses.Count == 0)
        //{
        //    var course = new Course() { CourseID = 1, CourseName = "รายวัน", TotalDay = 1, CoursePrice = 100, CourseType = COURSETYPE.DAILY, CreateDate = DateTime.Now };
        //    GetDB().Courses.Add(course);
        //    course = new Course() { CourseID = 2, CourseName = "3 เดือน", TotalDay = 1, CoursePrice = 300, CourseType = COURSETYPE.MONTLY, CreateDate = DateTime.Now };
        //    GetDB().Courses.Add(course);
        //    course = new Course() { CourseID = 3, CourseName = "6 เดือน", TotalDay = 1, CoursePrice = 600, CourseType = COURSETYPE.MONTLY, CreateDate = DateTime.Now };
        //    GetDB().Courses.Add(course);
        //    course = new Course() { CourseID = 4, CourseName = "12 เดือน", TotalDay = 1, CoursePrice = 1000, CourseType = COURSETYPE.MONTLY, CreateDate = DateTime.Now };
        //    GetDB().Courses.Add(course);
        //    GetDB().SaveChanges();
        //}
        return GetDB().Courses.ToList();
    }

    public List<AccessLog> GetAccessLogList()
    {
        return GetDB().AccessLog.Include("Member").ToList();
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

 
    public void MemberApplyCourse(Member member, Course course)
    {
        ApplyCourseLog acl = new ApplyCourseLog();
        acl.MemberId = member.MemberId;
        acl.ApplyDate = DateTime.Now;
        acl.CourseID = course.CourseID;
        acl.CoursePrice = course.CoursePrice;
        GetDB().ApplyCourseLog.Add(acl);

        if (member.ExpireDate == null)
        {
            member.ExpireDate = DateTime.Now.AddDays(course.TotalDay);
        }
        else
        {
            member.ExpireDate = member.ExpireDate.Value.AddDays(course.TotalDay);
        }

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
        var access = GetDB().AccessLog.Where(f => (f.AccessDate.Day == DateTime.Now.Day 
        && f.AccessDate.Month == DateTime.Now.Month 
        && f.AccessDate.Year == DateTime.Now.Year) && 
        f.MemberID == member.MemberId).SingleOrDefault();
        if (access == null)
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
    }
  
    
    public List<AccessLog> GetMemberAccessGymToday()
    {
        return GetDB().AccessLog.Where(accesslog => accesslog.AccessDate.Day == DateTime.Now.Day && accesslog.AccessDate.Month == DateTime.Now.Month && accesslog.AccessDate.Year == DateTime.Now.Year).ToList();
    }
    
    public List<ApplyCourseLog> GetIncomeByDay(int day, int month, int year)
    {
        List<ApplyCourseLog> list = GetDB().ApplyCourseLog.Where(applycourseLog => applycourseLog.ApplyDate.Day == day 
        && applycourseLog.ApplyDate.Month == month 
        && applycourseLog.ApplyDate.Year == year).ToList();

        var query = list.GroupBy(o => o).Select(g => new ApplyCourseLog
        {
            CourseID = g.Key.CourseID,
            ApplyDate = g.Key.ApplyDate,
            Course = g.Where(o=> o.CourseID == g.Key.CourseID && o.ApplyDate == g.Key.ApplyDate).FirstOrDefault().Course,
            Member = g.Where(o => o.CourseID == g.Key.CourseID).FirstOrDefault().Member,
            MemberId = g.Where(o => o.CourseID == g.Key.CourseID).FirstOrDefault().MemberId,
            CoursePrice = g.Sum(x => x.CoursePrice)
        }).ToList();
        return query;
    }

    public List<ApplyCourseLog> GetIncomeByMonth(int month, int year)
    {
        List<ApplyCourseLog> list = GetDB().ApplyCourseLog.Where(f => f.ApplyDate.Month == month && f.ApplyDate.Year == year).ToList();
        var query = list.GroupBy(o => new { o.CourseID, o.ApplyDate.Date.Year, o.ApplyDate.Date.Month }).Select(g => new ApplyCourseLog
        {
            CourseID = g.Key.CourseID,
            ApplyDate = g.Where(o => o.CourseID == g.Key.CourseID).FirstOrDefault().ApplyDate,
            Course = g.Where(o => o.CourseID == g.Key.CourseID).FirstOrDefault().Course,
            Member = g.Where(o => o.CourseID == g.Key.CourseID).FirstOrDefault().Member,
            MemberId = g.Where(o => o.CourseID == g.Key.CourseID).FirstOrDefault().MemberId,
            CoursePrice = g.Sum(x => x.CoursePrice)
        }).ToList();
        return query;
    }

    public List<ApplyCourseLog> GetIncomeByYear(int year)
    {
        List<ApplyCourseLog> list = GetDB().ApplyCourseLog.Where(f => f.ApplyDate.Year == year).ToList();
        var query = list.GroupBy(o => new { o.Course.CourseType, o.ApplyDate.Date.Year, o.ApplyDate.Date.Month }).Select(g => new ApplyCourseLog
        {
            CourseID = g.Where(o=>o.ApplyDate.Date.Year == g.Key.Year).FirstOrDefault().CourseID,
            ApplyDate = g.Where(o => o.ApplyDate.Date.Year == g.Key.Year).FirstOrDefault().ApplyDate,
            Course = g.Where(o => o.ApplyDate.Date.Year == g.Key.Year).FirstOrDefault().Course,
            Member = g.Where(o => o.ApplyDate.Date.Year == g.Key.Year).FirstOrDefault().Member,
            MemberId = g.Where(o => o.ApplyDate.Date.Year == g.Key.Year).FirstOrDefault().MemberId,
            CoursePrice = g.Sum(x => x.CoursePrice)
        }).ToList();
        return query;
    }
}
