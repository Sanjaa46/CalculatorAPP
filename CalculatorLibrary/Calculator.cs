using System;
using System.Collections.Generic;

namespace CalculatorLibrary
{
    /// <summary>
    /// A simple calculator that performs addition and subtraction, and includes memory storage.
    /// </summary>
    public class Calculator : CalculatorBase, ICalculations
    {
        private List<double> _memoryList = new List<double>();

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

        /// <summary>
        /// Stores a result in memory.
        /// </summary>
        /// <param name="result">The result to store.</param>
        public void Store(double result)
        {
            _memoryList.Add(result);
        }

        /// <summary>
        /// Recalls a result from memory.
        /// </summary>
        /// <param name="index">The index of the result to recall.</param>
        /// <returns>The recalled result.</returns>
        public double Recall(int index)
        {
            if (index < 0 || index >= _memoryList.Count)
            {
                throw new ArgumentOutOfRangeException(nameof(index), "Index must be within the bounds of the memory list.");
            }
            return _memoryList[index];
        }

    }
}
