using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExclusiveGym.WinForms.Models
{
    public class Course
    {
        public int CourseID { get; set; }
        public string CourseName { get; set; }
        public COURSETYPE CourseType { get; set; }
        public int CoursePrice { get; set; }
        public int TotalDay { get; set; }
        public DateTime CreateDate { get; set; }
    }

    public enum COURSETYPE
    {
        DAILY = 1,
        MONTKY = 2
    }
}
