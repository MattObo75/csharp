/*
Console.Write("Ange din ålder: ");
int age = int.Parse(Console.ReadLine());

if (age >= 18) { 
    Console.WriteLine("Du är myndig.");
}
else { 
    Console.WriteLine("Du är omyndig.");
}
*/
/*
Console.Write("Ange betyg (A-F): ");

string grade = Console.ReadLine().ToUpper();

if (grade == "F") { 
    Console.WriteLine("Ej godkänd"); 
} else { 
    Console.WriteLine("Godkänd"); 
}
*/
/*
Console.Write("Ange din ålder: "); 
int age2 = int.Parse(Console.ReadLine());

if (age2 < 18) { 
    Console.WriteLine("Omyndig"); 
} 
else if (age2 == 18) { 
    Console.WriteLine("Exakt 18!"); 
} 
else { 
    Console.WriteLine("Myndig");
}
*/
/*
Console.Write("Ange betyg (A-F): "); 
string grade = Console.ReadLine().ToUpper();

switch (grade) {
    
    case "A": 
    case "B": 
    case "C": 
        Console.WriteLine("Godkänd"); 
        break; 
    case "D": 
    case "E": 
        Console.WriteLine("Godkänd med viss reservation"); 
        break; 
    case "F": 
        Console.WriteLine("Ej godkänd"); 
        break; 
    default: 
        Console.WriteLine("Okänt betyg"); 
        break; 
}
*/
/*
Console.WriteLine("Välj alternativ:"); 
Console.WriteLine("1 - Säg hej"); 
Console.WriteLine("2 - Visa dagens datum"); 
Console.WriteLine("3 - Avsluta");

string choice = Console.ReadLine();

switch (choice)
{
    case "1":
        Console.WriteLine("Hej!");
        break;
    case "2":
        Console.WriteLine($"Dagens datum är {DateTime.Now.ToShortDateString()}");
        break;
    case "3":
        Console.WriteLine("Programmet avslutas...");
        break;
    default:
        Console.WriteLine("Okänt val");
        break;
}
*/
/*
Console.Write("Ange poäng (0-100): "); 
string input = Console.ReadLine(); 
int poang;

// Kontrollera att inmatningen är ett heltal
if (!int.TryParse(input, out poang) || poang < 0 || poang > 100) { 
    Console.WriteLine("Felaktig inmatning! Ange ett heltal mellan 0 och 100."); 
    return; // Avsluta programmet
}

// Switch med numeriska intervall
switch (poang)
{
    case int n when (n >= 90 && n <= 100): 
        Console.WriteLine("Betyg A"); 
        break;
    case int n when (n >= 80 && n < 90): 
        Console.WriteLine("Betyg B"); 
        break;
    case int n when (n >= 70 && n < 80): 
        Console.WriteLine("Betyg C"); 
        break;
    case int n when (n >= 60 && n < 70): 
        Console.WriteLine("Betyg D"); 
        break;
    case int n when (n >= 50 && n < 60): 
        Console.WriteLine("Betyg E"); 
        break;
    default: 
        Console.WriteLine("Underkänt"); 
        break;
}
*/
/*
string mening = "Hej världen från C#"; 
string[] ord = mening.Split(' ');

if (ord.Contains("C#")) { 
    Console.WriteLine("Texten innehåller C#"); 
}
else { 
    Console.WriteLine("C# hittades inte");
}
*/

/* Övning 1 Temperaturkontroll
Mål: Träna if-else och strängmetoder.
Instruktion:
1. Be användaren skriva in temperaturen i grader Celsius.
2. Om temperaturen är under 0, skriv “Det är frost”.
3. Om temperaturen är mellan 0 och 20, skriv “Lite kyligt”.
4. Om temperaturen över 20, skriv “Det är varmt”.
5. Konvertera de inmatade värdena med TryParse.
6. Skapa nästlade if-villkor där TryParse är det första if-villkoret.
7. Be användaren skriva in ett kommentarsord om vädret, använd Trim() och ToUpper(), och skriv sedan ut det tillsammans med meddelandet.
8. Kommentera koden.


// Be användaren ange temperaturen i grader Celsius
Console.Write("Ange temperaturen i grader Celsius: ");
// Läs inmatningen som en sträng
string tempInput = Console.ReadLine();

// Försök konvertera strängen till decimal
if (decimal.TryParse(tempInput, out decimal temp))  // Om konverteringen lyckades = sant
{
    if (temp < 0)   // Om temperaturen är under 0
    {
        Console.WriteLine("Det är frost");
    }
    else if (temp > 0 && temp <= 20)    // Om temperaturen är mellan 0 och 20
    {
        Console.WriteLine("Lite kyligt");
    }
    else                                // Temperaturen är över 20
    {
        Console.WriteLine("Det är varmt");
    }
}
else  // Om konverteringen misslyckades = falskt, dvs siffror har ej angetts:  skriv ut felmeddelande
{  
    Console.WriteLine("Ogiltig inmatning!");
}
// Be användaren beskriva vädret med ett ord
Console.Write("Beskriv vädret med ett ord: ");
// Läs inmatningen, konvertera till versaler
string textInput = Console.ReadLine().ToUpper();
// Ta bort eventuella blanksteg i början och slutet av strängen
string trimmedInput = textInput.Trim();
// Skriv ut det beskrivande ordet
Console.WriteLine($"Du beskrev vädret som: {trimmedInput}");
*/

