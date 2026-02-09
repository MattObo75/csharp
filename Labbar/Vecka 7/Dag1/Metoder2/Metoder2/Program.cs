namespace Metoder2
{
    internal class Program
    {
        /*
        Övning 1
        Unika värden i vald kolumn från textfil.

        Skapa ett program som:
        1. Anropar den befintliga funktionen som returnerar kolumnnamn
        2. Skriver ut alla kolumnnamn med index i konsolen (exempel: 0 = Country, 1 = Population, osv.)
        3. Låter användaren ange vilken kolumn som ska analyseras
        4. Läser igenom hela filen och:
        - hoppar över tomma rader eller rader med bara blanksteg.
        - ignorerar rubrikraden.
        - samlar alla värden i vald kolumn.
        5. Beräknar vilka värden som är unika 
        6. Skriver ut:
        - den valda kolumnens namn.
        - alla unika värden.
        - antal unika värden.
        */
        static void Main(string[] args)
        {
            // Sökväg till filen som används av båda övningarna
            string filePath = "X:\\source\\c#\\Labbar\\Vecka 7\\Dag1\\Metoder2\\Countries_area.txt";
            
            // Hämtar kolumnnamn en gång och återanvänder dem
            string[] columnNames = GetColumnNames(filePath);

            // Styr om programmet ska fortsätta köra
            bool runProgram = true;

            // Huvudloop för menyn
            while (runProgram)
            {
                // Skriver ut menyval till användaren
                Console.WriteLine();
                Console.WriteLine("Välj övning:");
                Console.WriteLine("1. Övning 1 – Unika värden i vald kolumn");
                Console.WriteLine("2. Övning 2 – Konvertering km till meter");
                Console.WriteLine("3. Avsluta");
                Console.Write("Ditt val: ");

                // Läser in användarens val
                string choice = Console.ReadLine();

                // Switch som avgör vad som ska köras
                switch (choice)
                {
                    case "1":
                        // Kör logiken för Övning 1
                        RunExercise1(filePath, columnNames);
                        break;

                    case "2":
                        // Kör (eller visar placeholder för) Övning 2
                        RunExercise2(filePath, columnNames);
                        break;

                    case "3":
                        // Avslutar programmet
                        Console.WriteLine("Programmet avslutas...");
                        runProgram = false;
                        break;

                    default:
                        // Hanterar ogiltiga menyval
                        Console.WriteLine("Ogiltigt val. Försök igen.");
                        break;
                }
            }
        }

        // ===========================
        // ÖVNING 1
        // ===========================

        // Kör hela logiken för Övning 1:
        // läser kolumnnamn, låter användaren välja kolumn,
        // beräknar unika värden och skriver ut resultatet.
        static void RunExercise1(string filePath, string[] columnNames)
        {   
            // Skriver ut alla kolumnnamn med index
            PrintColumnNames(columnNames);

            // Låter användaren välja kolumn
            int columnIndex = GetColumnIndexFromUser(columnNames.Length);

            // Hämtar alla värden i vald kolumn
            List<string> values = GetColumnValues(filePath, columnIndex);

            // Tar fram unika värden (LINQ utan lambda)
            IEnumerable<string> uniqueValues = values.Distinct();

            // Skriver ut slutresultatet
            PrintResultExercise1(columnNames[columnIndex], uniqueValues);
        }

        // ===========================
        // ÖVNING 2 
        // ===========================

        // Läser kolumnnamn och hämtar alla värden i kolumnen AreaKm2.
        // Omvandlar värdena från km² → m²
        // Returnerar en array med alla beräknade värden i m².
        // Resultatet skrivs ut på skärmen
        static void RunExercise2(string filePath, string[] columnNames)
        {
            Console.WriteLine();
            Console.WriteLine("Övning 2 – Konvertering km till meter");

            // Sätt index till 4 (AreaKm2)
            int columnIndex = 4; 

            // Hämtar alla värden i kolumn 4
            List<string> kmValues = GetColumnValues(filePath, columnIndex);

            // Konverterar värdena från km till meter
            List<double> meterValues = ConvertKmToMeters(kmValues);

            // Skriver ut slutresultatet
            PrintResultExercise2(columnNames[columnIndex], meterValues);
        }

        // ===========================
        // HJÄLPMETODER
        // ===========================

        // Skriver ut alla kolumnnamn tillsammans med deras index.
        public static void PrintColumnNames(string[] columnNames)
        {
            Console.WriteLine("Kolumnnamn:");

            for (int i = 0; i < columnNames.Length; i++)
            {
                Console.WriteLine($"{i} = {columnNames[i]}");
            }
        }

        // Låter användaren ange ett giltigt kolumnindex.
        // Validerar inmatningen så att indexet finns.
        public static int GetColumnIndexFromUser(int maxIndex)
        {
            Console.Write("Ange index för kolumn att analysera: ");
            int index;

            // Upprepar tills användaren anger ett giltigt heltal
            while (!int.TryParse(Console.ReadLine(), out index) || index < 0 || index >= maxIndex)
            {
                Console.Write("Ogiltigt index. Ange ett giltigt index: ");
            }

            return index;
        }

        // Läser igenom hela filen och samlar alla värden i den valda kolumnen.
        // Hoppar över tomma rader och ignorerar rubrikraden.
        public static List<string> GetColumnValues(string filePath, int columnIndex)
        {
            // Lista som lagrar värden från vald kolumn
            List<string> values = new List<string>();

            // Läser in alla rader från filen
            string[] lines = File.ReadAllLines(filePath);

            // Används för att hoppa över rubrikraden en gång
            bool headerSkipped = false;

            foreach (string line in lines)
            {
                // Hoppar över tomma rader
                if (string.IsNullOrWhiteSpace(line))
                    continue;

                // Första giltiga raden är rubrikraden
                if (!headerSkipped)
                {
                    headerSkipped = true;
                    continue;
                }

                // Delar upp raden i kolumner
                string[] parts = line.Split(';');

                // Säkerställer att kolumnindex finns i raden
                if (columnIndex < parts.Length)
                {
                    string trimmedValue = parts[columnIndex].Trim();

                    if (!string.IsNullOrWhiteSpace(trimmedValue))
                    {
                        values.Add(trimmedValue);
                    }
                }
            }

            return values;
        }

        // Läser första giltiga raden i filen och returnerar kolumnnamnen.
        // Återanvänds för att undvika duplicerad logik.
        public static string[] GetColumnNames(string filePath)
        {
            // Läser alla rader i filen
            string[] lines = File.ReadAllLines(filePath);

            foreach (string line in lines)
            {
                // Hoppar över tomma rader
                if (string.IsNullOrWhiteSpace(line))
                    continue;

                // Första giltiga raden innehåller kolumnnamn
                return line.Split(';');
            }

            // Returneras om ingen giltig rad hittas
            return Array.Empty<string>();
        }

        // Skriver ut kolumnnamn, alla unika värden samt antal unika värden.
        public static void PrintResultExercise1(string columnName, IEnumerable<string> uniqueValues)
        {
            Console.WriteLine();
            Console.WriteLine($"Vald kolumn: {columnName}");
            Console.WriteLine("Unika värden:");

            foreach (string value in uniqueValues)
            {
                Console.WriteLine(value);
            }

            Console.WriteLine($"Antal unika värden: {uniqueValues.Count()}");
        }        
        
        public static List<double> ConvertKmToMeters(List<string> kmValues)
        {
            List<double> valuesInMeters = new List<double>();

            foreach (string value in kmValues)
            {
                double km;

                // Försöker tolka värdet som ett tal
                if (double.TryParse(value, out km))
                {
                    // Konverterar km till meter
                    valuesInMeters.Add(km * 1000);
                }
            }

            return valuesInMeters;
        }
        public static void PrintResultExercise2(string columnName, List<double> meterValues)
        {
            Console.WriteLine();
            Console.WriteLine($"Vald kolumn: {columnName}");
            Console.WriteLine("Värden i meter:");
            foreach (double value in meterValues)
            {
                Console.WriteLine($"{value} m");
            }
            Console.WriteLine($"Antal konverterade värden: {meterValues.Count}");
        }
    }
}
