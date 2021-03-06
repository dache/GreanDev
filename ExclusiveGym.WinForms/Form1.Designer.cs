﻿namespace ExclusiveGym.WinForms
{
    partial class Form1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.MenuPanel = new System.Windows.Forms.Panel();
            this.btnPayment = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.currentMenuPanel = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.btnIncomeMenu = new System.Windows.Forms.Button();
            this.btnPromotionMenu = new System.Windows.Forms.Button();
            this.btnMemberMenu = new System.Windows.Forms.Button();
            this.btnHomeMenu = new System.Windows.Forms.Button();
            this.TitleBarPanel = new System.Windows.Forms.Panel();
            this.btnClose = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblDeviceStatus = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lblDate = new System.Windows.Forms.Label();
            this.paymentControl1 = new ExclusiveGym.WinForms.UserControls.PaymentControl();
            this.homeControl1 = new ExclusiveGym.WinForms.UserControls.HomeControl();
            this.reportControl1 = new ExclusiveGym.WinForms.UserControls.ReportControl();
            this.courseControl1 = new ExclusiveGym.WinForms.UserControls.CourseControl();
            this.memberControl1 = new ExclusiveGym.WinForms.UserControls.MemberControl();
            this.MenuPanel.SuspendLayout();
            this.TitleBarPanel.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // MenuPanel
            // 
            this.MenuPanel.BackColor = System.Drawing.Color.DarkOliveGreen;
            this.MenuPanel.Controls.Add(this.btnPayment);
            this.MenuPanel.Controls.Add(this.panel2);
            this.MenuPanel.Controls.Add(this.label6);
            this.MenuPanel.Controls.Add(this.label5);
            this.MenuPanel.Controls.Add(this.label4);
            this.MenuPanel.Controls.Add(this.label2);
            this.MenuPanel.Controls.Add(this.currentMenuPanel);
            this.MenuPanel.Controls.Add(this.label1);
            this.MenuPanel.Controls.Add(this.btnIncomeMenu);
            this.MenuPanel.Controls.Add(this.btnPromotionMenu);
            this.MenuPanel.Controls.Add(this.btnMemberMenu);
            this.MenuPanel.Controls.Add(this.btnHomeMenu);
            this.MenuPanel.Dock = System.Windows.Forms.DockStyle.Left;
            this.MenuPanel.Location = new System.Drawing.Point(0, 0);
            this.MenuPanel.Name = "MenuPanel";
            this.MenuPanel.Size = new System.Drawing.Size(188, 700);
            this.MenuPanel.TabIndex = 0;
            // 
            // btnPayment
            // 
            this.btnPayment.BackColor = System.Drawing.Color.DarkOliveGreen;
            this.btnPayment.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnPayment.FlatAppearance.BorderSize = 0;
            this.btnPayment.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.btnPayment.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPayment.Font = new System.Drawing.Font("Prompt", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPayment.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.btnPayment.Image = ((System.Drawing.Image)(resources.GetObject("btnPayment.Image")));
            this.btnPayment.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnPayment.Location = new System.Drawing.Point(12, 309);
            this.btnPayment.Name = "btnPayment";
            this.btnPayment.Size = new System.Drawing.Size(155, 45);
            this.btnPayment.TabIndex = 12;
            this.btnPayment.Text = " ใบเสร็จ";
            this.btnPayment.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnPayment.UseVisualStyleBackColor = false;
            this.btnPayment.Click += new System.EventHandler(this.btnMenu_Click);
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Location = new System.Drawing.Point(11, 558);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(181, 1);
            this.panel2.TabIndex = 11;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Prompt", 9.749999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(81, 648);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(96, 19);
            this.label6.TabIndex = 10;
            this.label6.Text = "083-163-4088";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Prompt", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(24, 619);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(155, 29);
            this.label5.TabIndex = 9;
            this.label5.Text = "Drunken Coder";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Prompt", 9.749999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(12, 600);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(90, 19);
            this.label4.TabIndex = 8;
            this.label4.Text = "Develope By.";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Prompt", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Snow;
            this.label2.Location = new System.Drawing.Point(5, 13);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(162, 49);
            this.label2.TabIndex = 7;
            this.label2.Text = "Exclusive";
            // 
            // currentMenuPanel
            // 
            this.currentMenuPanel.BackColor = System.Drawing.Color.Maroon;
            this.currentMenuPanel.Location = new System.Drawing.Point(0, 105);
            this.currentMenuPanel.Name = "currentMenuPanel";
            this.currentMenuPanel.Size = new System.Drawing.Size(10, 45);
            this.currentMenuPanel.TabIndex = 6;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Comic Sans MS", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Snow;
            this.label1.Location = new System.Drawing.Point(103, 56);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(76, 38);
            this.label1.TabIndex = 5;
            this.label1.Text = "GYM";
            // 
            // btnIncomeMenu
            // 
            this.btnIncomeMenu.BackColor = System.Drawing.Color.DarkOliveGreen;
            this.btnIncomeMenu.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnIncomeMenu.FlatAppearance.BorderSize = 0;
            this.btnIncomeMenu.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.btnIncomeMenu.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnIncomeMenu.Font = new System.Drawing.Font("Prompt", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnIncomeMenu.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.btnIncomeMenu.Image = ((System.Drawing.Image)(resources.GetObject("btnIncomeMenu.Image")));
            this.btnIncomeMenu.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnIncomeMenu.Location = new System.Drawing.Point(12, 258);
            this.btnIncomeMenu.Name = "btnIncomeMenu";
            this.btnIncomeMenu.Size = new System.Drawing.Size(155, 45);
            this.btnIncomeMenu.TabIndex = 0;
            this.btnIncomeMenu.Text = " รายงาน";
            this.btnIncomeMenu.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnIncomeMenu.UseVisualStyleBackColor = false;
            this.btnIncomeMenu.Click += new System.EventHandler(this.btnMenu_Click);
            // 
            // btnPromotionMenu
            // 
            this.btnPromotionMenu.BackColor = System.Drawing.Color.DarkOliveGreen;
            this.btnPromotionMenu.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnPromotionMenu.FlatAppearance.BorderSize = 0;
            this.btnPromotionMenu.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.btnPromotionMenu.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPromotionMenu.Font = new System.Drawing.Font("Prompt", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPromotionMenu.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.btnPromotionMenu.Image = ((System.Drawing.Image)(resources.GetObject("btnPromotionMenu.Image")));
            this.btnPromotionMenu.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnPromotionMenu.Location = new System.Drawing.Point(12, 207);
            this.btnPromotionMenu.Name = "btnPromotionMenu";
            this.btnPromotionMenu.Size = new System.Drawing.Size(155, 45);
            this.btnPromotionMenu.TabIndex = 0;
            this.btnPromotionMenu.Text = " จัดการคอร์ส";
            this.btnPromotionMenu.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnPromotionMenu.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnPromotionMenu.UseVisualStyleBackColor = false;
            this.btnPromotionMenu.Click += new System.EventHandler(this.btnMenu_Click);
            // 
            // btnMemberMenu
            // 
            this.btnMemberMenu.BackColor = System.Drawing.Color.DarkOliveGreen;
            this.btnMemberMenu.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnMemberMenu.FlatAppearance.BorderSize = 0;
            this.btnMemberMenu.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.btnMemberMenu.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMemberMenu.Font = new System.Drawing.Font("Prompt", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMemberMenu.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.btnMemberMenu.Image = ((System.Drawing.Image)(resources.GetObject("btnMemberMenu.Image")));
            this.btnMemberMenu.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnMemberMenu.Location = new System.Drawing.Point(12, 156);
            this.btnMemberMenu.Name = "btnMemberMenu";
            this.btnMemberMenu.Size = new System.Drawing.Size(155, 45);
            this.btnMemberMenu.TabIndex = 0;
            this.btnMemberMenu.Text = " สมาชิก";
            this.btnMemberMenu.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnMemberMenu.UseVisualStyleBackColor = false;
            this.btnMemberMenu.Click += new System.EventHandler(this.btnMenu_Click);
            // 
            // btnHomeMenu
            // 
            this.btnHomeMenu.BackColor = System.Drawing.Color.DarkOliveGreen;
            this.btnHomeMenu.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnHomeMenu.FlatAppearance.BorderSize = 0;
            this.btnHomeMenu.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.btnHomeMenu.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnHomeMenu.Font = new System.Drawing.Font("Prompt", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnHomeMenu.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.btnHomeMenu.Image = ((System.Drawing.Image)(resources.GetObject("btnHomeMenu.Image")));
            this.btnHomeMenu.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnHomeMenu.Location = new System.Drawing.Point(12, 105);
            this.btnHomeMenu.Name = "btnHomeMenu";
            this.btnHomeMenu.Size = new System.Drawing.Size(155, 45);
            this.btnHomeMenu.TabIndex = 0;
            this.btnHomeMenu.Text = " หน้าหลัก";
            this.btnHomeMenu.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnHomeMenu.UseVisualStyleBackColor = false;
            this.btnHomeMenu.Click += new System.EventHandler(this.btnMenu_Click);
            // 
            // TitleBarPanel
            // 
            this.TitleBarPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(211)))), ((int)(((byte)(155)))), ((int)(((byte)(140)))));
            this.TitleBarPanel.Controls.Add(this.btnClose);
            this.TitleBarPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.TitleBarPanel.Location = new System.Drawing.Point(188, 0);
            this.TitleBarPanel.Name = "TitleBarPanel";
            this.TitleBarPanel.Size = new System.Drawing.Size(921, 34);
            this.TitleBarPanel.TabIndex = 1;
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnClose.FlatAppearance.BorderSize = 0;
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.Font = new System.Drawing.Font("Comic Sans MS", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.btnClose.Image = ((System.Drawing.Image)(resources.GetObject("btnClose.Image")));
            this.btnClose.Location = new System.Drawing.Point(871, 2);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(38, 30);
            this.btnClose.TabIndex = 9;
            this.btnClose.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.DarkGray;
            this.panel1.Controls.Add(this.lblDeviceStatus);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.lblDate);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(188, 670);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(921, 30);
            this.panel1.TabIndex = 8;
            // 
            // lblDeviceStatus
            // 
            this.lblDeviceStatus.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblDeviceStatus.AutoSize = true;
            this.lblDeviceStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.749999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDeviceStatus.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.lblDeviceStatus.Location = new System.Drawing.Point(105, 6);
            this.lblDeviceStatus.Name = "lblDeviceStatus";
            this.lblDeviceStatus.Size = new System.Drawing.Size(43, 16);
            this.lblDeviceStatus.TabIndex = 2;
            this.lblDeviceStatus.Text = "status";
            this.lblDeviceStatus.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.749999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.label3.Location = new System.Drawing.Point(6, 6);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(97, 16);
            this.label3.TabIndex = 2;
            this.label3.Text = "Device Status :";
            // 
            // lblDate
            // 
            this.lblDate.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.lblDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.749999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDate.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.lblDate.Location = new System.Drawing.Point(666, 6);
            this.lblDate.Name = "lblDate";
            this.lblDate.Size = new System.Drawing.Size(243, 16);
            this.lblDate.TabIndex = 1;
            this.lblDate.Text = "16/09/2018 ";
            this.lblDate.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // paymentControl1
            // 
            this.paymentControl1.Location = new System.Drawing.Point(188, 34);
            this.paymentControl1.Name = "paymentControl1";
            this.paymentControl1.Size = new System.Drawing.Size(917, 630);
            this.paymentControl1.TabIndex = 14;
            // 
            // homeControl1
            // 
            this.homeControl1.BackColor = System.Drawing.SystemColors.Control;
            this.homeControl1.Location = new System.Drawing.Point(188, 35);
            this.homeControl1.Name = "homeControl1";
            this.homeControl1.Size = new System.Drawing.Size(917, 635);
            this.homeControl1.TabIndex = 13;
            // 
            // reportControl1
            // 
            this.reportControl1.Location = new System.Drawing.Point(188, 35);
            this.reportControl1.Name = "reportControl1";
            this.reportControl1.Size = new System.Drawing.Size(917, 635);
            this.reportControl1.TabIndex = 12;
            // 
            // courseControl1
            // 
            this.courseControl1.Location = new System.Drawing.Point(188, 35);
            this.courseControl1.Name = "courseControl1";
            this.courseControl1.Size = new System.Drawing.Size(917, 635);
            this.courseControl1.TabIndex = 11;
            // 
            // memberControl1
            // 
            this.memberControl1.Location = new System.Drawing.Point(188, 35);
            this.memberControl1.Name = "memberControl1";
            this.memberControl1.Size = new System.Drawing.Size(917, 635);
            this.memberControl1.TabIndex = 10;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1109, 700);
            this.Controls.Add(this.paymentControl1);
            this.Controls.Add(this.homeControl1);
            this.Controls.Add(this.reportControl1);
            this.Controls.Add(this.courseControl1);
            this.Controls.Add(this.memberControl1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.TitleBarPanel);
            this.Controls.Add(this.MenuPanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Exclusive GYM";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.MenuPanel.ResumeLayout(false);
            this.MenuPanel.PerformLayout();
            this.TitleBarPanel.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel MenuPanel;
        private System.Windows.Forms.Button btnHomeMenu;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnIncomeMenu;
        private System.Windows.Forms.Button btnPromotionMenu;
        private System.Windows.Forms.Button btnMemberMenu;
        private System.Windows.Forms.Panel currentMenuPanel;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel TitleBarPanel;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lblDate;
        private UserControls.MemberControl memberControl1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblDeviceStatus;
        private UserControls.CourseControl courseControl1;
        private UserControls.ReportControl reportControl1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Panel panel2;
        private UserControls.HomeControl homeControl1;
        private System.Windows.Forms.Button btnPayment;
        private UserControls.PaymentControl paymentControl1;
    }
}

