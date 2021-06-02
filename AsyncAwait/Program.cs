using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AsyncAwait
{
    class Program
    {
        static  void   Main(string[] args)
        {
            DoTask();
            Console.Read();
        }

        static async void DoTask()
        {

            //Statment Ahead 
            Console.WriteLine("Statement 1 ");//Return to Caller
            await Task.Run(()=> {
                Console.WriteLine("Statement 2");

            });//Async Task
            //Statement After
            Console.WriteLine("Statement 3 ");
            await Task.Run(() => {
                Console.WriteLine("Statement 4");

            });
            Console.WriteLine("Statement 5 ");
            await Task.Run(() => {
                Console.WriteLine("Statement 6");

            });
            Console.WriteLine("Statement 7 ");

        }
    }
}
