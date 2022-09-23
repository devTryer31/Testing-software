using CalculatorProj.Core;

namespace CalculatorProj.Tests.CalculatorTests
{
    public class DivisionTests
    {
        private static readonly ICalculator _calculator = new Calculator();

        [Theory] //Equivalence class: positive integers numbers.
        [InlineData(5d, 64d, 5 * 64d)] //1
        [InlineData(10d, 10e-5d, 10d * 10e-5d)] //2.1
        [InlineData(11e-5d, 23d, 11e-5d * 23d)] //2.2
        [InlineData(14e-5d, 10e-23d, 14e-5d * 10e-23d)] //2.3
        [InlineData(1d, 5e10d, 1d * 5e10d)]//3.1
        [InlineData(15e10d, 5d, 15e10d * 5d)]//3.2
        [InlineData(15e10d, 5e15d, 15e10d * 5e15d)]//3.3
        public void WithPositiveIntegers(double a, double b, double res)
        {
            Assert.Equal(res, _calculator.Multiply(a, b));
        }

        [Theory] //Equivalence class: negative integers numbers.
        [InlineData(-51d, -64d, -51 * -64d)] //1.1
        [InlineData(5d, -677d, 5 * -677d)] //1.2
        [InlineData(-123d, -677d, -123 * -677d)] //1.3
        [InlineData(-11d, -124e-5d, -11d * -124e-5d)] //2.1.1
        [InlineData(111d, -1241e-5d, 111d * -1241e-5d)] //2.1.2
        [InlineData(-101d, 124e-5d, -101d * 124e-5d)] //2.1.3
        [InlineData(-66e-5d, -23d, -66e-5d * -23d)] //2.2.1
        [InlineData(8e-5d, -23d, 8e-5d * -23d)] //2.2.2
        [InlineData(-10001e-5d, 23d, -10001e-5d * 23d)] //2.2.3
        [InlineData(-1d, -5e10d, -1d * -5e10d)]//3.1.1
        [InlineData(1d, -5e10d, 1d * -5e10d)]//3.1.2
        [InlineData(-1d, 5e10d, -1d * 5e10d)]//3.1.3
        [InlineData(-15e10d, -5d, -15e10d * -5d)]//3.2.1
        [InlineData(15e10d, -5d, 15e10d * -5d)]//3.2.2
        [InlineData(-15e10d, 5d, -15e10d * 5d)]//3.2.3
        [InlineData(-15e10d, -5e15d, -15e10d * -5e15d)]//3.3.1
        [InlineData(-15e10d, 5e15d, -15e10d * 5e15d)]//3.3.2
        [InlineData(15e10d, -5e15d, 15e10d * -5e15d)]//3.3.3
        public void WithNegativeIntegers(double a, double b, double res)
        {
            Assert.Equal(res, _calculator.Multiply(a, b));
        }

        [Theory] //Equivalence class: real positive/negative numbers.
        [InlineData(0d, 0d, 0d)]
        [InlineData(65.32d, 0d, 0d)]
        [InlineData(0.032d, 888.65d, 0.032d * 888.65d)]
        [InlineData(1e-32d, 1e32d, 1e-32d * 1e32d)]
        [InlineData(double.PositiveInfinity, 1e32d, double.PositiveInfinity * 1e32d)]
        [InlineData(double.NegativeInfinity, 1e32d, double.NegativeInfinity * 1e32d)]
        public void WithRealNumbers(double a, double b, double res)
        {
            Assert.Equal(_calculator.Multiply(a, b), res);
        }

        private readonly Random _gen = new();

        [Fact]
        public void RandomTest()
        {
            foreach (double p in new[] {
                1e1, 1e2, 1e3, 1e4, 1e5, 1e6, 1e7, 1e8, 1e9, 1e10, 1e100, 1e200,
                1e-1, 1e-2, 1e-3, 1e-4, 1e-5, 1e-6, 1e-7, 1e-8, 1e-9, 1e-10, 1e-100, 1e-200 })
            {
                for (int i = 0; i < 3_000; ++i)
                {
                    double a = GenerateRandom(p);
                    double b = GenerateRandom(p);

                    if(Math.Abs(b) < 10e-8)
                        Assert.Throws<DivideByZeroException>(() => _calculator.Divide(a,b));
                    else
                        Assert.Equal(a / b, _calculator.Divide(a, b));
                }
            }

            double GenerateRandom(double powTerm = 1)
            {
                return powTerm * (_gen.Next() % 2 == 0 ? -1 : 1) * (_gen.NextDouble() * (_gen.Next() - _gen.Next()) + _gen.Next());
            }
        }

        [Theory]
        [InlineData(12d, 10e-9)]
        [InlineData(10e-100d, 10e-9)]
        [InlineData(0d, -10e-9)]
        [InlineData(12d, 10e-19)]
        [InlineData(895d, 10e-100)]
        [InlineData(12d, -10e-100)]
        public void ThrowExceptionTest(double a, double b)
        {
            Assert.Throws<DivideByZeroException>(() => _calculator.Divide(a, b));
        }
    }
}
