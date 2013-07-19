using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ProdConsApp
{
    public static class BasicWaitHandle
    {
        private static EventWaitHandle waitHandle = new AutoResetEvent(false);

        public static void Run()
        {
            Console.WriteLine("starting first");
            new Thread(Waiter).Start();
            Console.WriteLine("starting second");
            new Thread(Waiter).Start();

            Thread.Sleep(1000);
            waitHandle.Set();

            Console.ReadLine();
        }

        private static void Waiter()
        {
            waitHandle.WaitOne();
            Console.WriteLine("....started");
            Thread.Sleep(500);
            waitHandle.Set();
        }
    }
}
