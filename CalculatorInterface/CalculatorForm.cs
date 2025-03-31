using System;
using System.Windows.Forms;
using CalculatorLibrary;

namespace CalculatorInterface
{
    public partial class CalculatorForm : Form
    {
        private Calculator _calculator;
        private bool _isNewInput = true;
        private string _currentOperation = null;

        public CalculatorForm()
        {
            InitializeComponent();
            _calculator = new Calculator();
        }

        // Event handler for number buttons (0-9)
        private void NumberButton_Click(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            string digit = button.Text;

            if (_isNewInput)
            {
                displayTextBox.Text = digit;
                _isNewInput = false;
            }
            else
            {
                displayTextBox.Text += digit;
            }
        }

        // Event handler for operation buttons (+, -, =)
        private void OperationButton_Click(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            string operation = button.Text;

            // Try to parse the current text to a number
            if (int.TryParse(displayTextBox.Text, out int currentNumber))
            {
                if (_isNewInput && _currentOperation != null)
                {
                    // Just changing the operation
                    _currentOperation = operation;
                    return;
                }

                if (_currentOperation == null)
                {
                    // First number entered, store it and set operation
                    _calculator.Add(currentNumber);
                }
                else
                {
                    // Perform the pending operation
                    PerformOperation(currentNumber);
                }

                // If equals was pressed, clear the operation
                if (operation == "=")
                {
                    _currentOperation = null;
                }
                else
                {
                    _currentOperation = operation;
                }

                // Display result and prepare for new input
                displayTextBox.Text = _calculator.Result.ToString();
                _isNewInput = true;
            }
        }

        private void PerformOperation(int number)
        {
            switch (_currentOperation)
            {
                case "+":
                    _calculator.Add(number);
                    break;
                case "-":
                    _calculator.Subtract(number);
                    break;
                default:
                    break;
            }
        }

        // Clear button handler
        private void ClearButton_Click(object sender, EventArgs e)
        {
            displayTextBox.Text = "0";
            _calculator = new Calculator();
            _currentOperation = null;
            _isNewInput = true;
            memoryListBox.Items.Clear();
        }

        // Memory button handlers
        private void MemoryClear_Click(object sender, EventArgs e)
        {
            // Clear all memory values
            memoryListBox.Items.Clear();
            // Reset calculator (or you could add a separate method to just clear memory)
            _calculator = new Calculator();
        }

        private void MemoryStore_Click(object sender, EventArgs e)
        {
            if (int.TryParse(displayTextBox.Text, out int value))
            {
                _calculator.Store(value);
                memoryListBox.Items.Add(value.ToString());
            }
        }

        private void MemoryAdd_Click(object sender, EventArgs e)
        {
            if (memoryListBox.Items.Count > 0 && int.TryParse(displayTextBox.Text, out int value))
            {
                // Get the last memory value
                int lastIndex = memoryListBox.Items.Count - 1;
                if (int.TryParse(memoryListBox.Items[lastIndex].ToString(), out int lastValue))
                {
                    // Update the memory with new value
                    int newValue = lastValue + value;
                    memoryListBox.Items[lastIndex] = newValue.ToString();
                    // Also store in calculator memory
                    _calculator.Store(newValue);
                }
            }
            else if (int.TryParse(displayTextBox.Text, out int value))
            {
                // No memory yet, just store current value
                _calculator.Store(value);
                memoryListBox.Items.Add(value.ToString());
            }
        }

        private void MemorySubtract_Click(object sender, EventArgs e)
        {
            if (memoryListBox.Items.Count > 0 && int.TryParse(displayTextBox.Text, out int value))
            {
                // Get the last memory value
                int lastIndex = memoryListBox.Items.Count - 1;
                if (int.TryParse(memoryListBox.Items[lastIndex].ToString(), out int lastValue))
                {
                    // Update the memory with new value
                    int newValue = lastValue - value;
                    memoryListBox.Items[lastIndex] = newValue.ToString();
                    // Also store in calculator memory
                    _calculator.Store(newValue);
                }
            }
            else if (int.TryParse(displayTextBox.Text, out int value))
            {
                // No memory yet, just store negative of current value
                _calculator.Store(-value);
                memoryListBox.Items.Add((-value).ToString());
            }
        }
    }
}