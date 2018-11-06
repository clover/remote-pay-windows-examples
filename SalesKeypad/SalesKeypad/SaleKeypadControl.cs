using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KeypadExample
{
    public partial class SaleKeypadControl : UserControl
    {
        /// <summary>
        /// Initiate a sale with an amount (in pennies)
        /// </summary>
        public event Action<long> Sale;

        // the inner sale value entered (as text)
        private string _saleValue = "";

        // The sale value entered (as text), update display when changed
        public string SaleValue {
            get => _saleValue;
            set
            {
                _saleValue = value;
                UpdateSaleDisplay();
            }
        }

        // The longest string the sale "calculator" should allow
        public int MaxLength { get; set; } = 10;

        // Pixel width of the margin spacing around and between buttons
        private const int OuterMarginWidth = 6;
        private const int ButtonSpacingWidth = 6;

        public SaleKeypadControl()
        {
            InitializeComponent();
            UpdateSaleDisplay();
            Focus();
        }

        /// <summary>
        /// Layout the buttons on resize
        /// </summary>
        private void ButtonPanel_SizeChanged(object sender, EventArgs e)
        {
            // Calculate a good centered button layout assuming square buttons and 3x4 grid with minimal button spacing
            int width = (ButtonPanel.ClientRectangle.Width - 2 * OuterMarginWidth - 2 * ButtonSpacingWidth) / 3;
            int height = (ButtonPanel.ClientRectangle.Height - 2 * OuterMarginWidth - 3 * ButtonSpacingWidth) / 4;

            int buttonSize = Math.Min(width, height);
            Size size = new Size(buttonSize, buttonSize);

            int centeredXOrigin = (ButtonPanel.ClientRectangle.Width - buttonSize * 3 - ButtonSpacingWidth * 2) / 2;
            Debug.WriteLine($"centered origin {centeredXOrigin}");

            // Layout the buttons with the calculated square size, at center top of the button panel
            Keypad0Button.Size = size;
            Keypad1Button.Size = size;
            Keypad2Button.Size = size;
            Keypad3Button.Size = size;
            Keypad4Button.Size = size;
            Keypad5Button.Size = size;
            Keypad6Button.Size = size;
            Keypad7Button.Size = size;
            Keypad8Button.Size = size;
            Keypad9Button.Size = size;
            Keypad00Button.Size = size;
            KeypadBackspaceButton.Size = size;

            int x = centeredXOrigin;
            int y = OuterMarginWidth;

            Keypad7Button.Location = new Point(x, y); x += ButtonSpacingWidth + buttonSize;
            Keypad8Button.Location = new Point(x, y); x += ButtonSpacingWidth + buttonSize;
            Keypad9Button.Location = new Point(x, y);

            x = centeredXOrigin;
            y += ButtonSpacingWidth + buttonSize;

            Keypad4Button.Location = new Point(x, y); x += ButtonSpacingWidth + buttonSize;
            Keypad5Button.Location = new Point(x, y); x += ButtonSpacingWidth + buttonSize;
            Keypad6Button.Location = new Point(x, y);

            x = centeredXOrigin;
            y += ButtonSpacingWidth + buttonSize;

            Keypad1Button.Location = new Point(x, y); x += ButtonSpacingWidth + buttonSize;
            Keypad2Button.Location = new Point(x, y); x += ButtonSpacingWidth + buttonSize;
            Keypad3Button.Location = new Point(x, y);

            x = centeredXOrigin;
            y += ButtonSpacingWidth + buttonSize;

            Keypad0Button.Location = new Point(x, y); x += ButtonSpacingWidth + buttonSize;
            Keypad00Button.Location = new Point(x, y); x += ButtonSpacingWidth + buttonSize;
            KeypadBackspaceButton.Location = new Point(x, y);
        }

        /// <summary>
        /// Initate a sale when the big green sale button is clicked
        /// </summary>
        private void SaleButton_Click(object sender, EventArgs e)
        {
            InitiateSale();
        }

        /// <summary>
        /// For all the keypad keys 0..9 & 00, append the key value to the sale price
        /// </summary>
        private void KeypadButton_Click(object sender, EventArgs e)
        {
            string value = (sender as Button)?.Tag as string;
            if (!string.IsNullOrEmpty(value))
            {
                Debug.WriteLine($"Pressed {value}");
                AddDigits(value);
            }
        }

        /// <summary>
        /// For the Backspace keypad key, remove the last value of the sale price
        /// </summary>
        private void KeypadBackspaceButton_Click(object sender, EventArgs e)
        {
            Debug.WriteLine($"Pressed Backspace");
            HandleControlKey(Keys.Back);
        }

        /// <summary>
        /// Clear the sale value back to zero
        /// </summary>
        private void ClearButton_Click(object sender, EventArgs e)
        {
            Debug.WriteLine($"Pressed Clear");
            HandleControlKey(Keys.Escape);
        }

        /// <summary>
        /// Keyboard interaction for numeric digits
        /// </summary>
        private void SaleKeypadControl_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar >= '0' && e.KeyChar <= '9')
            {
                Debug.WriteLine($"Typed {e.KeyChar}");
                AddDigits(e.KeyChar.ToString());
                e.Handled = true;
            }
        }

        /// <summary>
        /// Keyboard interaction for Backspace, Esc (clear), and Enter (sale)
        /// </summary>
        private void SaleKeypadControl_KeyUp(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Back:   HandleControlKey(Keys.Back); break;
                case Keys.Escape: HandleControlKey(Keys.Escape); break;
                case Keys.Enter:  HandleControlKey(Keys.Enter); break;
            }
        }

        private void AddDigits(string value)
        {
            // If we haven't got too big a number (and allow for '00' button)
            if (SaleValue.Length < MaxLength - value.Length)
            {
                SaleValue = SaleValue + value;
                SaleValue = SaleValue.TrimStart('0');
            }
        }

        private void HandleControlKey(Keys key)
        {
            switch (key)
            {
                case Keys.Back:
                    if (SaleValue.Length > 0)
                    {
                        SaleValue = SaleValue.Substring(0, SaleValue.Length - 1);
                    }
                    break;
                case Keys.Escape:
                    SaleValue = "";
                    break;
                case Keys.Enter:
                    InitiateSale();
                    break;
            }
        }

        /// <summary>
        /// Update the Price display
        /// </summary>
        private void UpdateSaleDisplay()
        {
            string display = BuildDisplayString(SaleValue);
            Debug.WriteLine($"Displaying {display}");
            PriceDisplay.Text = display;
        }

        /// <summary>
        /// Create a display formatted string from the internal value: 100 -> $1.00
        /// </summary>
        public string BuildDisplayString(string value)
        {
            // Format string
            string display = value ?? "";

            // Make sure there are enough values to show dollars and cents
            if (display.Length <= 2)
            {
                display = new string('0', 2 - display.Length + 1) + display;
            }

            return $"${display.Substring(0, display.Length - 2)}.{display.Substring(display.Length - 2)}";
        }

        /// <summary>
        /// Initiate a sale on the Clover Device for nonzero amounts (in pennies)
        /// </summary>
        private void InitiateSale()
        {
            Debug.WriteLine($"Perform Sale for {BuildDisplayString(SaleValue)} via CloverConnector");

            if (long.TryParse(SaleValue, out long amount) && amount > 0)
            {
                Sale?.Invoke(amount);
            }
        }

        public void NewSale()
        {
            SaleValue = "";
        }
    }
}
