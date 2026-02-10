namespace Klasser1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            /*
            Car myCar = new Car { Brand = "Volvo", Speed = 0 };
            Car myCar2 = new Car { Brand = "BMW", Speed = 0 };
            myCar2.StartEngine();

            // Anropar metod som påverkar objektet via en annan metod
            myCar.StartAndDrive();

            myCar2.Accelerate(30);

            // Anropa statisk metod via klassnamn
            Car.CarInfo();
            Console.ReadLine(); */

            // Använd statiska metoder direkt via klassnamn
            int sum = SimpleMath.Add(5, 7);
            int product = SimpleMath.Multiply(3, 4);
            Console.WriteLine($"Summa: {sum}");
            Console.WriteLine($"Produkt: {product}");

            // Skapa objekt för att använda instansmetoder
            SimpleMath mathObj = new SimpleMath();
            SimpleMath mathObj2 = new SimpleMath();
            // math1 räknar ut ett värde
            int resultFromMath1 = SimpleMath.Add(5, 3); // 8


            // resultatet används som input i math2
            int finalResult = SimpleMath.Multiply(resultFromMath1, 2); // 16            
            Console.WriteLine(finalResult);

            // mathObj.Subtract(10, 3); // ändrar LastResult
            // mathObj.Divide(20, 4); // ändrar LastResult
            // Console.WriteLine($"Senaste resultat lagrat i objektet: {mathObj.LastResult}");
            Console.ReadLine(); // Behövs för att hålla konsolen öppen
        }

        // Klassen ligger utanför Program-klassen men inom namespace
        public class Car
        {
            // Instansmetod 1: starta motorn
            public string Brand { get; set; }
            public double Speed { get; set; }
            public void StartEngine()
            {
                Console.WriteLine($"{Brand} motorn startad!");
            }

            // Instansmetod 2: öka hastighet
            public void Accelerate(int increase)
            {
                Speed += increase; // ändrar objektets tillstånd
                Console.WriteLine($"{Brand} kör nu i {Speed} km/h");
            }

            // Instansmetod 3: anropar Accelerate inifrån en annan metod
            public void StartAndDrive()
            {
                StartEngine();  // anropar en annan metod i samma objekt
                Accelerate(50); // påverkar objektets Speed
            }

            // Statisk metod
            public static void CarInfo()
            {
                Console.WriteLine("Alla bilar har 4 hjul ");
            }
        }

        // Klassen som innehåller både statiska och instansmetoder
        public class SimpleMath
        {
            // Instansfält för att lagra senaste resultat
            public int LastResult { get; private set; }            

            // Statisk metod: kan anropas utan objekt
            public static int Add(int a, int b)
            {
                return a + b;
            }

            // Statisk metod
            public static int Multiply(int a, int b)
            {
                return a * b;
            }

            // Instansmetod: påverkar objektets tillstånd
            public void Subtract(int a, int b)
            {
                LastResult = a - b;
                Console.WriteLine($"Resultatet av {a} - {b} = {LastResult}");
            }

            // Instansmetod: påverkar objektets tillstånd
            public void Divide(int a, int b)
            {
                if (b == 0)
                {
                    Console.WriteLine("Kan inte dividera med noll!");
                    return;
                }
                LastResult = a / b;
                Console.WriteLine($"Resultatet av {a} / {b} = {LastResult}");
            }
        }
    }
}
