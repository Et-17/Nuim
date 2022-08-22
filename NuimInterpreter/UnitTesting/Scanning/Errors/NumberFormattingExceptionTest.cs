using NuimInterpreter.ErrorReporting;
using NuimInterpreter.Scanning.Errors;

namespace UnitTesting.Scanning.Errors
{
    [TestClass]
    public class NumberFormattingExceptionTest
    {
        [TestMethod]
        public void Reporting()
        {
            StringWriter output = new();
            Reporter reporter = new(output);
            reporter.ReportError(new NumberFormattingException(5));
            Assert.AreEqual("[line 5] Number formatting error\r\n", output.ToString());
        }
    }
}
