using System;

namespace PetLib
{
    /// <summary>
    /// Abstract pet class with inherited from IPet interface
    /// </summary>
    public abstract class Pet : IPet
    {
        /// <summary>
        /// Name of the pet
        /// </summary>
        private string name;

        /// <summary>
        /// Mass of the pet
        /// </summary>
        private double mass;

        /// <summary>
        /// Protected constructor which creates an instance of Pet
        /// </summary>
        /// <param name="name"></param>
        /// <param name="mass"></param>
        protected Pet(string name, double mass)
        {
            Name = name;
            Mass = mass;
        }

        /// <summary>
        /// Property to get or set pet's name
        /// </summary>
        public string Name
        {
            get => name;
            set
            {
                if (value[0] < 'A' || value[0] > 'Z'
                    || !Array.TrueForAll(value.Substring(1).ToCharArray(),
                    l => l > 'a' - 1 && l < 'z' + 1) || value.Length < 3 || value.Length > 10)
                    throw new PetException($"Недопустимая кличка {value}");

                name = value;
            }
        }

        /// <summary>
        /// Property to get or set pet's mass
        /// </summary>
        public double Mass
        {
            get => mass;
            set
            {
                if (value < 0)
                    throw new PetException("Масса не может быть отрицательной");

                mass = value;
            }
        }

        /// <summary>
        /// Method for comparing two pets
        /// </summary>
        /// <param name="other"></param>
        /// <returns></returns>
        public int CompareTo(IPet other)
            => Mass == other.Mass ? Name.CompareTo(other.Name) : Mass.CompareTo(other.Mass);

        /// <summary>
        /// Method that convert's pet instance to string
        /// </summary>
        /// <returns></returns>
        public override string ToString()
            => $"name = {Name}, mass = {Mass:f2}";
    }
}
