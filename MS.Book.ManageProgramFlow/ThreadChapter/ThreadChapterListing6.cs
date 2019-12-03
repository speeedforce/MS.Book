using System;
using System.Threading;

namespace MS.Book.ManageProgramFlow.ThreadChapter
{
    public static class ThreadChapterListing6
    {
        private static readonly ThreadLocal<int> _field =
            new ThreadLocal<int>(() => Thread.CurrentThread.ManagedThreadId);

        private static void Run()
        {
            new Thread(() =>
            {
                for (int x = 0; x < _field.Value; x++)
                {
                   
                    Console.WriteLine("Thread A: {0}", x);
                }
            }).Start();


            new Thread(() =>
            {
                for (int x = 0; x < _field.Value; x++)
                {
                
                    Console.WriteLine("Thread B: {0}", x);
                }
            }).Start();
            Console.ReadKey();
        }
    }
}