using System;
using System.Threading;

namespace MS.Book.ManageProgramFlow.ThreadChapter
{
    
    /// <summary>
    /// By marking a field with the ThreadStatic attribute, each thread gets its own copy of a field
    /// </summary>
    public static class ThreadChapterListing5
    {
        /// <summary>
        /// By marking a field with the ThreadStatic attribute, each thread gets its own copy of a field
        /// </summary>
        [ThreadStatic] private static int _field;
        
        private static void Run()
        {
            new Thread(() =>
            {
                for (int x = 0; x < 10; x++)
                {
                    _field++;
                    Console.WriteLine("Thread A: {0}", _field);
                }
            }).Start();


            new Thread(() =>
            {
                for (int x = 0; x < 10; x++)
                {
                    _field++;
                    Console.WriteLine("Thread B: {0}", _field);
                }
            }).Start();
            Console.ReadKey();
        }
    }
}