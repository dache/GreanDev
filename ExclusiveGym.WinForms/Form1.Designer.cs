namespace ExclusiveGym.WinForms
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
            this.label2 = new System.Windows.Forms.Label();
            this.currentMenuPanel = new System.Windows.Forms.Panel();
            this.btnEmployeeMenu = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.btnIncomeMenu = new System.Windows.Forms.Button();
            this.btnPromotionMenu = new System.Windows.Forms.Button();
            this.btnMemberMenu = new System.Windows.Forms.Button();
            this.btnHomeMenu = new System.Windows.Forms.Button();
            this.TitleBarPanel = new System.Windows.Forms.Panel();
            this.btnSlideMenu = new System.Windows.Forms.PictureBox();
            this.btnClose = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.fpicture = new System.Windows.Forms.PictureBox();
            this.btnRegister = new System.Windows.Forms.Button();
            this.btnVerify = new System.Windows.Forms.Button();
            this.txtTemplate = new System.Windows.Forms.TextBox();
            this.prompt = new System.Windows.Forms.Label();
            this.deviceSerial = new System.Windows.Forms.Label();
            this.txtName = new System.Windows.Forms.TextBox();
            this.button2 = new System.Windows.Forms.Button();
            this.MenuPanel.SuspendLayout();
            this.TitleBarPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnSlideMenu)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fpicture)).BeginInit();
            this.SuspendLayout();
            // 
            // MenuPanel
            // 
            this.MenuPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(216)))), ((int)(((byte)(213)))), ((int)(((byte)(212)))));
            this.MenuPanel.Controls.Add(this.label2);
            this.MenuPanel.Controls.Add(this.currentMenuPanel);
            this.MenuPanel.Controls.Add(this.btnEmployeeMenu);
            this.MenuPanel.Controls.Add(this.label1);
            this.MenuPanel.Controls.Add(this.btnIncomeMenu);
            this.MenuPanel.Controls.Add(this.btnPromotionMenu);
            this.MenuPanel.Controls.Add(this.btnMemberMenu);
            this.MenuPanel.Controls.Add(this.btnHomeMenu);
            this.MenuPanel.Dock = System.Windows.Forms.DockStyle.Left;
            this.MenuPanel.Location = new System.Drawing.Point(0, 0);
            this.MenuPanel.Name = "MenuPanel";
            this.MenuPanel.Size = new System.Drawing.Size(205, 600);
            this.MenuPanel.TabIndex = 0;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Prompt", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(6, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(120, 36);
            this.label2.TabIndex = 7;
            this.label2.Text = "Exclusive";
            // 
            // currentMenuPanel
            // 
            this.currentMenuPanel.BackColor = System.Drawing.Color.Maroon;
            this.currentMenuPanel.Location = new System.Drawing.Point(0, 61);
            this.currentMenuPanel.Name = "currentMenuPanel";
            this.currentMenuPanel.Size = new System.Drawing.Size(10, 45);
            this.currentMenuPanel.TabIndex = 6;
            // 
            // btnEmployeeMenu
            // 
            this.btnEmployeeMenu.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnEmployeeMenu.FlatAppearance.BorderSize = 0;
            this.btnEmployeeMenu.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEmployeeMenu.Font = new System.Drawing.Font("Comic Sans MS", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEmployeeMenu.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.btnEmployeeMenu.Image = ((System.Drawing.Image)(resources.GetObject("btnEmployeeMenu.Image")));
            this.btnEmployeeMenu.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnEmployeeMenu.Location = new System.Drawing.Point(12, 265);
            this.btnEmployeeMenu.Name = "btnEmployeeMenu";
            this.btnEmployeeMenu.Size = new System.Drawing.Size(193, 45);
            this.btnEmployeeMenu.TabIndex = 0;
            this.btnEmployeeMenu.Text = "    Employee";
            this.btnEmployeeMenu.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnEmployeeMenu.UseVisualStyleBackColor = true;
            this.btnEmployeeMenu.Click += new System.EventHandler(this.btnMenu_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Comic Sans MS", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(123, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(76, 38);
            this.label1.TabIndex = 5;
            this.label1.Text = "GYM";
            // 
            // btnIncomeMenu
            // 
            this.btnIncomeMenu.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnIncomeMenu.FlatAppearance.BorderSize = 0;
            this.btnIncomeMenu.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnIncomeMenu.Font = new System.Drawing.Font("Comic Sans MS", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnIncomeMenu.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.btnIncomeMenu.Image = ((System.Drawing.Image)(resources.GetObject("btnIncomeMenu.Image")));
            this.btnIncomeMenu.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnIncomeMenu.Location = new System.Drawing.Point(12, 214);
            this.btnIncomeMenu.Name = "btnIncomeMenu";
            this.btnIncomeMenu.Size = new System.Drawing.Size(193, 45);
            this.btnIncomeMenu.TabIndex = 0;
            this.btnIncomeMenu.Text = "    Income";
            this.btnIncomeMenu.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnIncomeMenu.UseVisualStyleBackColor = true;
            this.btnIncomeMenu.Click += new System.EventHandler(this.btnMenu_Click);
            // 
            // btnPromotionMenu
            // 
            this.btnPromotionMenu.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnPromotionMenu.FlatAppearance.BorderSize = 0;
            this.btnPromotionMenu.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPromotionMenu.Font = new System.Drawing.Font("Comic Sans MS", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPromotionMenu.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.btnPromotionMenu.Image = ((System.Drawing.Image)(resources.GetObject("btnPromotionMenu.Image")));
            this.btnPromotionMenu.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnPromotionMenu.Location = new System.Drawing.Point(12, 163);
            this.btnPromotionMenu.Name = "btnPromotionMenu";
            this.btnPromotionMenu.Size = new System.Drawing.Size(193, 45);
            this.btnPromotionMenu.TabIndex = 0;
            this.btnPromotionMenu.Text = "    Promotion";
            this.btnPromotionMenu.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnPromotionMenu.UseVisualStyleBackColor = true;
            this.btnPromotionMenu.Click += new System.EventHandler(this.btnMenu_Click);
            // 
            // btnMemberMenu
            // 
            this.btnMemberMenu.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnMemberMenu.FlatAppearance.BorderSize = 0;
            this.btnMemberMenu.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMemberMenu.Font = new System.Drawing.Font("Comic Sans MS", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMemberMenu.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.btnMemberMenu.Image = ((System.Drawing.Image)(resources.GetObject("btnMemberMenu.Image")));
            this.btnMemberMenu.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnMemberMenu.Location = new System.Drawing.Point(12, 112);
            this.btnMemberMenu.Name = "btnMemberMenu";
            this.btnMemberMenu.Size = new System.Drawing.Size(193, 45);
            this.btnMemberMenu.TabIndex = 0;
            this.btnMemberMenu.Text = "    Member";
            this.btnMemberMenu.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnMemberMenu.UseVisualStyleBackColor = true;
            this.btnMemberMenu.Click += new System.EventHandler(this.btnMenu_Click);
            // 
            // btnHomeMenu
            // 
            this.btnHomeMenu.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnHomeMenu.FlatAppearance.BorderSize = 0;
            this.btnHomeMenu.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnHomeMenu.Font = new System.Drawing.Font("Comic Sans MS", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnHomeMenu.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.btnHomeMenu.Image = ((System.Drawing.Image)(resources.GetObject("btnHomeMenu.Image")));
            this.btnHomeMenu.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnHomeMenu.Location = new System.Drawing.Point(12, 61);
            this.btnHomeMenu.Name = "btnHomeMenu";
            this.btnHomeMenu.Size = new System.Drawing.Size(193, 45);
            this.btnHomeMenu.TabIndex = 0;
            this.btnHomeMenu.Text = "    Home";
            this.btnHomeMenu.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnHomeMenu.UseVisualStyleBackColor = true;
            this.btnHomeMenu.Click += new System.EventHandler(this.btnMenu_Click);
            // 
            // TitleBarPanel
            // 
            this.TitleBarPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(211)))), ((int)(((byte)(155)))), ((int)(((byte)(140)))));
            this.TitleBarPanel.Controls.Add(this.btnSlideMenu);
            this.TitleBarPanel.Controls.Add(this.btnClose);
            this.TitleBarPanel.Controls.Add(this.button1);
            this.TitleBarPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.TitleBarPanel.Location = new System.Drawing.Point(205, 0);
            this.TitleBarPanel.Name = "TitleBarPanel";
            this.TitleBarPanel.Size = new System.Drawing.Size(795, 42);
            this.TitleBarPanel.TabIndex = 1;
            // 
            // btnSlideMenu
            // 
            this.btnSlideMenu.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSlideMenu.Image = ((System.Drawing.Image)(resources.GetObject("btnSlideMenu.Image")));
            this.btnSlideMenu.Location = new System.Drawing.Point(6, 4);
            this.btnSlideMenu.Name = "btnSlideMenu";
            this.btnSlideMenu.Size = new System.Drawing.Size(32, 32);
            this.btnSlideMenu.TabIndex = 10;
            this.btnSlideMenu.TabStop = false;
            this.btnSlideMenu.Click += new System.EventHandler(this.btnSlideMenu_Click);
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
            this.btnClose.Location = new System.Drawing.Point(745, 4);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(38, 30);
            this.btnClose.TabIndex = 9;
            this.btnClose.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button1.FlatAppearance.BorderSize = 0;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Comic Sans MS", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.button1.Image = ((System.Drawing.Image)(resources.GetObject("button1.Image")));
            this.button1.Location = new System.Drawing.Point(706, 4);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(38, 30);
            this.button1.TabIndex = 8;
            this.button1.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.button1.UseVisualStyleBackColor = true;
            // 
            // fpicture
            // 
            this.fpicture.Location = new System.Drawing.Point(271, 76);
            this.fpicture.Name = "fpicture";
            this.fpicture.Size = new System.Drawing.Size(224, 242);
            this.fpicture.TabIndex = 2;
            this.fpicture.TabStop = false;
            // 
            // btnRegister
            // 
            this.btnRegister.Location = new System.Drawing.Point(501, 102);
            this.btnRegister.Name = "btnRegister";
            this.btnRegister.Size = new System.Drawing.Size(75, 23);
            this.btnRegister.TabIndex = 3;
            this.btnRegister.Text = "btnRegister";
            this.btnRegister.UseVisualStyleBackColor = true;
            this.btnRegister.Click += new System.EventHandler(this.btnRegister_Click);
            // 
            // btnVerify
            // 
            this.btnVerify.Location = new System.Drawing.Point(501, 222);
            this.btnVerify.Name = "btnVerify";
            this.btnVerify.Size = new System.Drawing.Size(75, 23);
            this.btnVerify.TabIndex = 4;
            this.btnVerify.Text = "btnVerify";
            this.btnVerify.UseVisualStyleBackColor = true;
            this.btnVerify.Click += new System.EventHandler(this.btnVerify_Click);
            // 
            // txtTemplate
            // 
            this.txtTemplate.Location = new System.Drawing.Point(501, 76);
            this.txtTemplate.Name = "txtTemplate";
            this.txtTemplate.Size = new System.Drawing.Size(287, 20);
            this.txtTemplate.TabIndex = 5;
            // 
            // prompt
            // 
            this.prompt.AutoSize = true;
            this.prompt.Location = new System.Drawing.Point(268, 324);
            this.prompt.Name = "prompt";
            this.prompt.Size = new System.Drawing.Size(35, 13);
            this.prompt.TabIndex = 6;
            this.prompt.Text = "label3";
            // 
            // deviceSerial
            // 
            this.deviceSerial.AutoSize = true;
            this.deviceSerial.Location = new System.Drawing.Point(268, 342);
            this.deviceSerial.Name = "deviceSerial";
            this.deviceSerial.Size = new System.Drawing.Size(68, 13);
            this.deviceSerial.TabIndex = 7;
            this.deviceSerial.Text = "deviceSerial ";
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(502, 195);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(231, 20);
            this.txtName.TabIndex = 8;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(611, 324);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 9;
            this.button2.Text = "button2";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1000, 600);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.deviceSerial);
            this.Controls.Add(this.prompt);
            this.Controls.Add(this.txtTemplate);
            this.Controls.Add(this.btnVerify);
            this.Controls.Add(this.btnRegister);
            this.Controls.Add(this.fpicture);
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
            ((System.ComponentModel.ISupportInitialize)(this.btnSlideMenu)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fpicture)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel MenuPanel;
        private System.Windows.Forms.Button btnHomeMenu;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnEmployeeMenu;
        private System.Windows.Forms.Button btnIncomeMenu;
        private System.Windows.Forms.Button btnPromotionMenu;
        private System.Windows.Forms.Button btnMemberMenu;
        private System.Windows.Forms.Panel currentMenuPanel;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel TitleBarPanel;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.PictureBox fpicture;
        private System.Windows.Forms.Button btnRegister;
        private System.Windows.Forms.Button btnVerify;
        private System.Windows.Forms.TextBox txtTemplate;
        private System.Windows.Forms.Label prompt;
        private System.Windows.Forms.Label deviceSerial;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.PictureBox btnSlideMenu;
    }
}

