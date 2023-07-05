using System;

namespace SRClass
{
    public class Cat
    {
        /// <summary>
        /// This field is a name of the cat
        /// </summary>
        private string name;

        /// <summary>
        /// This field is array of meows
        /// </summary>
        private string[] meowArr;

        /// <summary>
        /// This constructor with two parametrs creates a cat
        /// </summary>
        /// <param name="name"></param>
        /// <param name="meowArr"></param>
        public Cat(string name, string[] meowArr)
        {
            this.name = name;
            this.meowArr = meowArr;
        }

        public string this[string meow]
        {
            get
            {
                return meow;
            }
        }

        
        /// <summary>
        /// This override method converts Cat type to String
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            string res = $"{name} says ";
            for (int i = 0; i < meowArr.Length; i++)
            {
                res += $" {meowArr[i]} ";
            }

            return res;
        }
    }
}
