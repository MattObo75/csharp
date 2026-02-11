namespace Klasser3_ExerciseLibrary
{    

    // ========================================
    // HUVUDPROGRAM
    // ========================================
    internal class Program
    {
        // Globalt bibliotek och lista över läsare
        static Library library = new Library();
        static List<Reader> readers = new List<Reader>();

        static void Main(string[] args)
        {
            // Exempelböcker
            library.AddBook(new Book { Title = "Magi och mysterier", Pages = 120 });
            library.AddBook(new Book { Title = "Äventyret börjar", Pages = 90 });

            // Exempelläsare
            readers.Add(new Reader { Name = "Alice", Energy = 100 });
            readers.Add(new Reader { Name = "Bob", Energy = 80 });

            bool running = true; // Flagga för huvudloopen

            while (running)
            {
                // Meny för användaren
                Console.WriteLine("\n=== MAGISKT BIBLIOTEK ===");
                Console.WriteLine("1. Lägg till bok");
                Console.WriteLine("2. Ta bort bok");
                Console.WriteLine("3. Visa böcker");
                Console.WriteLine("4. Hitta bok");
                Console.WriteLine("5. Låna bok");
                Console.WriteLine("6. Återlämna bok");
                Console.WriteLine("7. Lägg till läsare");
                Console.WriteLine("8. Statistik");
                Console.WriteLine("9. Visa alla läsare");
                Console.WriteLine("10. Simulera bokläsning");
                Console.WriteLine("11. Vila");
                Console.WriteLine("12. Avsluta");
                Console.Write("Välj: ");

                string choice = Console.ReadLine();

                // Anropar metod baserat på användarens val
                switch (choice)
                {
                    case "1": AddBook(); break;
                    case "2": RemoveBook(); break;
                    case "3": library.ShowBooks(); break;
                    case "4": FindBook(); break;
                    case "5": BorrowBook(); break;
                    case "6": ReturnBook(); break;
                    case "7": AddReader(); break;
                    case "8": ShowStatistics(); break;
                    case "9": ShowReaders(); break;
                    case "10": SimulateReading(); break;
                    case "11": Rest(); break;
                    case "12": running = false; break;
                    default: Console.WriteLine("Ogiltigt val."); break;
                }
            }
        }

        // ========================================
        // METODER FÖR BOKHANTERING
        // ========================================

        static void AddBook()
        {
            Console.Write("Ange titel: ");
            string title = Console.ReadLine();

            Console.Write("Ange antal sidor: ");
            // Försök konvertera input till int, annars använd 100 som default
            if (!int.TryParse(Console.ReadLine(), out int pages))
            {
                pages = 100;
                Console.WriteLine("Ogiltigt sidantal. Default 100 används.");
            }

            // Skapa och lägg till boken i biblioteket
            library.AddBook(new Book { Title = title, Pages = pages });
            Console.WriteLine("Bok tillagd!");
        }

        static void RemoveBook()
        {
            Console.Write("Ange titel på boken som ska tas bort: ");
            string title = Console.ReadLine();

            // Hitta boken i biblioteket
            Book book = library.FindBook(title);
            if (book == null)
            {
                Console.WriteLine("Boken finns inte i biblioteket.");
                return;
            }

            // Ta bort boken
            library.RemoveBook(book);
            Console.WriteLine($"Boken '{title}' har tagits bort.");
        }

        static void FindBook()
        {
            Console.Write("Ange titel: ");
            string title = Console.ReadLine();

            Book book = library.FindBook(title);
            if (book != null)
                Console.WriteLine($"Boken hittades: {book.Title} ({book.Pages} sidor)");
            else
                Console.WriteLine("Boken hittades inte.");
        }

        // ========================================
        // METODER FÖR LÅNA/ÅTERLÄMNA BOK
        // ========================================

        static void BorrowBook()
        {
            Reader reader = SelectReader(); // Välj en läsare
            if (reader == null) return;

            Console.Write("Ange titel på boken som ska lånas: ");
            string title = Console.ReadLine();

            Book book = library.FindBook(title);
            if (book == null)
            {
                Console.WriteLine("Boken finns inte i biblioteket.");
                return;
            }

            // Försök låna boken
            if (reader.BorrowBook(book, library))
                Console.WriteLine($"{reader.Name} har lånat '{book.Title}'.");
            else
                Console.WriteLine("Boken kunde inte lånas.");
        }

        static void ReturnBook()
        {
            Reader reader = SelectReader(); // Välj en läsare
            if (reader == null) return;

            Console.Write("Ange titel på boken som ska återlämnas: ");
            string title = Console.ReadLine();

            // Kontrollera att läsaren verkligen lånat boken
            Book book = reader.BorrowedBooks.Find(b => b.Title == title);
            if (book == null)
            {
                Console.WriteLine("Du har inte lånat denna bok.");
                return;
            }

            // Återlämna boken till biblioteket
            reader.ReturnBook(book, library);
            Console.WriteLine($"{reader.Name} har återlämnat '{book.Title}'.");
        }

        // ========================================
        // METODER FÖR LÄSARE
        // ========================================

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

            // Skapa och lägg till läsaren i listan
            readers.Add(new Reader { Name = name, Energy = energy });
            Console.WriteLine("Läsare tillagd!");
        }

        static void SimulateReading()
        {
            Reader reader = SelectReader(); // Välj en läsare
            if (reader == null) return;

            if (reader.BorrowedBooks.Count == 0)
            {
                Console.WriteLine("Du har inga lånade böcker att läsa.");
                return;
            }

            Random rand = Random.Shared;
            Book book = reader.BorrowedBooks[rand.Next(reader.BorrowedBooks.Count)];

            Console.WriteLine($"\n{reader.Name} försöker läsa '{book.Title}'...");

            // Försök läsa boken, minskar energi
            if (reader.ReadBook(book))
            {
                LibraryService.LogRead(); // Logga läsningen
                Console.WriteLine($"Läsning lyckades! Energi kvar: {reader.Energy}");
            }
            else
            {
                Console.WriteLine("Inte tillräckligt med energi för att läsa boken.");
            }
        }

        static void Rest()
        {
            Reader reader = SelectReader(); // Välj en läsare
            if (reader == null) return;

            reader.Rest(); // Öka energi
            Console.WriteLine($"{reader.Name} har vilat och fått +40 energi. Nuvarande energi: {reader.Energy}");
        }

        // Hjälpmetod för att välja en läsare
        static Reader SelectReader()
        {
            if (readers.Count == 0)
            {
                Console.WriteLine("Inga läsare finns.");
                return null;
            }

            Console.WriteLine("Välj läsare:");
            for (int i = 0; i < readers.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {readers[i].Name} (Energi: {readers[i].Energy})");
            }

            if (!int.TryParse(Console.ReadLine(), out int choice) || choice < 1 || choice > readers.Count)
            {
                Console.WriteLine("Ogiltigt val.");
                return null;
            }

            return readers[choice - 1];
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

            // Visa varje läsare med status och antal lånade böcker
            foreach (var reader in readers)
            {
                string status = reader.IsExhausted ? "UTMATTAD" : "Aktiv";
                Console.WriteLine($"{reader.Name} - Energi: {reader.Energy} - Status: {status} - Lånade böcker: {reader.BorrowedBooks.Count}");
            }
        }
    }

    // ========================================
    // KLASS FÖR LÄSARE
    // ========================================
    class Reader
    {
        public string Name { get; set; } // Läsares namn
        public int Energy { get; set; }   // Läsares nuvarande energi
        public List<Book> BorrowedBooks { get; set; } = new List<Book>(); // Lånade böcker

        public bool IsExhausted => Energy <= 0; // Är läsaren utmattad?

        // Låna en bok från biblioteket
        public bool BorrowBook(Book book, Library library)
        {
            if (!library.Books.Contains(book)) return false;

            BorrowedBooks.Add(book);
            library.RemoveBook(book);
            return true;
        }

        // Återlämna en bok till biblioteket
        public void ReturnBook(Book book, Library library)
        {
            BorrowedBooks.Remove(book);
            library.AddBook(book);
        }

        // Läs en bok och minska energi
        public bool ReadBook(Book book)
        {
            if (IsExhausted)
            {
                Console.WriteLine($"{Name} är för utmattad för att läsa.");
                return false;
            }

            int energyNeeded = book.Pages / 2; // Energiförbrukning baserat på sidantal
            if (Energy < energyNeeded) return false;

            Energy -= energyNeeded;
            if (Energy <= 0)
                Console.WriteLine($"{Name} har blivit UTMATTAD!");

            return true;
        }

        // Vila för att återställa energi
        public void Rest()
        {
            Energy += 40;
        }
    }

    // ========================================
    // KLASS FÖR BÖCKER
    // ========================================
    class Book
    {
        public string Title { get; set; } // Boktitel
        public int Pages { get; set; }    // Antal sidor
    }

    // ========================================
    // KLASS FÖR BIBLIOTEK
    // ========================================
    class Library
    {
        public List<Book> Books { get; set; } = new List<Book>();

        public void AddBook(Book book)
        {
            Books.Add(book);
        }

        public void RemoveBook(Book book)
        {
            Books.Remove(book);
        }

        public void ShowBooks()
        {
            Console.WriteLine("\n=== Böcker i biblioteket ===");
            if (Books.Count == 0)
            {
                Console.WriteLine("Inga böcker finns.");
                return;
            }

            foreach (var book in Books)
            {
                Console.WriteLine($"{book.Title} - {book.Pages} sidor");
            }
        }

        public Book FindBook(string title)
        {
            return Books.Find(b => b.Title.Equals(title, StringComparison.OrdinalIgnoreCase));
        }
    }

    // ========================================
    // STATISTIK OCH SERVICE FÖR BIBLIOTEKET
    // ========================================
    static class LibraryService
    {
        public static int TotalBooksRead = 0; // Totalt antal lästa böcker

        // Logga varje gång en bok läses
        public static void LogRead()
        {
            TotalBooksRead++;
        }
    }
}
