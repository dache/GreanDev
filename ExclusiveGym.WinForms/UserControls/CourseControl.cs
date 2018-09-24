﻿using System;
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
            gvCourses.Columns[1].Width = 250;
            gvCourses.Columns[2].Width = 150;
            gvCourses.Columns[3].Width = 100;
            gvCourses.Columns[4].Width = 120;

            gvCourses.Columns[1].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            gvCourses.Columns[2].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            gvCourses.Columns[3].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            gvCourses.Columns[4].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;

            gvCourses.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            gvCourses.Columns[4].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            DataGridViewButtonColumn editButton = new DataGridViewButtonColumn();
            editButton.Name = "editButton";
            editButton.Text = "แก้ไข";
            editButton.HeaderText = "";
            editButton.UseColumnTextForButtonValue = true;
            editButton.Width = 130;
            editButton.DefaultCellStyle.BackColor = Color.FromArgb(240, 173, 78);
            editButton.FlatStyle = FlatStyle.Flat;
            editButton.DefaultCellStyle.ForeColor = Color.White;
            editButton.DefaultCellStyle.SelectionForeColor = Color.Wheat;            
            if (gvCourses.Columns["editButton"] == null)
            {
                gvCourses.Columns.Insert(6, editButton);
            }

            DataGridViewButtonColumn delButton = new DataGridViewButtonColumn();
            delButton.Name = "delButton";
            delButton.Text = "ลบ";
            delButton.HeaderText = "";
            delButton.UseColumnTextForButtonValue = true;
            delButton.DefaultCellStyle.BackColor = Color.FromArgb(212, 63, 58);
            delButton.FlatStyle = FlatStyle.Flat;
            delButton.DefaultCellStyle.ForeColor = Color.White;
            delButton.DefaultCellStyle.SelectionForeColor = Color.Wheat;
            if (gvCourses.Columns["delButton"] == null)
            {
                gvCourses.Columns.Insert(7, delButton);
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
