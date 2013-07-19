using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ProdConsApp
{
    public class ProducerConsumerQueue : IDisposable
    {
        private EventWaitHandle waitHandle = new AutoResetEvent(false);
        private Thread worker;
        private readonly object locker = new object();
        private Queue<string> tasks = new Queue<string>();

        public ProducerConsumerQueue()
        {
            worker = new Thread(Work);
            worker.Start();
        }

        public void EnqueueTask(string task)
        {
            lock (locker)
            {
                tasks.Enqueue(task);
            }

            waitHandle.Set();
        }

        public void Work()
        {
            while (true)
            {
                string task = null;
                lock (locker)
                {
                    if (tasks.Count > 0)
                    {
                        task = tasks.Dequeue();
                        if (task == null)
                        {
                            return;
                        }
                    }
                }

                if (task != null)
                {
                    Console.WriteLine(string.Format("Performing task {0}", task));
                    Thread.Sleep(1000);
                }
                else
                {
                    waitHandle.WaitOne();
                }
            }
        }

        public void Dispose()
        {
            EnqueueTask(null);
            worker.Join();
            waitHandle.Close();
        }

        public static void Run()
        {
            using (ProducerConsumerQueue q = new ProducerConsumerQueue())
            {
                q.EnqueueTask("Hello");

                for (int i = 0; i < 10; i++)
                {
                    q.EnqueueTask(string.Format("Say {0}", i));
                }

                q.EnqueueTask("Goodbye!");
            }
        }
    }
}