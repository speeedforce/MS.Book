using System;
using System.Threading;

namespace MS.Book.ManageProgramFlow
{
    static class Program
    {
        public static void Main(string[] args)
        {
            #region Thread Examples

            //Listing_1_1();
            //Listing_1_2();
            //Listing_1_3();
            //Listing_1_4();
            //Listing_1_5();
            //Listing_1_6();

            #endregion

            #region ThreadPool

            

            #endregion
        }


        #region Object 1.1 multithreading and asynchronous processing

        #region Listing 1.1

        /// <summary>
        /// Thread.Sleep(0) is used to signal to Windows that this thread is finished.
        /// Instead of waiting for the whole time-slice of the thread to finish, it will immediately switch to another thread
        /// </summary>
        private static void ThreadMethod()
        {
            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine("ThreadProc: {0}", i);
                Thread.Sleep(0);
            }
        }

        /// <summary>
        /// Creating Thread example
        /// </summary>
        private static void Listing_1_1()
        {
            Thread t = new Thread(new ThreadStart(ThreadMethod));
            t.Start();
            for (int i = 0; i < 4; i++)
            {
                Console.WriteLine("Main thread: Do some work.");
                Thread.Sleep(0);
            }

            t.Join();
        }

        #endregion
        
        #region Listing 1.2

        /// <summary>
        /// If t12.IsBackground = true, the app will be terminate immediately
        /// else app will finished after thread and write in console message. 
        /// </summary>
        /// Using type of process
        private static void Listing_1_2()
        {
            Thread t12 = new Thread(new ThreadStart(ThreadMethod)) {IsBackground = false};
            t12.Start();
        }

        #endregion

        /// <summary>
        ///  Example with sending parameters to Thread
        /// </summary>
        /// <param name="o"></param>
        #region Listing 1.3

        private static void ThreadWithParams(object o)
        {
            for (int i = 0; i < (int) o; i++)
            {
                Console.WriteLine("ThreadProc: {0}", i);
                Thread.Sleep(0);
            }
        }

        public static void Listing_1_3()
        {
            Thread t = new Thread(new ParameterizedThreadStart(ThreadWithParams));
            t.Start(54);
            t.Join();
        }

        #endregion

        /// <summary>
        /// Example correct aborting of thread.
        /// </summary>
        #region Listing 1.4

        private static void Listing_1_4()
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

        #endregion

        #region Listing 1.5 and Listing 1.6

        /// <summary>
        /// By marking a field with the ThreadStatic attribute, each thread gets its own copy of a field
        /// </summary>
        [ThreadStatic] private static int _field;

        private static ThreadLocal<int> _field_listing1_6 =
            new ThreadLocal<int>(() => Thread.CurrentThread.ManagedThreadId);

        private static void Listing_1_5()
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

        private static void Listing_1_6()
        {
            new Thread(() =>
            {
                for (int x = 0; x < _field_listing1_6.Value; x++)
                {
                    _field++;
                    Console.WriteLine("Thread A: {0}", _field);
                }
            }).Start();


            new Thread(() =>
            {
                for (int x = 0; x < _field_listing1_6.Value; x++)
                {
                    _field++;
                    Console.WriteLine("Thread B: {0}", _field);
                }
            }).Start();
            Console.ReadKey();
        }

        #endregion

        #endregion
        
    }
}