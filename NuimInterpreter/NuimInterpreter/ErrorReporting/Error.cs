using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NuimInterpreter.ErrorReporting
{
    /// <summary>
    /// A generic error type for reporting errors in Nuim code
    /// </summary>
    public class Error
    {
        public readonly int LineNumber;

        /// <summary>
        /// Constructs a new generic Nuim error
        /// </summary>
        /// <param name="lineNumber">The line number the error occurred at</param>
        /// <exception cref="ArgumentOutOfRangeException">Occurs if <c>lineNumber</c> is below zero</exception>
        public Error(int lineNumber)
        {
            if (lineNumber < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(lineNumber));
            }
            LineNumber = lineNumber;
        }

        /// <summary>
        /// Converts the error to a string for reporting
        /// </summary>
        /// <returns>The error message to be reported to the user</returns>
        public override string ToString() => "Unknown error";
    }
}
