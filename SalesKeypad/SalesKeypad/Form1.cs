using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using com.clover.remotepay.sdk;
using com.clover.remotepay.sdk.service.client;

namespace KeypadExample
{
    public partial class Form1 : Form
    {
        private readonly CloverConnectorClient clover = new CloverConnectorClient();
        private LogDatabaseManager Log = new LogDatabaseManager();

        private Timer messageTimer = new Timer();

        enum UiMode
        {
            Device,
            Sale,
            Log
        }

        public Form1()
        {
            InitializeComponent();

            // Change the "easy to see in Designer layout" settings to runtime settings
            SaleKeypadControl.BorderStyle = BorderStyle.None;
            SaleConnectionControl.BorderStyle = BorderStyle.None;
            SaleLogControl.BorderStyle = BorderStyle.None;

            Rectangle rect = new Rectangle(ClientRectangle.Left, ClientRectangle.Top, ClientRectangle.Width, LogButton.Top - ClientRectangle.Top - 6);
            SaleConnectionControl.Bounds = rect;
            SaleKeypadControl.Bounds = rect;
            SaleLogControl.Bounds = rect;

            // Set initial ui mode to the Device Connection screen
            ChangeMode(UiMode.Device);

            // Setup a "hide message" timer
            messageTimer.Tick += MessageTimer_Tick;

            FormClosed += Form1_FormClosed;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //
            // Setup the Clover Connector Device message handlers for connection state, sale, and error reporting
            //

            clover.Error += Clover_Error;
            clover.SaleComplete += Clover_SaleComplete;
            clover.PairingCode += Clover_PairingCode;
            clover.LogSale += Clover_LogSale;
            clover.ConnectionState += Clover_ConnectionState;

            // Save the base title for title manipulation
            Tag = Text;

            // Load Log data
            Log.Load();
            SaleLogControl.Log = Log.LogData;
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            Log.Save();
        }

        private void DisplayUiMessage(string message)
        {
            MessageLabel.Text = message;
            MessagePanel.Visible = true;
            MessagePanel.BringToFront();
        }

        private void ClearUiMessage()
        {
            MessagePanel.Visible = false;
            MessageLabel.Text = "";
        }

        private void MessageTimer_Tick(object sender, EventArgs e)
        {
            messageTimer.Stop();
            ClearUiMessage();
        }

        private void Clover_PairingCode(string code)
        {
            // Clover notifications happen on background threads, invoke a call on the ui thread
            // MessageBox.Show($"Enter this code on the Clover Device:\n\n{code}", "Clover Device Pairing Code", MessageBoxButtons.OK, MessageBoxIcon.Information);
            DisplayUiMessage($"Enter this code on the Clover Device\n\n{code}");
        }

        private void Clover_LogSale(long amount, DateTime date, string externalId, SaleResponse response)
        {
            // Clover notifications happen on background threads, invoke a call on the ui thread
            if (InvokeRequired)
            {
                BeginInvoke((Action<long, DateTime, string, SaleResponse>)Clover_LogSale, amount, date, externalId, response);
            }
            else
            {
                Log.AddItem(date, SaleKeypadControl.BuildDisplayString(amount.ToString()), externalId, response?.Payment?.id ?? "", response?.Success ?? false, response?.Payment?.cardTransaction?.last4 ?? "");
            }
        }

        private void Clover_ConnectionState(bool connected, bool ready)
        {
            // Clover notifications happen on background threads, invoke a call on the ui thread
            if (InvokeRequired)
            {
                BeginInvoke((Action<bool, bool>)Clover_ConnectionState, connected, ready);
            }
            else
            {
                // TODO: UI Icons for the states - Wingdings?
                Debug.WriteLine($"connected: {connected}, ready: {ready}");

                SaleConnectionControl.SetConnectionState(connected, ready);

                if (connected && !ready)
                {
                    DisplayUiMessage("Connected, initializing...");
                    Cursor = Cursors.Default;
                }
                else if (ready)
                {
                    ClearUiMessage();
                    Cursor = Cursors.Default;

                    if (!SaleConnectionControl.Visible)
                    {
                        ChangeMode(UiMode.Sale);
                    }
                }

                if (!connected && !SaleConnectionControl.Visible)
                {
                    messageTimer.Stop();
                    DisplayUiMessage("Device Disconnected");
                    messageTimer.Interval = 5000;
                    messageTimer.Start();
                }
            }
        }

