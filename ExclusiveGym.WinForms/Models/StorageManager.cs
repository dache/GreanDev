using System;
using System.Collections.Generic;
using System.Linq;
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


    #region MEMBER

    public void AddMember(Member m)
    {
        GetDB().Members.Add(m);
        SaveDB();
    }

    public void RemoveMember(Member m)
    {
        //var mem = GetMemeberById(m.MemberId);
        //mem.IsActive = false;
        m.IsActive = false;
        SaveDB();
    }

    public Member GetMemeberById(int memberId)
    {
        return GetDB().Members.Where(f => f.MemberId == memberId).SingleOrDefault();
    }

    public List<Member> GetMemberList()
    {
        return GetDB().Members.Where(f => f.IsActive == true).ToList();
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

    public void RemoveCourse(Course course)
    {
        GetDB().Courses.Remove(course);
        SaveDB();
    }

    public List<Course> GetCourseList()
    {
        return GetDB().Courses.Select(x => x).ToList();
    }

    public List<Course> GetAllCourses()
    {
        return GetDB().Courses.ToList();
    }

    public List<AccessLog> GetAccessLogListToday()
    {
        return GetDB().AccessLog.Where(accesslog => accesslog.AccessDate.Day == DateTime.Now.Day && accesslog.AccessDate.Month == DateTime.Now.Month && accesslog.AccessDate.Year == DateTime.Now.Year).ToList();
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

    public ApplyCourseLog GetApplyCourseLogByMemberID(int memberID)
    {
        return GetDB().ApplyCourseLog.Where(x => x.MemberId == memberID).OrderByDescending(p => p.ApplyDate)
                      .FirstOrDefault(); ;
    }
        public void MemberDailyApplyCourse(Member member, ApplyCourseLog memCourse)
    {
        var access = GetDB().AccessLog.Where(f => (f.AccessDate.Day == DateTime.Now.Day
       && f.AccessDate.Month == DateTime.Now.Month
       && f.AccessDate.Year == DateTime.Now.Year) &&
       f.MemberID == member.MemberId).SingleOrDefault();
        if (access == null)
        {
            GetDB().ApplyCourseLog.Add(memCourse);
            AccessLog accessLog = new AccessLog();
            accessLog.MemberID = member.MemberId;
            accessLog.AccessDate = DateTime.Now;
            accessLog.AccessType = COURSETYPE.DAILY;
            accessLog.Name = member.Name;
            accessLog.LastName = member.LastName;
            GetDB().AccessLog.Add(accessLog);
            SaveDB();
        }
    }

    public void MemberMontlyApplyCourse(Member member, ApplyCourseLog memCourse, DateTime accessDate)
    {
        GetDB().ApplyCourseLog.Add(memCourse);
        AccessLog accessLog = new AccessLog();
        accessLog.AccessDate = accessDate;
        accessLog.MemberID = member.MemberId;
        accessLog.AccessType = COURSETYPE.MONTLY;
        accessLog.Name = member.Name;
        accessLog.LastName = member.LastName;

        GetDB().AccessLog.Add(accessLog);
        SaveDB();
    }
    

    public void MemberApplyCourse(Member member, Course course)
    {
        ApplyCourseLog acl = new ApplyCourseLog();
        acl.CourseName = course.CourseName;
        acl.MemberId = member.MemberId;
        acl.Name = member.Name;
        acl.ApplyDate = DateTime.Now;
        acl.LastName = member.LastName;
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
        f.Name == member.Name && f.LastName == member.LastName).SingleOrDefault();
        if (access == null)
        {
            AccessLog accessLog = new AccessLog();
            accessLog.AccessDate = DateTime.Now;
            accessLog.AccessType = COURSETYPE.MONTLY;
            accessLog.Name = member.Name;
            accessLog.LastName = member.LastName;
            GetDB().AccessLog.Add(accessLog);
            SaveDB();
        }
    }


    public List<AccessLog> GetMemberAccessGymToday()
    {
        return GetDB().AccessLog.Where(accesslog => accesslog.AccessDate.Day == DateTime.Now.Day && accesslog.AccessDate.Month == DateTime.Now.Month && accesslog.AccessDate.Year == DateTime.Now.Year).ToList();
    }

    public List<ApplyCourseLog> GetIncomeTotal()
    {
        List<ApplyCourseLog> list = GetDB().ApplyCourseLog.ToList();

        var query = list.GroupBy(o => new { o.CourseName }).Select(g => new ApplyCourseLog
        {
            CourseName = g.Key.CourseName,
            ApplyDate = g.Where(o => o.CourseName == g.Key.CourseName).FirstOrDefault().ApplyDate,
            Name = g.Where(o => o.CourseName == g.Key.CourseName).FirstOrDefault().Name,
            LastName = g.Where(o => o.CourseName == g.Key.CourseName).FirstOrDefault().LastName,
            AutoID = g.Where(o => o.CourseName == g.Key.CourseName).FirstOrDefault().AutoID,
            CoursePrice = g.Sum(x => x.CoursePrice)
        }).ToList();
        return query;
    }

    public List<ApplyCourseLog> GetIncomeByDay(int day, int month, int year)
    {
        List<ApplyCourseLog> list = GetDB().ApplyCourseLog.Where(applycourseLog => applycourseLog.ApplyDate.Day == day
        && applycourseLog.ApplyDate.Month == month
        && applycourseLog.ApplyDate.Year == year).ToList();

        var query = list.GroupBy(o => o).Select(g => new ApplyCourseLog
        {
            AutoID = g.Key.AutoID,
            ApplyDate = g.Key.ApplyDate,
            CourseName = g.Key.CourseName,
            Name = g.Key.Name,
            LastName = g.Key.LastName,
            CoursePrice = g.Sum(x => x.CoursePrice)
        }).ToList();
        return query;
    }

    public List<ApplyCourseLog> GetIncomeByMonth(int month, int year)
    {
        List<ApplyCourseLog> list = GetDB().ApplyCourseLog.Where(f => f.ApplyDate.Month == month && f.ApplyDate.Year == year).ToList();
        var query = list.GroupBy(o => new { o.CourseName, o.ApplyDate.Date.Year, o.ApplyDate.Date.Month }).Select(g => new ApplyCourseLog
        {
            CourseName = g.Key.CourseName,
            AutoID = g.Where(o => o.CourseName == g.Key.CourseName).FirstOrDefault().AutoID,
            ApplyDate = g.Where(o => o.CourseName == g.Key.CourseName).FirstOrDefault().ApplyDate,
            Name = g.Where(o => o.CourseName == g.Key.CourseName).FirstOrDefault().Name,
            LastName = g.Where(o => o.CourseName == g.Key.CourseName).FirstOrDefault().LastName,
            CoursePrice = g.Sum(x => x.CoursePrice)
        }).ToList();
        return query;
    }

    public List<ApplyCourseLog> GetIncomeByYear(int year)
    {
        List<ApplyCourseLog> list = GetDB().ApplyCourseLog.Where(f => f.ApplyDate.Year == year).ToList();
        var query = list.GroupBy(o => new { o.CourseName, o.ApplyDate.Date.Year, o.ApplyDate.Date.Month }).Select(g => new ApplyCourseLog
        {
            CourseName = g.Key.CourseName,
            AutoID = g.Where(o => o.ApplyDate.Date.Year == g.Key.Year).FirstOrDefault().AutoID,
            ApplyDate = g.Where(o => o.ApplyDate.Date.Year == g.Key.Year).FirstOrDefault().ApplyDate,
            Name = g.Where(o => o.ApplyDate.Date.Year == g.Key.Year).FirstOrDefault().Name,
            LastName = g.Where(o => o.ApplyDate.Date.Year == g.Key.Year).FirstOrDefault().LastName,
            CoursePrice = g.Sum(x => x.CoursePrice)
        }).ToList();
        return query;
    }

    #region PAYMENTS

    public List<ApplyCourseLog> GetAllPayment()
    {
        return GetDB().ApplyCourseLog.ToList();
    }

    public ApplyCourseLog GetLastPayment()
    {
        //SELECT * FROM Table ORDER BY ID DESC LIMIT 1
        return GetDB().ApplyCourseLog.OrderByDescending(p => p.AutoID)
                       .FirstOrDefault(); ;
    }
    #endregion
}
