using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ProdConsApp
{
    ///Imagine you've got a toy that comes in two parts, and you need both parts to play with it—a toy drum and drumstick, for example. Now imagine that you've got two small children, both of whom like playing with it. If one of them gets both the drum and the drumstick, they can merrily play the drum until they get fed up. If the other child wants to play, they have to wait, however sad that makes them. Now imagine that the drum and the drumstick are buried (separately) in the toy box, and your children both decide to play with it at the same time, so go rummaging in the toy box. One finds the drum and the other finds the drumstick. Now they're stuck—unless the children are remarkably kind, each will hold onto whatever they've got and demand the other gives them the other bit, and neither gets to play.


    public static class DeadLockSample
    {
        private static object syncLock1 = new object();
        private static object syncLock2 = new object();
        private static int a = 0;
        private static float f = 0;

        private static void Start1()
        {
            lock (syncLock1)
            {
                Console.WriteLine("1 lock 1");
                a = a + 1;
                lock (syncLock2)
                {
                    Console.WriteLine("1 lock 2");
                    f = f + 1;
                }

                Console.WriteLine("1 unlock 2");
            }
            Console.WriteLine("1 unlock 1");
        }

        private static void Start2()
        {
            //Thread.Sleep(100);
            lock (syncLock2)
            {
                Console.WriteLine("2 lock 2");

                a = a - 1;
                lock (syncLock1)
                {
                    Console.WriteLine("2 lock 1");

                    f = f - 1;
                }
                Console.WriteLine("2 unlock 1");
            }

            Console.WriteLine("2 unlock 2");
        }

        public static void Run()
        {
            new Thread(new ThreadStart(Start1)).Start();
            new Thread(new ThreadStart(Start2)).Start();
            Console.ReadLine();
        }
    }
}
