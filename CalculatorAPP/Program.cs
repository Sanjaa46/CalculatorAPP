using System;
using CalculatorLibrary;

namespace CalculatorApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Calculator calc = new Calculator();
            Memory memory = new Memory();

            calc.Add(10);
            Console.WriteLine($"Result after adding 10: {calc.Result}");

            calc.Subtract(3);
            Console.WriteLine($"Result after subtracting 3: {calc.Result}");

            memory.Store(calc.Result);
            Console.WriteLine("Stored result in memory.");

            double recalled = memory.Recall(0);
            Console.WriteLine($"Recalled from memory: {recalled}");
        }
    }
}
