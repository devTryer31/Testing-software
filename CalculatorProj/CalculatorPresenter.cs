using CalculatorProj.Core;

namespace CalculatorProj
{
    public class CalculatorPresenter : ICalculatorPresenter
    {
        public CalculatorPresenter(ICalculatorView view, ICalculator calculator)
        {
            View = view;
            Calculator = calculator;
        }

        public ICalculatorView View { get; set; }
        public ICalculator Calculator { get; set; }

        private void ValidateArgs(out double a, out double b)
        {
            if (!double.TryParse(View.GetFirstArgumentAsString(), out a))
                throw new ArgumentException("Неверно введен первый аргумент.");
            if (!double.TryParse(View.GetSecondArgumentAsString(), out b))
                throw new ArgumentException("Неверно введен второй аргумент.");
        }

        public void OnDivideClicked()
        {
            ValidateArgs(out double a, out double b);
            try
            {
                View.PrintResult(Calculator.Divide(a, b));
            }
            catch (Exception dzEx)
            {
                View.DisplayError(dzEx.Message);
            }
        }

        public void OnMinusClicked()
        {
            ValidateArgs(out double a, out double b);
            View.PrintResult(Calculator.Subtract(a, b));
        }

        public void OnMultiplyClicked()
        {
            ValidateArgs(out double a, out double b);
            View.PrintResult(Calculator.Multiply(a, b));
        }

        public void OnPlusClicked()
        {
            ValidateArgs(out double a, out double b);
            View.PrintResult(Calculator.Sum(a, b));
        }
    }
}
