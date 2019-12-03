using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace MS.Book.ManageProgramFlow.AsyncAwaitChapter
{
    public static class AsyncAwaitListing1
    {
        public static void Run()
        {
            string result = DownloadContent().Result;
            Console.WriteLine(result);
        }

        private static async Task<string> DownloadContent()
        {
            using(HttpClient client = new HttpClient())
            {
                string result = await client.GetStringAsync("http://www.microsoft.com");
                return result;
            }
        }

        
        /// <summary>
        /// Example working threads
        /// </summary>
        public static  void Test()
        {
            Task<int> t = new Task<int>(() =>
            {
                Console.WriteLine("Run task...");
                Console.WriteLine();
                Thread.Sleep(5000); 
                Console.WriteLine("Task is completed");
           
                return 1;
            });
            t.Start();
            Console.WriteLine("Run main..");
            Thread.Sleep(2000);
            Console.WriteLine("Main is completed..");
           
            
            
            
            Console.WriteLine("Test");
            
            Console.WriteLine(t);
        }
    }
}