using System;

namespace PetLib
{
    /// <summary>
    /// Interface which describes a pet with name and mass
    /// </summary>
    public interface IPet : IComparable<IPet>
    {
        /// <summary>
        /// Name of the pet
        /// </summary>
        string Name { get; set; }

        /// <summary>
        /// mass of the pet
        /// </summary>
        double Mass { get; set; }
    }
}
