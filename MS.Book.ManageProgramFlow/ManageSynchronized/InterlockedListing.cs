using System;
using System.Threading;
using System.Threading.Tasks;

namespace MS.Book.ManageProgramFlow.ManageSynchronized
{
    public static class InterlockedListing
    {
        public static void Run()
        {
            int n = 0;
            var up = Task.Run(() =>
            {
                for (int i = 0; i < 1000000; i++)
                    Interlocked.Increment(ref n);
            });
                
                
            for (int i = 0; i < 1000000; i++)
                Interlocked.Decrement(ref n);
                        
                        
            up.Wait();
            Console.WriteLine(n);
        }
    }
}