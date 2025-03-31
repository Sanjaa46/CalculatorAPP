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

            Console.WriteLine("Simple Calculator Application");
            Console.WriteLine("----------------------------");

            while (continueCalculation)
            {
                Console.WriteLine("\nCurrent Result: " + calc.Result);
                Console.WriteLine("\nChoose an operation:");
                Console.WriteLine("1. Add");
                Console.WriteLine("2. Subtract");
                Console.WriteLine("3. Store result in memory");
                Console.WriteLine("4. Recall result from memory");
                Console.WriteLine("5. Show all memory values");
                Console.WriteLine("6. Clear result");
                Console.WriteLine("7. Exit");
                Console.Write("Enter your choice: ");

                // Handle invalid input more gracefully
                if (!int.TryParse(Console.ReadLine(), out int choice))
                {
                    Console.WriteLine("Invalid input. Please enter a number.");
                    continue;
                }

                try
                {
                    switch (choice)
                    {
                        case 1:
                            Console.Write("Enter a number to add: ");
                            if (double.TryParse(Console.ReadLine(), out double addValue))
                            {
                                calc.Add(addValue);
                                Console.WriteLine($"Result after adding {addValue}: {calc.Result}");
                            }
                            else
                            {
                                Console.WriteLine("Invalid number. Operation cancelled.");
                            }
                            break;

                        case 2:
                            Console.Write("Enter a number to subtract: ");
                            if (double.TryParse(Console.ReadLine(), out double subtractValue))
                            {
                                calc.Subtract(subtractValue);
                                Console.WriteLine($"Result after subtracting {subtractValue}: {calc.Result}");
                            }
                            else
                            {
                                Console.WriteLine("Invalid number. Operation cancelled.");
                            }
                            break;

                        case 3:
                            calc.Store(calc.Result);
                            Console.WriteLine($"Value {calc.Result} stored in memory.");
                            break;

                        case 4:
                            Console.Write("Enter memory index to recall (0 for the first value stored): ");
                            if (int.TryParse(Console.ReadLine(), out int index))
                            {
                                try
                                {
                                    double recalled = calc.Recall(index);
                                    Console.WriteLine($"Recalled from memory at index {index}: {recalled}");
                                }
                                catch (ArgumentOutOfRangeException)
                                {
                                    Console.WriteLine("Invalid memory index. No value at that position.");
                                }
                            }
                            else
                            {
                                Console.WriteLine("Invalid index. Operation cancelled.");
                            }
                            break;

                        case 5:
                            // New option to show all memory values
                            try
                            {
                                Console.WriteLine("Memory values:");
                                int count = 0;
                                while (true)
                                {
                                    try
                                    {
                                        double value = calc.Recall(count);
                                        Console.WriteLine($"  [{count}]: {value}");
                                        count++;
                                    }
                                    catch
                                    {
                                        break;
                                    }
                                }

                                if (count == 0)
                                {
                                    Console.WriteLine("  (Memory is empty)");
                                }
                            }
                            catch (Exception ex)
                            {
                                Console.WriteLine($"Error retrieving memory values: {ex.Message}");
                            }
                            break;

                        case 6:
                            // New option to clear the result
                            calc = new Calculator();
                            Console.WriteLine("Result cleared.");
                            break;

                        case 7:
                            continueCalculation = false;
                            Console.WriteLine("Exiting calculator. Goodbye!");
                            break;

                        default:
                            Console.WriteLine("Invalid choice. Please try again.");
                            break;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"An error occurred: {ex.Message}");
                }
            }
        }
    }
}