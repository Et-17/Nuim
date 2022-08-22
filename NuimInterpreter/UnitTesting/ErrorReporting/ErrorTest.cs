using NuimInterpreter.ErrorReporting;

namespace UnitTesting.ErrorReporting
{
    [TestClass]
    public class ErrorTest
    {
        [TestMethod]
        public void InvalidLineNumber()
        {
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => new Error(-5));
        }

        [TestMethod]
        public void Construction()
        {
            Assert.AreEqual(new Error(15).LineNumber, 15);
        }
    }
}
