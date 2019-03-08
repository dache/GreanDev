using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExclusiveGym.WinForms.Models
{
    public class Course
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int CourseID { get; set; }
        public string CourseName { get; set; }
        [Index]
        public COURSETYPE CourseType { get; set; }
        public int CoursePrice { get; set; }
        public int TotalDay { get; set; }
        [Index]
        public DateTime CreateDate { get; set; }
    }

    public class MemberApplyCourse
    {
        [Key]
        public int MemberId { get; set; }
        [Index]
        public int CourseID { get; set; }
        [Index]
        public DateTime ApplyDate { get; set; }
    }

    public enum COURSETYPE
    {
        DAILY = 1,
        MONTLY = 2
    }
}
