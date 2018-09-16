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

        }
    }
}
