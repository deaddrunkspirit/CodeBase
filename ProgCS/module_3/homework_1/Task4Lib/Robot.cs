using System;

namespace Task4Lib
{
    public delegate void Steps();

    public class Robot
    {
        private int x, y;

        public int X => x;
         
        public int Y => y;

        public void Right() { x++; }

        public void Left() { x--; }

        public void Forward() { y++; }

        public void Backward() { y--; }

        public string Position() 
            => $"The Pobot position:\nx = {x:f3},\ny = {y:f3}";
    }
}
