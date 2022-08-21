namespace NuimInterpreter
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(new Scanning.Token(Scanning.TokenType.INTEGER, "123", 123, 15));
        }
    }
}