using System;

namespace Task7Lib
{
    public class Display
    {
        public static int len = 30;
        public static string str = null;

        public static void BarShow(long n, int si, int kl)
        {
            int pos = Math.Abs((int)((double)kl / si * len));
            string s1 = new string('\u258c', pos), 
                s2 = new string('-', len - pos - 1) + '\u25c4';
            str = s1 + '\u258c' + s2;
            Console.Write("\r\t\t" + str);
        }
    }
}
