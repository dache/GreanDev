using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ExclusiveGym.WinForms.Models
{
    public class AccessLog
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int LogID { get; set; }
       // public int MemberID { get; set; }
        public COURSETYPE AccessType { get; set; }
        public DateTime AccessDate { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        //public Member Member { get; set; }
    }

    public class ApplyCourseLog
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int AutoID { get; set; }
        //public int CourseID { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string CourseName { get; set; }
        public int CoursePrice { get; set; }
        public DateTime ApplyDate { get; set; }
        //public int MemberId { get; set; }

        //public Course Course { get; set; }
       // public Member Member { get; set; }
    }
}
