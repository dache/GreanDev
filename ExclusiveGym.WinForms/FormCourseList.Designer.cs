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
            this.checkedListBox1 = new System.Windows.Forms.CheckedListBox();
            this.ApplyCourse = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // checkedListBox1
            // 
            this.checkedListBox1.FormattingEnabled = true;
            this.checkedListBox1.Location = new System.Drawing.Point(69, 79);
            this.checkedListBox1.Name = "checkedListBox1";
            this.checkedListBox1.Size = new System.Drawing.Size(598, 214);
            this.checkedListBox1.TabIndex = 0;
            // 
            // ApplyCourse
            // 
            this.ApplyCourse.Location = new System.Drawing.Point(298, 319);
            this.ApplyCourse.Name = "ApplyCourse";
            this.ApplyCourse.Size = new System.Drawing.Size(238, 95);
            this.ApplyCourse.TabIndex = 1;
            this.ApplyCourse.Text = "Apply";
            this.ApplyCourse.UseVisualStyleBackColor = true;
            this.ApplyCourse.Click += new System.EventHandler(this.ApplyCourse_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(393, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "label1";
            // 
            // FormCourseList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(833, 479);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.ApplyCourse);
            this.Controls.Add(this.checkedListBox1);
            this.Name = "FormCourseList";
            this.Text = "FormCourseList";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckedListBox checkedListBox1;
        private System.Windows.Forms.Button ApplyCourse;
        private System.Windows.Forms.Label label1;
    }
}