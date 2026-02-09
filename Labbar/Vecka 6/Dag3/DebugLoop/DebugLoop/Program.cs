/* Debug Övning 1
List<string> names = new List<string>();    // Skapa lista 
names.Add("Anna");  // Lägg till sträng på position 0
names.Add("Olle");  // Lägg till sträng på position 1
names.Add("Eva");   // Lägg till sträng på position 2

// Kör loop som stegar igenom namnlistan
foreach (var name in names)     // name är en temporär variabel
{
    Console.WriteLine(name);    // Skriv ut namnet
}

Console.WriteLine("Färdig!");   // Skriv ut "Färdig!"
Console.ReadLine();             // Pausar konsolen
*/

/* Debug Övning 2 Summera tal med en for-loop
1.Sätt en breakpoint på raden Console.Write($"Skriv tal {i}: ");
2.Starta Debug(F5).När programmet stannar, titta på Locals och se värdet på sum och number.
3. Stega med F10 för att köra raden och se hur summan ändras efter varje input.
4. Använd Immediate Window för att experimentera. Innan dess, kan du rensa fönstret från tidigare tester med högerklick och Clear all.
5. Skriv sedan sum += 10; Då ändras summan. 

int sum = 0; // Variabel för summan

for (int i = 1; i <= 5; i++)            // Loop för 5 tal
{
    Console.Write($"Skriv tal {i}: ");  // Be användaren skriva in ett tal
    string input = Console.ReadLine();  // Läs in tal som sträng
    try                                 // Försök att konvertera och lägga till i summan 
    {
        int number = int.Parse(input);  // Konvertera strängen till heltal
        sum += number;                  // Lägg till i summan
    }
    catch                               // Om konverteringen misslyckas
    {
        Console.WriteLine("Fel! Ange ett heltal."); // Felmeddelande
        i--;    // Upprepa iterationen om input är fel
    }
}
Console.WriteLine("Summan av talen är: " + sum); // Skriv ut summan
Console.ReadLine(); // Pausa konsolen
*/

/* Debug Övning 3 Hitta fel i beräkningen
1. Skriv in den enkla for-loopen där vi ombes att skriva in tre tal (vi testar med 2, 3) och sedan summera dem.
2. Sätt breakpoint på sum=number;
3. När programmet stannar, öppna Locals och titta, 0 1 2 visas
4. Stega med F10 eller pilen i menyn och kolla i Locals. Du ser att summan nollställs varje loop. Fundera på varför. Nu har vi identifierat felet m h a Locals.
5. Vi åtgärdar felet med att sätta sum+=number;

int sum = 0;        // Variabel för summan
for (int i = 1; i < 3; i++) // Loop för 3 tal
{
    Console.Write($"Skriv tal {i}: ");          // Be användaren skriva in ett tal
    int number = int.Parse(Console.ReadLine()); // Läs in tal och konvertera till heltal
    sum += number;  // Lägg till i summan
}
Console.WriteLine("Summan är: " + sum); // Skriv ut summan
*/

/* Debug Övning 4 Try-catch
Skriv in en bokstav i stället för tal. Se exception.

Console.WriteLine("Skriv ett tal: ");       // Be användaren skriva in ett tal
try  // Försök att konvertera input
{
    int number = int.Parse(Console.ReadLine()); // Läs in tal och konvertera till heltal
    Console.WriteLine("Talet är: " + number);   // Skriv ut talet
}
catch (FormatException)                 // Om konverteringen misslyckas
{
    Console.WriteLine("Fel format!");   // Felmeddelande
}
catch (OverflowException)               // Om talet är för stort eller för litet
{
    Console.WriteLine("Talet är för stort eller för litet!"); // Felmeddelande
}
*/

/* Loopar och listor ------------------------------------------------------------------------

// Skapar en lista som lagrar temperaturer
List<int> temperatures = new List<int>();

// Lägger till några temperaturvärden
temperatures.Add(18);
temperatures.Add(22);
temperatures.Add(25);

// Skriver ut medelvärde (manuellt)
int sum = 0;
foreach (int t in temperatures)
{
sum += t;
}
Console.WriteLine("Medeltemperatur: " + (sum / temperatures.Count));
*/

/* For-loop 

// Räknar ner från 10 till 1
for (int seconds = 10; seconds >= 1; seconds--)
{
    Console.WriteLine("Nedräkning: " + seconds);
}
*/

