using CalculatorProj.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace CalculatorProj.WPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window, ICalculatorView
    {
        private ICalculatorPresenter? _presenter;

        public MainWindow()
        {
            InitializeComponent();
        }

        public void DisplayError(string message)
        {
            resultId.Text = "Ошибка!" + message;
            //MessageBox.Show(message, "Ошибка!", MessageBoxButton.OK, MessageBoxImage.Error);
        }

        public string GetFirstArgumentAsString()
            => firstArgId.Text;

        public string GetSecondArgumentAsString()
            => secondArgId.Text;

        public void PrintResult(double result)
        {
            resultId.Text = result.ToString();
        }

        private void OnMainGridTextInput(object sender, TextCompositionEventArgs e)
        {
            if (!CanDoOperation)
                return;

            _presenter ??= new CalculatorPresenter(this, new Calculator());

            switch (e.Text)
            {
                case "/":
                    _presenter.OnDivideClicked();
                    operationId.Text = e.Text;
                    break;
                case "*":
                    _presenter.OnMultiplyClicked();
                    operationId.Text = e.Text;
                    break;
                case "+":
                    _presenter.OnPlusClicked();
                    operationId.Text = e.Text;
                    break;
                case "-":
                    _presenter.OnMinusClicked();
                    operationId.Text = e.Text;
                    break;
                default:
                    return;
                    //DisplayError("Неизвестная операция");
            }
            e.Handled = true;
        }

        private bool _correctFirstArg = false;
        private bool _correctSecondArg = false;

        private bool CanDoOperation => _correctFirstArg && _correctSecondArg;

        private bool ValidateInputArg(TextBox tb, string enteredText)
        {
            bool isValidInput = double.TryParse(tb!.Text + enteredText, out double d);
            if (!isValidInput)
            {
                tb.BorderBrush = Brushes.Red;
                DisplayError("Неверный формат входного аргумента");
            }
            else
            {
                tb.BorderBrush = Brushes.DarkGray;
            }
            return isValidInput;
        }

        private void OnArg1PreviewInput(object sender, TextCompositionEventArgs e)
        {
            var tb = sender as TextBox;
            _correctFirstArg = ValidateInputArg(tb!, e.Text);
            e.Handled = !_correctFirstArg;
        }

        private void OnArg2PreviewInput(object sender, TextCompositionEventArgs e)
        {
            var tb = sender as TextBox;
            _correctSecondArg = ValidateInputArg(tb!, e.Text);
            e.Handled = !_correctSecondArg;
        }
    }
}