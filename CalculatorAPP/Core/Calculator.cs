using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CalculatorApp.Models;
using CalculatorApp.Interfaces;

namespace CalculatorApp.Core
{
    public class Calculator : CalculatorBase, ICalculations
    {
        public void Add(double number)
        {
            Result += number;
        }

        public void Subtract(double number)
        {
            Result -= number;
        }
    }
}

