using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ExclusiveGym.WinForms.Models;

namespace ExclusiveGym.WinForms
{
    public partial class CourseForm : Form
    {
        private FinishCallback m_finishCallback;
        private Course m_currentCourse;
        private bool m_isUpdate;
        public CourseForm(Course course, FinishCallback callback)
        {
            InitializeComponent();
            if(course == null)
            {
                HeaderTxt.Text = "เพิ่มข้อมูล";
                btnSave.Text = "สร้าง";
                m_currentCourse = new Course();
                m_currentCourse.CreateDate = DateTime.Now;
            }
            else
            {
                m_isUpdate = true;
                m_currentCourse = course;
                HeaderTxt.Text = "แก้ไขข้อมูล";
                btnSave.Text = "บันทึก";
                txtName.Text = m_currentCourse.CourseName;
                priceTxt.Text = m_currentCourse.CoursePrice.ToString();
                totalDayTxt.Text = m_currentCourse.TotalDay.ToString();
                typeBox.Text = m_currentCourse.CourseType.ToString() ;
                
            }
            m_finishCallback = callback;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            m_currentCourse.CourseName = txtName.Text;
            m_currentCourse.CoursePrice = int.Parse(priceTxt.Text);
            if(typeBox.Text == "รายวัน")
                m_currentCourse.CourseType = COURSETYPE.DAILY;
            else
                m_currentCourse.CourseType = COURSETYPE.MONTLY;
            m_currentCourse.TotalDay = int.Parse(totalDayTxt.Text);

            if (m_isUpdate)
                StorageManager.GetSingleton().GetDB().Entry(m_currentCourse).State = System.Data.Entity.EntityState.Modified;
            else
                StorageManager.GetSingleton().GetDB().Courses.Add(m_currentCourse);

            StorageManager.GetSingleton().GetDB().SaveChanges();

            m_finishCallback();
            this.Close();
        }
    }
}
