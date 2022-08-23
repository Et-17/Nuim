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

        [TestMethod]
        public void EqualityNonNullLiteral()
        {
            Token tok1 = new(TokenType.APPLICATION, "placeholder", 123, 5);
            Token tok2 = new(TokenType.APPLICATION, "placeholder", 123, 5);
            Assert.AreEqual(tok1, tok2);
        }

        [TestMethod]
        public void EqualityNullLiteral()
        {
            Token tok1 = new(TokenType.APPLICATION, "placeholder", null, 5);
            Token tok2 = new(TokenType.APPLICATION, "placeholder", null, 5);
            Assert.AreEqual(tok1, tok2);
        }

        [TestMethod]
        public void NonEquality()
        {
            Token tok1 = new(TokenType.APPLICATION, "placeholder", 123, 5);
            Token tok2 = new(TokenType.INTEGER, "holderplace", 456, 5);
            Assert.AreNotEqual(tok1, tok2);
        }

        [TestMethod]
        public void InvalidEqualityQuery()
        {
            Token tok1 = new(TokenType.APPLICATION, "placeholder", 123, 5);
            Assert.IsFalse(tok1.Equals(null));
            Assert.IsFalse(tok1.Equals(123));
        }

        [TestMethod]
        public void SelfSimilarity()
        {
            Token tok1 = new(TokenType.APPLICATION, "placeholder", 123, 5);
            Assert.AreEqual(tok1, tok1);
        }

        [TestMethod]
        public void ReferencedEquality()
        {
            List<Token> tokl1 = new() { new(TokenType.APPLICATION, "placeholder", 123, 5) };
            List<Token> tokl2 = new() { new(TokenType.APPLICATION, "placeholder", 123, 5) };
            Assert.AreEqual(tokl1[0], tokl2[0]);
        }
    }
}
