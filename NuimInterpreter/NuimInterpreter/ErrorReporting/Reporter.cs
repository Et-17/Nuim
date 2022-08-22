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
    public class Reporter
    {
        /// <summary>
        /// All errors reported so far
        /// </summary>
        public readonly List<Error> Errors = new();
        /// <summary>
        /// The stream to write errors to
        /// </summary>
        public readonly TextWriter ErrorStream = Console.Error;

        /// <summary>
        /// Construct a new <c>Reporter</c>
        /// </summary>
        /// <param name="errorStream">The stream to output to</param>
        public Reporter(TextWriter errorStream)
        {
            ErrorStream = errorStream;
        }

        /// <summary>
        /// Reports an error to the stream specified in the <c>ErrorStream</c> property
        /// </summary>
        /// <param name="e">The error to report</param>
        public void ReportError(Error e)
        {
            Errors.Add(e);
            ErrorStream.WriteLine("[line {0}] {1}", e.LineNumber, e.ToString());
        }

        /// <summary>
        /// Outputs a count of the fatal errors encountered
        /// </summary>
        public void SummarizeErrors()
        {
            ErrorStream.WriteLine("Fatal errors: {0}", Errors.Count);
        }
    }
}
