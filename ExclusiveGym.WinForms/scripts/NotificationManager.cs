using System;
using System.Drawing;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using ExclusiveGym.WinForms;

class NotificationManager
{
    private static NotificationManager m_singleton;

    public static NotificationManager GetSingleton()
    {
        if (m_singleton == null) m_singleton = new NotificationManager();
        return m_singleton;
    }


    public void ShowNotification(Form f, string message)
    {
        Label notiLabel = new Label();
        Size size = new Size((int)(f.Size.Width - f.Size.Width * 0.05), 0);
        notiLabel.Size = size;
        notiLabel.Text = message;
        notiLabel.Font = new Font("Prompt", 15);
        notiLabel.BackColor = Color.White;
        notiLabel.ForeColor = Color.Black;
        notiLabel.Location = new Point(25, 0);
        notiLabel.AutoSize = false;
        notiLabel.TextAlign = ContentAlignment.MiddleCenter;
        FormManager.GetSingleton().GetCurrentFocusForm().Controls.Add(notiLabel);
        notiLabel.BringToFront();

        //Thread backgroundWorker = new Thread(() => BeginDisplay(f, notiLabel));
        //backgroundWorker.IsBackground = true;
        //backgroundWorker.Start();
        BeginDisplay(FormManager.GetSingleton().GetCurrentFocusForm(), notiLabel);
    }
    private async void BeginDisplay(Form f, Label label)
    {
        //label.BeginInvoke((MethodInvoker)async delegate()
        //{
        //    await Task.Delay(200);
        //    await BeginShow(f, label);
        //    await Task.Delay(400);
        //    await BeginHide(f, label);
        //    f.Controls.Remove(label);
        //});
        await Task.Delay(200);
        await BeginShow(f, label);
        await Task.Delay(2000);
        await BeginHide(f, label);
        
        f.Controls.Remove(label);
       // FormManager.GetSingleton().GetMainForm().Controls.Remove(label);
    }
    
    private async Task<bool> BeginShow(Form f, Label label)
    {
        bool isFinish = false;
        while (!isFinish)
        {
            await Task.Delay(1);
            label.BringToFront();
            //label.BackColor = Color.FromArgb(label.Size.Height, Color.Blue);
            label.Size = new Size(label.Size.Width, label.Size.Height + 2);
            isFinish = label.Size.Height > 70;
        }
        return isFinish;
    }
    private async Task<bool> BeginHide(Form f, Label label)
    {

        bool isFinish = false;
        while (!isFinish)
        {
            await Task.Delay(1);
            //label.BackColor = Color.FromArgb(label.Size.Height, Color.Blue);
            label.Size = new Size(label.Size.Width, label.Size.Height - 2);
            isFinish = label.Size.Height < 3;
        }
        return isFinish;
    }
    
}

