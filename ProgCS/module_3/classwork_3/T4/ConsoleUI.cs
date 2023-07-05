using System;

namespace Task4Lib
{
    public delegate void NewStringValue(string str);

    public class ConsoleUI
    {
        public UIString s = new UIString();

        public UIString S { get { return s; } set { s = value; } }

        public event NewStringValue NewStringValueHappened;

        public void GetStringFromUI()
        {
            Console.WriteLine("Input new string");
            s.Str = Console.ReadLine();
            NewStringValueHappened(s.Str);
            RefreshUI();
        }

        public void CreateUI()
        {
            NewStringValueHappened += s.NewStringHappenedHandler;
            RefreshUI();
        }

        public void RefreshUI() 
        {
            Console.Clear();
            Console.WriteLine($"String text: {s.Str}");
        }
    }
}