/* Övning 2 Fruktsortering med switch
Mål: Träna switch och strängmetoder.
Instruktion:
1. Be användaren skriva namnet på en frukt.
2. Använd ToLower() för att hantera små och stora bokstäver.
3. Använd switch för att skriva ut kategorin:
- "äpple", "päron", "banan" - “Vanlig frukt”
- "mango", "kiwi" - “Exotisk frukt”
- Allt annat - “Okänd frukt”
4. Kommentera koden.

// Be användaren skriva namnet på en frukt
Console.Write("Skriv namnet på en frukt: ");
// Läs inmatningen och konvertera till gemener
string fruitInput = Console.ReadLine().ToLower();

// Switch med sträng val för kategorisering av frukt
switch (fruitInput) {
    case "äpple":
    case "päron":
    case "banan":
        Console.WriteLine("Vanlig frukt");  // om nåt av casen matchar, skriv ut "Vanlig frukt"
        break;
    case "mango":
    case "kiwi":
        Console.WriteLine("Exotisk frukt"); // om nåt av casen matchar, skriv ut "Exotisk frukt"
        break;
    default:
        Console.WriteLine("Okänd frukt");   // om inget case matchar, skriv ut "Okänd frukt"
        break;
}
*/
/* Övning 3 Enkel räknesnurra (beräkning)
Mål: Träna switch och matematik baserat på användarval.
Instruktion:
1. Skapa en meny som låter användaren välja:
	1. Addera två tal
	2. Subtrahera två tal
	3. Kvadrera ett tal
	4. Avsluta
2. Beroende på valet, be användaren mata in ett eller två tal och skriv ut resultatet.
3. Om man matar in ett ogiltigt val, skriv “Ogiltigt val”.
4. Kommentera koden. 
*/
/*
// Visa menyalternativ för användaren
Console.WriteLine("Välj alternativ:");
Console.WriteLine("1 - Addera två tal");
Console.WriteLine("2 - Subtrahera två tal");
Console.WriteLine("3 - Kvadrera ett tal");
Console.WriteLine("4 - Avsluta");
// Läs användarens val
string choiceInput = Console.ReadLine();

// Försök konvertera användarens val till ett heltal, annars else-sats för ogiltig inmatning
if (int.TryParse(choiceInput, out int choice)) {
    switch (choice) // Switch baserat på användarens val
    {
        case 1:  // Addera två tal
            Console.Write("Ange första talet: ");
            double num1 = double.Parse(Console.ReadLine()); // Läs första talet och konvertera till double
            Console.Write("Ange andra talet: ");
            double num2 = double.Parse(Console.ReadLine()); // Läs andra talet och konvertera till double
            Console.WriteLine($"Resultat: {num1} + {num2} = {num1 + num2}");  // Skriv ut resultatet av additionen
            break;
        case 2:
            Console.Write("Ange första talet: "); // Subtrahera två tal
            double subNum1 = double.Parse(Console.ReadLine()); // Läs första talet och konvertera till double
            Console.Write("Ange andra talet: ");
            double subNum2 = double.Parse(Console.ReadLine()); // Läs andra talet och konvertera till double
            Console.WriteLine($"Resultat: {subNum1} - {subNum2} = {subNum1 - subNum2}"); // Skriv ut resultatet av subtraktionen
            break;
        case 3:
            Console.Write("Ange talet att kvadrera: ");  // Kvadrera ett tal
            double squareNum = double.Parse(Console.ReadLine()); // Läs talet och konvertera till double
            Console.WriteLine($"Resultat: {squareNum}^2 = {squareNum * squareNum}"); // Skriv ut resultatet av kvadreringen
            break;
        case 4:
            Console.WriteLine("Programmet avslutas...");  // Avsluta programmet
            break;
        default:
            Console.WriteLine("Ogiltigt val!");  // Ogiltigt val
            break;
    }
}
else { 
    Console.WriteLine("Ogiltig inmatning! Ange en siffra mellan 1 och 4."); 
}
*/
/* Övning 4 Kontrollera lösenordslängd
Mål: Träna if-else och strängmetoder.
Instruktion:
1. Be användaren skriva ett lösenord.
2. Om lösenordet är tomt (IsNullOrEmpty), skriv “Inget lösenord angivet”.
3. Om lösenordet har färre än 6 tecken, skriv “För kort lösenord”.
4. Om lösenordet är minst 6 tecken, skriv “Lösenordet är accepterat”.
5. Skriv också ut antal tecken i lösenordet (Length).
6. Kommentera koden.

Console.Write("Ange ett lösenord: ");   // Be användaren skriva ett lösenord
string password = Console.ReadLine();   // Läs inmatningen    

if (string.IsNullOrEmpty(password))     // Kontrollera om lösenordet är tomt  
{    
    Console.WriteLine("Inget lösenord angivet");
} 
else if (password.Length < 6)           // Kontrollera om lösenordet är kortare än 6 tecken
{         
    Console.WriteLine("För kort lösenord");
    Console.WriteLine($"Lösenordets längd: {password.Length} tecken");
}
else                                    // Lösenordet är minst 6 tecken långt
{                                  
    Console.WriteLine("Lösenordet är accepterat");
    Console.WriteLine($"Lösenordets längd: {password.Length} tecken");
}
*/
/* Övning 5 Konsolprogram med meny
Skapa ett konsolprogram i C# där användaren får göra ett val och programmet reagerar olika beroende på inmatning. Uppgiften ska träna användning av switch, if-satser, numerisk inmatning och stränghantering.
Programmet ska börja med att fråga användaren vad hen vill göra genom att visa följande meny:
1. Kontrollera temperatur
2. Kontrollera ord
3. Avsluta
Använd en switch-sats för att hantera användarens val. Om användaren anger något annat än 1, 2 eller 3 ska programmet skriva ”Ogiltigt val”.
Om användaren väljer Kontrollera temperatur ska programmet:
- Be användaren mata in en temperatur i grader Celsius
- Använda TryParse för att kontrollera att inmatningen är numerisk
- Med hjälp av if-satser skriva ut:
	- ”Kallt” om temperaturen är under 10
	- ”Lagom” om temperaturen är mellan 10 och 25
	- ”Varmt” om temperaturen är över 25
Om användaren väljer Kontrollera ord ska programmet:
- Be användaren skriva in ett valfritt ord
- Använda Trim() och ToUpper()
- Skriva ut om ordet är kort (färre än 5 tecken) eller långt (5 tecken eller fler)
- Skriva även ut hur många tecken ordet innehåller

Om användaren väljer Avsluta ska programmet skriva ut ett avslutsmeddelande och avslutas.
*/
Console.WriteLine("Välj alternativ:");              // Visa menyalternativ för användaren
Console.WriteLine("1 - Kontrollera temperatur");    // Alternativ 1
Console.WriteLine("2 - Kontrollera ord");           // Alternativ 2
Console.WriteLine("3 - Avsluta");                   // Alternativ 3
Console.Write("Ditt val: ");                        // Be användaren göra ett val

