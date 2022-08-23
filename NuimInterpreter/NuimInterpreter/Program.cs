namespace NuimInterpreter
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string program = "" +
                "test : int -> int => int; \n" + 
                "# comment test\n" +
                "test x y = 2a4.32 16 \"Hello, World! stdout println$;";
            Scanning.Scanner s = new(program, new(Console.Error));
            List<Scanning.Token> tokens = s.ScanTokens();
            tokens.ForEach(Console.WriteLine);
        }
    }
}