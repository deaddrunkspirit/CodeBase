namespace Task6Lib
{
    public delegate int MyDel(int first, int second);

    public class TestClass
    {
        public static int TestMethod(int first, int second) 
            => first > second ? first : second; 
    }
}
