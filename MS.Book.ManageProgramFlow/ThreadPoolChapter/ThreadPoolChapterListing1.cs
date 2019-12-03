using System;
using System.Threading;

namespace MS.Book.ManageProgramFlow.ThreadPoolChapter
{  
    /// <summary>
    /// Example work from thread pool
    /// </summary>
    public static class ThreadPoolChapterListing1
    {
        private static void Run()
        {
            ThreadPool.QueueUserWorkItem((s) =>
            {
                Console.WriteLine("Working on a thread from threadpool");
            });
            Console.ReadLine();
        }
    }
}