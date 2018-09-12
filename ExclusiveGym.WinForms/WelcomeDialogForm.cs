using ExclusiveGym.WinForms.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ExclusiveGym.WinForms
{
    public partial class WelcomeDialogForm : Form
    {
        private const int WS_EX_TRANSPARENT = 0x20;

        public WelcomeDialogForm(Member member)
        {
            InitializeComponent();
            SetStyle(ControlStyles.Opaque, true);

            lblMessage.Text = $"สวัสดี คุณ{member.Name} {member.LastName}";
            lblTime.Text = $"เข้าฟิสเนต เวลา {DateTime.Now}";
            StorageManager.GetSingleton().MemberAccessGym(member);
        }

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

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }

}
