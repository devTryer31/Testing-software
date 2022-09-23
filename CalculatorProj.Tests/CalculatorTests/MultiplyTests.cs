using CalculatorProj.Core;
using CalculatorProj.Tests.CalculatorTests.Base;

namespace CalculatorProj.Tests.CalculatorTests
{
    public class MultiplyTests : OperationTestsBase
    {
        private static readonly ICalculator _calculator = new Calculator();

        public MultiplyTests() : base(_calculator.Multiply)
        { }

        protected override double ApplyOperationCorrectly(double a, double b)
            => a * b;
    }
}
