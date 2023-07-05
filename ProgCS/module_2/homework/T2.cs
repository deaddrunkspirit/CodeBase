using System;

namespace SecondSem
{
    internal class Birthday
    {
        string name;

        int day, month, year;

        public Birthday(string name, int y, int m, int d) // конструктор
        {
            this.name = name;
            year = y;
            month = m;
            day = d;
        }

        public Birthday(string name, int d, string m, int y)
        {
            this.name = name;
            year = y;
            day = d;
            switch (m)
            {
                case "January":
                    month = 1;
                    break;
                case "February":
                    month = 2;
                    break;
                case "March":
                    month = 3;
                    break;
                case "April":
                    month = 4;
                    break;
                case "May":
                    month = 5;
                    break;
                case "June":
                    month = 6;
                    break;
                case "July":
                    month = 7;
                    break;
                case "August":
                    month = 8;
                    break;
                case "September":
                    month = 9;
                    break;
                case "October":
                    month = 10;
                    break;
                case "November":
                    month = 11;
                    break;
                case "December":
                    month = 12;
                    break;
                default:
                    throw new ArgumentException("Wrong month value");
            }
        }

        public Birthday()
        {
            this.name = "None";
            year = 1970;
            month = 1;
            day = 1;
        }

        DateTime Date // свойство
        {
            get { return new DateTime(year, month, day); }
        }

        public string Information // свойство
        {
            get
            {
                return name + ", birthday date is " +
                    day + ":" + month + ":" + year;
            }
        }

        public int HowManyDays // свойство
        {
            get
            {
                int today = DateTime.Now.DayOfYear;
                int birthday = Date.DayOfYear;
                int period = birthday >= today ?
                    birthday - today : 365 - today + birthday;

                return period;
            }
        }

    }


    class Program
    {
        static void Main()
        {
            var pers1 = new Birthday("Tony", 1992, 2, 9);
            var me = new Birthday("Eugen", 2001, 7, 27);
            var bro = new Birthday("George", 1999, 4, 10);
            var test = new Birthday("shit", 2000, "January", 12);
            PrintIfoAndDaysUntillBirthday(pers1);
            PrintIfoAndDaysUntillBirthday(me);
            PrintIfoAndDaysUntillBirthday(bro);
            PrintIfoAndDaysUntillBirthday(test);
        }

        private static void PrintIfoAndDaysUntillBirthday(Birthday pers)
        {
            Console.WriteLine("-------");
            Console.WriteLine(pers.Information);
            Console.WriteLine($"There are {pers.HowManyDays} untill next birthday");
            Console.WriteLine("-------");
        }
    }
}
