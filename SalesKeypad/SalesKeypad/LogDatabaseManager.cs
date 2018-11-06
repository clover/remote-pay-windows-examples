using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KeypadExample
{
    /// <summary>
    /// A real Point of Sale application will need to handle historical information appropriately, naturally.
    /// This sample application just keeps a little local xml file of recent transactions to display in the Log UI
    /// It will keep the last few sales and throw away sale data once the list gets too old or long
    /// </summary>
    class LogDatabaseManager
    {
        public DataTable LogData { get; set; }

        public LogDatabaseManager()
        {
            CreateTable();
        }

        public void Load(string filename = "payment-log.xml")
        {
            try
            {
                string filepath = Path.Combine(Environment.CurrentDirectory, filename);
                if (File.Exists(filepath))
                {
                    LogData.DataSet.ReadXml(filepath);
                    TrimData();
                }
            }
            catch (Exception exception)
            {
                Debug.WriteLine("Error reading payment-log file:\n" + exception.ToString());
            }
        }

        public void Save(string filename = "payment-log.xml")
        {
            try
            {
                string filepath = Path.Combine(Environment.CurrentDirectory, filename);
                TrimData();
                LogData.DataSet.WriteXml(filepath, XmlWriteMode.WriteSchema);
            }
            catch (Exception exception)
            {
                Debug.WriteLine("Error writing payment-log file:\n" + exception.ToString());
            }
        }

        public void CreateTable()
        {
            LogData = new DataTable();
            new DataSet().Tables.Add(LogData);

            LogData.Columns.Add("Date", typeof(DateTime));
            LogData.Columns.Add("Amount", typeof(string));
            LogData.Columns.Add("ExternalId", typeof(string));
            LogData.Columns.Add("PaymentId", typeof(string));
            LogData.Columns.Add("Success", typeof(bool));
            LogData.Columns.Add("LastFour", typeof(string));
        }

        public void AddItem( DateTime date, string amount, string externalId, string paymentId, bool success, string lastFour)
        {
            LogData.Rows.Add(date, amount, externalId, paymentId, success, lastFour);
            TrimData();
        }

        public void TrimData()
        {
            while (LogData.Rows.Count > 20)
            {
                LogData.Rows.RemoveAt(0);
            }
        }
    }
}
