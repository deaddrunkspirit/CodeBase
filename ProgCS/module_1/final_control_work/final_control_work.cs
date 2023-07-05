using System;
using System.IO;

namespace EKR_Sample
{
    class MainClass
    {
        static readonly Random rnd = new Random();
        static readonly string path = "Log.txt";

        public static void Logger(string log)
        {
            try
            {
                File.AppendAllText(path, log + Environment.NewLine);
            }
            catch (IOException)
            {
                Console.WriteLine($"При логировании сообщения: \"{log}\" " +
                    $"произошла ошибка");
            }
        }

        public static int ReadInt(string info, int left, int right)
        {
            int n;
            while (true)
            {
                try
                {
                    Console.WriteLine(info);
                    string str = Console.ReadLine();

                    Logger("Запрос на ввод: " + info);
                    Logger("Результат: " + str);

                    n = int.Parse(str);
                    if (n < left || n > right)
                        throw new ArgumentException();
                    break;
                }
                catch (ArgumentNullException)
                {
                    Console.WriteLine("Empty");
                    Logger("Empty");
                }
                catch (ArgumentException)
                {
                    Console.WriteLine($"Number must be in [{left};{right}]");
                    Logger($"Number must be in [{left};{right}]");
                }
                catch (OverflowException)
                {
                    Console.WriteLine($"Number must be in [{left};{right}]");
                    Logger($"Number must be in [{left};{right}]");
                }
                catch (FormatException)
                {
                    Console.WriteLine("Not a number");
                    Logger("Not a number");
                }
            }
            return n;
        }

        public static char ReadChar(string info, char left, char right)
        {
            char n;
            while (true)
            {
                try
                {
                    Console.WriteLine(info);
                    string str = Console.ReadLine();

                    Logger("Запрос на ввод: " + info);
                    Logger("Результат: " + str);

                    if (str.Length != 1)
                        throw new ArgumentException();
                    n = str[0];
                    if (n < left || n > right)
                        throw new ArgumentException();
                    break;
                }
                catch (ArgumentNullException)
                {
                    Console.WriteLine("Empty");
                    Logger("Empty");
                }
                catch (ArgumentException)
                {
                    Console.WriteLine($"Char must be in [{left};{right}]");
                    Logger($"Char must be in [{left};{right}]");
                }
                
            }
            return n;
        }

        public static void RunCommon(char[] chArr)
        {
            try
            {
                char common = CommonlyOccurringChar(chArr);
                Console.WriteLine("Самый частый элемент: " + common);
                Logger("Самый частый элемент: " + common);
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine("При нахождении самого частого элемента возникла ошибка: "
                    + ex.Message);
                Logger("При нахождении самого частого элемента возникла ошибка: "
                    + ex.Message);
            }
        }

        public static void RunK(char[] chArr)
        {
            int k = ReadInt("Введите k: ", 1, 26);
           
            try
            {
                char[] kCh = kChar(chArr, k);
                string ans = String.Join(" ", kCh);

                Console.WriteLine("Элементы, кратные k: " + ans);
                Logger("Элементы, кратные k: " + ans);
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine("При нахождении элементнов, кратных k возникла ошибка: "
                    + ex.Message);
                Logger("При нахождении элементнов, кратных k возникла ошибка: "
                    + ex.Message);
            }
        }

        public static void RunInterval(char[] chArr)
        {
            char ch1 = ReadChar("Введите ch1: ", 'a', 'z');
            char ch2 = ReadChar("Введите ch2: ", 'a', 'z');
            if (ch1 >= ch2)
            {
                Console.WriteLine("ch1 в алфавите правее, чем ch2");
                Logger("ch1 в алфавите правее, чем ch2");
            }
            else
            {
                try
                {
                    char[] charInterval = GetCharsInInterval(chArr, ch1, ch2);
                    Console.WriteLine(String.Join(" ", charInterval));
                    Logger(String.Join(" ", charInterval));
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine("При нахождении элементнов в интервале: "
                        + ex.Message);
                    Logger("При нахождении элементнов в интервале: "
                        + ex.Message);
                }
            }
        }

