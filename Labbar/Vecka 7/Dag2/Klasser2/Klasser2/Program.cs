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
                if (Mana < cost)
                {
                    Console.WriteLine($"{Name} har inte tillräckligt med mana.");
                    return 0;
                }
                
                Mana -= cost;
                TotalSpellsCast++;

                Console.WriteLine($"{Name} kastar en spell och använder {cost} mana.");
                return cost;
            }

            public void ReceiveMana(int amount)
            {
                Mana += amount;
                Console.WriteLine($"{Name} får {amount} mana.");
            }

            public static void ShowGlobalStats()
            {
                // Totalt antal kastade trollformler (statisk)
                Console.WriteLine();
                Console.WriteLine($"Totalt antal kastade spells: {TotalSpellsCast}");
            }

        }
        
    }
}
