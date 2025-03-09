using System;

namespace CalculatorLibrary
{
    /// <summary>
    /// A simple calculator that performs addition and subtraction.
    /// </summary>
    public class Calculator : CalculatorBase, ICalculations
    {
        /// <summary>
        /// Adds a number to the result.
        /// </summary>
        /// <param name="number">The number to add.</param>
        public void Add(double number)
        {
            this.Result += number;
        }

        /// <summary>
        /// Subtracts a number from the result.
        /// </summary>
        /// <param name="number">The number to subtract.</param>
        public void Subtract(double number)
        {
            this.Result -= number;
        }
    }
}
