using CalculatorProj.UITests;
using OpenQA.Selenium.Appium.Windows;

namespace CalculatorProj.SpecFlowTests.StepDefinitions
{
    [Binding]
    public sealed class CalculatorStepDefinitions : UITestsBase, IDisposable
    {

        private static readonly WindowsElement _firstArg;
        private string? _firstValue;
        private static readonly WindowsElement _secondArg;
        private string? _secondValue;
        private static readonly WindowsElement _result;
        private static readonly WindowsElement _operation;
        private string? _operationValue;
        private static readonly WindowsElement _window;

        static CalculatorStepDefinitions()
        {
            _firstArg = session.FindElementByAccessibilityId("firstArgId");
            _secondArg = session.FindElementByAccessibilityId("secondArgId");
            _result = session.FindElementByAccessibilityId("resultId");
            _operation = session.FindElementByAccessibilityId("operationId");
            _window = session.FindElementByAccessibilityId("mainWindowId");
        }

        [Given("the first number is (.*)")]
        public void GivenTheFirstNumberIs(string arg)
        {
            _firstArg.SendKeys(arg);
            _firstValue = arg;
        }

        [Given("the second number is (.*)")]
        public void GivenTheSecondNumberIs(string arg)
        {
            _secondArg.SendKeys(arg);
            _secondValue = arg;
        }

        [When("the two numbers are (.*)")]
        public void WhenTheTwoNumbersAreAdded(string commad)
        {
            _operationValue = commad switch
            {
                "added" => "+",
                "subtracted" => "-",
                "multiplied" => "*",
                "divided" => "/",
                _ => throw new ArgumentException($"Command {commad} not supported.")
            };
            _window.SendKeys(_operationValue);
        }

        [Then("the result should be (.*)")]
        public void ThenTheResultShouldBe(string result)
        {
            var validFirstArg = double.TryParse(_firstValue, out double a);
            var validSecondArg = double.TryParse(_secondValue, out double b);
            if(!validFirstArg || !validSecondArg || Math.Abs(b) < 10e-8)
            {
                Assert.Contains(result, _result.Text);
                return;
            }

            //_resultValue = _operationValue switch
            //{
            //    "+" => (a + b).ToString(),
            //    "-" => (a - b).ToString(),
            //    "*" => (a * b).ToString(),
            //    "/" => Math.Abs(b) < 10e-8 
            //        ? $"Ошибка!|b| < 10e-8, где b = {b}" 
            //        : (a / b).ToString(),
            //    _ => throw new ArgumentException(nameof(_operationValue))
            //};

            Assert.Equal(result, _result.Text);
        }

        [Then("with error")]
        public void WithTheError()
        {
            Assert.Contains("Ошибка!", _result.Text);
        }

        [Then("operation must be (.*)")]
        public void OperationMustBe(string operation)
        {
            Assert.Equal(operation, _operation.Text);
        }

        public void Dispose()
        {
            _firstArg.Click(); _firstArg.Clear();
            _secondArg.Click(); _secondArg.Clear();
        }
    }
}