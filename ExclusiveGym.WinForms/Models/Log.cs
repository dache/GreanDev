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
        [Index]
        public int MemberID { get; set; }
        [Index]
        public COURSETYPE AccessType { get; set; }
        [Index]
        public DateTime AccessDate { get; set; }
        [Index("nameindex")]
        [StringLength(400)]
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
        [Index("nameindex")]
        [StringLength(400)]
        public string Name { get; set; }
        public string LastName { get; set; }
        [Index("cnameindex")]
        [StringLength(400)]
        public string CourseName { get; set; }
        public int CoursePrice { get; set; }
        [Index]
        public DateTime ApplyDate { get; set; }
        [Index]
        public int MemberId { get; set; }

        //public Course Course { get; set; }
       // public Member Member { get; set; }
    }
}