        public static void RunCounter(char[] chArr)
        {
            try
            {
                int[] alp = CountOfCharFormAlp(chArr);
                int k = 0;
                for (int i = 0; i < alp.Length; i++)
                {
                    if (alp[i] == 0)
                        continue;
                    Console.WriteLine($"{(char)(i + 'a')} : {alp[i]} \t");
                    Logger($"{(char)(i + 'a')} : {alp[i]} \t");
                    
                }
                Console.WriteLine();
            }
            catch(ArgumentException ex)
            {
                Console.WriteLine("При подсчете символов из алфавита: "
                    + ex.Message);
                Logger("При подсчете символов из алфавита: "
                    + ex.Message);
            }
        }

        public static void Menu(int N)
        {
            string str = GenerateString(N);
            char[] chArr = str.ToCharArray();

            while (true)
            {
                int menu = ReadInt("Выберите номер пункта:\n\t" +
                    "1. Вывести массив\n\t" +
                    "2. Частый элемент\n\t" +
                    "3. Символы, кратные k\n\t" +
                    "4. Нахождение символов в интервале\n\t" +
                    "5. Подсчет каждого символа\n\t" +
                    "6. Ввести N снова или выйти", 1, 6);

                switch (menu)
                {
                    case 1:
                        Console.WriteLine(String.Join(" ", chArr));
                        Logger(String.Join(" ", chArr));
                        break;
                    case 2:
                        RunCommon(chArr);
                        break;
                    case 3:
                        RunK(chArr);
                        break;
                    case 4:
                        RunInterval(chArr);
                        break;
                    case 5:
                        RunCounter(chArr);
                        break;
                    case 6:
                        return;
                }
            }
        }

        public static void Main(string[] args)
        {
            do
            { 
                int N = ReadInt("Введите N: ", 1, Int32.MaxValue);
                
                Menu(N);

                Console.WriteLine("Для продолжения нажмите Enter");
                Logger("Для продолжения нажмите Enter");
            } while (Console.ReadKey(true).Key == ConsoleKey.Enter);
        }

        public static string GenerateString(int N)
        {
            string str = "";
            for (int i = 0; i < N; i++)
            {
                str += (char)rnd.Next('a', 'z' + 1);
            }
            return str;
        }

        public static char[] ConvertStrToChars(string str)
        {
            char[] chArr = new char[str.Length];

            for (int i = 0; i < str.Length; i++)
            {
                chArr[i] = str[i];
            }

            return chArr;
        }

        public static int[] CountOfCharFormAlp(char[] chArr)
        {
            if (chArr.Length == 0)
                throw new ArgumentException("Массив нулевой длины");

            int[] alp = new int['z' - 'a' + 1];
            for (int i = 0; i < chArr.Length; i++)
            {
                alp[chArr[i] - 'a']++;
            }
            return alp;
        }

        public static char CommonlyOccurringChar(char[] chArr)
        {
            if (chArr.Length == 0)
                throw new ArgumentException("Массив нулевой длины");

            int[] alp = CountOfCharFormAlp(chArr);
            int maxIndex = GetMaxIndex(alp);
            if (maxIndex == -1)
                throw new ArgumentException("Массив без элементов");
            else
                return (char)(maxIndex + 'a');
        }

        public static int GetMaxIndex(int[] arr)
        {
            int index = -1;
            int max = -1;
            for (int i = 0; i < arr.Length; i++)
            {
                if(arr[i] > max)
                {
                    max = arr[i];
                    index = i;
                }
            }
            return index;
        }

        public static char[] kChar(char[] chArr, int k)
        {
            if (chArr.Length == 0)
                throw new ArgumentException("Массив нулевой длины");
            char[] ans = new char[0];
            for (int i = 0; i < chArr.Length; i++)
            {
                if((chArr[i] - 'a') % k == 0)
                {
                    Array.Resize(ref ans, ans.Length + 1);
                    ans[ans.Length - 1] = chArr[i];
                }
            }

            return ans;
        }
        // По условию необходимо лишь посчитать количество, это не так важно.
        public static char[] GetCharsInInterval(char[] chArr, char ch1, char ch2)
        {
            if (chArr.Length == 0)
                throw new ArgumentException("Массив нулевой длины");
            char[] ans = new char[0];
            for (int i = 0; i < chArr.Length; i++)
            {
                if (chArr[i] > ch1 && chArr[i] < ch2)
                {
                    Array.Resize(ref ans, ans.Length + 1);
                    ans[ans.Length - 1] = chArr[i];
                }
            }
            return ans;
        }
    }
}
