using System;

namespace CalculatorLibrary
{
    public interface ICalculator
    {
        double Add(double x, double y);
        double Subtract(double x, double y);
        double Multiply(double x, double y);
        double Divide(double x, double y);
    }

    public class BasicCalculator : ICalculator
    {
        private double _lastResult;

        public double Add(double x, double y)
        {
            _lastResult = x + y;
            return _lastResult;
        }

        public double Subtract(double x, double y)
        {
            _lastResult = x - y;
            return _lastResult;
        }

        public double Multiply(double x, double y)
        {
            _lastResult = x * y;
            return _lastResult;
        }

        public double Divide(double x, double y)
        {
            if (y == 0)
                throw new InvalidOperationException("Cannot divide by zero.");
            _lastResult = x / y;
            return _lastResult;
        }

        public void Reset()
        {
            _lastResult = 0;
        }

        public double Result => _lastResult;
    }
}
