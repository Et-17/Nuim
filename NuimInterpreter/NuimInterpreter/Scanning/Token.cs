using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NuimInterpreter.Scanning
{
    public class Token
    {
        /// <summary>
        /// The type of token represented
        /// </summary>
        public readonly TokenType Type;
        /// <summary>
        /// The raw representation of the token
        /// </summary>
        public readonly string Lexeme;
        /// <summary>
        /// The actual value of the token
        /// </summary>
        public readonly Object? Literal;
        /// <summary>
        /// The line on which the token is
        /// </summary>
        public readonly int Line;

        /// <summary>
        /// Create a new token
        /// </summary>
        /// <param name="type">The type of token represented</param>
        /// <param name="lexeme">The raw representation of the token</param>
        /// <param name="literal">The actual value of the token</param>
        /// <param name="line">The line on which the token is</param>
        /// <exception cref="ArgumentOutOfRangeException">Occurs if <c>line</c> is below zero</exception>
        public Token(TokenType type, string lexeme, object? literal, int line)
        {
            Type = type;
            Lexeme = lexeme;
            Literal = literal;
            if (line < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(line));
            }
            Line = line;
        }

        public override string ToString() =>
            String.Format("{0}: {1}", Type, Lexeme);
    }
}