/* While-loop 

// Simulerar ett menyval
int choice = 0;
while (choice != 4)
{
    Console.WriteLine("1. Spela");
    Console.WriteLine("2. Inställningar");
    Console.WriteLine("3. Hjälp");
    Console.WriteLine("4. Avsluta");
    choice = int.Parse(Console.ReadLine());
}
*/

/* Do-while-loop 

// Användaren måste ange ålder minst en gång
int age;
do
{
    Console.Write("Ange din ålder: ");
    age = int.Parse(Console.ReadLine());
}
while (age < 18);
*/

/* Foreach-loop 

// Lista med betyg
List<char> grades = new List<char>() { 'A', 'B', 'C', 'A' };
// Skriver ut alla betyg
foreach (char g in grades)
{
    Console.WriteLine("Betyg: " + g);
}
*/

/* Nästlade for-loopar 

// Rita ett rutnät med stjärnor
for (int row = 1; row <= 4; row++)
{
    for (int col = 1; col <= 4; col++)
    {
        Console.Write("* ");
    }
    Console.WriteLine(); // Ny rad efter varje rad
}
*/

/* Continue 
// Hoppar över udda tal
for (int i = 1; i <= 10; i++)
{
    if (i % 2 != 0)
        continue;
        Console.WriteLine("Jämnt tal: " + i);
}
*/

/* Break 

// Avsluta loop när rätt kod anges
for (int attempts = 1; attempts <= 5; attempts++)
{
    Console.Write("Ange kod: ");
    string code = Console.ReadLine();
    if (code == "exit")
        break;
}
*/

/* Loopar med LINQ (Where) 

// Lista med priser
List<int> prices = new List<int>() { 120, 450, 80, 600, 200 };
// Filtrerar priser under 300
var cheapItems = prices.Where(p => p < 300);

// Skriver ut resultatet
foreach (int p in cheapItems)
{
    Console.WriteLine("Pris: " + p);
}
*/

/* Loopar Övning 1 
Du ska skriva ett program som:
- Låter användaren mata in ett antal temperaturvärden (t.ex. 5–10 värden).
- Sparar varje inmatning i en lista.
Beräknar och skriver ut:
	- Medeltemperaturen list.Average()
    - Det högsta och lägsta värdet, list.Min(), list.Max()
	- Antal temperaturer över ett visst värde (t.ex. 25 grader)

Krav:
-´Använd for-loop för inmatning.
- Använd List<int> för att spara värdena.
- Hantera felaktig inmatning med try-catch (t.ex.om användaren skriver text istället för ett heltal).


List<int> temperatures = new List<int>();       // Lista för att lagra temperaturvärden
int numberOfTemperatures = 5;                   // Antal temperaturvärden att mata in

for (int i = 0; i < numberOfTemperatures; i++)  // Loop för inmatning
{
    Console.Write($"Ange temperaturvärde {i + 1}: ");   // Be användaren mata in ett värde
    try
    {
        int temp = int.Parse(Console.ReadLine());       // Läs in och konvertera till heltal
        temperatures.Add(temp);                         // Lägg till värdet i listan
    }
    catch (FormatException)                             // Hantera felaktig inmatning
    {
        Console.WriteLine("Felaktig inmatning! Vänligen ange ett heltal.");
        i--; // Minska räknaren för att upprepa inmatningen
    }
}
Console.WriteLine($"Medeltemperatur: {temperatures.Average()}");    // Beräkna och skriv ut medeltemperaturen
Console.WriteLine($"Högsta temperatur: {temperatures.Max()}");      // Skriv ut högsta värdet
Console.WriteLine($"Lägsta temperatur: {temperatures.Min()}");      // Skriv ut lägsta värdet
int countAbove25 = temperatures.Count(t => t > 25);                 // Räkna antal värden över 25 grader
Console.WriteLine($"Antal temperatvärden över 25 grader: {countAbove25}"); // Skriv ut antalet värden över 25 grader
*/

