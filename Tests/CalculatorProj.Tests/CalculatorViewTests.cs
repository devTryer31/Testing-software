namespace CalculatorProj.Tests
{
    public class CalculatorViewTests
    {
        private readonly MemoryStream _stream;
        private readonly ICalculatorView _view;
        private readonly string _firstArg = 10.ToString();
        private readonly string _secondArg = 1e-3.ToString();
        public CalculatorViewTests()
        {
            _stream = new MemoryStream();
            _view = new CalculatorView(_firstArg, _secondArg, _stream);
        }

        [Fact]
        public void PrintResultTest()
        {
            //arrange
            double result = 5 + 5;

            //act
            _view.PrintResult(result);

            _stream.Seek(0, SeekOrigin.Begin);
            using StreamReader rsr = new(_stream);

            //assert
            Assert.Contains(result.ToString(), rsr.ReadToEnd());
        }

        [Fact]
        public void DisplayErrorTest()
        {
            //arrange
            string errMsg = "ОЧень важная ошибка на бэке!";

            //act
            _view.DisplayError(errMsg);

            _stream.Seek(0, SeekOrigin.Begin);
            using StreamReader rsr = new(_stream);

            //assert
            Assert.Contains(errMsg, rsr.ReadToEnd());
        }

        [Fact]
        public void GetArgsTest()
        {
            //arrange
            //act/assert
            Assert.Equal(_firstArg, _view.GetFirstArgumentAsString());
            Assert.Equal(_secondArg, _view.GetSecondArgumentAsString());
        }
    }
}
