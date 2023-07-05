namespace Task7Lib
{
    public delegate int MyDel(double first, double second);

    public class TestClass
    {
        public static int TestMethod(double first, double second) 
            => (int)first + (int)second; 
    }
}
