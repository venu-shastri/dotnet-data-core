using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace ThreadingBasics
{

    
    //public class DAO
    //{
    //    public readonly static DAO Instance = new DAO();
    //    Object _syncUpdaters = new Object();
    //    Object _syncReaders = new Object();
    //    private DAO() { }

    //   // [System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.Synchronized)]
    //    public void Create() {
            
    //        Monitor.Enter(_syncUpdaters);
    //        try
    //        {
    //           for (int i = 0; i < 10; i++)
    //            {
    //                Console.WriteLine("Create Action.......");
    //                Thread.Sleep(1000);
    //                if (i == 5) { return; }
    //            }
    //        }
    //        finally
    //        {
    //            Monitor.Exit(_syncUpdaters);
    //        }
    //    }
    //    //[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.Synchronized)]
    //    public void Delete() {

    //        lock (_syncUpdaters)
    //        {
    //            for (int i = 0; i < 10; i++)
    //            {
    //                Console.WriteLine("Delete Action.......");
    //                Thread.Sleep(500);
    //            }
    //        }
    //    }

    //    //[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.Synchronized)]
    //    public void Update() {
    //        Monitor.Enter(_syncUpdaters);
    //        for (int i = 0; i < 10; i++)
    //        {
    //            Console.WriteLine("Update Action.......");
    //            Thread.Sleep(800);
    //        }
    //        Monitor.Exit(_syncUpdaters);
    //    }
    //    //[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.Synchronized)]
    //    public void Select()
    //    {
    //        Monitor.Enter(_syncReaders);
    //        for (int i = 0; i < 10; i++)
    //        {
    //            Console.WriteLine("Select Action.......");
    //            Thread.Sleep(800);
    //        }
    //        Monitor.Exit(_syncReaders);
    //    }
    //   // [System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.Synchronized)]
    //    public void SelectByKey()
    //    {
    //        Monitor.Enter(_syncReaders);
    //        for (int i = 0; i < 10; i++)
    //        {
    //            Console.WriteLine("SelectKey Action.......");
    //            Thread.Sleep(800);
    //        }
    //        Monitor.Exit(_syncReaders);
    //    }
    //}

    public static class MutexWaitHanldes
    {
        public static Mutex _handleOne = new Mutex(true);
        public static Mutex _handleTwo = new Mutex(false);
    }
    public class DAO
    {
        public readonly static DAO Instance = new DAO();
        public Mutex _handleOne = new Mutex(true);
        public Mutex _handleTwo = new Mutex(true);
        private DAO() { }

        // [System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.Synchronized)]
        public void Create()
        {

            Console.WriteLine("Create Action Awaiting For Signal");
           this._handleOne.WaitOne();
                
            try
            {
                for (int i = 0; i < 10; i++)
                {
                    Console.WriteLine("Create Action.......");
                    Thread.Sleep(1000);
                    if (i == 5) { return; }
                }
            }
            finally
            {
                this._handleOne.ReleaseMutex();
            }
        }
        //[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.Synchronized)]
        public void Delete()
        {

            Console.WriteLine("Delete Action Awaiting For Signal");
            this._handleOne.WaitOne();
            for (int i = 0; i < 10; i++)
                {
                    Console.WriteLine("Delete Action.......");
                    Thread.Sleep(500);
                }
            this._handleOne.ReleaseMutex();
        }

        //[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.Synchronized)]
        public void Update()
        {
            Console.WriteLine("Update Action Awaiting For Signal");
            this._handleOne.WaitOne();
            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine("Update Action.......");
                Thread.Sleep(800);
            }
            this._handleOne.ReleaseMutex();
        }
        //[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.Synchronized)]
        public void Select()
        { 
            
            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine("Select Action.......");
                Thread.Sleep(800);
            }
            
        }
        // [System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.Synchronized)]
        public void SelectByKey()
        {
            
            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine("SelectKey Action.......");
                Thread.Sleep(800);
            }
            
        }
    }

    public class EventsDemo
    {
        //Forground Task
        static ManualResetEvent task1Handle = new ManualResetEvent(false);//wait state(red)
        static ManualResetEvent task2Handle = new ManualResetEvent(false);//wait state(red)
        static ManualResetEvent task3Handle = new ManualResetEvent(false);//wait state(red)
        static ManualResetEvent task4Handle = new ManualResetEvent(false);//wait state(red)
        static AutoResetEvent broadCastHandle = new AutoResetEvent(false);//wait state(red)
        static void Main1()
        {
            
            ThreadPool.QueueUserWorkItem(AsyncTask1);
            ThreadPool.QueueUserWorkItem(AsyncTask2);
            ThreadPool.QueueUserWorkItem(AsyncTask3);
            ThreadPool.QueueUserWorkItem(AsyncTask4);
            Thread.Sleep(2000);
            broadCastHandle.Set();
            WaitHandle.WaitAll(new WaitHandle[] { task1Handle,task2Handle,task3Handle,task4Handle });
            Console.WriteLine("End Of Main");
            WaitHandle.WaitAll(new WaitHandle[] { task1Handle, task2Handle, task3Handle, task4Handle });
            Console.WriteLine("Main End");
        }

        //BG Tasks
        static void AsyncTask1(object args) {
            Console.WriteLine("AsyncTask 1 Awaiting for Broadcast Signal");
            broadCastHandle.WaitOne();
        for(int i = 0; i < 10; i++)
            {
                Console.WriteLine($"AsyncTask1 -> {i}");
                System.Threading.Thread.Sleep(1000);
            }
            task1Handle.Set();
        }
        static void AsyncTask2(object args) {
            
            Console.WriteLine("AsyncTask 2 Awaiting for Broadcast Signal");
            broadCastHandle.WaitOne();
            for (int i = 0; i < 5; i++)
            {
                Console.WriteLine($"AsyncTask2 -> {i}");
                System.Threading.Thread.Sleep(2000);
            }
            task2Handle.Set();
        }

    
        static void AsyncTask3(object args) {
          
            Console.WriteLine("AsyncTask 3 Awaiting for Broadcast Signal");
            broadCastHandle.WaitOne();
            for (int i = 0; i < 15; i++)
            {
                Console.WriteLine($"AsyncTask3 -> {i}");
                System.Threading.Thread.Sleep(1000);
            }
            task3Handle.Set();
        }
        static void AsyncTask4(object args) {
            
            Console.WriteLine("AsyncTask 4 Awaiting for Broadcast Signal");
            broadCastHandle.WaitOne();
            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine($"AsyncTask4 -> {i}");
                System.Threading.Thread.Sleep(2000);
            }
            task4Handle.Set();
        }
    }

    class SynchronizationDemo
    {
    
        static void Main_1()
        {
            DAO singleton = DAO.Instance;
            new Thread(singleton.Create).Start();
            new Thread(singleton.Delete).Start();
            new Thread(singleton.Update).Start();

            Console.WriteLine("Click Here To Start Thread Actions");
            Console.ReadKey();
            singleton._handleOne.ReleaseMutex();

             new Thread(singleton.Select).Start();
             new Thread(singleton.SelectByKey).Start();

            
            Console.WriteLine("End OF Main");


        }
    }
}
