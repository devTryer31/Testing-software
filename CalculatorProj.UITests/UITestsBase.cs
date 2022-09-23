using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Windows;

namespace CalculatorProj.UITests
{
    public class UITestsBase
    {

        protected const string WindowsApplicationDriverUrl = "http://127.0.0.1:4723";
        private static readonly string WpfAppId = Environment.CurrentDirectory + @"\..\..\..\..\CalculatorProj.WPF\bin\Debug\net6.0-windows\CalculatorProj.WPF.exe";

        protected static readonly WindowsDriver<WindowsElement> session;

        static UITestsBase()
        {
            AppiumOptions appiumOptions = new();
            appiumOptions.AddAdditionalCapability("app", WpfAppId);
            appiumOptions.AddAdditionalCapability("deviceName", "WindowsPC");
            session = new WindowsDriver<WindowsElement>(new Uri(WindowsApplicationDriverUrl), appiumOptions);
        }

        //example
        //[Fact]
        //public void Test1()
        //{
        //    var fa = session.FindElementByAccessibilityId("fa");
        //    fa.SendKeys("123");
        //    var sa = session.FindElementByAccessibilityId("sa");
        //    sa.SendKeys("321");
        //    session.FindElementByAccessibilityId("addBtn").Click();
        //    string res = session.FindElementByAccessibilityId("res").Text;
        //    Assert.Equal("444", res);
        //}
    }
}