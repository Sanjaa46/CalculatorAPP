// Fields to track calculator state
using CalculatorLibrary;
using System;

private Calculator _calculator;
private Memory _memory;
private bool _isNewInput = true;

public CalculatorForm()
{
    InitializeComponent();
    _calculator = new Calculator();
    _memory = new Memory();
}

private void NumberButton_Click(object sender, EventArgs e)
{
    Button button = (Button)sender;
    string digit = button.Text;

    if (_isNewInput)
    {
        resultTextBox.Text = digit;
        _isNewInput = false;
    }
    else
    {
        resultTextBox.Text += digit;
    }
}

private void OperationButton_Click(object sender, EventArgs e)
{
    Button button = (Button)sender;
    string operation = button.Text;

    // Try to parse the current text to a number
    if (int.TryParse(resultTextBox.Text, out int currentNumber))
    {
        switch (operation)
        {
            case "+":
                _calculator.Add(currentNumber);
                resultTextBox.Text = _calculator.Result.ToString();
                _isNewInput = true;
                break;

            case "-":
                _calculator.Subtract(currentNumber);
                resultTextBox.Text = _calculator.Result.ToString();
                _isNewInput = true;
                break;

            case "=":
                // For equals, we'll assume previous operation is already applied
                resultTextBox.Text = _calculator.Result.ToString();
                _isNewInput = true;
                break;
        }
    }
}

private void ClearButton_Click(object sender, EventArgs e)
{
    resultTextBox.Text = "0";
    _calculator = new Calculator();
    _isNewInput = true;
}