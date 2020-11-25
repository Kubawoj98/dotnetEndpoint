using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace dotNetEndpoint.Controllers
{
    [Route("[controller]")]
    public class ThreadsController : Controller 
    {
        static Thread thread1, thread2;
        [Route("new_thread")]
        public string NewThread()
        {
            string test = "";
            Thread th = Thread.CurrentThread;
            th.Name = "GłównyWątek";
            test += th.Name;
            RevDeBugAPI.Snapshot.RecordSnapshot("new_thread");
            return test;
        }
        [Route("child_threads")]
        public string ChildThreads()
        {
            string test = "";
            ThreadStart ts = new ThreadStart(CallToChildThread);
            test +=("Główny wątek: Tworzenie wątku pochodnego");
            Thread pochodnyWatek = new Thread(ts);
            // Uruchamiamy wątek pochodny
            pochodnyWatek.Start();
            // zatrzymanie głównego wątku
            Thread.Sleep(2000);
            // przerwanie wątku pochodnego
            test += ("Główny wątek: przerwanie wątku pochodnego");
            pochodnyWatek.Interrupt();
            RevDeBugAPI.Snapshot.RecordSnapshot("child_threads");
            return test;

        }
        [Route("join_threads")]
        public string JoinThreads()
        {
            string test = "Wypisano w konsoli";
            thread1 = new Thread(ThreadProc);
            thread1.Name = "Thread1";
            thread1.Start();

            thread2 = new Thread(ThreadProc);
            thread2.Name = "Thread2";
            thread2.Start();
            RevDeBugAPI.Snapshot.RecordSnapshot("join_threads");

            return test;

        }
        public static void CallToChildThread()
        {
            try
            {
                Console.WriteLine("Wątek pochodny wystartował");
                // wykonanie jakichś instrukcji, np. odliczanie do 10
                for (int i = 0; i < 10; i++)
                {
                    // przerwanie wykonywania wątku na okreslony okres czasu
                    Thread.Sleep(2);
                    Console.WriteLine(i);
                }
                Console.WriteLine("Wątek został wykonany");
            }
            catch (ThreadAbortException e)
            {
                Console.WriteLine("Wyjątek: ThreadAbortException");
            }
            finally
            {
                Console.WriteLine("Nie można złapać wyjątku");
            }

        }
        private static void ThreadProc()
        {
            Console.WriteLine("\nCurrent thread: {0}", Thread.CurrentThread.Name);
            if (Thread.CurrentThread.Name == "Thread1" &&
                thread2.ThreadState != ThreadState.Unstarted)
                thread2.Join();

            Thread.Sleep(4000);
            Console.WriteLine("\nCurrent thread: {0}", Thread.CurrentThread.Name);
            Console.WriteLine("Thread1: {0}", thread1.ThreadState);
            Console.WriteLine("Thread2: {0}\n", thread2.ThreadState);
        }
    }
}
