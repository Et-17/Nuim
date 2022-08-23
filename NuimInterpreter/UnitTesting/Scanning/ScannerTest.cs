using NuimInterpreter.Scanning;
using NuimInterpreter.ErrorReporting;

namespace UnitTesting.Scanning
{
    [TestClass]
    public class ScannerTest
    {
        [TestMethod]
        public void Construction()
        {
            StringWriter output = new();
            Reporter reporter = new(output);
            Scanner scanner = new("", reporter);
            Assert.IsTrue(scanner.Tokens.Count == 0);
        }

        [TestMethod]
        public void UnterminatedString()
        {
            StringWriter output = new();
            Reporter reporter = new(output);
            string program = "\"open string";
            Scanner scanner = new(program, reporter);
            scanner.ScanTokens();
            Assert.AreEqual("[line 1] Unterminated String\r\n", output.ToString());
        }

        [TestMethod]
        public void InvalidNumberFormatting()
        {
            StringWriter output = new();
            Reporter reporter = new(output);
            string program = "14a8";
            Scanner scanner = new(program, reporter);
            scanner.ScanTokens();
            Assert.AreEqual("[line 1] Number formatting error\r\n", output.ToString());
        }

        [TestMethod]
        public void FunctionSignatureTokenization()
        {
            StringWriter output = new();
            Reporter reporter = new(output);
            string program = "add : int -> int => int;";
            List<Token> expected = new() 
            { 
                new(TokenType.VARIABLE, "add", null, 1),
                new(TokenType.ARG_COLON, ":", null, 1),
                new(TokenType.VARIABLE, "int", null, 1),
                new(TokenType.ARG_ARROW, "->", null, 1),
                new(TokenType.VARIABLE, "int", null, 1),
                new(TokenType.RETURN_ARROW, "=>", null, 1),
                new(TokenType.VARIABLE, "int", null, 1),
                new(TokenType.SEMICOLON, ";", null, 1)
            };
            Scanner scanner = new(program, reporter);
            List<Token> scanned = scanner.ScanTokens();
            Assert.AreEqual(0, reporter.Errors.Count);
            foreach ((Token a, Token b) in expected.Zip(scanned))
            {
                Assert.AreEqual(a, b);
            }
        }

        [TestMethod]
        public void FunctionDefinitionTokenization()
        {
            StringWriter output = new();
            Reporter reporter = new(output);
            string program = "add x y = x succ$ y pred$ add$";
            List<Token> expected = new()
            {
                new(TokenType.VARIABLE, "add", null, 1),
                new(TokenType.VARIABLE, "x", null, 1),
                new(TokenType.VARIABLE, "y", null, 1),
                new(TokenType.DEF_EQUAL, "=", null, 1),
                new(TokenType.VARIABLE, "x", null, 1),
                new(TokenType.VARIABLE, "succ", null, 1),
                new(TokenType.APPLICATION, "$", null, 1),
                new(TokenType.VARIABLE, "y", null, 1),
                new(TokenType.VARIABLE, "pred", null, 1),
                new(TokenType.APPLICATION, "$", null, 1),
                new(TokenType.VARIABLE, "add", null, 1),
                new(TokenType.APPLICATION, "$", null, 1)
            };
            Scanner scanner = new(program, reporter);
            List<Token> scanned = scanner.ScanTokens();
            Assert.AreEqual(0, reporter.Errors.Count);
            foreach((Token a, Token b) in expected.Zip(scanned))
            {
                Assert.AreEqual(a, b);
            }
        }

        [TestMethod]
        public void CommentTokenization()
        {
            StringWriter output = new();
            Reporter reporter = new(output);
            string program = "one;\n#sample comment\ntwo;";
            List<Token> expected = new()
            {
                new(TokenType.VARIABLE, "one", null, 1),
                new(TokenType.SEMICOLON, ";", null, 1),
                new(TokenType.VARIABLE, "two", null, 3),
                new(TokenType.SEMICOLON, ";", null, 3)
            };
            Scanner scanner = new(program, reporter);
            List<Token> scanned = scanner.ScanTokens();
            Assert.AreEqual(0, reporter.Errors.Count);
            foreach((Token a, Token b) in expected.Zip(scanned))
            {
                Assert.AreEqual(a, b);
            }
        }

        [TestMethod]
        public void MultilineTokenization()
        {
            StringWriter output = new();
            Reporter reporter = new(output);
            string program = "one\ntwo";
            List<Token> expected = new()
            {
                new(TokenType.VARIABLE, "one", null, 1),
                new(TokenType.VARIABLE, "two", null, 2)
            };
            Scanner scanner = new(program, reporter);
            List<Token> scanned = scanner.ScanTokens();
            Assert.AreEqual(0, reporter.Errors.Count);
            foreach((Token a, Token b) in expected.Zip(scanned))
            {
                Assert.AreEqual(a, b);
            }
        }

        [TestMethod]
        public void VariableTokenHandling()
        {
            StringWriter output = new();
            Reporter reporter = new(output);
            string program = "-- ==";
            List<Token> expected = new()
            {
                new(TokenType.VARIABLE, "--", null, 1),
                new(TokenType.VARIABLE, "==", null, 1),
            };
            Scanner scanner = new(program, reporter);
            List<Token> scanned = scanner.ScanTokens();
            Assert.AreEqual(0, reporter.Errors.Count);
            foreach((Token a, Token b) in expected.Zip(scanned))
            {
                Assert.AreEqual(a, b);
            }
        }

        [TestMethod]
        public void MultilineStringHandling()
        {
            StringWriter output = new();
            Reporter reporter = new(output);
            string program = "\"one\ntwo\"";
            List<Token> expected = new()
            {
                new(TokenType.STRING, "\"one\ntwo\"", "one\ntwo", 2)
            };
            Scanner scanner = new(program, reporter);
            List<Token> scanned = scanner.ScanTokens();
            Assert.AreEqual(0, reporter.Errors.Count);
            foreach((Token a, Token b) in expected.Zip(scanned))
            {
                Assert.AreEqual(a, b);
            }
        }

        [TestMethod]
        public void EOFMatch()
        {
            StringWriter output = new();
            Reporter reporter = new(output);
            string program = "=";
            List<Token> expected = new()
            {
                new(TokenType.VARIABLE, "=", null, 1)
            };
            Scanner scanner = new(program, reporter);
            List<Token> scanned = scanner.ScanTokens();
            Assert.AreEqual(0, reporter.Errors.Count);
            foreach((Token a, Token b) in expected.Zip(scanned))
            {
                Assert.AreEqual(a, b);
            }
        }
    }
}