        private void Clover_Error(CloverDeviceErrorEvent error)
        {
            // MessageBox.Show(error.Message + $"\n\nDetails:\n{error.ErrorType}, {error.Cause}, {error.Code}", "Clover Device Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            DisplayUiMessage(error.Message + $"\n\nDetails:\n{error.ErrorType}, {error.Cause}, {error.Code}");
        }

        /// <summary>
        /// Resize layout handler. Keep Device, Sale, and Log button proportionally sized across bottom of form
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Form1_SizeChanged(object sender, EventArgs e)
        {
            int margin = 3;
            int width = (ClientRectangle.Width - 4 * margin) / 3;

            int x = margin;
            DeviceButton.Width = width;
            DeviceButton.Left = x;
            x += width + margin;

            SaleButton.Width = width;
            SaleButton.Left = x;
            x += width + margin;

            LogButton.Width = width;
            LogButton.Left = x;
        }

        // Ui mode Button handlers
        private void DeviceButton_Click(object sender, EventArgs e) => ChangeMode(UiMode.Device);
        private void SaleButton_Click(object sender, EventArgs e) => ChangeMode(UiMode.Sale);
        private void LogButton_Click(object sender, EventArgs e) => ChangeMode(UiMode.Log);

        private void ChangeMode(UiMode mode)
        {
            SaleKeypadControl.Visible = mode == UiMode.Sale;
            SaleConnectionControl.Visible = mode == UiMode.Device;
            SaleLogControl.Visible = mode == UiMode.Log;
        }

        /// <summary>
        /// Device Connection screen raised a Connect signal
        /// </summary>
        private void SaleConnectionControl_Connect(string connectionString)
        {
            Cursor = Cursors.WaitCursor;

            DisplayUiMessage("Connecting...");
            ChangeMode(UiMode.Sale);

            if (!clover.Connect(connectionString))
            {
                Cursor = Cursors.Default;
                ClearUiMessage();
            }
        }

        /// <summary>
        /// Device Connection screen raised a Disconnect signal
        /// </summary>
        private void SaleConnectionControl_Disconnect()
        {
            ChangeMode(UiMode.Device);
            ClearUiMessage();
            clover.Disconnect();
            SaleConnectionControl.SetConnectionState(false, false);
        }

        /// <summary>
        /// Sale screen raised a Sale signal
        /// </summary>
        private void SaleKeypadControl_Sale(long amount)
        {
            // Every sale must have an amount and an external id (usable to connect the transaction to other systems like shipping, accounting, etc.)
            // For the sample application, just use a unique id based on the current time
            string externalId = $"Keypad-Sale-{DateTime.Now:yyMMdd-HHmmss.fff}";

            if (externalId.Length > 32)
            {
                externalId = externalId.Substring(0, 32);
            }

            clover.StartSale(amount, externalId);
        }

        /// <summary>
        /// Sale completed on the clover device
        /// </summary>
        /// <param name="success"></param>
        /// <param name="details"></param>
        private void Clover_SaleComplete(bool success, SaleResponse details)
        {
            // Clover notifications happen on background threads, invoke a call on the ui thread
            if (InvokeRequired)
            {
                BeginInvoke((Action<bool, SaleResponse>)Clover_SaleComplete, success, details);
            }
            else
            {
                if (success)
                {
                    SaleKeypadControl.NewSale();

                    MessageBox.Show(this, $"Sale completed {details.Result} \"{details.Reason}\"\n{details.Message}\nid = {details.Payment.id}, external id = {details.Payment.externalPaymentId}", $"Sale {(success ? "Complete" : "Failed")}", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show(this, $"Sale Completed with results: {details.Result} \"{details.Reason}\"\n{details.Message}", $"Sale Failed", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                Debug.WriteLine($"Sale completed. success={success}, message=\"{details.Message ?? ""}\"");
            }
        }
    }
}
