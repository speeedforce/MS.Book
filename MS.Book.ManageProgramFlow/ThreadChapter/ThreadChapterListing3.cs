using System;
using System.Threading;
namespace MS.Book.ManageProgramFlow.ThreadChapter
{
    /// <summary>
    ///  Example with sending parameters to Thread
    /// </summary>
    /// <param name="o"></param>
    public static class ThreadChapterListing3
    {
        private static void ThreadWithParams(object o)
        {
            for (int i = 0; i < (int) o; i++)
            {
                Console.WriteLine("ThreadProc: {0}", i);
                Thread.Sleep(0);
            }
        }

        public static void Run()
        {
            Thread t = new Thread(new ParameterizedThreadStart(ThreadWithParams));
            t.Start(54);
            t.Join();
        }
    }
}