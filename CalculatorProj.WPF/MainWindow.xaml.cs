using CalculatorProj.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
            MessageBox.Show(message, "Ошибка!", MessageBoxButton.OK, MessageBoxImage.Error);
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
            if (_presenter is null)
                _presenter = new CalculatorPresenter(this, new Calculator());

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
    }
}