using System;
using CalculatorLibrary;

namespace CalculatorApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Calculator calc = new Calculator();
            bool continueCalculation = true;

            while (continueCalculation)
            {
                Console.WriteLine("Choose an operation:");
                Console.WriteLine("1. Add");
                Console.WriteLine("2. Subtract");
                Console.WriteLine("3. Store result in memory");
                Console.WriteLine("4. Recall result from memory");
                Console.WriteLine("5. Exit");
                Console.Write("Enter your choice: ");
                int choice = Convert.ToInt32(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                        Console.Write("Enter a number to add: ");
                        double addValue = Convert.ToDouble(Console.ReadLine());
                        calc.Add(addValue);
                        Console.WriteLine($"Result after adding {addValue}: {calc.Result}");
                        break;

                    case 2:
                        Console.Write("Enter a number to subtract: ");
                        double subtractValue = Convert.ToDouble(Console.ReadLine());
                        calc.Subtract(subtractValue);
                        Console.WriteLine($"Result after subtracting {subtractValue}: {calc.Result}");
                        break;

                    case 3:
                        calc.Store(calc.Result);
                        Console.WriteLine("Stored result in memory.");
                        break;

                    case 4:
                        Console.Write("Enter memory index to recall: ");
                        int index = Convert.ToInt32(Console.ReadLine());
                        double recalled = calc.Recall(index);
                        Console.WriteLine($"Recalled from memory: {recalled}");
                        break;

                    case 5:
                        continueCalculation = false;
                        break;

                    default:
                        Console.WriteLine("Invalid choice. Please try again.");
                        break;
                }
            }
        }
    }
}
