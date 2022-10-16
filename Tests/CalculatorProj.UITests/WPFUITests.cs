using OpenQA.Selenium.Appium.Windows;

namespace CalculatorProj.UITests
{
    public class WPFUITests : UITestsBase, IDisposable
    {
        private static readonly WindowsElement _firstArg;
        private static readonly WindowsElement _secondArg;
        private static readonly WindowsElement _result;
        private static readonly WindowsElement _operation;
        private static readonly WindowsElement _window;

        static WPFUITests()
        {
            _firstArg = session.FindElementByAccessibilityId("firstArgId");
            _secondArg = session.FindElementByAccessibilityId("secondArgId");
            _result = session.FindElementByAccessibilityId("resultId");
            _operation = session.FindElementByAccessibilityId("operationId");
            _window = session.FindElementByAccessibilityId("mainWindowId");
        }

        public WPFUITests()
        {
            _firstArg.SendKeys("123,321");
            _secondArg.SendKeys("321,123");
        }

        public void Dispose()
        {
            _secondArg.Click();
            _secondArg.Clear();
            _firstArg.Click();
            _firstArg.Clear();
        }


        [Theory]
        [InlineData("/", 123.321 / 321.123)]
        [InlineData("*", 123.321 * 321.123)]
        [InlineData("+", 123.321 + 321.123)]
        [InlineData("-", 123.321 - 321.123)]
        public void SimpleOperationsInvokeTest(string operation, double correctResult)
        {
            //act
            _window.SendKeys(operation);
            string resultText = _result.Text;
            string operationText = _operation.Text;

            //assert
            Assert.Equal(correctResult.ToString(), resultText);
            Assert.Equal(operation, operationText);
        }

        [Fact]
        public void ErrorInvokeTest()
        {
            //arrange
            _secondArg.Click();
            _secondArg.Clear();
            _secondArg.SendKeys("0");

            //act
            _window.SendKeys("/");

            //assert
            Assert.Contains("Ошибка", _result.Text);
            Assert.Contains("|b|", _result.Text);
        }

        [Fact]
        public void ArgInputError()
        {
            //arrange
            _secondArg.Click(); _secondArg.Clear();

            //act
            _secondArg.SendKeys("asd");

            //assert
            Assert.Contains("Ошибка", _result.Text);
            Assert.Contains("Неверный формат входного аргумента", _result.Text);

            //arrange
            _secondArg.Click(); _secondArg.Clear();
            _secondArg.SendKeys("123");

            _firstArg.Click(); _firstArg.Clear();
            _firstArg.SendKeys("p-o");

            //assert
            Assert.Contains("Ошибка", _result.Text);
            Assert.Contains("Неверный формат входного аргумента", _result.Text);
        }
    }
}
