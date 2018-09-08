using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ExclusiveGym.WinForms.UserControls
{
    public partial class MemberControl : UserControl
    {
        public MemberControl()
        {
            InitializeComponent();
        }

        private void MemberControl_Load(object sender, EventArgs e)
        {
            Random r = new Random();
            List<Member> members = new List<Member>();
            for (int i = 0; i < 10; i++)
            {
                var m1 = new Member() { Id = Guid.NewGuid(), Name = "Decha", LastName = "Tarat" };
                m1.Phone = "0123456789";
                m1.MemberType = (enumMemberType)r.Next(0, 3);
                members.Add(m1);
            }

            gvMembers.DataSource = members;

            //gvMembers.Columns[3].Visible = false;
            gvMembers.Columns[4].Visible = false;
            gvMembers.Columns[5].Visible = false;
            gvMembers.Columns[7].Visible = false;

     
            foreach (DataGridViewRow row in gvMembers.Rows)
            {
                Member member = (Member)row.DataBoundItem;
                if(member.MemberType == enumMemberType.Daily)
                {                    
                    row.Cells[0].Style.BackColor = Color.Red;                 
                }else if(member.MemberType == enumMemberType.Month)
                {
                    row.Cells[0].Style.BackColor = Color.Blue;
                   
                }
                else
                {
                    row.Cells[0].Style.BackColor = Color.Green;
                }
                row.DefaultCellStyle.BackColor = Color.Red;
            }
            gvMembers.Rows[2].Cells[2].Style.BackColor = Color.Red;
            //if (Convert.ToInt32(row.Cells[7].Value) < Convert.ToInt32(row.Cells[10].Value))
            //{
            //    row.DefaultCellStyle.BackColor = Color.Red;
            //}

        }

        private void txtMemberSearch_Enter(object sender, EventArgs e)
        {
            if (txtMemberSearch.Text == "ค้นหาจาก ชื่อหรือนามสกุล")
            {
                txtMemberSearch.Text = "";
                txtMemberSearch.ForeColor = Color.Black;
            }
        }

        private void txtMemberSearch_Leave(object sender, EventArgs e)
        {
            if (txtMemberSearch.Text == "")
            {
                txtMemberSearch.Text = "ค้นหาจาก ชื่อหรือนามสกุล";
                txtMemberSearch.ForeColor = Color.DarkGray;
            }
        }

        private void btnNewMember_Click(object sender, EventArgs e)
        {
            var memberForm = new MemberForm();
            memberForm.ShowDialog();
        }


    }

    public class Member
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Phone { get; set; }
        public DateTime BirthDate { get; set; }
        public string FingerPrint { get; set; }
        public enumMemberType MemberType { get; set; }
        public bool IsActive { get; set; }
    }

    public enum enumMemberType
    {
        Daily,
        Month,
        Year
    }
}
