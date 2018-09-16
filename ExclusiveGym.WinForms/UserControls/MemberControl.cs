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

            gvMembers.Columns[0].Visible = false;
            gvMembers.Columns[3].Visible = false;
            gvMembers.Columns[5].Visible = false;
            gvMembers.Columns[6].Visible = false;
            gvMembers.Columns[7].Visible = false;
            gvMembers.Columns[8].Visible = false;
            gvMembers.Columns[9].Visible = false;
            gvMembers.Columns[10].Visible = false;
            gvMembers.Columns[11].Visible = false;
            gvMembers.Columns[12].Visible = false;
            gvMembers.Columns[13].Visible = false;
            gvMembers.Columns[14].Visible = false;
            gvMembers.Columns[15].Visible = false;
            gvMembers.Columns[16].Visible = false;
            gvMembers.Columns[17].Visible = false;
            gvMembers.Columns[18].Visible = false;
            gvMembers.Columns[20].Visible = false;
            gvMembers.Columns[21].Visible = false;

            gvMembers.Columns[1].HeaderText = "ชื่อ";
            gvMembers.Columns[2].HeaderText = "นามสกุล";
            gvMembers.Columns[4].HeaderText = "อายุ";
            gvMembers.Columns[19].HeaderText = "วันหมดอายุ";


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

            DataGridViewButtonColumn courseButton = new DataGridViewButtonColumn();
            courseButton.Name = "courseButton";
            courseButton.Text = "สมัครคอร์ส";        
            courseButton.HeaderText = "";
            courseButton.UseColumnTextForButtonValue = true;
            if (gvMembers.Columns["courseButton"] == null)
            {
                gvMembers.Columns.Insert(22, courseButton);
            }

            DataGridViewButtonColumn editButton = new DataGridViewButtonColumn();
            editButton.Name = "editButton";
            editButton.Text = "แก้ไข";
            editButton.HeaderText = "";
            editButton.UseColumnTextForButtonValue = true;
            if (gvMembers.Columns["editButton"] == null)
            {
                gvMembers.Columns.Insert(23, editButton);
            }

        }

        private void gvMembers_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == gvMembers.Columns["editButton"].Index)
            {
                //Do something with your button.
                Member member = (Member)gvMembers.CurrentRow.DataBoundItem;
                var mForm = new MemberForm(member);
                mForm.ShowDialog();
            }
            if (e.ColumnIndex == gvMembers.Columns["courseButton"].Index)
            {
                //Do something with your button.
                Member member = (Member)gvMembers.CurrentRow.DataBoundItem;
                var mForm = new DialogNeedApplyCourse(member, NonFunc);
                mForm.ShowDialog();
            }
        }

        private void NonFunc()
        {

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

        private void txtMemberSearch_TextChanged(object sender, EventArgs e)
        {
            List<Member> members = StorageManager.GetSingleton().GetMemberList();

            var name = txtMemberSearch.Text.Trim();
            if(name == "" || name == "ค้นหาจาก ชื่อหรือนามสกุล")
            {
                gvMembers.DataSource = members;
            }
            else
            {
                gvMembers.DataSource = members.Where(f => f.Name.StartsWith(name)).ToList();
            }
            
        }
    }
   
}
