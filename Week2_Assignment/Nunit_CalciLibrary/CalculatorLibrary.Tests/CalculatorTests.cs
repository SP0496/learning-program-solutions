using NUnit.Framework;
using CalculatorLibrary;
using System;

namespace CalculatorLibrary.Tests
{
    [TestFixture]
    public class CalculatorUnitTests
    {
        private BasicCalculator calc;

        [SetUp]
        public void Setup()
        {
            calc = new BasicCalculator();
        }

        [TearDown]
        public void Teardown()
        {
            calc.Reset();
        }

        [TestCase(2, 3, 5)]
        [TestCase(-1, 1, 0)]
        [TestCase(0, 0, 0)]
        public void Add_ShouldReturnCorrectResult(double a, double b, double expected)
        {
            var actual = calc.Add(a, b);
            Assert.AreEqual(expected, actual);
        }

        [TestCase(10, 4, 6)]
        [TestCase(0, 0, 0)]
        public void Subtract_ShouldReturnCorrectResult(double a, double b, double expected)
        {
            Assert.AreEqual(expected, calc.Subtract(a, b));
        }

        [TestCase(3, 3, 9)]
        [TestCase(-2, 2, -4)]
        public void Multiply_ShouldReturnCorrectResult(double a, double b, double expected)
        {
            Assert.AreEqual(expected, calc.Multiply(a, b));
        }

        [TestCase(9, 3, 3)]
        [TestCase(1, -1, -1)]
        public void Divide_ShouldReturnCorrectResult(double a, double b, double expected)
        {
            Assert.AreEqual(expected, calc.Divide(a, b));
        }

        [Test]
        public void Divide_ByZero_ThrowsException()
        {
            Assert.Throws<InvalidOperationException>(() => calc.Divide(4, 0));
        }

        [Test]
        public void Result_ShouldHoldLastOperationResult()
        {
            calc.Add(1, 2);
            Assert.AreEqual(3, calc.Result);
        }

        [Test]
        public void Reset_ShouldClearResult()
        {
            calc.Multiply(5, 5);
            calc.Reset();
            Assert.AreEqual(0, calc.Result);
        }
    }
}
