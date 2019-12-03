using System;
using System.Threading;

namespace MS.Book.ManageProgramFlow.ThreadChapter
{
    /// <summary>
    /// Creating Thread example
    /// </summary>
    public static class ThreadChapterListing1
    {
        private static void ThreadMethod()
        {
            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine("ThreadProc: {0}", i);
                Thread.Sleep(0);
            }
        }
        
        private static void Run()
        {
            Thread t = new Thread(ThreadMethod);
            t.Start();
            for (int i = 0; i < 4; i++)
            {
                Console.WriteLine("Main thread: Do some work.");
                Thread.Sleep(0);
            }

            t.Join();
        }
    }
}