/* Loopar Övning 2 
Programmet ska slumpa fram ett hemligt tal mellan 1 och 50.
- Användaren får max 7 försök att gissa talet.
- Efter varje gissning ska programmet skriva ut:
	- “För högt” om gissningen är större än talet
	- “För lågt” om gissningen är mindre än talet
	- “Rätt!” om gissningen stämmer

- Om användaren gissar rätt avslutas loopen direkt.
- Programmet ska även hantera felaktig inmatning (icke-nummer).

Talet kan slumpas med nedanstående procedur:
Random rnd = new Random();
int secret = rnd.Next(1, 51); // 1–50 


Random rnd = new Random();
int secret = rnd.Next(1, 51); // Slumpa fram hemligt tal mellan 1 och 50

int maxAttempts = 7;          // Max antal försök

bool guessedCorrectly = false; // Flagga för att kontrollera om talet gissades rätt

for (int attempt = 1; attempt <= maxAttempts; attempt++) // Loop för gissningar
{
    Console.Write($"Försök {attempt}/{maxAttempts}. Gissa talet (1-50): "); // Be användaren gissa talet
    try
    {
        int guess = int.Parse(Console.ReadLine()); // Läs in och konvertera gissningen
        if (guess < 1 || guess > 50)                // Kontrollera om gissningen är inom giltigt intervall
        {
            Console.WriteLine("Gissningen måste vara mellan 1 och 50.");
            attempt--; // Minska räknaren för att upprepa försöket
            continue;
        }
        if (guess > secret) // Gissningen är för hög
        {
            Console.WriteLine("För högt!");
        }
        else if (guess < secret) // Gissningen är för låg
        {
            Console.WriteLine("För lågt!");
        }
        else // Gissningen är korrekt
        {
            Console.WriteLine("Rätt!");
            guessedCorrectly = true; // Sätt flaggan till true
            break; // Avsluta loopen
        }
    }
    catch (FormatException) // Hantera felaktig inmatning
    {
        Console.WriteLine("Felaktig inmatning! Vänligen ange ett heltal mellan 1 och 50.");
        attempt--; // Minska räknaren för att upprepa försöket
    }
}
*/
/* Loopar Övning 3 
Filtrera studenter med 70 poäng eller mer.
Krav:
- Skapa två listor:
	- names – med studentnamn.
	- scores – med poäng, där varje poäng motsvarar samma index i names.
- Använd en foreach-loop för att gå igenom alla poäng i listan scores.
- Använd en räknare (i) för att hålla koll på vilket namn som matchar varje poäng.
- Använd en if-sats för att filtrera de studenter som har 70 poäng eller mer.
- Skriv ut varje student som klarade kursen.


List<string> names = new List<string>() { "Kalle", "Bertil", "Maria", "Tommy", "Eva", "Mattias" }; // Lista med studentnamn
List<int> scores = new List<int>() { 85, 62, 90, 45, 78, 70 }; // Lista med poäng

int i = 0; // Räknare för att hålla koll på index
foreach (string name in names)
{
    int score = scores[i]; // Hämta motsvarande poäng från scores-listan
    if (score >= 70) // Kontrollera om poängen är 70 eller mer
    {
        Console.WriteLine($"{name} klarade kursen med {score} poäng."); // Skriv ut studentens namn och poäng
    }
    i++; // Öka räknaren för nästa iteration
}
*/
/* Extrauppgift Övning 1
1. Be användaren skriva sitt namn.
2. Använd Trim() för att ta bort onödiga mellanslag.
3. Kontrollera:
	- Om namnet är tomt: skriv “Inget namn angivet” och avsluta.
4. Be användaren skriva in sin ålder.
5. Använd TryParse för att kontrollera att åldern är numerisk.
6. Med hjälp av if/else skriv ut:
	- Under 18 är: “Du är minderårig”
	- 18–64 år: “Du är vuxen”
	- 65 år eller äldre: “Du är pensionär”
7. Skriv även ut:
	- Namnet i versaler (ToUpper())
	- Antal tecken i namnet (Length)

- Kommentera koden. 

Console.Write("Ange ditt namn: ");          // Be användaren skriva sitt namn
string name = Console.ReadLine().Trim().ToUpper();    // Läs in namnet och ta bort onödiga mellanslag


if (string.IsNullOrEmpty(name))             // Kontrollera om namnet är tomt
{
    Console.WriteLine("Inget namn angivet"); // Skriv ut meddelande och avsluta
    return;
}
Console.Write("Ange din ålder: ");         // Be användaren skriva in sin ålder
string ageInput = Console.ReadLine();      // Läs in åldern som sträng

if (string.IsNullOrEmpty(ageInput))
{
    Console.WriteLine("Ingen ålder angiven"); // Skriv ut meddelande och avsluta
    return;
}

if (int.TryParse(ageInput, out int age))   // Försök att konvertera åldern till heltal
{
    if (age < 18)                          // Kontrollera om användaren är minderårig
    {
        Console.WriteLine($"Hej {name}, du är minderårig. Längden på ditt namn är {name.Length}.");
    }
    else if (age >= 18 && age <= 64)       // Kontrollera om användaren är vuxen
    {
        Console.WriteLine($"Hej {name}, du är vuxen. Längden på ditt namn är {name.Length}.");
    }
    else                                   // Annars är användaren pensionär
    {
        Console.WriteLine($"Hej {name}, du är pensionär. Längden på ditt namn är {name.Length}.");
    }
}
else                                       // Om konverteringen misslyckas
{
    Console.WriteLine("Felaktig ålder! Vänligen ange ett numeriskt värde.");
    return;
}
*/

