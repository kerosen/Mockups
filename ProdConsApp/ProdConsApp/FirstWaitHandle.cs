using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ProdConsApp
{
    public static class MyWaitHandle
    {
        private static EventWaitHandle waitHandle = new AutoResetEvent(false);
        public static void Run()
        {
            new Thread(Waiter).Start();
            Thread.Sleep(1000);
            waitHandle.Set();
        }

        private static void Waiter()
        {
            Console.WriteLine("Waiting...1");
            waitHandle.WaitOne();
            Console.WriteLine("Waiting...2");

            Console.WriteLine("Notified");
        }
    }

}
