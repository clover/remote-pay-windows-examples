using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using com.clover.remotepay.sdk;
using com.clover.remotepay.transport;

namespace KeypadExample
{
    class CloverConnectorClient
    {
        #region Define Application and Merchant Details

        public string RemoteAppId { get; set; } = "Clover.com RemoteAppId";
        public string PosName { get; set; } = "CloverSdk KeypadExample";
        public string SerialNumber { get; set; } = "1";

        #endregion

        #region Communicate Clover Signals to App UI

        public event LogSaleHandler LogSale;
        public event SaleCompleteHandler SaleComplete;
        public event PairingCodeHandler PairingCode;
        public event ConnectionChangedHandler ConnectionState;
        public event ErrorHandler Error;

        // Delegates for above events
        public delegate void LogSaleHandler(long amount, DateTime date, string externalId, SaleResponse response);
        public delegate void SaleCompleteHandler(bool success, SaleResponse details);
        public delegate void PairingCodeHandler(string code);
        public delegate void ConnectionChangedHandler(bool connected, bool ready);
        public delegate void ErrorHandler(CloverDeviceErrorEvent error);

        #endregion


        #region Connect with Clover Device

        public bool DeviceConnected { get; set; }
        public bool DeviceReady { get; set; }

        public MerchantInfo MerchantInfo { get; private set; }

        private ICloverConnector cloverConnector;
        private SimpleCloverConnectorListener listener;
        private string Address { get; set; }

        /// <summary>
        /// Connect to the specified Clover device
        /// </summary>
        public bool Connect(string connectionString)
        {
            CloverDeviceConfiguration config = null;
            Address = connectionString;

            if (connectionString.Trim().ToUpper() == "USB")
            {
                // USB connected Clover Devices are directly connected to the machine and so don't need any extra identification or Pairing information
                config = new USBCloverDeviceConfiguration(RemoteAppId, true);
                Address = "USB";
            }
            else
            {
                // Network connections require a pairing information and send extra identification to the device
                config = new WebSocketCloverDeviceConfiguration(connectionString, RemoteAppId, true, 1, PosName, SerialNumber, LoadPairingAuthToken(connectionString, RemoteAppId, PosName), OnPairingCode, OnPairingSuccess, OnPairingState);
            }

            if (config != null)
            {
                cloverConnector = CloverConnectorFactory.createICloverConnector(config);

                listener = new SimpleCloverConnectorListener(cloverConnector);
                listener.DeviceConnected += Listener_DeviceConnected;
                listener.DeviceReady += Listener_DeviceReady;
                listener.DeviceDisconnected += Listener_DeviceDisconnected;
                listener.DeviceError += Listener_DeviceError;
                listener.SaleResponse += Listener_SaleResponse;

                cloverConnector.AddCloverConnectorListener(listener);
                cloverConnector.InitializeConnection();
            }

            return config != null;
        }

        /// <summary>
        /// Disconnect from a device
        /// Note: USB devices can only be connected to once per process in the current CloverConnector SDK.
        /// </summary>
        public void Disconnect()
        {
            if (cloverConnector != null)
            {
                cloverConnector.RemoveCloverConnectorListener(listener);
                cloverConnector.ResetDevice();

                cloverConnector = null;
            }
        }

        private void Listener_DeviceConnected()
        {
            DeviceConnected = true;
            DeviceReady = false;
            MerchantInfo = null;
            ConnectionState?.Invoke(DeviceConnected, DeviceReady);
        }

        private void Listener_DeviceReady(MerchantInfo merchantInfo)
        {
            DeviceConnected = true;
            DeviceReady = true;
            MerchantInfo = merchantInfo;
            ConnectionState?.Invoke(DeviceConnected, DeviceReady);
        }

        private void Listener_DeviceDisconnected()
        {
            DeviceConnected = false;
            DeviceReady = false;
            MerchantInfo = null;
            ConnectionState?.Invoke(DeviceConnected, DeviceReady);
        }

        private void Listener_DeviceError(CloverDeviceErrorEvent error)
        {
            Error?.Invoke(error);
        }

        private void Listener_SaleResponse(SaleResponse response)
        {
            SaleComplete?.Invoke(response.Success, response);

            if (response.Success)
            {
                LogSale?.Invoke(response.Payment.amount, DateTime.Now, response.Payment.externalPaymentId, response);
            }
        }

        /// <summary>
        /// The device needs to pair with the POS to confirm proper security and configuration.
        /// If a previously established authToken was sent to the device, this step will be skipped.
        /// (Until the token expires and a new pairing exchange occurrs.)
        /// Not all connection types require paring. For example, a USB direct connection does not send pairing messages.
        /// </summary>
        void OnPairingCode(string code)
        {
            PairingCode?.Invoke(code);

            // Some fallback code if PairingCode event isn't being handled - not necessary but makes the sample more robust
            if (PairingCode == null)
            {
                System.Windows.Forms.MessageBox.Show($"Enter this pairing code on the Clover Device to confirm the computer and device have identified each other correctly.\n\n\t Pairing Code:  {code}", "Clover Device Network Pairing", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Information);
            }
        }

        /// <summary>
        /// Device received pairing code and sends an authToken the POS can use to avoid pairing in future connections.
        /// (Until the token expires and a new pairing exchange occurrs.)
        /// </summary>
        void OnPairingSuccess(string authToken)
        {
            SavePairingAuthToken(Address, RemoteAppId, PosName, authToken);
        }