string val = Console.ReadLine(); // Läs användarens val

switch (val)    // Switch baserat på användarens val
{
    case "1":
        Console.Write("Ange en temperatur i grader Celsius: "); // Be användaren mata in en temperatur
        string input = Console.ReadLine();                      // Läs inmatningen

        if (double.TryParse(input, out double temperatur))      // Försök konvertera inmatningen till ett numeriskt värde
        {
            if (temperatur < 10)            // Om temperaturen är under 10
            {
                Console.WriteLine("Kallt"); // Skriv ut "Kallt"
            }
            else if (temperatur <= 25)      // Om temperaturen är mellan 10 och 25
            {
                Console.WriteLine("Lagom"); // Skriv ut "Lagom"
            }
            else                            // Om temperaturen är över 25
            {
                Console.WriteLine("Varmt"); // Skriv ut "Varmt"
            }
        }
        else // Om inmatningen inte är numerisk
        {
            Console.WriteLine("Ogiltig temperaturinmatning"); // Skriv ut felmeddelande
        }
        break;

    case "2":
        Console.Write("Skriv in ett ord: "); // Be användaren skriva in ett ord
        string ord = Console.ReadLine();     // Läs inmatningen

        ord = ord.Trim().ToUpper();          // Ta bort blanksteg och konvertera till versaler

        Console.WriteLine($"Ordet innehåller {ord.Length} tecken."); // Skriv ut antal tecken i ordet

        if (ord.Length < 5)                       // Om ordet har färre än 5 tecken
        {
            Console.WriteLine("Ordet är kort.");  // Skriv ut "Ordet är kort."
        }
        else // Om ordet har 5 tecken eller fler
        {
            Console.WriteLine("Ordet är långt."); // Skriv ut "Ordet är långt."
        }
        break;

    case "3":
        Console.WriteLine("Programmet avslutas!"); // Skriv ut avslutsmeddelande
        break;

    default:
        Console.WriteLine("Ogiltigt val"); // Skriv ut "Ogiltigt val" för ogiltig inmatning
        break;
}

