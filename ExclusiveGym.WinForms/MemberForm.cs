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
    public partial class MemberForm : Form
    {
        private const int WS_EX_TRANSPARENT = 0x20;
               
        public MemberForm()
        {
            InitializeComponent();            
            SetStyle(ControlStyles.Opaque, true);
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
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

        private void btnSave_Click(object sender, EventArgs e)
        {
            using (var db = new ExclusiveGymContext())
            {
                var newMember = new Member();
                newMember.Name = txtName.Text;
                newMember.LastName = txtLastName.Text;
                newMember.CreateDate = DateTime.Now;
                newMember.BirthDate = DateTime.Now;
                newMember.FingerPrint = lblFingerPrint.Text;

                db.Members.Add(newMember);
                db.SaveChanges();
            }
        }

        public void ReceiveFingerPrint(string fingerPrint)
        {
            lblFingerPrint.Text = fingerPrint;
        }

        private void btnFingerPrint_Click(object sender, EventArgs e)
        {
            var fingerForm = new FingerPrintForm();
            fingerForm.Send = new FingerPrintForm.SendFingerPrint(ReceiveFingerPrint);
            fingerForm.ShowDialog();
        }
    }
}
