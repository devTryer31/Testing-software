namespace CalculatorProj.Tests.CalculatorTests.Base
{
    public abstract class OperationTestsBase
    {
        protected OperationDelegate OperationToTest { get; }

        protected delegate double OperationDelegate(double a, double b);

        protected abstract double ApplyOperationCorrectly(double a, double b);

        protected OperationTestsBase(OperationDelegate operationToTest)
        {
            OperationToTest = operationToTest;
        }

        [Theory] //Equivalence class: positive integers numbers.
        [InlineData(5d, 64d)] //1
        [InlineData(10d, 10e-5d)] //2.1
        [InlineData(11e-5d, 23d)] //2.2
        [InlineData(14e-5d, 10e-23d)] //2.3
        [InlineData(1d, 5e10d)]//3.1
        [InlineData(15e10d, 5d)]//3.2
        [InlineData(15e10d, 5e15d)]//3.3
        public void WithPositiveIntegers(double a, double b)
        {
            Assert.Equal(ApplyOperationCorrectly(a, b), OperationToTest.Invoke(a, b));
        }

        [Theory] //Equivalence class: negative integers numbers.
        [InlineData(-51d, -64d)] //1.1
        [InlineData(5d, -677d)] //1.2
        [InlineData(-123d, -677d)] //1.3
        [InlineData(-11d, -124e-5d)] //2.1.1
        [InlineData(111d, -1241e-5d)] //2.1.2
        [InlineData(-101d, 124e-5d)] //2.1.3
        [InlineData(-66e-5d, -23d)] //2.2.1
        [InlineData(8e-5d, -23d)] //2.2.2
        [InlineData(-10001e-5d, 23d)] //2.2.3
        [InlineData(-14e-5d, -10e-23d)] //2.3.1
        [InlineData(14e-5d, -10e-23d)] //2.3.1
        [InlineData(-14e-5d, 10e-23d)] //2.3.1
        [InlineData(-1d, -5e10d)]//3.1.1
        [InlineData(1d, -5e10d)]//3.1.2
        [InlineData(-1d, 5e10d)]//3.1.3
        [InlineData(-15e10d, -5d)]//3.2.1
        [InlineData(15e10d, -5d)]//3.2.2
        [InlineData(-15e10d, 5d)]//3.2.3
        [InlineData(-15e10d, -5e15d)]//3.3.1
        [InlineData(-15e10d, 5e15d)]//3.3.2
        [InlineData(15e10d, -5e15d)]//3.3.3
        public void WithNegativeIntegers(double a, double b)
        {
            Assert.Equal(ApplyOperationCorrectly(a, b), OperationToTest.Invoke(a, b));
        }

        [Theory] //Equivalence class: real positive/negative numbers.
        [InlineData(0d, 0d)]
        [InlineData(65.32d, 0d)]
        [InlineData(0.032d, 888.65d)]
        [InlineData(1e-32d, 1e32d)]
        [InlineData(double.PositiveInfinity, 1e32d)]
        [InlineData(double.NegativeInfinity, 1e32d)]
        public void WithRealNumbers(double a, double b)
        {
            Assert.Equal(ApplyOperationCorrectly(a, b), OperationToTest.Invoke(a, b));
        }

        private Random gen = new();

        [Fact]
        public void RandomTest()
        {
            foreach (double p in new[] { 1e10, 1e100, 1e200 })
            {
                for (int i = 0; i < 3_000; ++i)
                {
                    double a = GenerateRandom(p);
                    double b = GenerateRandom(p);
                    Assert.Equal(ApplyOperationCorrectly(a, b), OperationToTest.Invoke(a, b));
                }
            }

            double GenerateRandom(double powTerm = 1)
            {
                return gen.NextDouble() * (gen.Next() - gen.Next()) + gen.Next() + powTerm;
            }
        }
    }
}
