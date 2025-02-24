using CalculatorLibrary;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CalculatorLibrary.Tests
{
    [TestClass]
    public class CalculatorTests
    {
        [TestMethod]
        public void Add_AddsNumberToResult()
        {
            // Arrange
            var calculator = new Calculator();
            calculator.Add(5);

            // Act
            calculator.Add(3);

            // Assert
            Assert.AreEqual(8, calculator.Result);
        }

        [TestMethod]
        public void Subtract_SubtractsNumberFromResult()
        {
            // Arrange
            var calculator = new Calculator();
            calculator.Add(5);

            // Act
            calculator.Subtract(3);

            // Assert
            Assert.AreEqual(2, calculator.Result);
        }
    }
}
