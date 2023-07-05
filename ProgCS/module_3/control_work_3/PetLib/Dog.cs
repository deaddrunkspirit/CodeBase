namespace PetLib
{
    /// <summary>
    /// Class dog inherited from pet
    /// </summary>
    public class Dog : Pet
    {
        /// <summary>
        /// This constructor creates an instance of dog 
        /// </summary>
        /// <param name="name">dog's name</param>
        /// <param name="mass">dog's mass</param>
        public Dog(string name, double mass) : base(name, mass)
        {
        }

        /// <summary>
        /// This method converts an instance of Dog to string
        /// </summary>
        /// <returns></returns>
        public override string ToString()
            => "Dog with " + base.ToString();
    }
}
