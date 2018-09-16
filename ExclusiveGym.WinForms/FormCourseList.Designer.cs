namespace ExclusiveGym.WinForms
{
    partial class FormCourseList
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
            this.ApplyCourse = new System.Windows.Forms.Button();
            this.AddCourse = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // ApplyCourse
            // 
            this.ApplyCourse.Location = new System.Drawing.Point(246, 394);
            this.ApplyCourse.Name = "ApplyCourse";
            this.ApplyCourse.Size = new System.Drawing.Size(238, 95);
            this.ApplyCourse.TabIndex = 1;
            this.ApplyCourse.Text = "Apply";
            this.ApplyCourse.UseVisualStyleBackColor = true;
            this.ApplyCourse.Click += new System.EventHandler(this.ApplyCourse_Click);
            // 
            // AddCourse
            // 
            this.AddCourse.Location = new System.Drawing.Point(39, 24);
            this.AddCourse.Name = "AddCourse";
            this.AddCourse.Size = new System.Drawing.Size(93, 74);
            this.AddCourse.TabIndex = 3;
            this.AddCourse.Text = "AddCourse";
            this.AddCourse.UseVisualStyleBackColor = true;
            // 
            // FormCourseList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1000, 650);
            this.Controls.Add(this.AddCourse);
            this.Controls.Add(this.ApplyCourse);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FormCourseList";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FormCourseList";
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button ApplyCourse;
        private System.Windows.Forms.Button AddCourse;
    }
}