namespace KeypadExample
{
    partial class SaleLogControl
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
            this.TitleLabel = new System.Windows.Forms.Label();
            this.TotalLabel = new System.Windows.Forms.Label();
            this.LogView = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.LogView)).BeginInit();
            this.SuspendLayout();
            // 
            // TitleLabel
            // 
            this.TitleLabel.BackColor = System.Drawing.SystemColors.Window;
            this.TitleLabel.Dock = System.Windows.Forms.DockStyle.Top;
            this.TitleLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F);
            this.TitleLabel.Location = new System.Drawing.Point(0, 0);
            this.TitleLabel.Name = "TitleLabel";
            this.TitleLabel.Size = new System.Drawing.Size(591, 72);
            this.TitleLabel.TabIndex = 0;
            this.TitleLabel.Text = "Log";
            this.TitleLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // TotalLabel
            // 
            this.TotalLabel.BackColor = System.Drawing.SystemColors.Window;
            this.TotalLabel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.TotalLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F);
            this.TotalLabel.Location = new System.Drawing.Point(0, 641);
            this.TotalLabel.Name = "TotalLabel";
            this.TotalLabel.Size = new System.Drawing.Size(591, 72);
            this.TotalLabel.TabIndex = 2;
            this.TotalLabel.Text = "$0.00 Total";
            this.TotalLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // LogView
            // 
            this.LogView.AllowUserToAddRows = false;
            this.LogView.AllowUserToDeleteRows = false;
            this.LogView.AllowUserToOrderColumns = true;
            this.LogView.AllowUserToResizeRows = false;
            this.LogView.BackgroundColor = System.Drawing.SystemColors.Window;
            this.LogView.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.LogView.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.EnableWithoutHeaderText;
            this.LogView.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.LogView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.LogView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LogView.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.LogView.EnableHeadersVisualStyles = false;
            this.LogView.Location = new System.Drawing.Point(0, 72);
            this.LogView.MultiSelect = false;
            this.LogView.Name = "LogView";
            this.LogView.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.LogView.RowHeadersVisible = false;
            this.LogView.RowTemplate.Height = 24;
            this.LogView.ShowCellErrors = false;
            this.LogView.ShowCellToolTips = false;
            this.LogView.ShowEditingIcon = false;
            this.LogView.ShowRowErrors = false;
            this.LogView.Size = new System.Drawing.Size(591, 569);
            this.LogView.TabIndex = 3;
            // 
            // SaleLogControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.LogView);
            this.Controls.Add(this.TitleLabel);
            this.Controls.Add(this.TotalLabel);
            this.Name = "SaleLogControl";
            this.Size = new System.Drawing.Size(591, 713);
            ((System.ComponentModel.ISupportInitialize)(this.LogView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label TitleLabel;
        private System.Windows.Forms.Label TotalLabel;
        private System.Windows.Forms.DataGridView LogView;
    }
}
