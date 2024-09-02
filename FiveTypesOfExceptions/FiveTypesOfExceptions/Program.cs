namespace FiveTypesOfExceptions
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");

            Exception[] exceptions = new Exception[]
            {
                new DivideByZeroException() ,
                new MyException(),
                new ArgumentException(),
                new FileNotFoundException(),
                new FormatException()
            };

            try
            {
                for (int i = 0; i < exceptions.Length; i++)
                {
                    try
                    {
                        throw exceptions[i];
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e.ToString());
                    }
                    finally
                    {
                        Console.WriteLine("This is block finally");
                    }
                }
            }
            catch (Exception)
            {

                throw;
            }
            Console.Read();
        }

        public class MyException: Exception
        {
            public MyException() { }

            public MyException(string message): base(message)
            { }
        }
    }
}
