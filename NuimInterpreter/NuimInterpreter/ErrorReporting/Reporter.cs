using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NuimInterpreter.ErrorReporting
{
    /// <summary>
    /// A <c>static</c> class used for reporting errors in Nuim code
    /// </summary>
    public static class Reporter
    {
        /// <summary>
        /// All errors reported so far
        /// </summary>
        public readonly static List<Error> Errors = new();
        /// <summary>
        /// The stream to write errors to
        /// </summary>
        public readonly static TextWriter ErrorStream = Console.Error;

        /// <summary>
        /// Reports an error to the stream specified in the <c>ErrorStream</c> property
        /// </summary>
        /// <param name="e">The error to report</param>
        public static void ReportError(Error e)
        {
            Errors.Add(e);
            ErrorStream.WriteLine("[line {0}] {1}", e.LineNumber, e.ToString());
        }

        /// <summary>
        /// Outputs a count of the fatal errors encountered
        /// </summary>
        public static void SummarizeErrors()
        {
            ErrorStream.WriteLine("Fatal errors: {0}", Errors.Count);
        }
    }
}
