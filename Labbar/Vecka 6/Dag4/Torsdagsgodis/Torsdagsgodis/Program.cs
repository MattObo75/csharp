/*
Torsdagsgodis
Vi gör ett console program som läser in en textfil som innehåller informationen om olika länder. Det finns fyra kolumner med data: 
Country, Population, GDP och Currency. 
När filen är inläst så ska programmet lägga ut innehållet i en ny lista, kolla om det finns tomma rader i den filen och rensa ut dessa
och som sista åtgärden, kolla upp om det finns några länder som börjar på bokstaven S. Dessa länder kommer då att sparas i en till lista och visas upp i Consolen.
Vi skapar en algoritm som är en sekvens av steg, d v s vad och i vilken ordning behöver göras för att skapa ett sådant program.
1. Läs in filens namn i en variabel.
Det kan göras enkelt om vi känner till lagringsplatsen.
string filePath = @"X:\source\c#\Labbar\Dag4\Countries.txt";
2. Skapa ett objekt av fillänken med StreamReader() klassen som har inputargument av typen sträng. Vi sänder filllänken dit. 
Nu har vi hela innehållet av filen i variabeln reader. using ser till att filen stängs automatiskt. 
Using används för alla objekt som anropar externa resurser och behöver städas upp när allt är klart, t ex:
- filer
- nätverk
- databaskopplingar
- strömmar
- grafik / GDI
3. StreamReader har en metod ReadLine() som läser en rad i taget och flyttar till nästa rad. Vi använder ReadLine() inne i StreamReader(). 
All filinläsning måste ske där. Vi lägger raderna i en lista allLInes. Den måste skapas i förväg.
4. Vi kan kolla upp den inlästa filen huruvida det kom upp några tomma rader eller blanksteg. 
Det kan testas om använder en metod som finns i string på vår lista och använder IsNullOrWhiteSpace() för det. 
Det returnerar true om det finns blanksteg eller något saknas. Vi kan använda foreach eller for-loop. 
Som ni ser, behövs en till lista validCountries, som ska skapas i förväg.
5. Nu har vi en lista validCountries som innehåller rader där varje rad är en sträng som innehåller namn, befolkningsmängd, bnp och valutakoden. 
Vi kan använda foreach för att skapa ett villkor och hitta de raderna där namn på landet börjar på ett S. 
Vi måste förstå att varje rad i validCountries ser ut så här: Sweden;10500000;635000000000;SEK 
Då splittar vi varje rad i strängar och sedan kommer åt den första strängen. 
*/

using System;
using System.Collections.Generic;
using System.Reflection.PortableExecutable;
using System.Runtime.ConstrainedExecution;
using System.Runtime.Intrinsics.Arm;

/*
Övning 1
Beräkna GDP per capita (GDP / Population) för varje land och:
- Spara endast de länder där GDP per capita är över ett visst värde.
- Sortera resultatet i fallande ordning.
- Visa de 5 rikaste länderna per invånare.
Krav
- Använd samma textfil.
- Läs in data som i din kod.
Använd:
- Split
- TryParse
- LINQ
- minst en foreach
- Hantera felaktiga data utan att programmet kraschar.

Tips:
GDP och Population är strängar: måste konverteras till double / long
GDP per capita = GDP / Population
Använd:
- OrderByDescending(...)
- Take(5)

try
{
    // Sökväg till textfilen
    string filePath = @"X:\source\c#\Labbar\Dag4\Countries.txt";

    // Lista som lagrar alla rader från filen
    List<string> allLines = new List<string>();

    // Läs filen säkert med StreamReader
    using (StreamReader reader = new StreamReader(filePath))
    {
        string line;
        while ((line = reader.ReadLine()) != null)
        {
            allLines.Add(line);
        }
    }

    // Lista för icke-tomma rader
    List<string> validCountries = new List<string>();
    foreach (string country in allLines)
    {
        if (!string.IsNullOrWhiteSpace(country))
        {
            validCountries.Add(country);
        }
    }

    // Lista som lagrar rika länder (namn + BNP per capita)
    List<(string Country, double GDPPerCapita)> richCountries = new List<(string, double)>();

    foreach (string country in validCountries)
    {
        // Dela upp raden med semikolon
        string[] parts = country.Split(';');

        // Säkerställ korrekt format
        if (parts.Length == 4)
        {
            string name = parts[0];

            // Försök tolka siffror
            if (double.TryParse(parts[1], out double population) && double.TryParse(parts[2], out double gdp))
            {
                // Skydda mot division med noll
                if (population > 0)
                {
                    double gdpPerCapita = gdp / population;

                    if (gdpPerCapita > 50000)
                    {
                        richCountries.Add((name, gdpPerCapita));
                    }
                }
            }
        }
    }

    // Sortera fallande och välj topp 5
    var topRichCountries = richCountries.OrderByDescending(c => c.GDPPerCapita).Take(5);

    Console.WriteLine("De 5 rikaste länderna per invånare:");
    Console.WriteLine("-----------------------------------");

    foreach (var country in topRichCountries)   // stega igenom de 5 rikaste länderna
    {
        // skriver ut namnet på landet och dess BNP per capita i valutaformat
        Console.WriteLine($"{country.Country}: {country.GDPPerCapita:C}");
    }
}
// Fångar fel om filen inte hittas
catch (FileNotFoundException)
{
    Console.WriteLine("Fel: Filen hittades inte. Kontrollera sökvägen.");
}
// Fångar fel vid åtkomst (t.ex. saknade rättigheter)
catch (UnauthorizedAccessException)
{
    Console.WriteLine("Fel: Du saknar behörighet att läsa filen.");
}
// Fångar alla andra oväntade fel
catch (Exception ex)
{
    Console.WriteLine("Ett oväntat fel inträffade:");
    Console.WriteLine(ex.Message);
}
*/
/*
Övning 2
Analysera valutor i filen och ta reda på:
- Hur många länder använder varje valuta.
- Vilken valuta som används av flest länder.
- Lista alla länder som använder den valutan.
Krav
Använd:
- GroupBy
- Count
- Where
- Minst en lösning med foreach
- Skriv ut resultatet på ett tydligt sätt i konsolen
- Hantera felaktiga data utan att programmet kraschar.
- Kommentera koden
*/

