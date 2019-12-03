using System;
using System.Threading;
namespace MS.Book.ManageProgramFlow.ThreadChapter
{
    /// <summary>
    /// If t12.IsBackground = true, the app will be terminate immediately
    /// else app will finished after thread and write in console message. 
    /// </summary>
    /// Using type of process
    public static class ThreadChapterListing2
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
            Thread t12 = new Thread(new ThreadStart(ThreadMethod)) {IsBackground = false};
            t12.Start();
        }
    }
}