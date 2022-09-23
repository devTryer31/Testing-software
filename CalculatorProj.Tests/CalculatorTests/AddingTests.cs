using CalculatorProj.Core;
using CalculatorProj.Tests.CalculatorTests.Base;

namespace CalculatorProj.Tests.CalculatorTests
{
    public class AddingTests : OperationTestsBase
    {
        private static readonly ICalculator _calculator = new Calculator();

        public AddingTests() : base(_calculator.Sum)
        { }

        protected override double ApplyOperationCorrectly(double a, double b)
            => a + b;
    }
}
