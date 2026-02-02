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
/* Skriv textrad
Console.Write("Ange pris på äpplen: ");
// Be användaren mata in priset och spara varibel
string priceInput = Console.ReadLine();
// Konertera strängen till decimal
decimal price = Convert.ToDecimal(priceInput);
// Skriv textrad
Console.Write("Ange antal äpplen: ");
// Be användaren mata in antal och spara variabel
string numberInput = Console.ReadLine();
// Konvertera strängen till int
int.TryParse(numberInput, out int numberInt);
// Skriv ut priset på äpplen
Console.WriteLine("Pris på äpplen: " + price);
// Skriv ut antal äpplen
Console.WriteLine("Antal äpplen: " + numberInt);
// Räkna ut totalsumman som decimal variabel
decimal TotalSum = price * numberInt;
// Räkna ut momsen som decimal variabel
decimal VAT = TotalSum * 0.25E2m;
// Skriv ut kvitto med totalsumma och moms
Console.WriteLine("Kvitto\n======\nTotalsumma: " + TotalSum + " kr\n" + "Moms: " + VAT + " kr");
*/

/*  Labb 1 - övning 3
Skapa ett Console-program som:
1. Ber användaren ange:
- antal timmar
- antal minuter
2. Konverterar värdena till int.
3. Räknar ut den totala tiden i minuter.
4. Skriver ut resultatet.
5. Skriv kommentar om varje rad (ovanför raden)
Krav:
- Använd int.TryParse.
- Ingen if / else.
- Resultatet ska lagras i en variabel.

// Skriv textrad
Console.Write("Ange antal timmar: ");
// Be användaren mata in timmar och spara varibel
string hourInput = Console.ReadLine();
// Konvertera strängen till int
int.TryParse(hourInput, out int hour);
// Skriv textrad
Console.Write("Ange antal minuter: ");
// Be användaren mata in timmar och spara varibel
string minuteInput = Console.ReadLine();
// Konvertera strängen till int
int.TryParse(minuteInput, out int minute);
// Räkna ut total tid i minuter och spara i variabel
int totalMinutes = (hour * 60) + minute;
// Skriv ut resultatet
Console.WriteLine("Total tid i minuter: " + totalMinutes + " minuter"); */

/*  Labb 1 - övning 3
Skapa ett Console-program som:
1.Ber användaren ange:
- pris per smoothie i kronor
- antal smoothisar
2. Konverterar värdena till:
- decimal (pris)
- int (antal)
3. Räknar ut:
- totalpriset
4. Konverterar totalpriset till string
5. Skriver ut resultatet med ett tydligt meddelande och med konkatineringsmetoden.
Krav:
- Använd decimal.TryParse
- Använd int.TryParse
- Använd ToString()
- Ingen if / else
- Kommentar ovanför varje rad */

/* Skriv textrad
Console.Write("Ange pris per smoothie i kronor: ");
// Be användaren mata in pris
string priceInput = Console.ReadLine();
// Konvertera strängen till decimal
decimal price = Convert.ToDecimal(priceInput);
// Skriv textrad
Console.Write("Ange antal smoothies: ");
// Be användaren mata in antal
string numberInput = Console.ReadLine();
// Konvertera strängen till int
int.TryParse(numberInput, out int number);
// Räkna ut totalpriset och spara i variabel
decimal totalPrice = price * number;
// Skriv ut resultatet
Console.WriteLine("Totalpriset för " + number + " smoothies är: " + totalPrice.ToString() + " kronor");
*/

/*  Labb 1 - övning 4 
Skapa ett Console-program som:
1.Ber användaren ange:
-kostnad för frukost.
-kostnad för lunch.
-kostnad för middag.
2.Konverterar värdena till decimal.
3. Räknar ut den genomsnittliga kostnaden.
4. Skriver ut resultatet.
Krav:
-Använd Convert.ToDecimal().
- Ingen if / else.
- Alla värden ska lagras i variabler.
- Skriv kommentar om varje rad (ovanför raden) */

// Skriv textrad
Console.Write("Ange priset för frukost: ");
// Be användaren mata in pris för frukost
string breakfastInput = Console.ReadLine();
// Konvertera strängen till decimal
decimal breakfast = Convert.ToDecimal(breakfastInput);
// Skriv textrad
Console.Write("Ange priset för lunch: ");
// Be användaren mata in pris för lunch
string lunchInput = Console.ReadLine();
// Konvertera strängen till decimal
decimal lunch = Convert.ToDecimal(lunchInput);
// Skriv textrad
Console.Write("Ange priset för middag: ");
// Be användaren mata in pris för middag
string dinnerInput = Console.ReadLine();
// Konvertera strängen till decimal
decimal dinner = Convert.ToDecimal(dinnerInput);
// Beräkna den genomsnittliga kostnaden och spara i variabel
decimal averageCost = (breakfast + lunch + dinner) / 3;
averageCost = Math.Round(averageCost, 2);
// Skriv ut resultatet
Console.WriteLine("Den genomsnittliga kostnaden för måltiderna är: " + averageCost + " kronor");