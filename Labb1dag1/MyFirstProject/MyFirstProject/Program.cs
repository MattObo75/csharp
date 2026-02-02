/* Labb 1 - övning 1
Console.Write("Namn: ");
string firstName = Console.ReadLine();
Console.Write("Age: ");
string age = Console.ReadLine();
int ageInt = int.Parse(age);
string heighttext = "1,75";
double.TryParse(heighttext, out double height);
Console.WriteLine("Namn: " + firstName);
Console.WriteLine("Ålder: " + age);
Console.WriteLine("Längd: " + height);
decimal price = 999.99m;
bool isAvailable = true;
Console.WriteLine("Pris: " + price);
Console.WriteLine("Tillgänglig: " + isAvailable);
char grade = 'A';
byte roomNumber = 3;
Console.WriteLine("Betyg: " + grade);
Console.WriteLine("Sal: " + roomNumber);
int systernage = ageInt + 2;
Console.WriteLine("Systerns ålder: " + systernage);
Console.Write("Ange priset för din lunch: ");
string breakfastInput = Console.ReadLine();
decimal breakfast = Convert.ToDecimal(breakfastInput);
int priceOre = (int)(breakfast * 100);
Console.WriteLine("Pris i öre: " + priceOre);
Console.WriteLine("Pris i öre: {0}", priceOre); 
Console.WriteLine($"Pris i öre: {priceOre}"); 

Labb 1 - övning 2
Skapa ett Console-program som:
1.Ber användaren att ange:
-priset på en vara.
-hur många varor som köps.
2. Räknar ut:
-Totalsumma.
-moms (25 %)
3. Skriver ut ett enkelt kvitto
Krav:
-Använd decimal för pengar.
-Använd int för antal.
-Använd TryParse.
-Ingen if / else.
-Skriv kommentar om varje rad (ovanför raden).
 */
Console.Write("Ange pris på äpplen: ");
string priceInput = Console.ReadLine();
decimal price = Convert.ToDecimal(priceInput);
Console.Write("Ange antal äpplen: ");
string numberInput = Console.ReadLine();
int.TryParse(numberInput, out int numberInt);
Console.WriteLine("Pris på äpplen: " + price);
Console.WriteLine("Antal äpplen: " + numberInt);
decimal TotalSum = price * numberInt;
decimal VAT = TotalSum * 0.25m;
Console.WriteLine("Kvitto\n======\nTotalsumma: " + TotalSum + " kr\n" + "Moms: " + VAT + " kr");