try
{
    // Absolute path to the text file containing country data.
    // The file is expected to be semicolon-separated.
    string filePath = @"X:\source\c#\Labbar\Dag4\Countries.txt";

    // A list of tuples to store country name and its currency.
    // Tuple format: (Country, Currency)
    List<(string Country, string Currency)> countries = new();

    // StreamReader is used to read the file line by line.
    // "using" ensures the file is closed and resources are released automatically.
    using (StreamReader reader = new StreamReader(filePath))
    {
        // Reads and discards the first line (typically a header row).
        reader.ReadLine();

        string line;

        // Reads the file one line at a time until the end of the file is reached.
        while ((line = reader.ReadLine()) != null)
        {
            // Skip empty lines or lines that only contain whitespace.
            if (string.IsNullOrWhiteSpace(line))
                continue;

            // Split the line into parts using ';' as the delimiter.
            // Each line is expected to have exactly 4 columns.
            string[] parts = line.Split(';');

            // If the line does not contain exactly 4 columns,
            // it is considered invalid and skipped.
            if (parts.Length != 4)
                continue;

            // Extract the country name (column 1) and remove extra whitespace.
            string country = parts[0].Trim();

            // Extract the currency (column 4) and remove extra whitespace.
            string currency = parts[3].Trim();

            // Only add the data if both country and currency are non-empty.
            if (!string.IsNullOrWhiteSpace(country) &&
                !string.IsNullOrWhiteSpace(currency))
            {
                // Add a tuple containing country and currency to the list.
                countries.Add((country, currency));
            }
        }
    }

    // Group the countries by currency using LINQ.
    var currencyGroups = countries
        .GroupBy(c => c.Currency)       // Group by the Currency field
        .Select(group => new            // Project each group into a new anonymous object
        {
            Currency = group.Key,       // The currency name (group key)
            Count = group.Count(),      // Number of countries using this currency
            Countries = group
                .Select(c => c.Country) // List of country names in the group
                .ToList()
        })
        .OrderByDescending(group => group.Count) // Sort currencies by usage (most first)
        .ToList();

    // Print header for the currency summary.
    Console.WriteLine("Antal länder per valuta:");
    Console.WriteLine("------------------------");

    // Loop through each currency group and print how many countries use it.
    foreach (var group in currencyGroups)
    {
        // Handle singular vs plural ("land" vs "länder").
        if (group.Count > 1)
        {
            Console.WriteLine($"{group.Currency}: {group.Count} länder");
        }
        else
        {
            Console.WriteLine($"{group.Currency}: {group.Count} land");
        }
    }

    // Find the highest number of countries using the same currency.
    int maxCount = currencyGroups.Max(g => g.Count);

    // Find all currencies that are used by this maximum number of countries.
    var mostUsedCurrencies = currencyGroups
        .Where(g => g.Count == maxCount)
        .ToList();

    // Print header for the most-used currency section.
    Console.WriteLine();
    Console.WriteLine("Valuta som används av flest länder:");
    Console.WriteLine("----------------------------------");

    // Loop through the most-used currencies (handles ties).
    foreach (var currency in mostUsedCurrencies)
    {
        // Print the currency name and how many countries use it.
        Console.WriteLine($"{currency.Currency}: ({currency.Count} länder)");
        Console.WriteLine("Länder:");

        // Print each country that uses this currency.
        foreach (string country in currency.Countries)
        {
            Console.WriteLine($"- {country}");
        }

        // Blank line for better readability between currencies.
        Console.WriteLine();
    }
}
catch (FileNotFoundException)
{
    // Thrown if the file path is invalid or the file does not exist.
    Console.WriteLine("Fel: Filen hittades inte.");
}
catch (UnauthorizedAccessException)
{
    // Thrown if the program does not have permission to read the file.
    Console.WriteLine("Fel: Åtkomst till filen nekades.");
}
catch (Exception ex)
{
    // Catches any other unexpected errors.
    Console.WriteLine("Ett oväntat fel inträffade:");
    Console.WriteLine(ex.Message);
}

var hello = 10;
if (hello == 10)
    Console.WriteLine("Svaret är 10");
else if (hello == 20)
    Console.WriteLine("Svaret är 20");
else
    Console.WriteLine("Svaret är varken 10 eller 20");