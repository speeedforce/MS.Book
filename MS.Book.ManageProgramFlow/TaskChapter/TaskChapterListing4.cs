using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace MS.Book.ManageProgramFlow.TaskChapter
{
    public static class TaskChapterListing4
    {
        /// <summary>
        /// WaitAny example
        /// </summary>
        public static void Run()
        {
            Task<int>[] tasks = new Task<int>[3];

            tasks[0] = Task.Run(() =>
            {
                Thread.Sleep(4000);
                Console.WriteLine("Running 1");
                return 1;
            });
            
            tasks[1] = Task.Run(() =>
            {
                Thread.Sleep(1000);
                Console.WriteLine("Running 2");
                return 2;
            });
            
            tasks[2] = Task.Run(() =>
            {
                Thread.Sleep(3000);
                Console.WriteLine("Running 3");
                return 3;
            });

            while (tasks.Length > 0)
            {
                int i = Task.WaitAny(tasks);

                Task<int> completedTask = tasks[i];
                
                Console.WriteLine(completedTask.Result);

                var temp = tasks.ToList();
                temp.RemoveAt(i);
                tasks = temp.ToArray();
            }
        }
    }
}