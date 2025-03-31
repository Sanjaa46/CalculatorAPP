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
            displayTextBox.Text = "0";
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
                if (_isNewInput && _currentOperation != null && operation != "=")
                {
                    // Just changing the operation without a new number
                    _currentOperation = operation;
                    statusLabel.Text = $"Operation changed to {operation}";
                    return;
                }

                if (_currentOperation == null)
                {
                    // First number entered, store it and set operation
                    _calculator.Add(currentNumber);
                    statusLabel.Text = $"Added {currentNumber}";
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
                    statusLabel.Text = "Calculation complete";
                }
                else
                {
                    _currentOperation = operation;
                    statusLabel.Text = $"Operation set to {operation}";
                }

                // Display result and prepare for new input
                displayTextBox.Text = _calculator.Result.ToString();
                _isNewInput = true;
            }
            else
            {
                // Invalid number
                statusLabel.Text = "Please enter a valid number";
            }
        }

        private void PerformOperation(int number)
        {
            switch (_currentOperation)
            {
                case "+":
                    _calculator.Add(number);
                    statusLabel.Text = $"Added {number}";
                    break;
                case "-":
                    _calculator.Subtract(number);
                    statusLabel.Text = $"Subtracted {number}";
                    break;
                default:
                    statusLabel.Text = "Unknown operation";
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
            statusLabel.Text = "Calculator cleared";
        }

        // Memory button handlers
        private void MemoryClear_Click(object sender, EventArgs e)
        {
            // Clear all memory values
            memoryListBox.Items.Clear();
            // Reset calculator (or you could add a separate method to just clear memory)
            _calculator = new Calculator();
            statusLabel.Text = "Memory cleared";
        }

        private void MemoryStore_Click(object sender, EventArgs e)
        {
            if (int.TryParse(displayTextBox.Text, out int storedValue))
            {
                _calculator.Store(storedValue);
                memoryListBox.Items.Add(storedValue.ToString());
                statusLabel.Text = $"Stored {storedValue} in memory";
            }
            else
            {
                statusLabel.Text = "Cannot store: Invalid number";
            }
        }

        private void MemoryAdd_Click(object sender, EventArgs e)
        {
            if (!int.TryParse(displayTextBox.Text, out int addedValue))
            {
                statusLabel.Text = "Cannot add to memory: Invalid number";
                return;
            }

            if (memoryListBox.Items.Count > 0)
            {
                // Get the last memory value
                int lastIndex = memoryListBox.Items.Count - 1;
                if (int.TryParse(memoryListBox.Items[lastIndex].ToString(), out int lastValue))
                {
                    // Create a new memory entry instead of modifying the last one
                    int newValue = lastValue + addedValue;
                    memoryListBox.Items.Add(newValue.ToString());
                    _calculator.Store(newValue);
                    statusLabel.Text = $"Added {addedValue} to memory: {newValue}";
                }
                else
                {
                    statusLabel.Text = "Error reading memory value";
                }
            }
            else
            {
                // No memory yet, just store current value
                _calculator.Store(addedValue);
                memoryListBox.Items.Add(addedValue.ToString());
                statusLabel.Text = $"Stored {addedValue} in memory";
            }
        }

        private void MemorySubtract_Click(object sender, EventArgs e)
        {
            if (!int.TryParse(displayTextBox.Text, out int subtractedValue))
            {
                statusLabel.Text = "Cannot subtract from memory: Invalid number";
                return;
            }

            if (memoryListBox.Items.Count > 0)
            {
                // Get the last memory value
                int lastIndex = memoryListBox.Items.Count - 1;
                if (int.TryParse(memoryListBox.Items[lastIndex].ToString(), out int lastValue))
                {
                    // Create a new memory entry instead of modifying the last one
                    int newValue = lastValue - subtractedValue;
                    memoryListBox.Items.Add(newValue.ToString());
                    _calculator.Store(newValue);
                    statusLabel.Text = $"Subtracted {subtractedValue} from memory: {newValue}";
                }
                else
                {
                    statusLabel.Text = "Error reading memory value";
                }
            }
            else
            {
                // No memory yet, just store negative of current value
                _calculator.Store(-subtractedValue);
                memoryListBox.Items.Add((-subtractedValue).ToString());
                statusLabel.Text = $"Stored {-subtractedValue} in memory";
            }
        }

        // Added method to recall memory values
        private void MemoryListBox_DoubleClick(object sender, EventArgs e)
        {
            if (memoryListBox.SelectedIndex >= 0)
            {
                if (int.TryParse(memoryListBox.SelectedItem.ToString(), out int selectedValue))
                {
                    displayTextBox.Text = selectedValue.ToString();
                    _isNewInput = false;
                    statusLabel.Text = $"Recalled {selectedValue} from memory";
                }
                else
                {
                    statusLabel.Text = "Error recalling memory value";
                }
            }
        }
    }
}