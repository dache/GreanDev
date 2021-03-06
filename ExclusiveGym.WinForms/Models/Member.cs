﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExclusiveGym.WinForms.Models
{
    public class Member
    {
        public Member()
        {
            Problems = new List<MedicalProblem>();
        }
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int MemberId { get; set; }
        [Index("nameindex")]
        [StringLength(100)]
        public string Name { get; set; }
        public string LastName { get; set; }
        public DateTime BirthDate { get; set; }
        public int Age { get; set; }
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
        [Index("emailindex")]
        [StringLength(100)]
        public string Email { get; set; }
        [Index("findex")]
        [StringLength(900)]
        public string FingerPrint { get; set; }
        [Index]
        public DateTime? ExpireDate { get; set; }
        public DateTime CreateDate { get; set; }
        [Index]
        public bool IsActive { get; set; }
        public virtual List<MedicalProblem> Problems { get; set; }
        public virtual List<MemberKnow> MemberKnows { get; set; }
        public MemberProfile MemberProfile { get; set; }
    }

    public class MemberProfile
    {
        public Guid Id { get; set; }
        public int MemberId { get; set; }
        public byte[] ImageByte { get; set; }
    }

    public class MedicalProblem
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int MedicalID { get; set; }
        public string ProblemName { get; set; }

        public int MemberId { get; set; }
        public Member Member { get; set; }
    }

    public class MemberKnow
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int MemberKnowId { get; set; }
        public enumMemberKnow MemberKnowFrom { get; set; }
        public int MemberId { get; set; }
        public Member Member { get; set; }
    }

    public enum enumGender
    {
        Male = 1,
        Female = 2
    }

    public enum enumProblem
    {
        NoProblem,
        Heart,
        HighBlood,
        Asthma, // หอบหืด
        AchesAndPains,
        Diabetes, // เบาหวาน
        Other
    }

    public enum enumMemberKnow
    {
        Advertise = 1,
        Internet = 2,
        Facebook = 3,
        FromFriend = 4
    }
}
