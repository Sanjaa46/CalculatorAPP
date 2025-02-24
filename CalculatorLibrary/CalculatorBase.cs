using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalculatorLibrary
{
    /// <summary>
    /// Abstract class for a calculator. Stores calculation results.
    /// </summary>
    public abstract class CalculatorBase
    {
        /// <summary>
        /// Stores the result of calculations.
        /// </summary>
        public double Result { get; protected set; }
    }
}


