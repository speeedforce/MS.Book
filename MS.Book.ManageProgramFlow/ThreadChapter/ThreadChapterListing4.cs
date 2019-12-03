using System;
using System.Threading;

namespace MS.Book.ManageProgramFlow.ThreadChapter
{
    /// <summary>
    /// Example correct aborting of thread.
    /// </summary>
    public static class ThreadChapterListing4
    {
        private static void Run()
        {
            bool stopped = false;

            Thread t = new Thread(new ThreadStart(() =>
            {
                while (!stopped)
                {
                    Console.WriteLine("Running...");
                    Thread.Sleep(500);
                }
            }));

            t.Start();

            Console.WriteLine("Press any key to exit");
            Console.ReadKey();

            stopped = false;
            t.Join();
        }
    }
}