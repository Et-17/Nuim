using NuimInterpreter.ErrorReporting;
using System.Text;

namespace UnitTesting.ErrorReporting
{
    [TestClass]
    public class ReporterTest
    {
        [TestMethod]
        public void Reporting()
        {
            StringWriter output = new();
            Reporter reporter = new(output);
            reporter.ReportError(new(15));
            Assert.AreEqual("[line 15] Unknown error\r\n", output.ToString());
        }

        [TestMethod]
        public void ErrorCounting()
        {
            StringWriter output = new();
            Reporter reporter = new(output);
            reporter.ReportError(new(1));
            reporter.ReportError(new(2));
            reporter.ReportError(new(3));
            // Clear output so we're only testing the summary
            StringBuilder outputsb = output.GetStringBuilder();
            outputsb.Remove(0, outputsb.Length);
            reporter.SummarizeErrors();
            Assert.AreEqual("Fatal errors: 3\r\n", output.ToString());
        }

        [TestMethod]
        public void PreviousErrorLogging()
        {
            StringWriter output = new();
            Reporter reporter = new(output);
            List<Error> testerrors = new() { new(1), new(2), new(3) };
            testerrors.ForEach(reporter.ReportError);
            // Test the elements one by one for reliability
            testerrors.Zip(reporter.Errors)
                .ToList()
                .ForEach(x => Assert.AreEqual(x.First, x.Second));
        }
    }
}
