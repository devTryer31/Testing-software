using System.Text;

namespace CalculatorProj
{
    public class CalculatorView : ICalculatorView
    {
        private const string _errPrefix = "!Ошибка: ";
        private const string _resPrefix = "Результат: ";
        private readonly string _firstArg;
        private readonly string _secondArg;
        private readonly StreamWriter _outputStream;

        public CalculatorView(string firstArg, string secondArg, Stream outputStream, Encoding encoding = null)
        {
            _firstArg = firstArg;
            _secondArg = secondArg;
            _outputStream = new StreamWriter(outputStream, encoding ?? Encoding.UTF8)
            {
                AutoFlush = true,
            };
        }

        public void DisplayError(string message)
        {
            //Console.BackgroundColor = ConsoleColor.DarkRed;
            _outputStream.WriteLine(_errPrefix + message);
            //Console.BackgroundColor = ConsoleColor.Black;
            //Console.WriteLine();
        }

        public string GetFirstArgumentAsString()
            => _firstArg;

        public string GetSecondArgumentAsString()
            => _secondArg;

        public void PrintResult(double result)
        {
            _outputStream.WriteLine(_resPrefix + result);
            //Console.BackgroundColor = ConsoleColor.DarkGreen;
            //Console.Write(result);
            //Console.BackgroundColor = ConsoleColor.Black;
            //Console.WriteLine();
        }
    }
}
