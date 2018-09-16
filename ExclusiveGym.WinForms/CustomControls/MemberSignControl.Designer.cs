namespace ExclusiveGym.WinForms.CustomControls
{
    partial class MemberSignControl
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label13 = new System.Windows.Forms.Label();
            this.lblMemberType = new System.Windows.Forms.Label();
            this.lblCurrentTime = new System.Windows.Forms.Label();
            this.lblName = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Prompt", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label13.Location = new System.Drawing.Point(5, 29);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(57, 22);
            this.label13.TabIndex = 7;
            this.label13.Text = "เข้าเวลา";
            // 
            // lblMemberType
            // 
            this.lblMemberType.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblMemberType.AutoSize = true;
            this.lblMemberType.Font = new System.Drawing.Font("Prompt", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMemberType.ForeColor = System.Drawing.Color.Purple;
            this.lblMemberType.Location = new System.Drawing.Point(232, 6);
            this.lblMemberType.Name = "lblMemberType";
            this.lblMemberType.Size = new System.Drawing.Size(65, 22);
            this.lblMemberType.TabIndex = 6;
            this.lblMemberType.Text = "รายเดือน";
            // 
            // lblCurrentTime
            // 
            this.lblCurrentTime.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblCurrentTime.AutoSize = true;
            this.lblCurrentTime.Font = new System.Drawing.Font("Prompt", 9.749999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCurrentTime.ForeColor = System.Drawing.Color.DarkOrange;
            this.lblCurrentTime.Location = new System.Drawing.Point(238, 31);
            this.lblCurrentTime.Name = "lblCurrentTime";
            this.lblCurrentTime.Size = new System.Drawing.Size(59, 19);
            this.lblCurrentTime.TabIndex = 4;
            this.lblCurrentTime.Text = "15:30:29";
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Font = new System.Drawing.Font("Prompt", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblName.ForeColor = System.Drawing.Color.DimGray;
            this.lblName.Location = new System.Drawing.Point(5, 5);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(173, 24);
            this.lblName.TabIndex = 3;
            this.lblName.Text = "Firstname  LastName";
            // 
            // MemberSignControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.label13);
            this.Controls.Add(this.lblMemberType);
            this.Controls.Add(this.lblName);
            this.Controls.Add(this.lblCurrentTime);
            this.Name = "MemberSignControl";
            this.Size = new System.Drawing.Size(300, 55);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label lblMemberType;
        private System.Windows.Forms.Label lblCurrentTime;
        private System.Windows.Forms.Label lblName;
    }
}
