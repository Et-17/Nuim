using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NuimInterpreter.Scanning.Errors
{
    /// <summary>
    /// An exception for incorrectly formatted numbers
    /// </summary>
    internal class NumberFormattingException : ErrorReporting.Error
    {
        public NumberFormattingException(int lineNumber) : base(lineNumber) { }

        public override string ToString() => "Number formatting error";
    }
}
