using System.Reflection.PortableExecutable;

namespace Klasser3_Exercise
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Book b1 = new Book { Title = "Magic 101", Pages = 100 };
            Book b2 = new Book { Title = "Potion Secrets", Pages = 50 };

            Reader r1 = new Reader { Name = "Alice", Energy = 100 };
            Reader r2 = new Reader { Name = "Bob", Energy = 80 };

            // Alice läser Magic 101
            int usedEnergy = r1.ReadBook(b1);
            LibraryService.LogRead();
            Console.WriteLine($"{r1.Name} använde {usedEnergy} energi. Energy kvar: {r1.Energy}");

            // Bob läser Potion Secrets
            usedEnergy = r2.ReadBook(b2);
            LibraryService.LogRead();
            Console.WriteLine($"{r2.Name} använde {usedEnergy} energi. Energy kvar: {r2.Energy}");

            // Visa totala antal lästa böcker
            Console.WriteLine($"Totalt lästa böcker: {LibraryService.TotalBooksRead}");
        }

        class Reader
        {
            public string Name { get; set; }
            public int Energy { get; set; }

            public int ReadBook(Book book)
            {
                int energyUsed = book.Pages / 2;
                Energy -= energyUsed;
                return energyUsed;
            }
        }

        class Book
        {
            public string Title { get; set; }
            public int Pages { get; set; }
        }

        static class LibraryService
        {
            public static int TotalBooksRead = 0;
            public static void LogRead()
            {
                TotalBooksRead++;
            }
        }
    }
}
