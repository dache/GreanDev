namespace ExclusiveGym.WinForms.UserControls
{
    partial class PaymentControl
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            this.gvPayments = new System.Windows.Forms.DataGridView();
            this.label29 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.gvPayments)).BeginInit();
            this.SuspendLayout();
            // 
            // gvPayments
            // 
            this.gvPayments.AllowUserToAddRows = false;
            this.gvPayments.AllowUserToDeleteRows = false;
            this.gvPayments.AllowUserToResizeColumns = false;
            this.gvPayments.AllowUserToResizeRows = false;
            this.gvPayments.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.gvPayments.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Prompt", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gvPayments.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.gvPayments.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Prompt", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle5.Padding = new System.Windows.Forms.Padding(2);
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.gvPayments.DefaultCellStyle = dataGridViewCellStyle5;
            this.gvPayments.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.gvPayments.Location = new System.Drawing.Point(30, 56);
            this.gvPayments.MultiSelect = false;
            this.gvPayments.Name = "gvPayments";
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Prompt", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle6.Padding = new System.Windows.Forms.Padding(2);
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gvPayments.RowHeadersDefaultCellStyle = dataGridViewCellStyle6;
            this.gvPayments.RowHeadersVisible = false;
            this.gvPayments.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToDisplayedHeaders;
            this.gvPayments.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gvPayments.Size = new System.Drawing.Size(852, 548);
            this.gvPayments.TabIndex = 0;
            this.gvPayments.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.gvPayments_CellClick);
            // 
            // label29
            // 
            this.label29.AutoSize = true;
            this.label29.Font = new System.Drawing.Font("Prompt", 18F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label29.ForeColor = System.Drawing.Color.DimGray;
            this.label29.Location = new System.Drawing.Point(14, 14);
            this.label29.Name = "label29";
            this.label29.Size = new System.Drawing.Size(198, 36);
            this.label29.TabIndex = 13;
            this.label29.Text = "ประวัติการชำระเงิน";
            // 
            // PaymentControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.label29);
            this.Controls.Add(this.gvPayments);
            this.Name = "PaymentControl";
            this.Size = new System.Drawing.Size(917, 630);
            ((System.ComponentModel.ISupportInitialize)(this.gvPayments)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView gvPayments;
        private System.Windows.Forms.Label label29;
    }
}
