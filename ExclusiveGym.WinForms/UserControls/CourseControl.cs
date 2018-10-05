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
    public partial class CourseControl : UserControl
    {
        public CourseControl()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var CourseForm = new CourseForm(null, FinishCallback);
            CourseForm.ShowDialog();
        }
        
        private void FinishCallback()
        {
            gvCourses.DataSource = null;
            gvCourses.Update();
            gvCourses.Refresh();
            gvCourses.Columns.Remove("editButton");
            gvCourses.Columns.Remove("delButton");
            Form1.m_instance.FocusToMainForm();
            InitCourse();
        }

        private void CourseControl_Load(object sender, EventArgs e)
        {
            InitCourse();            
        }

        private void AddNewButton(string courseName, string courseText, Color buttonColor)
        {
            DataGridViewButtonColumn newButton = new DataGridViewButtonColumn();
            newButton.Name = courseName;
            newButton.Text = courseText;
            newButton.HeaderText = "";
            newButton.UseColumnTextForButtonValue = true;
            newButton.DefaultCellStyle.BackColor = buttonColor;
            newButton.FlatStyle = FlatStyle.Flat;
            newButton.DefaultCellStyle.ForeColor = Color.White;
            newButton.DefaultCellStyle.SelectionForeColor = Color.Wheat;
            if (gvCourses.Columns[courseName] == null)
            {
                gvCourses.Columns.Insert(gvCourses.Columns.Count, newButton);
            }
        }

        private void InitCourse()
        {
            List<Course> courses = StorageManager.GetSingleton().GetAllCourses();
            gvCourses.DataSource = courses;

            gvCourses.Columns[0].Visible = false;
            gvCourses.Columns[5].Visible = false;

            gvCourses.Columns[1].HeaderText = "ชื่อคอร์ส";                   
            gvCourses.Columns[2].HeaderText = "ประเภทคอร์ส";            
            gvCourses.Columns[3].HeaderText = "ราคา";
            gvCourses.Columns[4].HeaderText = "จำนวนวัน";
            gvCourses.Columns[1].Width = 250;
            gvCourses.Columns[2].Width = 150;
            gvCourses.Columns[3].Width = 100;
            gvCourses.Columns[4].Width = 120;

            gvCourses.Columns[3].DefaultCellStyle.Format = "N0";

            gvCourses.Columns[1].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            gvCourses.Columns[2].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            gvCourses.Columns[3].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            gvCourses.Columns[4].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;

            gvCourses.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            gvCourses.Columns[4].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            AddNewButton("editButton", "แก้ไข", Color.FromArgb(240, 173, 78));
            AddNewButton("delButton", "ลบ", Color.FromArgb(212, 63, 58));
            
        }

        private void gvCourses_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == gvCourses.Columns["editButton"].Index)
            {                
                Course course = (Course)gvCourses.CurrentRow.DataBoundItem;
                var CourseForm = new CourseForm(course, FinishCallback);
                CourseForm.ShowDialog();
            }

            if (e.ColumnIndex == gvCourses.Columns["delButton"].Index)
            {
                Course course = (Course)gvCourses.CurrentRow.DataBoundItem;
                var form = new DialogForm("ยืนยันการลบคอร์ส?", $"ลบคอร์ส {course.CourseName}");
                if(form.ShowDialog() == DialogResult.OK)
                {
                    StorageManager.GetSingleton().RemoveCourse(course);
                    FinishCallback();
                }
            }
        }
    }
}
