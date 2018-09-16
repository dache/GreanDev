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
using ExclusiveGym.WinForms.CustomControls;

namespace ExclusiveGym.WinForms.UserControls
{
    public partial class HomeControl : UserControl
    {
        public HomeControl()
        {
            InitializeComponent();

            var logs = StorageManager.GetSingleton().GetAccessLogList();
            foreach(var memberLog in logs)
            {
                var customControl = new MemberSignControl(memberLog);
                tableLayoutPanel1.Controls.Add(customControl);
            }

            lblMemberCount.Text = logs.Count().ToString();
        }

        public void Refresh()
        {
            tableLayoutPanel1.Controls.Clear();
            var logs = StorageManager.GetSingleton().GetAccessLogList();
            foreach (var memberLog in logs)
            {
                var customControl = new MemberSignControl(memberLog);
                tableLayoutPanel1.Controls.Add(customControl);
            }
        }
    }
}
