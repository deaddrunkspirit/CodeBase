using System;

namespace Task6Lib
{
    public class Dwarf : Creature
    {
        public Dwarf(string name, string location) : base(name, location)
        {
        }

        public override void RingIsFoundEventHandler(object sender, RingIsFoundEventArgs e)
        {
            Console.WriteLine($"{Name} >> Sharpen axes, salvage supplies!" +
                $" We are leaving {Location}. {e.Message} waits for us");
        }
    }
}