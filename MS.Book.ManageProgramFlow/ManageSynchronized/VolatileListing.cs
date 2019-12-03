using System;
using System.Threading;

namespace MS.Book.ManageProgramFlow.ManageSynchronized
{
    public static class VolatileListing
    {
        private static volatile int _flag = 0;
        private static int _value = 0;
        public static void Run()
        {
            new Thread(Thread2).Start();
            new Thread(Thread1).Start();
           
        }
        
        public static void Thread1()
        {
            _value = 5;
            _flag = 1;
        }
        public static void Thread2()
        {
            if (_flag == 1)
                Console.WriteLine(_value);
        }
    }
}