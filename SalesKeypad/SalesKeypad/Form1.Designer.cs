namespace KeypadExample
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
            this.DeviceButton = new System.Windows.Forms.Button();
            this.SaleButton = new System.Windows.Forms.Button();
            this.LogButton = new System.Windows.Forms.Button();
            this.MessagePanel = new System.Windows.Forms.Panel();
            this.MessageLabel = new System.Windows.Forms.Label();
            this.SaleLogControl = new KeypadExample.SaleLogControl();
            this.SaleConnectionControl = new KeypadExample.SaleConnectionControl();
            this.SaleKeypadControl = new KeypadExample.SaleKeypadControl();
            this.MessagePanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // DeviceButton
            // 
            this.DeviceButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.DeviceButton.FlatAppearance.BorderSize = 0;
            this.DeviceButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(255)))));
            this.DeviceButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(230)))), ((int)(((byte)(255)))));
            this.DeviceButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.DeviceButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.DeviceButton.ForeColor = System.Drawing.Color.Gray;
            this.DeviceButton.Location = new System.Drawing.Point(12, 729);
            this.DeviceButton.Name = "DeviceButton";
            this.DeviceButton.Size = new System.Drawing.Size(111, 43);
            this.DeviceButton.TabIndex = 1;
            this.DeviceButton.Text = "Device";
            this.DeviceButton.UseVisualStyleBackColor = true;
            this.DeviceButton.Click += new System.EventHandler(this.DeviceButton_Click);
            // 
            // SaleButton
            // 
            this.SaleButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.SaleButton.FlatAppearance.BorderSize = 0;
            this.SaleButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(255)))));
            this.SaleButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(230)))), ((int)(((byte)(255)))));
            this.SaleButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.SaleButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.SaleButton.ForeColor = System.Drawing.Color.Gray;
            this.SaleButton.Location = new System.Drawing.Point(129, 729);
            this.SaleButton.Name = "SaleButton";
            this.SaleButton.Size = new System.Drawing.Size(111, 43);
            this.SaleButton.TabIndex = 1;
            this.SaleButton.Text = "Sale";
            this.SaleButton.UseVisualStyleBackColor = true;
            this.SaleButton.Click += new System.EventHandler(this.SaleButton_Click);
            // 
            // LogButton
            // 
            this.LogButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.LogButton.FlatAppearance.BorderSize = 0;
            this.LogButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(255)))));
            this.LogButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(230)))), ((int)(((byte)(255)))));
            this.LogButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.LogButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.LogButton.ForeColor = System.Drawing.Color.Gray;
            this.LogButton.Location = new System.Drawing.Point(246, 729);
            this.LogButton.Name = "LogButton";
            this.LogButton.Size = new System.Drawing.Size(111, 43);
            this.LogButton.TabIndex = 1;
            this.LogButton.Text = "Log";
            this.LogButton.UseVisualStyleBackColor = true;
            this.LogButton.Click += new System.EventHandler(this.LogButton_Click);
            // 
            // MessagePanel
            // 
            this.MessagePanel.BackColor = System.Drawing.SystemColors.Window;
            this.MessagePanel.Controls.Add(this.MessageLabel);
            this.MessagePanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MessagePanel.Location = new System.Drawing.Point(0, 0);
            this.MessagePanel.Name = "MessagePanel";
            this.MessagePanel.Padding = new System.Windows.Forms.Padding(6);
            this.MessagePanel.Size = new System.Drawing.Size(413, 771);
            this.MessagePanel.TabIndex = 0;
            this.MessagePanel.Visible = false;
            // 
            // MessageLabel
            // 
            this.MessageLabel.BackColor = System.Drawing.SystemColors.Window;
            this.MessageLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MessageLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F);
            this.MessageLabel.ForeColor = System.Drawing.Color.Gray;
            this.MessageLabel.Location = new System.Drawing.Point(6, 6);
            this.MessageLabel.Name = "MessageLabel";
            this.MessageLabel.Size = new System.Drawing.Size(401, 759);
            this.MessageLabel.TabIndex = 0;
            this.MessageLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // SaleLogControl
            // 
            this.SaleLogControl.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.SaleLogControl.BackColor = System.Drawing.Color.Yellow;
            this.SaleLogControl.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.SaleLogControl.Location = new System.Drawing.Point(12, 531);
            this.SaleLogControl.Log = null;
            this.SaleLogControl.Name = "SaleLogControl";
            this.SaleLogControl.Size = new System.Drawing.Size(389, 172);
            this.SaleLogControl.TabIndex = 3;
            // 
            // SaleConnectionControl
            // 
            this.SaleConnectionControl.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.SaleConnectionControl.BackColor = System.Drawing.SystemColors.Window;
            this.SaleConnectionControl.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.SaleConnectionControl.Location = new System.Drawing.Point(12, 377);
            this.SaleConnectionControl.Name = "SaleConnectionControl";
            this.SaleConnectionControl.Size = new System.Drawing.Size(389, 150);
            this.SaleConnectionControl.TabIndex = 2;
            this.SaleConnectionControl.Connect += new System.Action<string>(this.SaleConnectionControl_Connect);
            this.SaleConnectionControl.Disconnect += new System.Action(this.SaleConnectionControl_Disconnect);
            // 
            // SaleKeypadControl
            // 
            this.SaleKeypadControl.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.SaleKeypadControl.BackColor = System.Drawing.SystemColors.Window;
            this.SaleKeypadControl.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.SaleKeypadControl.Location = new System.Drawing.Point(12, 12);
            this.SaleKeypadControl.MaxLength = 10;
            this.SaleKeypadControl.Name = "SaleKeypadControl";
            this.SaleKeypadControl.SaleValue = "";
            this.SaleKeypadControl.Size = new System.Drawing.Size(389, 361);
            this.SaleKeypadControl.TabIndex = 0;
            this.SaleKeypadControl.Sale += new System.Action<long>(this.SaleKeypadControl_Sale);
            // 
            // Form1
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(413, 771);
            this.Controls.Add(this.SaleLogControl);
            this.Controls.Add(this.SaleConnectionControl);
            this.Controls.Add(this.LogButton);
            this.Controls.Add(this.SaleButton);
            this.Controls.Add(this.DeviceButton);
            this.Controls.Add(this.SaleKeypadControl);
            this.Controls.Add(this.MessagePanel);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(360, 650);
            this.Name = "Form1";
            this.Text = "Clover Keypad Example";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.SizeChanged += new System.EventHandler(this.Form1_SizeChanged);
            this.MessagePanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private SaleKeypadControl SaleKeypadControl;
        private System.Windows.Forms.Button DeviceButton;
        private System.Windows.Forms.Button SaleButton;
        private System.Windows.Forms.Button LogButton;
        private SaleConnectionControl SaleConnectionControl;
        private SaleLogControl SaleLogControl;
        private System.Windows.Forms.Panel MessagePanel;
        private System.Windows.Forms.Label MessageLabel;
    }
}

