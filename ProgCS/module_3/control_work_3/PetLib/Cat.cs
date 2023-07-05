namespace PetLib
{
    /// <summary>
    /// Class cat inherited from pet
    /// </summary>
    public class Cat : Pet
    {
        /// <summary>
        /// This constructor creates an instance of cat 
        /// </summary>
        /// <param name="name">cat's name</param>
        /// <param name="mass">cat's mass</param>
        public Cat(string name, double mass) : base(name, mass)
        {
        }

        /// <summary>
        /// This method converts an instance of Cat to string
        /// </summary>
        /// <returns></returns>
        public override string ToString()
            => "Cat with " + base.ToString();
    }
}
