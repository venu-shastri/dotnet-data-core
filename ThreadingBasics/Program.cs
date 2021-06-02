using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThreadingBasics
{
    class Program
    {

        static void Main_old(string[] args)
        {
            //System.Threading.ThreadStart -  void()
            //System.Threading.ParameterizedThreadStart - void(object)

            System.Threading.Thread _task_one_thread =
                  new System.Threading.Thread(new System.Threading.ThreadStart(TaskOne))
                  { Name= "TaskOneThread"};




            //    System.Threading.Thread _task_two_thread =
            //    new System.Threading.Thread(new System.Threading.ParameterizedThreadStart(TimerTask)) {
            //        IsBackground=true };
            //_task_two_thread.Name = "TaskTwoThread";

            System.Threading.WaitCallback _bgTaskAddress = new System.Threading.WaitCallback(TimerTask);
            System.Threading.ThreadPool.QueueUserWorkItem(_bgTaskAddress);


            System.Threading.Thread _task_one_new_thread =
                  new System.Threading.Thread(new System.Threading.ThreadStart(TaskOne));
            _task_one_new_thread.Name = "NewThread";

            _task_one_thread.Start();
            _task_one_new_thread.Start();
            //_task_two_thread.Start();
           
        }

        //New Execution Path
        static void TaskOne() {
        
            for(int i = 0; i < 10; i++)
            {
                Console.WriteLine("TaskOne excecuting By " + System.Threading.Thread.CurrentThread.Name);
                System.Threading.Thread.Sleep(1000);
            }
                
        }

        static void TimerTask(object initialParams) {
            while(true)
            {
                System.Threading.Thread.Sleep(1000);
                Console.WriteLine($"TaskTwo excecuting By  {System.Threading.Thread.CurrentThread.IsThreadPoolThread}");
            }
        }
    }
}
