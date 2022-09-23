namespace CalculatorProj
{
    public interface ICalculatorView
    {
        /// <summary>
        /// Отображает результат вычисления
        /// </summary>
        void PrintResult(double result);

        /// <summary>
        /// Показывает ошибку, например деление на 0, пустые аргументы и прочее
        /// </summary>
        void DisplayError(string message);

        /// <summary>
        /// Возвращает значение, введенное в поле первого аргументы
        /// </summary>
        string GetFirstArgumentAsString();

        /// <summary>
        /// Возвращает значение, введенное в поле второго аргументы
        /// </summary>
        string GetSecondArgumentAsString();
    }
}
