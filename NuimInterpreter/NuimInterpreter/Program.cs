namespace NuimInterpreter
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ErrorReporting.Reporter.ReportError(new(15));
            ErrorReporting.Reporter.ReportError(new(20));
            ErrorReporting.Reporter.SummarizeErrors();
        }
    }
}