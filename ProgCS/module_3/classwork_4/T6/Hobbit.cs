using System;

namespace Task6Lib
{
    public class Hobbit : Creature
    {
        public Hobbit(string name, string location) : base(name, location)
        {
        }

        public override void RingIsFoundEventHandler(object sender, RingIsFoundEventArgs e)
        {
            Console.WriteLine($"{Name} >> Leaving {Location}! Going to {e.Message}");
        }
    }
}