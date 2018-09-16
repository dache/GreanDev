namespace ExclusiveGym.WinForms.UserControls
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
            this.ReportTabpage.Controls.Add(this.dailyTab);
            this.ReportTabpage.Controls.Add(this.monthlyTab);
            this.ReportTabpage.Controls.Add(this.yearTab);
            this.ReportTabpage.Location = new System.Drawing.Point(0, 3);
            this.ReportTabpage.Name = "ReportTabpage";
            this.ReportTabpage.SelectedIndex = 0;
            this.ReportTabpage.Size = new System.Drawing.Size(797, 577);
            this.ReportTabpage.TabIndex = 1;
            // 
            // dailyTab
            // 
            this.dailyTab.Controls.Add(this.dailyDatePicker);
            this.dailyTab.Controls.Add(this.dailyView);
            this.dailyTab.Controls.Add(this.dailySumPriceLabel);
            this.dailyTab.Controls.Add(this.dailyDataView);
            this.dailyTab.Controls.Add(this.label2);
            this.dailyTab.Location = new System.Drawing.Point(4, 22);
            this.dailyTab.Name = "dailyTab";
            this.dailyTab.Padding = new System.Windows.Forms.Padding(3);
            this.dailyTab.Size = new System.Drawing.Size(789, 551);
            this.dailyTab.TabIndex = 0;
            this.dailyTab.Text = "รายวัน";
            this.dailyTab.UseVisualStyleBackColor = true;
            // 
            // dailyDatePicker
            // 
            this.dailyDatePicker.CustomFormat = "dd-MMM-yyyy";
            this.dailyDatePicker.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.749999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dailyDatePicker.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dailyDatePicker.Location = new System.Drawing.Point(288, 34);
            this.dailyDatePicker.Name = "dailyDatePicker";
            this.dailyDatePicker.Size = new System.Drawing.Size(120, 22);
            this.dailyDatePicker.TabIndex = 29;
            // 
            // dailyView
            // 
            this.dailyView.Location = new System.Drawing.Point(604, 13);
            this.dailyView.Name = "dailyView";
            this.dailyView.Size = new System.Drawing.Size(138, 57);
            this.dailyView.TabIndex = 20;
            this.dailyView.Text = "ดูรายงาน";
            this.dailyView.UseVisualStyleBackColor = true;
            this.dailyView.Click += new System.EventHandler(this.dailyView_Click);
            // 
            // dailySumPriceLabel
            // 
            this.dailySumPriceLabel.AutoSize = true;
            this.dailySumPriceLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dailySumPriceLabel.ForeColor = System.Drawing.Color.DimGray;
            this.dailySumPriceLabel.Location = new System.Drawing.Point(285, 507);
            this.dailySumPriceLabel.Name = "dailySumPriceLabel";
            this.dailySumPriceLabel.Size = new System.Drawing.Size(129, 18);
            this.dailySumPriceLabel.TabIndex = 19;
            this.dailySumPriceLabel.Text = "รายได้รวม  : {0} บาท";
            // 
            // dailyDataView
            // 
            this.dailyDataView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dailyDataView.Location = new System.Drawing.Point(29, 76);
            this.dailyDataView.Name = "dailyDataView";
            this.dailyDataView.Size = new System.Drawing.Size(713, 409);
            this.dailyDataView.TabIndex = 18;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.DimGray;
            this.label2.Location = new System.Drawing.Point(47, 34);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(84, 18);
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
            this.monthlyTab.Location = new System.Drawing.Point(4, 22);
            this.monthlyTab.Name = "monthlyTab";
            this.monthlyTab.Padding = new System.Windows.Forms.Padding(3);
            this.monthlyTab.Size = new System.Drawing.Size(789, 551);
            this.monthlyTab.TabIndex = 1;
            this.monthlyTab.Text = "รายเดือน";
            this.monthlyTab.UseVisualStyleBackColor = true;
            // 
            // monthDateTimePicker
            // 
            this.monthDateTimePicker.CustomFormat = "MMM-yyyy";
            this.monthDateTimePicker.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.749999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.monthDateTimePicker.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.monthDateTimePicker.Location = new System.Drawing.Point(299, 34);
            this.monthDateTimePicker.Name = "monthDateTimePicker";
            this.monthDateTimePicker.Size = new System.Drawing.Size(120, 22);
            this.monthDateTimePicker.TabIndex = 31;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.DimGray;
            this.label1.Location = new System.Drawing.Point(58, 34);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(97, 18);
            this.label1.TabIndex = 30;
            this.label1.Text = "กรุณาเลือกเดือน";
            // 
            // monthlyView
            // 
            this.monthlyView.Location = new System.Drawing.Point(615, 9);
            this.monthlyView.Name = "monthlyView";
            this.monthlyView.Size = new System.Drawing.Size(138, 57);
            this.monthlyView.TabIndex = 28;
            this.monthlyView.Text = "ดูรายงาน";
            this.monthlyView.UseVisualStyleBackColor = true;
            this.monthlyView.Click += new System.EventHandler(this.monthlyView_Click);
            // 
            // monthlySumPriceLabel
            // 
            this.monthlySumPriceLabel.AutoSize = true;
            this.monthlySumPriceLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.monthlySumPriceLabel.ForeColor = System.Drawing.Color.DimGray;
            this.monthlySumPriceLabel.Location = new System.Drawing.Point(296, 503);
            this.monthlySumPriceLabel.Name = "monthlySumPriceLabel";
            this.monthlySumPriceLabel.Size = new System.Drawing.Size(129, 18);
            this.monthlySumPriceLabel.TabIndex = 27;
            this.monthlySumPriceLabel.Text = "รายได้รวม  : {0} บาท";
            // 
            // montDataView
            // 
            this.montDataView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.montDataView.Location = new System.Drawing.Point(40, 72);
            this.montDataView.Name = "montDataView";
            this.montDataView.Size = new System.Drawing.Size(713, 409);
            this.montDataView.TabIndex = 26;
            // 
            // yearTab
            // 
            this.yearTab.Controls.Add(this.yearDateTimePicker);
            this.yearTab.Controls.Add(this.label3);
            this.yearTab.Controls.Add(this.yearView);
            this.yearTab.Controls.Add(this.yearSumPriceLabel);
            this.yearTab.Controls.Add(this.yearDataView);
            this.yearTab.Location = new System.Drawing.Point(4, 22);
            this.yearTab.Name = "yearTab";
            this.yearTab.Padding = new System.Windows.Forms.Padding(3);
            this.yearTab.Size = new System.Drawing.Size(789, 551);
            this.yearTab.TabIndex = 2;
            this.yearTab.Text = "รายปี";
            this.yearTab.UseVisualStyleBackColor = true;
            // 
            // yearDateTimePicker
            // 
            this.yearDateTimePicker.CustomFormat = "yyyy";
            this.yearDateTimePicker.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.749999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.yearDateTimePicker.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.yearDateTimePicker.Location = new System.Drawing.Point(288, 24);
            this.yearDateTimePicker.Name = "yearDateTimePicker";
            this.yearDateTimePicker.Size = new System.Drawing.Size(120, 22);
            this.yearDateTimePicker.TabIndex = 31;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.DimGray;
            this.label3.Location = new System.Drawing.Point(47, 24);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(77, 18);
            this.label3.TabIndex = 30;
            this.label3.Text = "กรุณาเลือกปี";
            // 
            // yearView
            // 
            this.yearView.Location = new System.Drawing.Point(615, 9);
            this.yearView.Name = "yearView";
            this.yearView.Size = new System.Drawing.Size(138, 57);
            this.yearView.TabIndex = 28;
            this.yearView.Text = "ดูรายงาน";
            this.yearView.UseVisualStyleBackColor = true;
            this.yearView.Click += new System.EventHandler(this.yearView_Click);
            // 
            // yearSumPriceLabel
            // 
            this.yearSumPriceLabel.AutoSize = true;
            this.yearSumPriceLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.yearSumPriceLabel.ForeColor = System.Drawing.Color.DimGray;
            this.yearSumPriceLabel.Location = new System.Drawing.Point(296, 503);
            this.yearSumPriceLabel.Name = "yearSumPriceLabel";
            this.yearSumPriceLabel.Size = new System.Drawing.Size(129, 18);
            this.yearSumPriceLabel.TabIndex = 27;
            this.yearSumPriceLabel.Text = "รายได้รวม  : {0} บาท";
            // 
            // yearDataView
            // 
            this.yearDataView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.yearDataView.Location = new System.Drawing.Point(40, 72);
            this.yearDataView.Name = "yearDataView";
            this.yearDataView.Size = new System.Drawing.Size(713, 409);
            this.yearDataView.TabIndex = 26;
            // 
            // ReportControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.ReportTabpage);
            this.Name = "ReportControl";
            this.Size = new System.Drawing.Size(800, 580);
            this.ReportTabpage.ResumeLayout(false);
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
    }
}
