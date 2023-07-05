using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace A
{
    class A
    {
        static void Main()
        {
            int numberOfStudents;
            if (!int.TryParse(Console.ReadLine(), out numberOfStudents)
                || numberOfStudents < 1 || numberOfStudents > 100000)
            {
                Console.WriteLine("wrong");
                return;
            }
            int i = 0; /// counter for loop
            while (i < numberOfStudents)
            {
                string input = Console.ReadLine();
                /// this value will save input 
                /// to work with it later in method
                if (!CorrectInput(input))
                /// Checking for correct input
                {
                    Console.WriteLine("wrong");
                    return;
                }

                if (input == "bus")
                {
                    Console.WriteLine(3);
                }
                else if (input == "taxi")
                {
                    int price;
                    if (!int.TryParse(Console.ReadLine(), out price)
                        || price < 1 || price > 1000000)
                    /// Checking for correct input for price of the taxi 
                    {
                        Console.WriteLine("wrong");
                        return;
                    }
                    Console.WriteLine(NumberOfBills(price));
                }
                i++;
            }
        }

        /// <summary>
        /// This method checks the input for correctness
        /// </summary>

        static bool CorrectInput(string input)
        {
            if (input == "bus" || input == "none" || input == "taxi")
            {
                return true;
            }
            return false;
        }

        /// <summary>
        /// this method calculates the number of 
        /// bills students need to spend
        /// </summary>

        static int NumberOfBills(int price)
        {
            /// the price will be discounted if price > 1500
            if (price > 1500)
            {
                double priceWithSale = price;
                priceWithSale *= 0.8;
                price = Convert.ToInt32(Math.Ceiling(priceWithSale));
            }

            int countOfBills = 0; /// this is count of bills (or notes)
            while (price > 0)
            {
                if (price >= 500)
                /// count of five hundred notes
                {
                    countOfBills = price / 500;
                    price %= 500;
                }
                else if (price < 500 && price > 400)
                /// count of five hundred notes (the rest)
                {
                    price -= 500;
                    countOfBills++;
                }
                else if (price <= 400 && price > 300 || price > 100 && price <= 200)
                {
                    /// count of two hundred notes
                    price -= 200;
                    countOfBills++;
                }
                else if (price > 200 && price <= 300 || price > 0 && price <= 100)
                /// count of one hundred notes
                {
                    price -= 100;
                    countOfBills++;
                }
            }
            return countOfBills;
        }
    }
}
