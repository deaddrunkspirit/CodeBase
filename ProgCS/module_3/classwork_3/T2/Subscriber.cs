using System;
using System.Collections.Generic;
using System.Text;

namespace Task2Lib
{
    public class SomethingHappenedSubscriber
    {
        public void SomethingHappenedHandler() 
        { 
            Console.WriteLine("Subscriber has handled an event"); 
        }
    }
}
