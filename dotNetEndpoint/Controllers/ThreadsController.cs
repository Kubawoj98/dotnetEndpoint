using Microsoft.AspNetCore.Mvc;
﻿using dotNetEndpointApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace dotNetEndpoint.Controllers
{
    [Route("[controller]")]

    public class ThreadsController : Controller
    {
        public Thread thread1 { get; set; }
        public Thread thread2 { get; set; }
        public Thread thread3 { get; set; }
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
        public void JoinThreads()
        {
            var testCase = new TwoThreadsJoinCase();
            testCase.initializeTwoThreads();
        }

        [Route("call_thread")]
        public string CallThread()
        {
            string test = "";
            ThreadStart ts1 = new ThreadStart(CallToFirstThread);
            ThreadStart ts2 = new ThreadStart(CallToSecondThread);
            thread1 = new Thread(ts1);
            thread2 = new Thread(ts2);
            thread1.Start();
            using (var afc=System.Threading.ExecutionContext.SuppressFlow())
            {
                thread2.Start();
            }
            

            RevDeBugAPI.Snapshot.RecordSnapshot("call_thread");

            return test;

        }
        [Route("multipleCallOfMehtod")]
        public string multipleCallOfMehtod()
        {
            string test = "";
            ThreadStart ts1 = new ThreadStart(displayUserData);
            ThreadStart ts2 = new ThreadStart(displayUserData);
            ThreadStart ts3 = new ThreadStart(displayUserData);
            thread1 = new Thread(ts1);
            thread2 = new Thread(ts2);
            thread3 = new Thread(ts3);
            thread1.Start();
            thread2.Start();
            thread3.Start();


            RevDeBugAPI.Snapshot.RecordSnapshot("multipleCallOfMehtod");

            return test;

        }
        public static void displayUserData()
        {
            Person person = new Person("Tyson", "Fury");
            Console.WriteLine(person.GetUserData());

            person.GetUserData();
        }
        public static void CallToFirstThread()
        {
            try
            {
                Console.WriteLine("Wątek pierwszy wystartował");
                Thread.Sleep(5000);
                var url = "http://0.0.0.0:6015/Console/console_writeline";
                var httpClient = new HttpClient();
                var response = httpClient.GetAsync(url);
                Console.WriteLine("Wątek został wykonany");

            }
            catch (ThreadInterruptedException e)
            {
                Console.WriteLine("Wyjątek: ThreadInterruptedException");

            }
            finally
            {
                Console.WriteLine("Nie można złapać wyjątku");
            }


        }
        public static void CallToSecondThread()
        {
            try
            {
                Console.WriteLine("Wątek pierwszy wystartował");
                Thread.Sleep(6000);
                var url = "http://0.0.0.0:6015/Lists/list_size";
                var httpClient = new HttpClient();
                var response = httpClient.GetAsync(url);
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
            catch (ThreadInterruptedException e)
            {
                Console.WriteLine("Wyjątek: ThreadInterruptedException");
            }
            finally
            {
                Console.WriteLine("Nie można złapać wyjątku");
            }
        }
        public class TwoThreadsJoinCase
        {
            private Thread thread1, thread2;
            public void initializeTwoThreads()
            {
                string test = "Wypisano w konsoli";
                thread1 = new Thread(ThreadProc);
                thread1.Name = "Thread1";
                thread2 = new Thread(ThreadProc);
                thread2.Name = "Thread2";
                thread1.Start();
                thread2.Start();
                RevDeBugAPI.Snapshot.RecordSnapshot("join_threads");
            }
            private void ThreadProc()
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
}
