using NuimInterpreter.Scanning;

namespace UnitTesting.Scanning
{
    [TestClass]
    public class TokenTest
    {
        [TestMethod]
        public void InvalidTokenCreation()
        {
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => new Token(TokenType.EOF, "placeholder", null, -5));
        }

        [TestMethod]
        public void TokenCreationNullLiteral()
        {
            Token tok = new(TokenType.EOF, "placeholder", null, 5);
            Assert.AreEqual(TokenType.EOF, tok.Type);
            Assert.AreEqual("placeholder", tok.Lexeme);
            Assert.IsNull(tok.Literal);
            Assert.AreEqual(5, tok.Line);
        }

        [TestMethod]
        public void TokenCreationFilledLiteral()
        {
            Token tok = new(TokenType.EOF, "placeholder", 123, 5);
            Assert.AreEqual(TokenType.EOF, tok.Type);
            Assert.AreEqual("placeholder", tok.Lexeme);
            Assert.AreEqual(123, tok.Literal);
            Assert.AreEqual(5, tok.Line);
        }

        [TestMethod]
        public void ToStringConversion()
        {
            foreach (TokenType type in Enum.GetValues(typeof(TokenType)))
            {
                Token tok = new(type, "placeholder", null, 5);
                Assert.AreEqual(String.Format("{0}: placeholder", type), tok.ToString());
            }
        }
    }
}
