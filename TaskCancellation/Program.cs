using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace TaskCancellation
{
    class Program
    {
        static void Main(string[] args)
        {
            CancellationTokenSource _tokenSource = new CancellationTokenSource();
            CancellationToken _token = _tokenSource.Token;
            //  _tokenSource.Cancel();

            Task _task = Task.Factory.StartNew(AsyncTask, _token, _token);

            System.Threading.Thread.Sleep(5000);
            _tokenSource.Cancel();
            try
            {
                _task.Wait();
            }
            catch(AggregateException ex)
            {
                foreach( Exception _exception in ex.Flatten().InnerExceptions)
                {
                    Console.WriteLine(_exception.Message);
                }
            }

            Console.WriteLine(_task.IsCanceled);
        }

        static void AsyncTask(object state)
        {
            CancellationToken _token = (CancellationToken)state;
            

            for (int i = 0; i < 10; i++)
                {
                //if (_token.IsCancellationRequested)
                //{
                //    return;
                //}
                // _token.ThrowIfCancellationRequested();
                if (i == 5)
                {
                    if (_token.WaitHandle.WaitOne())
                    {
                        return;
                    }
                }
                Console.WriteLine($"Async Task {i}");

                    System.Threading.Thread.Sleep(1000);
                }

            
        }
    }

}
   
    

