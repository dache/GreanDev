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
using ExclusiveGym.WinForms.CustomControls;

namespace ExclusiveGym.WinForms
{
    public partial class CourseForm : OpacityBGForm
    {
        private FinishCallback m_finishCallback;
        private Course m_currentCourse;
        private bool m_isUpdate;
        public CourseForm(Course course, FinishCallback callback)
        {
            InitializeComponent();

            typeBox.Items.Add(new ComboboxItem() { Text = "รายวัน", Value = COURSETYPE.DAILY });
            typeBox.Items.Add(new ComboboxItem() { Text = "รายเดือน", Value = COURSETYPE.MONTLY });

            if (course == null)
            {
                HeaderTxt.Text = "เพิ่มข้อมูล";
                btnSave.Text = "เพิ่ม";
                m_currentCourse = new Course();
                m_currentCourse.CreateDate = DateTime.Now;
                typeBox.SelectedIndex = 1;
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
                typeBox.SelectedIndex = (m_currentCourse.CourseType == COURSETYPE.DAILY) ? 0 : 1;
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
            if (typeBox.Text == "รายวัน")
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

    public class ComboboxItem
    {
        public string Text { get; set; }
        public object Value { get; set; }

        public override string ToString()
        {
            return Text;
        }
    }
}
