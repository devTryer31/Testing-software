using CalculatorProj;
using CalculatorProj.Core;
using System.Text;

Console.OutputEncoding = Encoding.UTF8;
ICalculatorView view = new CalculatorView(args[1], args[2], Console.OpenStandardOutput());

string[] operations = { "/", "*", "+", "-" };
string op = args[0];
try
{
    if (!operations.Contains(op))
        throw new ArgumentException("Неизвестный тип операции.");
}
catch (ArgumentException argEx)
{
    view.DisplayError(argEx.Message);
    return;
}

ICalculatorPresenter presenter = new CalculatorPresenter(
    calculator: new Calculator(),
    view: view
);
try
{
    switch (op)
    {
        case "/":
            presenter.OnDivideClicked();
            break;
        case "*":
            presenter.OnMultiplyClicked();
            break;
        case "+":
            presenter.OnPlusClicked();
            break;
        case "-":
            presenter.OnMinusClicked();
            break;
        default:
            throw new InvalidOperationException("Неопределенная операция");
    }
}
catch (Exception ex)
{
    view.DisplayError(ex.Message);
    return;
}