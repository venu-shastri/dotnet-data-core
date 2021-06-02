using System;
using System.Collections;
using System.Collections.Generic;
//using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Design
{
   
    public static class IEnumerableTypeExtensionMethods
    {
       
        public static IEnumerable<T> Filter<T>(this IEnumerable<T> source, Func<T, bool> predicate)
        {

            foreach (T item in source)
            {
                if (predicate.Invoke(item))
                {
                    yield return item;
                }
            }
            
            
        }
        public static IEnumerable<T> Select<T>(this IEnumerable<T> source, Func<T, bool> predicate)
        {

            foreach (T item in source)
            {
                if (predicate.Invoke(item))
                {
                    yield return item;
                }
            }
           
        }
        public static IEnumerable<T> Any<T>(this IEnumerable<T> source, Func<T, bool> predicate)
        {

            foreach (T item in source)
            {
                if (predicate.Invoke(item))
                {
                    yield return item;
                }
            }
            //IEnumerator<T> iterator = source.GetEnumerator();
            //try
            //{
            //    while (iterator.MoveNext())
            //    {
            //       T item= iterator.Current;
            //        if (predicate.Invoke(item))
            //        {
            //            temp.Add(item);
            //        }
            //    }
            //}
            //finally
            //{
            //    if(iterator is IDisposable)
            //    {
            //        iterator.Dispose();
            //    }
            //}
            
        }
        public static IEnumerable<T> All<T>(this IEnumerable<T> source, Func<T, bool> predicate)
        {

            foreach (T item in source)
            {
                if (predicate.Invoke(item))
                {
                    yield return item;
                }
            }
            //IEnumerator<T> iterator = source.GetEnumerator();
            //try
            //{
            //    while (iterator.MoveNext())
            //    {
            //       T item= iterator.Current;
            //        if (predicate.Invoke(item))
            //        {
            //            temp.Add(item);
            //        }
            //    }
            //}
            //finally
            //{
            //    if(iterator is IDisposable)
            //    {
            //        iterator.Dispose();
            //    }
            //}
            
        }
        public static IEnumerable<T> Sort<T>(this IEnumerable<T> source)
        {

            foreach (T item in source)
            {
                //if (predicate.Invoke(item))
                //{
                yield return item;
                //}
            }
            //IEnumerator<T> iterator = source.GetEnumerator();
            //try
            //{
            //    while (iterator.MoveNext())
            //    {
            //       T item= iterator.Current;
            //        if (predicate.Invoke(item))
            //        {
            //            temp.Add(item);
            //        }
            //    }
            //}
            //finally
            //{
            //    if(iterator is IDisposable)
            //    {
            //        iterator.Dispose();
            //    }
            //}
            
        }
    }

    public class Array<T> : IEnumerable<T>
    {
        public IEnumerator<T> GetEnumerator()
        {
            throw new NotImplementedException();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }
    }
    public class Program
    {
        
        public static void Main(string[] args)
        {
            string[] names = { "abc", "xyz", "dddd", "fghkkl" };
            Array<string> _namesArray = new Array<string>();

            _namesArray.Select(null).Filter(null).All(null).Any(null).Sort();//Fluent Interface Pattern

           IEnumerable<string> _result= IEnumerableTypeExtensionMethods.Select<string>(_namesArray, null);
            _result = IEnumerableTypeExtensionMethods.Filter<string>(_result, null);

        }
        //Pure Function
       
    }
}
