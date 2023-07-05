using System;

namespace Task6Lib
{
    public class Wizard : Creature
    {
        new public delegate void RingIsFoundEventHandler
            (object sender, RingIsFoundEventArgs e);

        public event RingIsFoundEventHandler RaiseRingIsFoundEvent;

        public Wizard(string name, string location) : base(name, location)
        {
        }

        public void SomeThisIsChangedInAir()
        {
            Console.WriteLine($"{Name} >> The ring was found! Bilbo had it. " +
                $"Leaving {Location}. I'll meet you in Rivendell. " +
                $"Come as soon as you can . . .");
            RaiseRingIsFoundEvent(this, new RingIsFoundEventArgs("Rivendell"));
        }
    }
}