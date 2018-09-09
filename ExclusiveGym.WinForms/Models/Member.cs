using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExclusiveGym.WinForms.Models
{
    public class Member
    {
        public int MemberId { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public DateTime BirthDate { get; set; }
        public enumGender Gender { get; set; }
        public string ThaiId { get; set; }
        public string HouseNumber { get; set; }
        public string VillageNumber { get; set; }
        public string VillageName { get; set; }
        public string Lane { get; set; }
        public string Road { get; set; }
        public string SubDistrict { get; set; }
        public string District { get; set; }
        public string Province { get; set; }
        public string PostCode { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string FingerPrint { get; set; }
        public DateTime? ExpireDate { get; set; }
        public DateTime CreateDate { get; set; }
        public bool IsActive { get; set; }
        public List<MedicalProblem> Problems { get; set; }
    }

    public class MedicalProblem
    {
        public int MedicalID { get; set; }
        public int MemberID { get; set; }
        public string Detail { get; set; }
    }

    public class ApplyCourse
    {
        public int MemberId { get; set; }
        public int CourseID { get; set; }
        public DateTime ExpireDate { get; set; }
    }

    public enum enumGender
    {
        Male = 1,
        Female = 2
    }
}
