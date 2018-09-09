using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExclusiveGym.WinForms.Models
{
    public class ExclusiveGymContext : DbContext
    {
        public ExclusiveGymContext() : base("ExclusiveGymDB")
        {

        }

        public DbSet<Member> Members { get; set; }
        public DbSet<Course> Courses { get; set; }
    }
}
