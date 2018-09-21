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
            //InitMember();
            

            // InitMember();

        }

        private void FinishCallback()
        {
            InitMember();
            Form1.m_instance.SetupFingerprint();
        }

        private void LoadMember()
        {
            gvMembers.BeginInvoke((MethodInvoker)delegate () 
            {
                gvMembers.DataSource = null;
                
                gvMembers.Refresh();
                try
                {
                    gvMembers.Columns.Remove("courseButton");
                    gvMembers.Columns.Remove("editButton");
                }
                catch { }
               //List<Member> members = StorageManager.GetSingleton().GetMemberList();
                gvMembers.DataSource = StorageManager.GetSingleton().GetDB().Members.Select(p => new { p.Name, p.LastName, p.Age, p.ExpireDate }).ToList();
                
                gvMembers.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.EnableResizing; //or even better .DisableResizing. Most time consumption enum is DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders
               
                gvMembers.Columns[0].HeaderText = "ชื่อ";
                gvMembers.Columns[1].HeaderText = "นามสกุล";
                gvMembers.Columns[2].HeaderText = "อายุ";
                gvMembers.Columns[3].HeaderText = "วันหมดอายุ";
                gvMembers.Columns[3].DefaultCellStyle.Format = "dd MMMM yyyy";
                gvMembers.Columns[3].DefaultCellStyle.FormatProvider = new System.Globalization.CultureInfo("th-TH");

                gvMembers.Columns[0].Width = 180;
                gvMembers.Columns[1].Width = 180;
                gvMembers.Columns[2].Width = 70;
                gvMembers.Columns[3].Width = 120;


                gvMembers.Columns[0].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                gvMembers.Columns[1].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                gvMembers.Columns[2].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                gvMembers.Columns[3].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;

                gvMembers.Columns[2].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                gvMembers.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

                DataGridViewButtonColumn courseButton = new DataGridViewButtonColumn();
                courseButton.Name = "courseButton";
                courseButton.Text = "สมัครคอร์ส";
                courseButton.HeaderText = "";
                courseButton.UseColumnTextForButtonValue = true;
                courseButton.DefaultCellStyle.BackColor = Color.FromArgb(91, 192, 222);
                courseButton.FlatStyle = FlatStyle.Flat;
                courseButton.DefaultCellStyle.ForeColor = Color.White;
                courseButton.DefaultCellStyle.SelectionForeColor = Color.Wheat;
                if (gvMembers.Columns["courseButton"] == null)
                {
                    gvMembers.Columns.Insert(4, courseButton);
                }

                DataGridViewButtonColumn editButton = new DataGridViewButtonColumn();
                editButton.Name = "editButton";
                editButton.Text = "แก้ไข";
                editButton.HeaderText = "";
                editButton.UseColumnTextForButtonValue = true;
                editButton.DefaultCellStyle.BackColor = Color.FromArgb(240, 173, 78);
                editButton.FlatStyle = FlatStyle.Flat;
                editButton.DefaultCellStyle.ForeColor = Color.White;
                editButton.DefaultCellStyle.SelectionForeColor = Color.Wheat;
                if (gvMembers.Columns["editButton"] == null)
                {
                    gvMembers.Columns.Insert(5, editButton);
                }
                gvMembers.Update();
                gvMembers.ClearSelection();
            });

            
        }
        public void InitMember()
        {
            System.Threading.Thread loadthread = new System.Threading.Thread(LoadMember);
            loadthread.IsBackground = true;
            loadthread.Start();
            
        }

        private void gvMembers_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == gvMembers.Columns["editButton"].Index)
            {
                //Do something with your button.
                Member member = (Member)gvMembers.CurrentRow.DataBoundItem;
                var mForm = new MemberForm(member);
                mForm.m_registryiSdone = FinishCallback;
                mForm.ShowDialog();
            }
            if (e.ColumnIndex == gvMembers.Columns["courseButton"].Index)
            {
                //Do something with your button.
                Member member = (Member)gvMembers.CurrentRow.DataBoundItem;
                var mForm = new DialogNeedApplyCourse(member, null);
                mForm.ShowDialog();
            }
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
            memberForm.m_registryiSdone = FinishCallback;
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
