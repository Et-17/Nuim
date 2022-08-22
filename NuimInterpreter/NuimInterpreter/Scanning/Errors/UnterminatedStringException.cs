using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NuimInterpreter.Scanning.Errors
{
    /// <summary>
    /// An exception for strings that don't get terminated before EOF
    /// </summary>
    internal class UnterminatedStringException : NuimInterpreter.ErrorReporting.Error
    {
        public UnterminatedStringException(int lineNumber) : base(lineNumber) { }

        public override string ToString() => "Unterminated String";
    }
}
