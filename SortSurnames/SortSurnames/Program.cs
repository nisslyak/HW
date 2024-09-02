namespace SortSurnames
{
    internal class Program
    {
        public class InvalidInputException : Exception
        {
            public InvalidInputException(string message) : base(message) { }
        }
        public delegate void SortSurnamesDelegate(List<string> surnames);

		public class Sorter
		{
			public event SortSurnamesDelegate SurnamesSorted;
            public void SortSurnames(List<string> surnames)
            {
                Console.WriteLine("Starting the sorting");
                OnProcessCompleted(surnames);
                Console.WriteLine("Sorting is complete");
            }

            protected virtual void OnProcessCompleted(List<string> surnames)
            {
                SurnamesSorted?.Invoke(surnames);
            }
        }


        static void Main(string[] args)
        {
			try
			{
                Sorter sorter = new Sorter();

                List<string> surnameList = new List<string>();
                surnameList.Add("Vladimirov");
                surnameList.Add("Makarova");
                surnameList.Add("Burdeed");
                surnameList.Add("Porohova");

                Console.WriteLine("Enter 1 for sorting A-Z or 2 for sorting Z-A:");
                string input = Console.ReadLine();

                if (input != "1" && input != "2")
                {
                    throw new InvalidInputException("Invalid input. Please enter 1 or 2.");
                }
                if (input == "1")
                {
                    sorter.SurnamesSorted += SortSurnamesAscending;
                }
                else
                {
                    sorter.SurnamesSorted += SortSurnamesDescending;
                }

                sorter.SortSurnames(surnameList);

                Console.WriteLine("\nSorted surnames:");
                foreach (var surname in surnameList)
                {
                    Console.WriteLine(surname);
                }
            }
			catch (InvalidInputException ex)
			{
                Console.WriteLine(ex.Message);
			}
			finally
			{
                Console.WriteLine("Program execution completed.");
            }
        }

        public static void SortSurnamesAscending(List<string> surnames)
        {
            surnames.Sort();
        }

        public static void SortSurnamesDescending(List<string> surnames)
        {
            surnames.Sort();
            surnames.Reverse();
        }
    }
}
