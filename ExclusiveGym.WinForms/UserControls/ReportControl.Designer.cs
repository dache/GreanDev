﻿namespace ExclusiveGym.WinForms.UserControls
{
    partial class ReportControl
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
            this.ReportTabpage = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.label4 = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.dailyTab = new System.Windows.Forms.TabPage();
            this.dailyDatePicker = new System.Windows.Forms.DateTimePicker();
            this.dailyView = new System.Windows.Forms.Button();
            this.dailySumPriceLabel = new System.Windows.Forms.Label();
            this.dailyDataView = new System.Windows.Forms.DataGridView();
            this.label2 = new System.Windows.Forms.Label();
            this.monthlyTab = new System.Windows.Forms.TabPage();
            this.monthDateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.monthlyView = new System.Windows.Forms.Button();
            this.monthlySumPriceLabel = new System.Windows.Forms.Label();
            this.montDataView = new System.Windows.Forms.DataGridView();
            this.yearTab = new System.Windows.Forms.TabPage();
            this.yearDateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.yearView = new System.Windows.Forms.Button();
            this.yearSumPriceLabel = new System.Windows.Forms.Label();
            this.yearDataView = new System.Windows.Forms.DataGridView();
            this.ReportTabpage.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.dailyTab.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dailyDataView)).BeginInit();
            this.monthlyTab.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.montDataView)).BeginInit();
            this.yearTab.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.yearDataView)).BeginInit();
            this.SuspendLayout();
            // 
            // ReportTabpage
            // 
            this.ReportTabpage.Controls.Add(this.tabPage1);
            this.ReportTabpage.Controls.Add(this.dailyTab);
            this.ReportTabpage.Controls.Add(this.monthlyTab);
            this.ReportTabpage.Controls.Add(this.yearTab);
            this.ReportTabpage.Font = new System.Drawing.Font("Prompt", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ReportTabpage.Location = new System.Drawing.Point(0, 3);
            this.ReportTabpage.Name = "ReportTabpage";
            this.ReportTabpage.SelectedIndex = 0;
            this.ReportTabpage.Size = new System.Drawing.Size(914, 624);
            this.ReportTabpage.TabIndex = 1;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.label4);
            this.tabPage1.Controls.Add(this.dataGridView1);
            this.tabPage1.Location = new System.Drawing.Point(4, 33);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(906, 587);
            this.tabPage1.TabIndex = 3;
            this.tabPage1.Text = "ทั้งหมด";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            this.label4.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.label4.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label4.Font = new System.Drawing.Font("Prompt", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.DimGray;
            this.label4.Location = new System.Drawing.Point(3, 555);
            this.label4.Name = "label4";
            this.label4.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label4.Size = new System.Drawing.Size(900, 29);
            this.label4.TabIndex = 21;
            this.label4.Text = "รายได้รวม  : {0} บาท";
            this.label4.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AllowUserToResizeColumns = false;
            this.dataGridView1.BackgroundColor = System.Drawing.SystemColors.ActiveCaption;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dataGridView1.Location = new System.Drawing.Point(16, 43);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.Size = new System.Drawing.Size(871, 468);
            this.dataGridView1.TabIndex = 20;
            // 
            // dailyTab
            // 
            this.dailyTab.Controls.Add(this.dailyDatePicker);
            this.dailyTab.Controls.Add(this.dailyView);
            this.dailyTab.Controls.Add(this.dailySumPriceLabel);
            this.dailyTab.Controls.Add(this.dailyDataView);
            this.dailyTab.Controls.Add(this.label2);
            this.dailyTab.Location = new System.Drawing.Point(4, 33);
            this.dailyTab.Name = "dailyTab";
            this.dailyTab.Padding = new System.Windows.Forms.Padding(3);
            this.dailyTab.Size = new System.Drawing.Size(906, 587);
            this.dailyTab.TabIndex = 0;
            this.dailyTab.Text = "รายวัน";
            this.dailyTab.UseVisualStyleBackColor = true;
            // 
            // dailyDatePicker
            // 
            this.dailyDatePicker.CustomFormat = "dd-MMM-yyyy";
            this.dailyDatePicker.Font = new System.Drawing.Font("Prompt", 9.749999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dailyDatePicker.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dailyDatePicker.Location = new System.Drawing.Point(126, 12);
            this.dailyDatePicker.Name = "dailyDatePicker";
            this.dailyDatePicker.Size = new System.Drawing.Size(144, 27);
            this.dailyDatePicker.TabIndex = 29;
            this.dailyDatePicker.ValueChanged += new System.EventHandler(this.dailyDatePicker_ValueChanged);
            // 
            // dailyView
            // 
            this.dailyView.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(122)))), ((int)(((byte)(183)))));
            this.dailyView.FlatAppearance.BorderSize = 0;
            this.dailyView.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.dailyView.Font = new System.Drawing.Font("Prompt", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dailyView.ForeColor = System.Drawing.Color.White;
            this.dailyView.Location = new System.Drawing.Point(289, 11);
            this.dailyView.Name = "dailyView";
            this.dailyView.Size = new System.Drawing.Size(120, 35);
            this.dailyView.TabIndex = 20;
            this.dailyView.Text = "ดูรายงาน";
            this.dailyView.UseVisualStyleBackColor = false;
            this.dailyView.Click += new System.EventHandler(this.dailyView_Click);
            // 
            // dailySumPriceLabel
            // 
            this.dailySumPriceLabel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.dailySumPriceLabel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.dailySumPriceLabel.Font = new System.Drawing.Font("Prompt", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dailySumPriceLabel.ForeColor = System.Drawing.Color.DimGray;
            this.dailySumPriceLabel.Location = new System.Drawing.Point(3, 555);
            this.dailySumPriceLabel.Name = "dailySumPriceLabel";
            this.dailySumPriceLabel.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.dailySumPriceLabel.Size = new System.Drawing.Size(900, 29);
            this.dailySumPriceLabel.TabIndex = 19;
            this.dailySumPriceLabel.Text = "รายได้รวม  : {0} บาท";
            this.dailySumPriceLabel.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // dailyDataView
            // 
            this.dailyDataView.AllowUserToAddRows = false;
            this.dailyDataView.AllowUserToDeleteRows = false;
            this.dailyDataView.AllowUserToResizeColumns = false;
            this.dailyDataView.BackgroundColor = System.Drawing.SystemColors.ActiveCaption;
            this.dailyDataView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dailyDataView.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dailyDataView.Location = new System.Drawing.Point(19, 52);
            this.dailyDataView.Name = "dailyDataView";
            this.dailyDataView.RowHeadersVisible = false;
            this.dailyDataView.Size = new System.Drawing.Size(871, 468);
            this.dailyDataView.TabIndex = 18;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Prompt", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.DimGray;
            this.label2.Location = new System.Drawing.Point(15, 15);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(105, 24);
            this.label2.TabIndex = 13;
            this.label2.Text = "กรุณาเลือกวัน";
            // 
            // monthlyTab
            // 
            this.monthlyTab.Controls.Add(this.monthDateTimePicker);
            this.monthlyTab.Controls.Add(this.label1);
            this.monthlyTab.Controls.Add(this.monthlyView);
            this.monthlyTab.Controls.Add(this.monthlySumPriceLabel);
            this.monthlyTab.Controls.Add(this.montDataView);
            this.monthlyTab.Location = new System.Drawing.Point(4, 33);
            this.monthlyTab.Name = "monthlyTab";
            this.monthlyTab.Padding = new System.Windows.Forms.Padding(3);
            this.monthlyTab.Size = new System.Drawing.Size(906, 587);
            this.monthlyTab.TabIndex = 1;
            this.monthlyTab.Text = "รายเดือน";
            this.monthlyTab.UseVisualStyleBackColor = true;
            // 
            // monthDateTimePicker
            // 
            this.monthDateTimePicker.CustomFormat = "MMM-yyyy";
            this.monthDateTimePicker.Font = new System.Drawing.Font("Prompt", 9.749999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.monthDateTimePicker.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.monthDateTimePicker.Location = new System.Drawing.Point(144, 12);
            this.monthDateTimePicker.Name = "monthDateTimePicker";
            this.monthDateTimePicker.Size = new System.Drawing.Size(120, 27);
            this.monthDateTimePicker.TabIndex = 31;
            this.monthDateTimePicker.ValueChanged += new System.EventHandler(this.monthDateTimePicker_ValueChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Prompt", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.DimGray;
            this.label1.Location = new System.Drawing.Point(15, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(122, 24);
            this.label1.TabIndex = 30;
            this.label1.Text = "กรุณาเลือกเดือน";
            // 
            // monthlyView
            // 
            this.monthlyView.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(122)))), ((int)(((byte)(183)))));
            this.monthlyView.FlatAppearance.BorderSize = 0;
            this.monthlyView.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.monthlyView.ForeColor = System.Drawing.Color.White;
            this.monthlyView.Location = new System.Drawing.Point(289, 11);
            this.monthlyView.Name = "monthlyView";
            this.monthlyView.Size = new System.Drawing.Size(120, 35);
            this.monthlyView.TabIndex = 28;
            this.monthlyView.Text = "ดูรายงาน";
            this.monthlyView.UseVisualStyleBackColor = false;
            this.monthlyView.Click += new System.EventHandler(this.monthlyView_Click);
            // 
            // monthlySumPriceLabel
            // 
            this.monthlySumPriceLabel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.monthlySumPriceLabel.Font = new System.Drawing.Font("Prompt", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.monthlySumPriceLabel.ForeColor = System.Drawing.Color.DimGray;
            this.monthlySumPriceLabel.Location = new System.Drawing.Point(3, 555);
            this.monthlySumPriceLabel.Name = "monthlySumPriceLabel";
            this.monthlySumPriceLabel.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.monthlySumPriceLabel.Size = new System.Drawing.Size(900, 29);
            this.monthlySumPriceLabel.TabIndex = 27;
            this.monthlySumPriceLabel.Text = "รายได้รวม  : {0} บาท";
            this.monthlySumPriceLabel.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // montDataView
            // 
            this.montDataView.BackgroundColor = System.Drawing.SystemColors.ActiveCaption;
            this.montDataView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.montDataView.Location = new System.Drawing.Point(19, 52);
            this.montDataView.Name = "montDataView";
            this.montDataView.Size = new System.Drawing.Size(871, 468);
            this.montDataView.TabIndex = 26;
            // 
            // yearTab
            // 
            this.yearTab.Controls.Add(this.yearDateTimePicker);
            this.yearTab.Controls.Add(this.label3);
            this.yearTab.Controls.Add(this.yearView);
            this.yearTab.Controls.Add(this.yearSumPriceLabel);
            this.yearTab.Controls.Add(this.yearDataView);
            this.yearTab.Location = new System.Drawing.Point(4, 33);
            this.yearTab.Name = "yearTab";
            this.yearTab.Padding = new System.Windows.Forms.Padding(3);
            this.yearTab.Size = new System.Drawing.Size(906, 587);
            this.yearTab.TabIndex = 2;
            this.yearTab.Text = "รายปี";
            this.yearTab.UseVisualStyleBackColor = true;
            // 
            // yearDateTimePicker
            // 
            this.yearDateTimePicker.CustomFormat = "yyyy";
            this.yearDateTimePicker.Font = new System.Drawing.Font("Prompt", 9.749999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.yearDateTimePicker.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.yearDateTimePicker.Location = new System.Drawing.Point(117, 12);
            this.yearDateTimePicker.Name = "yearDateTimePicker";
            this.yearDateTimePicker.Size = new System.Drawing.Size(71, 27);
            this.yearDateTimePicker.TabIndex = 31;
            this.yearDateTimePicker.ValueChanged += new System.EventHandler(this.yearDateTimePicker_ValueChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Prompt", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.DimGray;
            this.label3.Location = new System.Drawing.Point(15, 15);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(96, 24);
            this.label3.TabIndex = 30;
            this.label3.Text = "กรุณาเลือกปี";
            // 
            // yearView
            // 
            this.yearView.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(122)))), ((int)(((byte)(183)))));
            this.yearView.FlatAppearance.BorderSize = 0;
            this.yearView.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.yearView.ForeColor = System.Drawing.Color.White;
            this.yearView.Location = new System.Drawing.Point(289, 11);
            this.yearView.Name = "yearView";
            this.yearView.Size = new System.Drawing.Size(120, 35);
            this.yearView.TabIndex = 28;
            this.yearView.Text = "ดูรายงาน";
            this.yearView.UseVisualStyleBackColor = false;
            this.yearView.Click += new System.EventHandler(this.yearView_Click);
            // 
            // yearSumPriceLabel
            // 
            this.yearSumPriceLabel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.yearSumPriceLabel.Font = new System.Drawing.Font("Prompt", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.yearSumPriceLabel.ForeColor = System.Drawing.Color.DimGray;
            this.yearSumPriceLabel.Location = new System.Drawing.Point(3, 555);
            this.yearSumPriceLabel.Name = "yearSumPriceLabel";
            this.yearSumPriceLabel.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.yearSumPriceLabel.Size = new System.Drawing.Size(900, 29);
            this.yearSumPriceLabel.TabIndex = 27;
            this.yearSumPriceLabel.Text = "รายได้รวม  : {0} บาท";
            this.yearSumPriceLabel.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // yearDataView
            // 
            this.yearDataView.BackgroundColor = System.Drawing.SystemColors.ActiveCaption;
            this.yearDataView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.yearDataView.Location = new System.Drawing.Point(19, 52);
            this.yearDataView.Name = "yearDataView";
            this.yearDataView.Size = new System.Drawing.Size(871, 468);
            this.yearDataView.TabIndex = 26;
            // 
            // ReportControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.ReportTabpage);
            this.Name = "ReportControl";
            this.Size = new System.Drawing.Size(917, 630);
            this.Load += new System.EventHandler(this.ReportControl_Load);
            this.ReportTabpage.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.dailyTab.ResumeLayout(false);
            this.dailyTab.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dailyDataView)).EndInit();
            this.monthlyTab.ResumeLayout(false);
            this.monthlyTab.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.montDataView)).EndInit();
            this.yearTab.ResumeLayout(false);
            this.yearTab.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.yearDataView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl ReportTabpage;
        private System.Windows.Forms.TabPage dailyTab;
        private System.Windows.Forms.TabPage monthlyTab;
        private System.Windows.Forms.TabPage yearTab;
        private System.Windows.Forms.DataGridView dailyDataView;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label dailySumPriceLabel;
        private System.Windows.Forms.Label monthlySumPriceLabel;
        private System.Windows.Forms.DataGridView montDataView;
        private System.Windows.Forms.Label yearSumPriceLabel;
        private System.Windows.Forms.DataGridView yearDataView;
        private System.Windows.Forms.Button dailyView;
        private System.Windows.Forms.Button monthlyView;
        private System.Windows.Forms.Button yearView;
        private System.Windows.Forms.DateTimePicker dailyDatePicker;
        private System.Windows.Forms.DateTimePicker monthDateTimePicker;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker yearDateTimePicker;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DataGridView dataGridView1;
    }
}
