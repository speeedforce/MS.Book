﻿using System;
using System.Threading;
using System.Threading.Tasks;

namespace MS.Book.ManageProgramFlow.ManageSynchronized
{
    public static class CancelingTaskListing
    {
        public static void Run()
        {
            CancellationTokenSource cancellationTokenSource = new CancellationTokenSource();
            CancellationToken token = cancellationTokenSource.Token;
            
            Task task = Task.Run(() =>
            {
                while(!token.IsCancellationRequested)
                {
                    Console.Write("*");
                    Thread.Sleep(1000);
                }
                
                
                token.ThrowIfCancellationRequested();
            }, token);


            try
            {
                Console.WriteLine("Press enter to stop the task");
                Console.ReadLine();
                cancellationTokenSource.Cancel();
                task.Wait();
            
            }
            catch (AggregateException e)
            {
                Console.WriteLine(e.InnerExceptions[0].Message);
                Console.WriteLine("Press enter to end the application");
                Console.ReadLine();
            }
          
        }
    }
}