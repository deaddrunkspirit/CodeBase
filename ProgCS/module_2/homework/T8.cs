using System;

namespace T8
{
    class Schedule
    {
        public string this[string day]
        {
            get
            {
                switch (day)
                {
                    case "Monday":
                        return days[0] == null ? "No lessons" : days[0];
                    case "Tuesday":
                        return days[1] == null ? "No lessons" : days[1];
                    case "Wednesday":
                        return days[2] == null ? "No lessons" : days[2];
                    case "Thursday":
                        return days[3] == null ? "No lessons" : days[3];
                    case "Friday":
                        return days[4] == null ? "No lessons" : days[4];
                    case "Saturday":
                        return days[5] == null ? "No lessons" : days[5];
                    case "Sunday":
                        return days[6] == null ? "No lessons" : days[6];
                    default:
                        return "Incorrect input";
                }
            }
        }

        string[] days = new string[7];

        public Schedule(params string[] d)
        {
            for (int i = 0; i < d.Length; i++)
            {
                days[i] = d[i];
            }
        }
    }

    class Program
    {
        static void Main()
        {
            var Module2 = new Schedule("9:00", "10:30", null, "13:40", "15:00", null, null);
            Console.WriteLine("In module 2 lessons strarts at:\n");
            Console.WriteLine("Monday: \t" + Module2["Monday"]);
            Console.WriteLine("Tuesday: \t" + Module2["Tuesday"]);
            Console.WriteLine("Wednesday: \t" + Module2["Wednesday"]);
            Console.WriteLine("Thursday: \t" + Module2["Thursday"]);
            Console.WriteLine("Friday: \t" + Module2["Friday"]);
            Console.WriteLine("Saturday: \t" + Module2["Saturday"]);
            Console.WriteLine("Sunday: \t" + Module2["Sunday"]);
            Console.ReadKey();
        }
    }
}
