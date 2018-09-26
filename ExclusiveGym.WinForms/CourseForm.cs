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
            
            if (course == null)
            {
                HeaderTxt.Text = "เพิ่มข้อมูล";
                btnSave.Text = "เพิ่ม";
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
            }
            m_finishCallback = callback;
        }

        #region BGOpacity
        private const int WS_EX_TRANSPARENT = 0x20;
        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams cp = base.CreateParams;
                cp.ExStyle = cp.ExStyle | WS_EX_TRANSPARENT;
                return cp;
            }
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            using (var brush = new SolidBrush(Color.FromArgb(50 * 255 / 100, this.BackColor)))
            {
                e.Graphics.FillRectangle(brush, this.ClientRectangle);
            }
            base.OnPaint(e);
        }

        #endregion

        private void EndForm()
        {
            if(m_finishCallback != null)
                m_finishCallback();
            this.Close();
        }
        private void btnCancel_Click(object sender, EventArgs e)
        {
            EndForm();
        }
        
        private void btnSave_Click(object sender, EventArgs e)
        {
            m_currentCourse.CourseName = txtName.Text;
            m_currentCourse.CoursePrice = int.Parse(priceTxt.Text);
            m_currentCourse.CourseType = COURSETYPE.MONTLY;
            m_currentCourse.TotalDay = int.Parse(totalDayTxt.Text);

            if (m_isUpdate)
                StorageManager.GetSingleton().GetDB().Entry(m_currentCourse).State = System.Data.Entity.EntityState.Modified;
            else
                StorageManager.GetSingleton().GetDB().Courses.Add(m_currentCourse);

            StorageManager.GetSingleton().GetDB().SaveChanges();

            EndForm();
        }

        private void CourseForm_Load(object sender, EventArgs e)
        {
            FormManager.GetSingleton().SetCurrentFocusForm(this);
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
