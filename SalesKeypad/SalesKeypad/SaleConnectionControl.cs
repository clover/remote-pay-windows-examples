using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KeypadExample
{
    public partial class SaleConnectionControl : UserControl
    {
        public event Action<string> Connect;
        public event Action Disconnect;

        public SaleConnectionControl()
        {
            InitializeComponent();
        }

        /// <summary>
        /// When the big green connect button is clicked, resolve the connection string and raise the Connect event
        /// </summary>
        private void ConnectButton_Click(object sender, EventArgs e)
        {
            string connectionString = "";

            if (UsbConnectionRadio.Checked)
            {
                connectionString = "USB";
            }

            if (!string.IsNullOrEmpty(connectionString))
            {
                Connect?.Invoke(connectionString);
            }
        }

        /// <summary>
        /// When the big red disconnect button is clicked, raise the Connect event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DisconnectButton_Click(object sender, EventArgs e)
        {
            Disconnect?.Invoke();
        }

        public void SetConnectionState(bool connected, bool ready)
        {
            ConnectButton.Visible = !connected;
            DisconnectButton.Visible = connected;
        }

    }
}
