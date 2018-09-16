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

namespace ExclusiveGym.WinForms.CustomControls
{
    public partial class MemberSignControl : UserControl
    {
        public MemberSignControl(AccessLog accessLog)
        {
            InitializeComponent();

            lblName.Text = $"{accessLog.Member.Name}  {accessLog.Member.LastName}";
            lblMemberType.Text = (accessLog.AccessType == COURSETYPE.DAILY) ? "รายวัน" : "รายเดือน";
            lblCurrentTime.Text = accessLog.AccessDate.ToString("hh:mm:ss");
        }
    }
}
