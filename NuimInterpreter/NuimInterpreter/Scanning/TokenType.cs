using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NuimInterpreter.Scanning
{
    /// <summary>
    /// An enumerate with the types of tokens that can exist
    /// </summary>
    public enum TokenType
    {
        // Expression lexing
        APPLICATION, VARIABLE, SEMICOLON,
        
        // Function definition
        FUNCTION, BINDING, DEF_EQUAL, ARG_ARROW, RETURN_ARROW, ARG_COLON, 
        
        // Literals
        CHAR, STRING, INTEGER,

        EOF
    }
}
