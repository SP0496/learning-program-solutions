using System;

namespace ForecastApp
{
    // Class to handle forecasting logic
    class GrowthPredictor
    {
        // Basic recursive method to calculate forecast
        public double CalculateRecursive(double amount, double rate, int time)
        {
            if (time == 0)
                return amount;

            return CalculateRecursive(amount, rate, time - 1) * (1 + rate);
        }

        // Optimized recursive method using memoization
        public double CalculateWithMemory(double amount, double rate, int time, double[] saved)
        {
            if (time == 0)
                return amount;

            if (saved[time] != 0)
                return saved[time];

            saved[time] = CalculateWithMemory(amount, rate, time - 1, saved) * (1 + rate);
            return saved[time];
        }
    }

    class ForecastRunner
    {
        static void Main(string[] args)
        {
            double initialAmount = 1200.0;
            double yearlyRate = 0.06;
            int forecastYears = 8;

            GrowthPredictor predictor = new GrowthPredictor();

            // Using simple recursion
            double resultRecursive = predictor.CalculateRecursive(initialAmount, yearlyRate, forecastYears);
            Console.WriteLine("Forecast (Recursive): " + resultRecursive.ToString("F2"));

            // Using optimized recursion
            double[] cache = new double[forecastYears + 1];
            double resultMemo = predictor.CalculateWithMemory(initialAmount, yearlyRate, forecastYears, cache);
            Console.WriteLine("Forecast (Memoized): " + resultMemo.ToString("F2"));
        }
    }
}
