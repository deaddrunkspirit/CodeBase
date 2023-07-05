using Task6Lib;
using System;

namespace Task6
{
    public class T6
    {
        public static void Main()
        {
            do
            {
                var gendalf = new Wizard("Gendalf", "Shire");
                Creature[] allianceOfTheRing = {
                new Hobbit("Frodo", "Shire"), new Hobbit("Sam", "Shire"),
                new Hobbit("Pippin", "Shire"), new Hobbit("Merry", "Shire"),
                new Human("Aragorn", "Bree"), new Human("Boromir", "Gondor"),
                new Dwarf("Gimli", "Erebor"), new Elf("Legolas", "Mirkwood")
                };
                foreach (Creature creature in allianceOfTheRing)
                    gendalf.RaiseRingIsFoundEvent += creature.RingIsFoundEventHandler;
                gendalf.SomeThisIsChangedInAir();
                Console.WriteLine("\n\nTo exit press Escape key" +
                    "\nTo continue press any key . . .");
            } while (Console.ReadKey().Key != ConsoleKey.Escape);

            {
            }
        }
    }
}