using System;
using System.Threading.Tasks;

namespace MS.Book.ManageProgramFlow.TaskChapter
{
       
   
    public static class TaskChapterListing2
    {
        /// <summary>
        /// Example of continuation tasks
        /// </summary>
        public static void RunContinuation()
        {
            Task<int> t = Task.Run(() => 42).ContinueWith((i) => i.Result * 3);

            Console.WriteLine(t.Result);
        }
        
        
        /// <summary>
        /// Overloading continuation 
        /// </summary>
        public static void RunContinuationOverload()
        {
            Task<int> t = Task.Run(() => 42);
            t.ContinueWith((i) =>
            {
                Console.WriteLine("Canceled");
            }, TaskContinuationOptions.OnlyOnCanceled);
            t.ContinueWith((i) =>
            {
                Console.WriteLine("Faulted");
            }, TaskContinuationOptions.OnlyOnFaulted);
            var completedTask = t.ContinueWith((i) =>
            {
                Console.WriteLine("Completed");
            }, TaskContinuationOptions.OnlyOnRanToCompletion);
            completedTask.Wait();
        }
        
        
    }
}