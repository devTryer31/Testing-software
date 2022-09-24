using CalculatorProj.Core;

namespace CalculatorProj.Tests
{
    public class CalculatorPresenterTests : IDisposable
    {
        private static readonly ViewMock _viewMock;
        private static readonly ICalculatorPresenter _presenter;

        static CalculatorPresenterTests()
        {
            _viewMock = new ViewMock();
            _presenter = new CalculatorPresenter(_viewMock, new CalculatorStub());
        }

        public void Dispose()
        {
            _viewMock.SetAllCountPropsToZero();
        }

        [Fact]
        public void OnOperationClickedTest()
        {
            //arrange/act
            int produseCnt = 5;
            for (int i = 0; i < produseCnt; i++)
            {
                _presenter.OnPlusClicked();
                _presenter.OnMinusClicked();
                _presenter.OnMultiplyClicked();
            }

            //result
            Assert.Equal(produseCnt * 3, _viewMock.PrintResultInvokeCount);
            Assert.Equal(produseCnt * 3, _viewMock.GetSecondArgumentAsStringInvokeCount);
            Assert.Equal(produseCnt * 3, _viewMock.GetFirstArgumentAsStringInvokeCount);
        }

        [Fact]
        public void OnDivideClickedWithErrTest()
        {
            //arrange
            _viewMock.SecondArg = 0;
            //act
            _presenter.OnDivideClicked();
            //res
            Assert.Equal(0, _viewMock.PrintResultInvokeCount);
            Assert.Equal(1, _viewMock.DisplayErrorInvokeCount);
            Assert.Equal(1, _viewMock.GetSecondArgumentAsStringInvokeCount);
            Assert.Equal(1, _viewMock.GetFirstArgumentAsStringInvokeCount);
        }
    }

    internal class ViewMock : ICalculatorView
    {
        public int DisplayErrorInvokeCount { get; private set; }
        public int GetFirstArgumentAsStringInvokeCount { get; private set; }
        public int GetSecondArgumentAsStringInvokeCount { get; private set; }
        public int PrintResultInvokeCount { get; private set; }

        public double FirstArg { get; set; } = 1;
        public double SecondArg { get; set; } = 2;

        public void DisplayError(string message) => ++DisplayErrorInvokeCount;

        public void SetAllCountPropsToZero()
        {
            DisplayErrorInvokeCount = 0;
            GetFirstArgumentAsStringInvokeCount = 0;
            GetSecondArgumentAsStringInvokeCount = 0;
            PrintResultInvokeCount = 0;
        }

        public string GetFirstArgumentAsString()
        {
            ++GetFirstArgumentAsStringInvokeCount;
            return FirstArg.ToString();
        }

        public string GetSecondArgumentAsString()
        {
            ++GetSecondArgumentAsStringInvokeCount;
            return SecondArg.ToString();
        }

        public void PrintResult(double result)
            => ++PrintResultInvokeCount;
    }

    internal class CalculatorStub : ICalculator
    {
        public double Divide(double a, double b) => b == 0 ? throw new DivideByZeroException(b.ToString()) : 0;

        public double Multiply(double a, double b) => 0;

        public double Subtract(double a, double b) => 0;

        public double Sum(double a, double b) => 0;
    }
}
