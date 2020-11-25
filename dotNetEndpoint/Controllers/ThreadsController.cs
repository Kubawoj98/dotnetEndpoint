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
        [Route("new_thread")]
        public string NewThread()
        {
            string test = "";
            Thread th = Thread.CurrentThread;
            th.Name = "GłównyWątek";
            test += th.Name;
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
    }
}
