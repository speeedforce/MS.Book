using System;
using System.Threading;
using System.Threading.Tasks;

namespace MS.Book.ManageProgramFlow.TaskChapter
{
    public static class TaskChapterListing1
    {
        public static void Run()
        {
            Task<int> t = Task.Run((() => {Thread.Sleep(4000); return 42; }));

            Console.WriteLine(t.Result);
        }
    }
}