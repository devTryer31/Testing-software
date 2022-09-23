using System;

namespace CalculatorProj.Core
{
    public class Calculator : ICalculator
    {
        public double Divide(double a, double b)
        {
            if (Math.Abs(b) < 10e-8)
                throw new DivideByZeroException($"|b| < 10e-8, где b = {b}");

            return a / b;
        }

        public double Multiply(double a, double b)
            => a * b;

        public double Subtract(double a, double b)
            => a - b;

        public double Sum(double a, double b)
            => a + b;
    }
}
