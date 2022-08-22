using NuimInterpreter.ErrorReporting;
using NuimInterpreter.Scanning.Errors;

namespace UnitTesting.Scanning.Errors
{
    [TestClass]
    public class UnterminatedStringExceptionTest
    {
        [TestMethod]
        public void Reporting()
        {
            StringWriter output = new();
            Reporter reporter = new(output);
            reporter.ReportError(new UnterminatedStringException(5));
            Assert.AreEqual("[line 5] Unterminated String\r\n", output.ToString());
        }
    }
}
