using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GCDemo
{

    class A
    {
        B obj = new B();
    
    }
    class B
    {

    }
    class C
    {

    }
    class Program
    {
        static A globalRef;
        static void Main_old(string[] args)
        {
            Allocate();
            GC.Collect();
        }
        static void Allocate()
        {
            //Stack Variable
            A obj = new A();
            //Stack Variable
            List<object> _container = new List<object>();
            _container.Add(obj);
            //Static Ref
            globalRef = obj;
            //Console.WriteLine($"Generation Value {GC.GetGeneration(obj)}");//0
            GC.Collect();
            obj = null;
            //Console.WriteLine($"Generation Value {GC.GetGeneration(obj)}");//1
            _container = null;
            GC.Collect();
            //Console.WriteLine($"Generation Value {GC.GetGeneration(obj)}");//2
            globalRef = null;
            GC.Collect();
            

        }
    }
}
