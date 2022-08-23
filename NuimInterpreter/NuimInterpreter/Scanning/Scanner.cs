using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NuimInterpreter.Scanning
{
    /// <summary>
    /// Scans and tokenizes Nuim code. First call <c>InitScanner</c> to give it the code, then call <c>ScanTokens</c> to tokenize the code
    /// </summary>
    public class Scanner
    {
        /// <summary>
        /// The source being scanned
        /// </summary>
        private string Source = "";
        /// <summary>
        /// The previously scanned tokens
        /// </summary>
        public List<Token> Tokens = new();
        /// <summary>
        /// The position of the start of the token being scanned
        /// </summary>
        private int Start = 0;
        /// <summary>
        /// The position of the character currently being scanned
        /// </summary>
        private int Current = 0;
        /// <summary>
        /// The physical line being scanned
        /// </summary>
        private int Line = 1;
        /// <summary>
        /// The reporter to use to report errors
        /// </summary>
        private ErrorReporting.Reporter Reporter;

        /// <summary>
        /// Construct a new scanner on the given source
        /// </summary>
        /// <param name="source">The source to scan</param>
        /// <param name="reporter">The reporter to report errors to</param>
        public Scanner(string source, ErrorReporting.Reporter reporter)
        {
            Source = source;
            Reporter = reporter;
        }

        /// <summary>
        /// Activate the scanner on the current source
        /// </summary>
        /// <returns>The scanned tokens</returns>
        public List<Token> ScanTokens()
        {
            while (!IsAtEnd())
            {
                Start = Current;
                ScanToken();
            }

            return Tokens;
        }

        /// <summary>
        /// Scans the next token
        /// </summary>
        private void ScanToken()
        {
            // Get next character
            char c = Advance();

            if (c == '\n') Line++;
            if (char.IsWhiteSpace(c)) return;
            
            switch (c)
            {
                case ';':
                    AddToken(TokenType.SEMICOLON);
                    break;

                case '$':
                    AddToken(TokenType.APPLICATION);
                    break;

                case ':':
                    AddToken(TokenType.ARG_COLON);
                    break;

                case '-':
                    if (Match('>')) AddToken(TokenType.ARG_ARROW);
                    else HandleVariable();
                    break;

                case '=':
                    if (char.IsWhiteSpace(Peek())) AddToken(TokenType.DEF_EQUAL);
                    else if (Match('>')) AddToken(TokenType.RETURN_ARROW);
                    else HandleVariable();
                    break;

                case '#':
                    while (Peek() != '\n' && !IsAtEnd()) Current++;
                    break;

                case '"':
                    HandleString();
                    break;

                default:
                    if (char.IsNumber(c)) HandleNum();
                    else HandleVariable();
                    break;
            }
        }

        /// <summary>
        /// Matches the next character in the source, and automatically advances the scanner if matched
        /// </summary>
        /// <param name="expected">The character to match</param>
        /// <returns>Whether or not the charater was matched</returns>
        private bool Match(char expected)
        {
            if (IsAtEnd()) return false;
            if (Peek() != expected) return false;

            Current++;
            return true;
        }

        /// <summary>
        /// Scans a variable token
        /// </summary>
        private void HandleVariable()
        {
            while (!IsAtEnd() && Peek() != '$' && Peek() != ';' && !char.IsWhiteSpace(Peek()))
            {
                Advance();
            }

            AddToken(TokenType.VARIABLE);
        }

        /// <summary>
        /// Scans a string literal
        /// </summary>
        private void HandleString()
        {
            while (!IsAtEnd() && Peek() != '"')
            {
                if (Peek() == '\n')
                {
                    Line++;
                }

                Advance();
            }

            if (IsAtEnd())
            {
                Reporter.ReportError(new Errors.UnterminatedStringException(Line));
            }
            else
            {
                Advance();
                AddToken(TokenType.STRING, Source.Substring(Start + 1, (Current - 1) - (Start + 1)));
            }

        }

        /// <summary>
        /// Scans a number literal
        /// </summary>
        private void HandleNum()
        {
            while (!IsAtEnd() && Peek() != '$' && !char.IsWhiteSpace(Peek()))
            {
                Advance();
            }

            try
            {
                AddToken(TokenType.INTEGER, Convert.ToInt32(Source[Start..Current]));
            } catch (FormatException)
            {
                Reporter.ReportError(new Errors.NumberFormattingException(Line));
            }
        }

        /// <summary>
        /// Detect if the scanner has reached the end of the source
        /// </summary>
        /// <returns>Whether or not the scanner has reached the end of the source</returns>
        private bool IsAtEnd() => Current >= Source.Length;

        /// <summary>
        /// Get the next character of the source and then move forward
        /// </summary>
        /// <returns>The next character of the source</returns>
        private char Advance() => Source[Current++];

        /// <summary>
        /// Get the next character of the source without moving forward
        /// </summary>
        /// <returns>The next character of the source</returns>
        private char Peek() => IsAtEnd() ? '\0' : Source[Current];

        /// <summary>
        /// Add a new token, given only the type
        /// </summary>
        /// <param name="type">The type of the new token</param>
        private void AddToken(TokenType type)
        {
            AddToken(type, null);
        }

        /// <summary>
        /// Add a new token with a literal
        /// </summary>
        /// <param name="type">Then type of the new token</param>
        /// <param name="literal">The literal value of the token</param>
        private void AddToken(TokenType type, object? literal)
        {
            Tokens.Add(new(type, Source[Start..Current], literal, Line));
        }
    }
}
