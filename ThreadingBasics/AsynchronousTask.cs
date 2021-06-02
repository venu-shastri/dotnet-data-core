using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks; //TPS

namespace ThreadingBasics
{
    class AsynchronousTask
    {

        //caller
        static void Main_1()
        {
            //Parallel.Invoke(Task1, Task2, Task3);
            //System.Threading.ThreadPool.QueueUserWorkItem((obj) =>
            //{

            //    try
            //    {
            //        Parallel.Invoke(Task1, Task2, Task3);
            //    }
            //    catch(AggregateException ex)
            //    {

            //    }
            //});

            //Console.Read();

            //Task _asyncTask1 = new Task(Task1);
            //Task _asyncTask2 = new Task(Task2);
            //Task _asyncTask3= new Task(Task3);

            //_asyncTask1.Start();
            //_asyncTask2.Start();
            //_asyncTask3.Start();
         Task _asyncTask1=   Task.Factory.StartNew(Task1);
            Task _asyncTask2 = Task.Factory.StartNew(Task1);
            Task _asyncTask3 = Task.Factory.StartNew(Task1);
            Task<string> _asyncTask4 = Task.Factory.StartNew<string>(()=> { return "Func Task"; });
            _asyncTask4.Start();
           
            Task<string> _asyncTask5 = new Task<string>(() => { return "New Func Task"; });
            try
            {
                Task.WaitAll(_asyncTask1, _asyncTask2, _asyncTask3);
            }
            catch(AggregateException ex)
            {
              foreach(var exception in ex.Flatten().InnerExceptions)
                {
                    Console.WriteLine(exception.Message);
                }
            }

        }

        
        //Calleee
        static void Task1()
        {
            for (int i = 0; i < 10; i++)
            {
                if (i == 8)
                {
                    throw new Exception("Task1 Exception ");
                }
                Console.WriteLine($"Task1.....{System.Threading.Thread.CurrentThread.IsThreadPoolThread}");
                System.Threading.Thread.Sleep(1000);
            }
        }
        static void Task2()
        {
            for (int i = 0; i < 10; i++)
            {
                if (i == 5)
                {
                    throw new Exception("Task2 Exception ");
                }
                Console.WriteLine($"Task2.....{System.Threading.Thread.CurrentThread.IsThreadPoolThread}");
                System.Threading.Thread.Sleep(1000);
            }
        }
        static void Task3()
        {
            for (int i = 0; i < 10; i++)
            {
                if (i == 3)
                {
                    throw new Exception("Task3 Exception ");
                }
                Console.WriteLine($"Task3.....{System.Threading.Thread.CurrentThread.IsThreadPoolThread}");
                System.Threading.Thread.Sleep(1000);
            }
        }


        static void Main_Parent_Child()
        {
            Task _mainTask = new Task(() => {

                Console.WriteLine("Parent Tast Begin");

                Task _detachedTask = new Task(() => {
                    Console.WriteLine("Detached  Tast Begin");
                    System.Threading.Thread.Sleep(5000);
                    Console.WriteLine("Detached  Tast End");

                });
                _detachedTask.Start();
                Task _childTask = new Task(() => {

                    Console.WriteLine("Child task Begin");
                    Task _gChildTask = new Task(() => {

                        
                        Console.WriteLine("GrandChild  Task Begin");
                        System.Threading.Thread.Sleep(1000);
                        Console.WriteLine("GrandChild  Task End");
                        throw new Exception("Grand Child Task Exception");

                    }, TaskCreationOptions.AttachedToParent);
                    _gChildTask.Start();
                    System.Threading.Thread.Sleep(3000);
                    Console.WriteLine("Child Task End");
                    throw new Exception("Child Task Exception");


                }, TaskCreationOptions.AttachedToParent);
                _childTask.Start();

                Console.WriteLine("Parent Task End");
                throw new Exception("Main Task exception");
            },TaskCreationOptions.DenyChildAttach);
            _mainTask.Start();
            try
            {
                _mainTask.Wait();
            }
            catch(AggregateException ex)
            {
                foreach(var exception in ex.Flatten().InnerExceptions)
                {
                    Console.WriteLine(exception.Message);
                }
            }
        }

        static void Main()
        {
            //HttpRequest , HandleHttpResponse, Validate-> Transform , Dump
            //HttpRequest , HandleHttpResponse, Validate->LogHandler 
            //HttpRequest, HandleHttResponse, ErrorHandler
            while (true) {
                Console.WriteLine("Press Any Key To Send Httprequest");
                Console.ReadLine();
                AjaxCode();

            }
            
            
        }

        static void AjaxCode()
        {
                Task<int> httpReuestTask = new Task<int>(() =>
                {
                    Console.WriteLine("HttpRequest Begin");
                    System.Threading.Thread.Sleep(2000);
                    Console.WriteLine("HttpRequest End");
                    return new Random().Next(1, 5);


                });

                Task _httpResponseTask = httpReuestTask.ContinueWith((pt) =>
                {
                    Console.WriteLine("HttpResponse Processing Task Begin");
                    Console.WriteLine($"Resullt {pt.Result}");
                    if (pt.Result % 2 != 0)
                    {
                        throw new Exception("Invalid Http Resposne");

                    }
                    System.Threading.Thread.Sleep(2000);
                    Console.WriteLine("HttpResponse Processing Task End");


                }, TaskContinuationOptions.OnlyOnRanToCompletion);
                _httpResponseTask.ContinueWith((pt) =>
                {

                    Console.WriteLine("Error Handler Begin");
                    Console.WriteLine(pt.Exception.InnerException.Message);
                    System.Threading.Thread.Sleep(2000);
                    Console.WriteLine("Error Handler End");


                }, TaskContinuationOptions.OnlyOnFaulted);
                _httpResponseTask.ContinueWith((pt) =>
                {
                    Console.WriteLine("Validation Handler Begin");

                    System.Threading.Thread.Sleep(2000);
                    Console.WriteLine("Validation  Handler End");


                }, TaskContinuationOptions.OnlyOnRanToCompletion | TaskContinuationOptions.NotOnFaulted);

                httpReuestTask.Start();
            
        }
    }
}
