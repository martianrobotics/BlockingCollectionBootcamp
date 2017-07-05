using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlockingCollectionBootcamp
{
    class Program
    {
        static void Main(string[] args)
        {
            int count=0;

            var blockingCollection = new BlockingCollection<string>();
            Task.Factory.StartNew(() =>
            {
                while (true)
                {
                    blockingCollection.Add("value" + count);
                    count++;
                }
            });

            Task.Factory.StartNew(() =>
            {
                while (true)
                {
                    Console.WriteLine("Worker 1: " + blockingCollection.Take());
                }
            });

            Task.Factory.StartNew(() =>
            {
                while (true)
                {
                    Console.WriteLine("Worker 2: " + blockingCollection.Take());
                }
            });
            Task.WaitAll();
            //var queue = new ConcurrentQueue<string>();
            //Task.Factory.StartNew(() =>
            //{
            //    while (true)
            //    {
            //        queue.Enqueue("value" + count);
            //        count++;
            //    }
            //});

            //Task.Factory.StartNew(() =>
            //{
            //    while (true)
            //    {
            //        string value;
            //        if (queue.TryDequeue(out value))
            //        {
            //            Console.WriteLine("Worker 1: " + value);
            //        }
            //    }
            //});

            //Task.Factory.StartNew(() =>
            //{
            //    while (true)
            //    {
            //        string value;
            //        if (queue.TryDequeue(out value))
            //        {
            //            Console.WriteLine("Worker 2: " + value);
            //        }

            //    }
            //});
        }
    }
}
