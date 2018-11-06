namespace KeypadExample
{
    partial class SaleConnectionControl
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
            this.ConnectButton = new System.Windows.Forms.Button();
            this.UsbConnectionRadio = new System.Windows.Forms.RadioButton();
            this.LanConnectionRadio = new System.Windows.Forms.RadioButton();
            this.DisconnectButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // ConnectButton
            // 
            this.ConnectButton.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ConnectButton.BackColor = System.Drawing.Color.LimeGreen;
            this.ConnectButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F);
            this.ConnectButton.Location = new System.Drawing.Point(3, 3);
            this.ConnectButton.Name = "ConnectButton";
            this.ConnectButton.Size = new System.Drawing.Size(483, 130);
            this.ConnectButton.TabIndex = 0;
            this.ConnectButton.Text = "Connect";
            this.ConnectButton.UseVisualStyleBackColor = false;
            this.ConnectButton.Click += new System.EventHandler(this.ConnectButton_Click);
            // 
            // UsbConnectionRadio
            // 
            this.UsbConnectionRadio.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.UsbConnectionRadio.Appearance = System.Windows.Forms.Appearance.Button;
            this.UsbConnectionRadio.Checked = true;
            this.UsbConnectionRadio.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F);
            this.UsbConnectionRadio.Location = new System.Drawing.Point(46, 212);
            this.UsbConnectionRadio.Name = "UsbConnectionRadio";
            this.UsbConnectionRadio.Padding = new System.Windows.Forms.Padding(10, 20, 10, 20);
            this.UsbConnectionRadio.Size = new System.Drawing.Size(396, 122);
            this.UsbConnectionRadio.TabIndex = 1;
            this.UsbConnectionRadio.TabStop = true;
            this.UsbConnectionRadio.Text = "USB";
            this.UsbConnectionRadio.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.UsbConnectionRadio.UseVisualStyleBackColor = true;
            // 
            // LanConnectionRadio
            // 
            this.LanConnectionRadio.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.LanConnectionRadio.Appearance = System.Windows.Forms.Appearance.Button;
            this.LanConnectionRadio.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F);
            this.LanConnectionRadio.Location = new System.Drawing.Point(46, 376);
            this.LanConnectionRadio.Name = "LanConnectionRadio";
            this.LanConnectionRadio.Padding = new System.Windows.Forms.Padding(10, 20, 10, 20);
            this.LanConnectionRadio.Size = new System.Drawing.Size(396, 122);
            this.LanConnectionRadio.TabIndex = 1;
            this.LanConnectionRadio.Text = "Network";
            this.LanConnectionRadio.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.LanConnectionRadio.UseVisualStyleBackColor = true;
            this.LanConnectionRadio.Visible = false;
            // 
            // DisconnectButton
            // 
            this.DisconnectButton.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.DisconnectButton.BackColor = System.Drawing.Color.OrangeRed;
            this.DisconnectButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F);
            this.DisconnectButton.Location = new System.Drawing.Point(3, 3);
            this.DisconnectButton.Name = "DisconnectButton";
            this.DisconnectButton.Size = new System.Drawing.Size(483, 130);
            this.DisconnectButton.TabIndex = 2;
            this.DisconnectButton.Text = "Disconnect";
            this.DisconnectButton.UseVisualStyleBackColor = false;
            this.DisconnectButton.Visible = false;
            this.DisconnectButton.Click += new System.EventHandler(this.DisconnectButton_Click);
            // 
            // SaleConnectionControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.Controls.Add(this.LanConnectionRadio);
            this.Controls.Add(this.UsbConnectionRadio);
            this.Controls.Add(this.ConnectButton);
            this.Controls.Add(this.DisconnectButton);
            this.Name = "SaleConnectionControl";
            this.Size = new System.Drawing.Size(489, 642);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button ConnectButton;
        private System.Windows.Forms.RadioButton UsbConnectionRadio;
        private System.Windows.Forms.RadioButton LanConnectionRadio;
        private System.Windows.Forms.Button DisconnectButton;
    }
}
