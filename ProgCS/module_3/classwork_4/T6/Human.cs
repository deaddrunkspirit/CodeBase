using System;

namespace Task6Lib
{
    public class Human : Creature
    {
        public Human(string name, string location) : base(name, location)
        {
        }

        public override void RingIsFoundEventHandler(object sender, RingIsFoundEventArgs e)
        {
            Console.WriteLine($"{Name} >> Wizard {((Wizard)sender).Name} called." +
                $" I need to go to {e.Message} from {Location}");
        }
    }
}