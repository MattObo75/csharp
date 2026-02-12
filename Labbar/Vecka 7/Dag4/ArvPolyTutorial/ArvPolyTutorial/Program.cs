namespace ArvPolyTutorial
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Vehicle car = new Vehicle("Volvo");
            car.Drive();

            Car myCar = new Car("Saab");
            myCar.Drive(); // Ärver Drive() från Vehicle
            myCar.Honk(); // Egen metod i subklassen

            Vehicle2 bike = new Motorcycle("Yamaha");
            bike.Start();

            Animal cat = new Cat("Misse");
            cat.MakeSound();

            Dog fido = new Dog("Fido");
            fido.MakeSound();
            
            List<Animal> animals = new List<Animal> { cat, fido };

            foreach (Animal a in animals)
            {
                a.MakeSound(); // Samma metod, olika beteende
            }
        }

        class Vehicle
        {
            public string Brand;
            public Vehicle(string brand)
            {
                Brand = brand;
                Console.WriteLine($"Creating a vehicle: {Brand}");
            }
            public void Drive()
            {
                Console.WriteLine($"{Brand} drives forward.");
            }
        }

        class Car : Vehicle
        {
            public Car(string brand) : base(brand) { }
            public void Honk()
            {
                Console.WriteLine($"{Brand} honks: Beep!");
            }
        }

        class Vehicle2
        {
            public string Brand;
            public Vehicle2(string brand) { Brand = brand; }
            public virtual void Start()
            {
                Console.WriteLine($"{Brand} starts.");
            }
        }

        class Motorcycle : Vehicle2
        {
            public Motorcycle(string brand) : base(brand) { }
            public override void Start()
            {
                Console.WriteLine($"{Brand} roars as a motorcycle!");
            }
        }

        abstract class Animal
        {
            public string Name;
            public Animal(string name) { Name = name; }
            public abstract void MakeSound();
            public virtual void Sleep()
            {
                Console.WriteLine($"{Name} sleeps...");
            }
        }

        class Cat : Animal
        {
            public Cat(string name) : base(name) { }
            public override void MakeSound()
            {
                Console.WriteLine($"{Name} says: Meow!");
            }
        }

        class Dog : Animal
        {
            public Dog(string name) : base(name) { }
            public override void MakeSound()
            {
                base.Sleep(); // Anropar basklassens Sleep()
                Console.WriteLine($"{Name} says: Woof!");
            }
        }
    }
}
