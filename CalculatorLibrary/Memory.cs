using System.Collections.Generic;

namespace CalculatorLibrary
{
    /// <summary>
    /// Represents a memory storage for calculator results.
    /// </summary>
    public class Memory
    {
        private List<double> _memory = new List<double>();

        /// <summary>
        /// Stores a result in memory.
        /// </summary>
        /// <param name="result">The result to store.</param>
        public void Store(double result)
        {
            _memory.Add(result);
        }

        /// <summary>
        /// Recalls a result from memory.
        /// </summary>
        /// <param name="index">The index of the result to recall.</param>
        /// <returns>The recalled result.</returns>
        public double Recall(int index)
        {
            return _memory[index];
        }
    }
}
