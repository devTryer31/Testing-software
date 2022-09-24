using CalculatorProj.Core;
using CalculatorProj.Tests.CalculatorTests.Base;

namespace CalculatorProj.Tests.CalculatorTests
{
    public class SubTests : OperationTestsBase
    {
        private static readonly ICalculator _calculator = new Calculator();

        public SubTests() : base(_calculator.Subtract)
        { }

        protected override double ApplyOperationCorrectly(double a, double b)
            => a - b;
    }
}
