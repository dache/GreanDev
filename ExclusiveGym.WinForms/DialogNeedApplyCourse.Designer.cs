namespace ExclusiveGym.WinForms
{
    partial class DialogNeedApplyCourse
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.Daily = new System.Windows.Forms.Button();
            this.FindOtherCourse = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // Daily
            // 
            this.Daily.Location = new System.Drawing.Point(102, 163);
            this.Daily.Name = "Daily";
            this.Daily.Size = new System.Drawing.Size(205, 137);
            this.Daily.TabIndex = 0;
            this.Daily.Text = "Daily";
            this.Daily.UseVisualStyleBackColor = true;
            this.Daily.Click += new System.EventHandler(this.Daily_Click);
            // 
            // FindOtherCourse
            // 
            this.FindOtherCourse.Location = new System.Drawing.Point(453, 163);
            this.FindOtherCourse.Name = "FindOtherCourse";
            this.FindOtherCourse.Size = new System.Drawing.Size(205, 137);
            this.FindOtherCourse.TabIndex = 1;
            this.FindOtherCourse.Text = "FindCourse";
            this.FindOtherCourse.UseVisualStyleBackColor = true;
            this.FindOtherCourse.Click += new System.EventHandler(this.FindOtherCourse_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(400, 61);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "label1";
            // 
            // DialogNeedApplyCourse
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.FindOtherCourse);
            this.Controls.Add(this.Daily);
            this.Name = "DialogNeedApplyCourse";
            this.Text = "DialogNeedApplyCourse";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button Daily;
        private System.Windows.Forms.Button FindOtherCourse;
        private System.Windows.Forms.Label label1;
    }
}