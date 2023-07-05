namespace Task6Lib
{
    public abstract class Creature
    {
        public string Name { get; private set; }

        public string Location { get; set; }

        protected Creature(string name, string location)
        {
            Name = name;
            Location = location;
        }

        public virtual void RingIsFoundEventHandler(object sender, RingIsFoundEventArgs e)
        { }
    }
}