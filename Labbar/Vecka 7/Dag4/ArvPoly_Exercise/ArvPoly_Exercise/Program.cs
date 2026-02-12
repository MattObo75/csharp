namespace ArvPoly_Exercise
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Animal> zoo = new List<Animal>();

            Console.WriteLine("Welcome to the Zoo Simulator!");
            string[] animalTypes = { "Lion", "Elephant", "Parrot", "Cow", "Wolf", "Bear" };

            foreach (string type in animalTypes)
            {
                Console.Write($"Enter a name for your {type}: ");
                string name = Console.ReadLine()!;

                // Skapa objekt baserat på typ
                Animal animal = type switch
                {
                    "Lion" => new Lion(name),
                    "Elephant" => new Elephant(name),
                    "Parrot" => new Parrot(name),
                    "Cow" => new Cow(name),
                    "Wolf" => new Wolf(name),
                    "Bear" => new Bear(name),
                    _ => throw new Exception("Unknown animal type")
                };

                zoo.Add(animal);
            }

            Console.WriteLine("\n--- Zoo Activities ---\n");

            // Polymorfism – loopar igenom alla djur
            foreach (Animal a in zoo)
            {
                a.MakeSound();
                a.Eat();
                a.Sleep();
                Console.WriteLine();
            }

            Console.WriteLine("End of Zoo Simulator!");
        }

        // 1. Abstrakt basklass
        abstract class Animal
        {
            public string Name { get; set; }

            public Animal(string name)
            {
                Name = name;
            }

            // Abstrakt metod – varje djur implementerar sitt ljud
            public abstract void MakeSound();

            // Virtuell metod – standardbeteende för mat
            public virtual void Eat()
            {
                Console.WriteLine($"{Name} eats food.");
            }

            // Virtuell metod för sömn, kan override:as
            public virtual void Sleep()
            {
                Console.WriteLine($"{Name} sleeps in a regular way.");
            }
        }

        // 2. Subklasser
        class Lion : Animal
        {
            public Lion(string name) : base(name) { }

            public override void MakeSound()
            {
                Console.WriteLine($"{Name} roars!");
            }

            public override void Sleep()
            {
                Console.WriteLine($"{Name} sleeps under a tree.");
            }
        }

        class Elephant : Animal
        {
            public Elephant(string name) : base(name) { }

            public override void MakeSound()
            {
                Console.WriteLine($"{Name} trumpets!");
            }

            public override void Eat()
            {
                Console.WriteLine($"{Name} eats lots of leaves and grass.");
            }

            public override void Sleep()
            {
                Console.WriteLine($"{Name} sleeps standing up.");
            }
        }

        class Parrot : Animal
        {
            public Parrot(string name) : base(name) { }

            public override void MakeSound()
            {
                Console.WriteLine($"{Name} says: Hello!");
            }

            public override void Eat()
            {
                base.Eat(); // Använder basklassens Eat
                Console.WriteLine($"{Name} chirps happily after eating.");
            }

            public override void Sleep()
            {
                Console.WriteLine($"{Name} sleeps perched on a branch.");
            }
        }

        class Cow : Animal
        {
            public Cow(string name) : base(name) { }

            public override void MakeSound()
            {
                Console.WriteLine($"{Name} moos!");
            }

            public override void Sleep()
            {
                Console.WriteLine($"{Name} lies down in the meadow to sleep.");
            }
        }

        class Wolf : Animal
        {
            public Wolf(string name) : base(name) { }

            public override void MakeSound()
            {
                Console.WriteLine($"{Name} howls!");
            }

            public override void Eat()
            {
                Console.WriteLine($"{Name} hunts and eats meat.");
            }

            public override void Sleep()
            {
                Console.WriteLine($"{Name} sleeps in the den.");
            }
        }

        class Bear : Animal
        {
            public Bear(string name) : base(name) { }

            public override void MakeSound()
            {
                Console.WriteLine($"{Name} growls!");
            }

            public override void Sleep()
            {
                Console.WriteLine($"{Name} hibernates during winter.");
            }
        }
    }
}
