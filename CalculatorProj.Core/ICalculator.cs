namespace CalculatorProj.Core
{
    public interface ICalculator
    {
        /// <summary>
        /// Вычисляет сумму двух чисел
        /// </summary>
        double Sum(double a, double b);


        /// <summary>
        /// Вычисляет разность двух чисел a - b
        /// </summary>
        double Subtract(double a, double b);

        /// <summary>
        /// Вычисляет произведение двух чисел
        /// </summary>
        double Multiply(double a, double b);

        /// <summary>
        /// Вычисляет отношение числа а к числу <paramref name="b"/>.
        /// </summary>
        /// <remarks>
        /// Должен выбросить <see cref="System.DivideByZeroException"/> если |<paramref name="a"/>| &lt; 10e-8
        /// </remarks>
        double Divide(double a, double b);
    }
}
