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

        public override bool Equals(object? obj)
        {
            if (obj == null)
            {
                //throw new ArgumentNullException(nameof(obj));
                return false;
            } else if (obj.GetType() != GetType()) 
            {
                //throw new ArgumentException("Invalid Type", nameof(obj));
                return false;
            } else
            {
                Token objT = (Token)obj;
                return Type == objT.Type
                    && Lexeme.Equals(objT.Lexeme)
                    // The next line is very hacky but it works
                    // It's a ternary that first checks if both literals are null, and returns true if they are
                    // If they aren't, it compares them together
                    // The bit near the end with the Literal ?? new() just handles solo-null literals
                    // If we didn't have that it'd still work, but we'd get compiler warnings
                    && (Literal == null && objT.Literal == null) || (Literal ?? new()).Equals(objT.Literal)
                    && Line == objT.Line;
            }
        }

        public override int GetHashCode() => base.GetHashCode();
    }
}
