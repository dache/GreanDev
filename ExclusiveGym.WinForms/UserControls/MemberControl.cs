using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ExclusiveGym.WinForms.Models;

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
            List<Member> members = StorageManager.GetSingleton().GetMemberList();

            gvMembers.DataSource = members;

            //gvMembers.Columns[3].Visible = false;
            gvMembers.Columns[4].Visible = false;
            gvMembers.Columns[5].Visible = false;
            gvMembers.Columns[7].Visible = false;

     
            //foreach (DataGridViewRow row in gvMembers.Rows)
            //{
            //    Member member = (Member)row.DataBoundItem;
            //    if(member.MemberType == enumMemberType.Daily)
            //    {                    
            //        row.Cells[0].Style.BackColor = Color.Red;                 
            //    }else if(member.MemberType == enumMemberType.Month)
            //    {
            //        row.Cells[0].Style.BackColor = Color.Blue;
                   
            //    }
            //    else
            //    {
            //        row.Cells[0].Style.BackColor = Color.Green;
            //    }
            //    row.DefaultCellStyle.BackColor = Color.Red;
            //}
            //gvMembers.Rows[2].Cells[2].Style.BackColor = Color.Red;
            
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
   
}