/* Extrauppgift Övning 2
1. Be användaren mata in ett poängresultat mellan 0 och 100.
2. Använd TryParse för att kontrollera inmatningen.
3. Om talet är utanför intervallet 0–100: skriv “Ogiltigt poängresultat”.
4. Annars:
	- Dela poängen med 10 (heltalsdivision).
	- Använd switch för att sätta betyg:
		10: A
		9: B
		8: C
		7: D
		6: E
		0–5: F
5. Skriv ut både poängen och betyget.
6. Kommentera koden.


Console.Write("Ange ditt poängresultat (0-100): "); // Be användaren mata in ett poängresultat
string input = Console.ReadLine();                  // Läs in poängresultatet som sträng

if (int.TryParse(input, out int score))             // Försök att konvertera inmatningen till heltal
{
    if (score < 0 || score > 100)                   // Kontrollera om poängen är inom giltigt intervall
    {
        Console.WriteLine("Ogiltigt poängresultat"); // Skriv ut meddelande om ogiltigt resultat
    }
    else
    {
        int gradeValue = score / 10;            // Dela poängen med 10 för att få betygsvärdet
        string grade;                           // Variabel för betyget
        switch (gradeValue)                     // Använd switch för att bestämma betyget
        {
            case 10:
                grade = "A";
                break;
            case 9:
                grade = "B";
                break;
            case 8:
                grade = "C";
                break;
            case 7:
                grade = "D";
                break;
            case 6:
                grade = "E";
                break;
            default:
                grade = "F";
                break;
        }
        Console.WriteLine($"Poäng: {score}, Betyg: {grade}"); // Skriv ut poängen och betyget
    }
}
else                                            // Om konverteringen misslyckas
{
    Console.WriteLine("Felaktig inmatning! Vänligen ange ett numeriskt värde.");
}
*/
/* Extrauppgift Övning 3
1. Skapa två fördefinierade värden i koden:
	- Användarnamn: "admin"
	- Lösenord: "1234"
2. Be användaren mata in ett användarnamn.
3. Använd Trim() och ToLower() på inmatningen.
4. Be användaren mata in ett lösenord.
5. Kontrollera med if/else:
	- Om användarnamn och lösenord stämmer: “Inloggning lyckades”
	- Om användarnamnet är fel men lösenordet rätt: “Fel användarnamn”
	- Om användarnamnet är rätt men lösenordet fel: “Fel lösenord”
	- Om båda är fel: “Fel användarnamn och lösenord”
6. Kommentera koden.
*/
string correctUsername = "admin"; // Fördefinierat användarnamn
string correctPassword = "1234";  // Fördefinierat lösenord
Console.Write("Ange användarnamn: "); // Be användaren mata in ett användarnamn
string inputUsername = Console.ReadLine().Trim().ToLower(); // Läs in och bearbeta användarnamnet
Console.Write("Ange lösenord: "); // Be användaren mata in ett lösenord
string inputPassword = Console.ReadLine(); // Läs in lösenordet
if (inputUsername == correctUsername && inputPassword == correctPassword) // Kontrollera om båda är rätt
{
    Console.WriteLine("Inloggning lyckades"); // Skriv ut framgångsmeddelande
}
else if (inputUsername != correctUsername && inputPassword == correctPassword) // Fel användarnamn
{
    Console.WriteLine("Fel användarnamn"); // Skriv ut felmeddelande för användarnamn
}
else if (inputUsername == correctUsername && inputPassword != correctPassword) // Fel lösenord
{
    Console.WriteLine("Fel lösenord"); // Skriv ut felmeddelande för lösenord
}
else // Båda är fel
{
    Console.WriteLine("Fel användarnamn och lösenord"); // Skriv ut felmeddelande för båda
}
Console.ReadLine();