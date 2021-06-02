using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Concurrent;

namespace ParallelSupport
{
    class Program
    {
        static void Main_(string[] args)
        {
            Console.WriteLine(System.Environment.ProcessorCount);
            string[] paragraph = { "a", "b", "c", "d", "e", "f", "g", "h", "i" };
            //Chunk : a,b,c,d
            //chunk: e,f,g,h
            System.Diagnostics.Stopwatch _watch = new System.Diagnostics.Stopwatch();
            _watch.Start();
            //Partition
            //Schedule
            //Collate
            // List<string> resultList= paragraph.AsParallel().WithDegreeOfParallelism(2).Select(Encrypt).ToList();
            // paragraph.AsParallel().WithDegreeOfParallelism(2).Select(Encrypt).ForAll((item) => {
            System.Collections.Concurrent.Partitioner.Create(paragraph,true).
                AsParallel().
                WithDegreeOfParallelism(2).
                Select(Encrypt)
                .ForAll(item=>
                {
                Console.WriteLine($"{item} " +
                    $"and Thread Id {System.Threading.Thread.CurrentThread.ManagedThreadId} " +
                    $"Are You From Thread Pool {System.Threading.Thread.CurrentThread.IsThreadPoolThread}");
            });
            _watch.Stop();
            Console.WriteLine(_watch.ElapsedMilliseconds);

          
        }

        static void Main()
        {
            string[] paragraph = { "a", "b", "c", "d", "e", "f", "g", "h", "i" };
            //for(int i = 0; i < paragraph.Length; i++)
            //{
            //    Console.WriteLine(Encrypt(paragraph[i]));
            //}
            //List<string> _encryptedList = new List<string>();
            System.Collections.Concurrent.ConcurrentBag<string> _encryptedList = new ConcurrentBag<string>();
            
            Parallel.For(0, paragraph.Length, (i) => {

               Console.WriteLine(Encrypt(paragraph[i]));
               // _encryptedList.Add(Encrypt(paragraph[i]));
            });
           
        }
        static string Encrypt(string item)
        {
            if (item == "b")
            {
               // System.Threading.Thread.Sleep(10000);
            }
            System.Threading.Thread.Sleep(1000);

            return item.ToUpper();
        }
    }
}
