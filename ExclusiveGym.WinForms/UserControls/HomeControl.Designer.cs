namespace ExclusiveGym.WinForms.UserControls
{
    partial class HomeControl
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(HomeControl));
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.label29 = new System.Windows.Forms.Label();
            this.panel4 = new System.Windows.Forms.Panel();
            this.label6 = new System.Windows.Forms.Label();
            this.lblIncome = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label5 = new System.Windows.Forms.Label();
            this.lblMemberCount = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.btnDailyRegister = new System.Windows.Forms.Button();
            this.panel4.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.BackColor = System.Drawing.Color.White;
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Location = new System.Drawing.Point(18, 75);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(881, 394);
            this.tableLayoutPanel1.TabIndex = 15;
            // 
            // label29
            // 
            this.label29.AutoSize = true;
            this.label29.Font = new System.Drawing.Font("Prompt", 18F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label29.ForeColor = System.Drawing.Color.DarkGreen;
            this.label29.Location = new System.Drawing.Point(16, 36);
            this.label29.Name = "label29";
            this.label29.Size = new System.Drawing.Size(180, 36);
            this.label29.TabIndex = 12;
            this.label29.Text = "สมาชิกเข้าใช้วันนี้";
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.White;
            this.panel4.Controls.Add(this.label6);
            this.panel4.Controls.Add(this.lblIncome);
            this.panel4.Controls.Add(this.label8);
            this.panel4.Location = new System.Drawing.Point(346, 493);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(553, 112);
            this.panel4.TabIndex = 13;
            // 
            // label6
            // 
            this.label6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Prompt", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.DimGray;
            this.label6.Location = new System.Drawing.Point(482, 56);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(62, 40);
            this.label6.TabIndex = 2;
            this.label6.Text = "บาท";
            // 
            // lblIncome
            // 
            this.lblIncome.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.lblIncome.BackColor = System.Drawing.Color.White;
            this.lblIncome.Font = new System.Drawing.Font("Prompt", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblIncome.ForeColor = System.Drawing.Color.LightPink;
            this.lblIncome.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lblIncome.Location = new System.Drawing.Point(122, 32);
            this.lblIncome.Name = "lblIncome";
            this.lblIncome.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.lblIncome.Size = new System.Drawing.Size(362, 72);
            this.lblIncome.TabIndex = 1;
            this.lblIncome.Text = "0";
            this.lblIncome.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label8
            // 
            this.label8.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Prompt", 14.25F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.DimGray;
            this.label8.Location = new System.Drawing.Point(447, 4);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(97, 29);
            this.label8.TabIndex = 0;
            this.label8.Text = "รายได้วันนี้";
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.White;
            this.panel3.Controls.Add(this.pictureBox1);
            this.panel3.Controls.Add(this.label5);
            this.panel3.Controls.Add(this.lblMemberCount);
            this.panel3.Controls.Add(this.label3);
            this.panel3.Location = new System.Drawing.Point(18, 493);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(320, 115);
            this.panel3.TabIndex = 14;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(4, 4);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(113, 108);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 3;
            this.pictureBox1.TabStop = false;
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Prompt", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.DimGray;
            this.label5.Location = new System.Drawing.Point(254, 51);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(51, 40);
            this.label5.TabIndex = 2;
            this.label5.Text = "คน";
            // 
            // lblMemberCount
            // 
            this.lblMemberCount.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblMemberCount.AutoSize = true;
            this.lblMemberCount.Font = new System.Drawing.Font("Prompt", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMemberCount.ForeColor = System.Drawing.Color.DeepSkyBlue;
            this.lblMemberCount.Location = new System.Drawing.Point(169, 33);
            this.lblMemberCount.Name = "lblMemberCount";
            this.lblMemberCount.Size = new System.Drawing.Size(79, 72);
            this.lblMemberCount.TabIndex = 1;
            this.lblMemberCount.Text = "10";
            this.lblMemberCount.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Prompt", 14.25F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.DimGray;
            this.label3.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.label3.Location = new System.Drawing.Point(173, 4);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(144, 29);
            this.label3.TabIndex = 0;
            this.label3.Text = "จำนวนเข้าใช้วันนี้";
            // 
            // btnDailyRegister
            // 
            this.btnDailyRegister.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(193)))), ((int)(((byte)(7)))));
            this.btnDailyRegister.FlatAppearance.BorderSize = 0;
            this.btnDailyRegister.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDailyRegister.Font = new System.Drawing.Font("Prompt", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDailyRegister.Location = new System.Drawing.Point(769, 24);
            this.btnDailyRegister.Name = "btnDailyRegister";
            this.btnDailyRegister.Size = new System.Drawing.Size(130, 45);
            this.btnDailyRegister.TabIndex = 16;
            this.btnDailyRegister.Text = "เข้าใช้งานรายวัน";
            this.btnDailyRegister.UseVisualStyleBackColor = false;
            this.btnDailyRegister.Click += new System.EventHandler(this.btnDailyRegister_Click);
            // 
            // HomeControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.Controls.Add(this.btnDailyRegister);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.label29);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.panel3);
            this.Name = "HomeControl";
            this.Size = new System.Drawing.Size(917, 630);
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label label29;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label lblIncome;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label lblMemberCount;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnDailyRegister;
    }
}
