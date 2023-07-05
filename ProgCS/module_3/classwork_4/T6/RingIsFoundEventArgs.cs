using System;

namespace Task6Lib
{
    public class RingIsFoundEventArgs : EventArgs
    {
        public string Message { get; set; }

        public RingIsFoundEventArgs(string message)
        {
            Message = message;
        }
    }
}