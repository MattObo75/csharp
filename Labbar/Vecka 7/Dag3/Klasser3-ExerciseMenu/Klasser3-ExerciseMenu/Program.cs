using System.Reflection.PortableExecutable;

namespace Klasser3_ExerciseMenu
{
    internal class Program
    {
        static List<Reader> readers = new List<Reader>();
        static List<Book> books = new List<Book>();
        static void Main(string[] args)
        {
            bool running = true;

            while (running)
            {
                Console.WriteLine("\n=== MAGISKT BIBLIOTEK ===");
                Console.WriteLine("1. Lägg till läsare");
                Console.WriteLine("2. Lägg till bok");
                Console.WriteLine("3. Simulera bokläsning");
                Console.WriteLine("4. Statistik");
                Console.WriteLine("5. Visa alla läsare");
                Console.WriteLine("6. Avsluta");
                Console.Write("Välj: ");

                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1": AddReader(); break;
                    case "2": AddBook(); break;
                    case "3": SimulateReading(); break;
                    case "4": ShowStatistics(); break;
                    case "5": ShowReaders(); break;
                    case "6": running = false; break;
                    default: Console.WriteLine("Ogiltigt val."); break;
                }
            }
        }
        static void AddReader()
        {
            Console.Write("Ange namn: ");
            string name = Console.ReadLine();

            Console.Write("Ange startenergi: ");
            if (!int.TryParse(Console.ReadLine(), out int energy))
            {
                energy = 100;
                Console.WriteLine("Ogiltig energi. Default 100 används.");
            }

            readers.Add(new Reader { Name = name, Energy = energy });
            Console.WriteLine("Läsare tillagd!");
        }

        static void AddBook()
        {
            Console.Write("Ange titel: ");
            string title = Console.ReadLine();

            Console.Write("Ange antal sidor: ");
            if (!int.TryParse(Console.ReadLine(), out int pages))
            {
                pages = 100;
                Console.WriteLine("Ogiltigt sidantal. Default 100 används.");
            }

            books.Add(new Book { Title = title, Pages = pages });
            Console.WriteLine("Bok tillagd!");
        }

        static void SimulateReading()
        {
            if (readers.Count == 0)
                readers.Add(new Reader { Name = "Standard-Läsare", Energy = 100 });

            if (books.Count == 0)
                books.Add(new Book { Title = "Standardbok", Pages = 50 });

            Random rand = Random.Shared;

            Reader reader = readers[rand.Next(readers.Count)];
            Book book = books[rand.Next(books.Count)];

            Console.WriteLine($"\n{reader.Name} försöker läsa '{book.Title}'...");

            if (reader.ReadBook(book))
            {
                LibraryService.LogRead();
                Console.WriteLine($"Läsning lyckades! Energi kvar: {reader.Energy}");
            }
            else
            {
                Console.WriteLine("Inte tillräckligt med energi för att läsa boken.");
            }
        }

        static void ShowStatistics()
        {
            Console.WriteLine($"\nTotalt antal lästa böcker: {LibraryService.TotalBooksRead}");
        }

        static void ShowReaders()
        {
            Console.WriteLine("\n=== Alla läsare ===");

            if (readers.Count == 0)
            {
                Console.WriteLine("Inga registrerade läsare.");
                return;
            }

            foreach (var reader in readers)
            {
                string status = reader.IsExhausted ? "UTMATTAD" : "Aktiv";
                Console.WriteLine($"{reader.Name} - Energi: {reader.Energy} - Status: {status}");
            }
        }
        class Reader
        {
            public string Name { get; set; }
            public int Energy { get; set; }

            public bool IsExhausted => Energy <= 0;

            public bool ReadBook(Book book)
            {
                int energyNeeded = book.Pages / 2;

                if (IsExhausted)
                {
                    Console.WriteLine($"{Name} är för utmattad för att läsa.");
                    return false;
                }

                if (Energy < energyNeeded)
                    return false;

                Energy -= energyNeeded;

                if (Energy <= 0)
                    Console.WriteLine($"{Name} har blivit UTMATTAD!");

                return true;
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