        /// <summary>
        /// Device is transitioning to pairing states, like Pin Code Required before pairing
        /// (Only is called for some devices and configurations)
        /// </summary>
        /// <param name="state"></param>
        /// <param name="message"></param>
        void OnPairingState(string state, string message)
        {
        }

        /// <summary>
        /// Load the previous network pairing auth token from storage.
        /// Storage could be anything, for convenience in the Keypad Example use the registry.
        /// If the auth token is empty (or has expired or is invalid), the device will simply redisplay the pairing screen
        /// </summary>
        private static string LoadPairingAuthToken(string address, string remoteAppId, string posName)
        {
            return Microsoft.Win32.Registry.GetValue($"HKEY_CURRENT_USER\\Software\\{posName}\\{remoteAppId}\\{address}\\Pairing Tokens", "authToken", "") as string ?? "";
        }

        /// <summary>
        /// Save the current network pairing auth token to storage
        /// Storage could be anything, for convenience in the Keypad Example use the registry
        /// In future connections if the token isn't sent to the device, the device will simply redisplay the pairing screen.
        /// Note: The token will eventually expire to require devices to be periodically paired with computers. This is configurable on the device.
        /// </summary>
        private static void SavePairingAuthToken(string address, string remoteAppId, string posName, string authToken)
        {
            Microsoft.Win32.Registry.GetValue($"HKEY_CURRENT_USER\\Software\\{posName}\\{remoteAppId}\\{address}\\Pairing Tokens", "authToken", authToken);
        }

        #endregion

        #region Perform a Sale on the Clover Device (succeeds or fails)

        public void StartSale(long amount, string externalId)
        {
            //
            // Set up a Clover SDK SALE
            //

            // Build a Sale Request sdk object
            SaleRequest sale = new SaleRequest();
            sale.Amount = amount;
            sale.ExternalId = externalId;

            // Initiate Sale on the Device
            cloverConnector.Sale(sale);

            // Now wait to get messages from the Clover Device through the SDK Listener to find out what happened, success or failure
        }

        #endregion

        #region Local Clover SDK Results Events Listener code

        /// <summary>
        /// SimpleCloverConnectorListener is a simple way to route SDK response messages to the Keypad Example application.
        /// It builds on the DefaultCloverConnectorListener provided in the SDK to avoid implementing a full ICloverConnectorListener with empty code in this example application.
        /// 
        /// The Clover listener transmits async messages out of the Clover SDK from the Clover Device, and is made for you to adapt into your own architecture. Your ICloverConnectorListener
        /// maybe be part of one of your business objects, may fire events or messages, may be a UI object like the Clover SDK Example POS project, or may fit in your architecture in a completely 
        /// different way dependant only on how you wish to receive and process Clover device messages.
        /// </summary>
        class SimpleCloverConnectorListener : DefaultCloverConnectorListener
        {
            private readonly ICloverConnector cloverConnector;

            #region Events

            // For the purpose of this sample App, we care about and monitor these five messages: Connected, Ready, Disconnected; SaleResponse; and Error.

            public event Action DeviceConnected;
            public event Action<MerchantInfo> DeviceReady;
            public event Action DeviceDisconnected;
            public event Action<SaleResponse> SaleResponse;
            public event Action<CloverDeviceErrorEvent> DeviceError;

            #endregion

            public SimpleCloverConnectorListener(ICloverConnector cloverConnector) : base(cloverConnector)
            {
                this.cloverConnector = cloverConnector;
            }

            //
            // Messages from Clover SDK to route through to the Keypad Example classes
            //

            public override void OnDeviceReady(MerchantInfo merchantInfo) => DeviceReady?.Invoke(merchantInfo);
            public override void OnDeviceConnected() => DeviceConnected?.Invoke();
            public override void OnDeviceDisconnected() => DeviceDisconnected?.Invoke();
            public override void OnSaleResponse(SaleResponse response) => SaleResponse?.Invoke(response);
            public override void OnDeviceError(CloverDeviceErrorEvent deviceErrorEvent) => DeviceError?.Invoke(deviceErrorEvent);

            #region Payment Acceptance messages

            /// <summary>
            /// Handle OnConfirmPaymentRequest to decide whether an otherwise valid payment from the user should be accepted or rejected:
            ///   For example: The payment may be a duplicate payment
            ///                The payment device may have lost connection with the payment server and be in offline mode (store process payments later)
            /// 
            /// Here is where business logic like "accept payments under $10 even if offline, but reject larger payments" can be called.
            /// Or the Point of Sale application may propmt the user/cashier in some circumstances.
            /// This allows a business to manage their risk of nonpayment and return - some payment processing and banking agreements handle
            /// fraud responsibility differently in some of these circumstances.
            ///               
            /// </summary>
            public override void OnConfirmPaymentRequest(ConfirmPaymentRequest request)
            {
                // For simplicity in this sample, accept all payments (Duplicate and Offline)
                cloverConnector.AcceptPayment(request.Payment);
            }

            /// <summary>
            /// Handle the request to verify the signature is acceptable to the user/cashier
            /// Best case this involves comparing the signature to the card.
            /// 
            /// Here is where business logic like "payments over $100 must compare user signature to signature on card"
            /// or "verify card and customer picture ID" can be called.
            /// The request object contains signature line and point data to draw the signature on the POS screen for comparison
            /// with the customer's signature, for example.
            /// </summary>
            public override void OnVerifySignatureRequest(VerifySignatureRequest request)
            {
                // For simplicity in this sample, accept all signatures immediately
                request.Accept();
            }
            #endregion
        }

        #endregion
    }
}
