namespace Klasser2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Wizard gandalf = new Wizard { Name = "Gandalf", Mana = 100 };
            Wizard merlin = new Wizard { Name = "Merlin", Mana = 80 };
            // Gandalf kastar en spell
            int usedMana = gandalf.CastSpell(30);

            // Merlin får manan Gandalf använde
            merlin.ReceiveMana(usedMana);
            // Merlin kastar två spells
            merlin.CastSpell(20);
            merlin.CastSpell(10);

            Console.WriteLine();
            Console.WriteLine($"Gandalfs mana: {gandalf.Mana}");
            Console.WriteLine($"Merlins mana: {merlin.Mana}");

            // Statisk metod
            Wizard.ShowGlobalStats();
            Console.ReadLine(); // håller konsolen öppen
        }

        class Wizard
        {
            public string Name { get; set; }
            public int Mana { get; set; }

            public static int TotalSpellsCast = 0;
            public int CastSpell(int cost)
            {
                Mana -= cost;
                TotalSpellsCast++;
                return Mana;
            }

            public void ReceiveMana(int amount)
            {
                Mana += amount;
            }

            public static void ShowGlobalStats()
            {
                   // Totalt antal kastade trollformler (statisk)
                Console.WriteLine();
                Console.WriteLine($"Total number of spells casted: {TotalSpellsCast}");
            }

        }
        
    }
}
