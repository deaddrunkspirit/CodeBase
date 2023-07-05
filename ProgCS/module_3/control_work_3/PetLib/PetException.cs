using System;
using System.Runtime.Serialization;

namespace PetLib
{
    /// <summary>
    /// Custom exception class created to catch invalid pet data,
    /// such as negative mass or incorrect name
    /// </summary>
    public class PetException : Exception
    {
        public PetException()
        {
        }

        public PetException(string message) : base(message)
        {
        }

        public PetException(string message, Exception innerException)
            : base(message, innerException)
        {
        }

        protected PetException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }
    }
}
