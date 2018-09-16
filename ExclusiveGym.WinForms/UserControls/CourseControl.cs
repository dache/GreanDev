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

            InitCourse();
        }

        private void CourseControl_Load(object sender, EventArgs e)
        {
            InitCourse();            
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

            DataGridViewButtonColumn editButton = new DataGridViewButtonColumn();
            editButton.Name = "editButton";
            editButton.Text = "แก้ไข";
            editButton.HeaderText = "";
            editButton.UseColumnTextForButtonValue = true;
            if (gvCourses.Columns["editButton"] == null)
            {
                gvCourses.Columns.Insert(6, editButton);
            }
        }

        private void gvCourses_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == gvCourses.Columns["editButton"].Index)
            {                
                Course course = (Course)gvCourses.CurrentRow.DataBoundItem;
                var CourseForm = new CourseForm(course, FinishCallback);
                CourseForm.ShowDialog();
            }           
        }
    }
}
