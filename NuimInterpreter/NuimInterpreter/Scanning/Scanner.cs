using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NuimInterpreter.Scanning
{
    internal static class Scanner
    {
        /// <summary>
        /// The source being scanned
        /// </summary>
        private static string Source = "";
        /// <summary>
        /// The previously scanned tokens
        /// </summary>
        private static List<Token> Tokens = new();
        /// <summary>
        /// The position of the start of the token being scanned
        /// </summary>
        private static int Start = 0;
        /// <summary>
        /// The position of the character currently being scanned
        /// </summary>
        private static int Current = 0;
        /// <summary>
        /// The physical line being scanned
        /// </summary>
        private static int Line = 1;

        /// <summary>
        /// Change the internal source
        /// </summary>
        /// <param name="source">The new source to use</param>
        public static void InitScanner(string source)
        {
            Source = source;
        }

        /// <summary>
        /// Detect if the scanner has reached the end of the source
        /// </summary>
        /// <returns>Whether or not the scanner has reached the end of the source</returns>
        private static bool IsAtEnd() => Current >= Source.Length;

        /// <summary>
        /// Get the next character of the source
        /// </summary>
        /// <returns>The next character of the source</returns>
        private static char Advance() => Source[Current++];

        /// <summary>
        /// Add a new token, given only the type
        /// </summary>
        /// <param name="type">The type of the new token</param>
        private static void AddToken(TokenType type)
        {
            AddToken(type, null);
        }

        /// <summary>
        /// Add a new token with a literal
        /// </summary>
        /// <param name="type">Then type of the new token</param>
        /// <param name="literal">The literal value of the token</param>
        private static void AddToken(TokenType type, object? literal)
        {
            Tokens.Add(new(type, Source.Substring(Start, Current), literal, Line));
        }
    }
}
