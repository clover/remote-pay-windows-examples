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
    public partial class SaleLogControl : UserControl
    {
        public DataTable Log { get { return LogView.DataSource as DataTable; } set { LogView.DataSource = null; LogView.DataSource = value; } }
        public SaleLogControl()
        {
            InitializeComponent();
        }
    }
}
