/* Övning 1
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

/* Övning 2 Summera tal med en for-loop
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

/* Övning 3 Hitta fel i beräkningen
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

/* Övning 4 Try-catch
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