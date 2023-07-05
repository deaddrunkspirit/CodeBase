using System;

namespace Task6Lib
{
    public class Elf : Creature
    {
        public Elf(string name, string location) : base(name, location)
        {
        }

        public override void RingIsFoundEventHandler(object sender, RingIsFoundEventArgs e)
        {
            Console.WriteLine($"{Name} >> The stars aren't shining as bright " +
                $"as usual. The flowers wilt. Leaves says to leave {Location} " +
                $"and go to {e.Message}");
        }
    }
}