using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GCDemo
{

    class DataHandler : IDisposable
    {
        private bool disposedValue;

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    // TODO: dispose managed state (managed objects)
                }

                // TODO: free unmanaged resources (unmanaged objects) and override finalizer
                // TODO: set large fields to null
                disposedValue = true;
            }
        }

        // // TODO: override finalizer only if 'Dispose(bool disposing)' has code to free unmanaged resources
        // ~DataHandler()
        // {
        //     // Do not change this code. Put cleanup code in 'Dispose(bool disposing)' method
        //     Dispose(disposing: false);
        // }

        public void Dispose()
        {
            // Do not change this code. Put cleanup code in 'Dispose(bool disposing)' method
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }
    }
    class FileReader:IDisposable
    {

        bool isDisposed = false;
        public void Read() {

            if (isDisposed) { throw new ObjectDisposedException(nameof(FileReader)); }
            for(int i = 0; i < 10; i++)
            {
                Console.WriteLine("File Read In Action.....");
                System.Threading.Thread.Sleep(1000);
            }
        
        }

        protected virtual void Dispose(bool isDisposing)
        {
            if (!isDisposed)
            {
                if (isDisposing)//Determine Caller (Dispose,Finalize)
                {
                    GC.SuppressFinalize(this);
                    isDisposed = true;
                    Console.WriteLine($"File Handle Released By {System.Threading.Thread.CurrentThread.ManagedThreadId} via Dispose Method");
                }
                else
                {
                    Console.WriteLine($"File Handle Released By {System.Threading.Thread.CurrentThread.ManagedThreadId} via Finalize Method");
                }
            }
        }
        public void Dispose()
        {
            Dispose(true);
            
        }
        //private void Finalize() { }
        ~FileReader()
        {

            Dispose(false);

        }

    }


    class EntryPoint
    {

        static void Main()
        {
            Client();
        }
        static void Client()
        {
            DataHandler _handler = new DataHandler();

            FileReader _reader = new FileReader();
            _reader.Read();
           // _reader.Dispose();
            //_reader.Dispose();
            //_reader.Read();
            _reader = null;
            _handler = null;
            
            GC.Collect();// 1 st GC Cycle - Mark reader object for finalization (Request For Finalizer Thread)
            GC.WaitForPendingFinalizers();//Wait for Finalizer Thread to address pending finalization requests
            
            GC.Collect();//2 nd Gc Cycle - Remove Reader object
        }
    }
}
