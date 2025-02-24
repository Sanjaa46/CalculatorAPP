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
            Result += number;
        }

        /// <summary>
        /// Subtracts a number from the result.
        /// </summary>
        /// <param name="number">The number to subtract.</param>
        public void Subtract(double number)
        {
            Result -= number;
        }
    }

    /// <summary>
    /// Abstract class for a calculator. Stores calculation results.
    /// </summary>
    public abstract class CalculatorBase
    {
        /// <summary>
        /// Stores the result of calculations.
        /// </summary>
        public double Result { get; set; }
    }

    /// <summary>
    /// Interface for basic calculations.
    /// </summary>
    public interface ICalculations
    {
        /// <summary>
        /// Adds a number to the result.
        /// </summary>
        /// <param name="number">The number to add.</param>
        void Add(double number);

        /// <summary>
        /// Subtracts a number from the result.
        /// </summary>
        /// <param name="number">The number to subtract.</param>
        void Subtract(double number);
    }
}
