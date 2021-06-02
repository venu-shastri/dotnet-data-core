using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DynamicProgramming
{
    public class A :System.Dynamic.DynamicObject{

        public void Fun() { }
        public override bool TryInvokeMember(InvokeMemberBinder binder, object[] args, out object result)
        {
          
            result = null;
            Console.WriteLine(binder.Name);
            return true;
        }

        Dictionary<string, object> _propertyStore = new Dictionary<string, object>();
        public override bool TrySetMember(SetMemberBinder binder, object value)
        {
            _propertyStore[binder.Name] = value;
            return true;
        }
        public override bool TryGetMember(GetMemberBinder binder, out object result)
        {
            result = null;
            if (_propertyStore.ContainsKey(binder.Name))
            {
                result = _propertyStore[binder.Name];
                return true;
            }
            return false;
        }
    }
    public class B {
        public void Fun() { }
    }
    public class C {
        public void Fun() { }
    }
   public class Program
    {
       public static void Main(string[] args)
        {

            CSVParser parser = new CSVParser();
            parser.FilePath = "..//..//customers.csv";
           IEnumerable<dynamic> selectedCustomers= 
                parser.GetAllLines().Where((dynamic line) => line.City.ToString() == "CHN");
            foreach(dynamic customer in selectedCustomers)
            {
                Console.WriteLine(customer.Name);
            }
            ///Generic(new A());
           // Generic(new B());
            //Generic(new C());
        }
        public static void Generic(dynamic source)
        {
            source.MoreFun();//RuntimeBinder
            source.Foo();
            source.Add(10, 20);
            source.Name = "Tom";
            Console.WriteLine(source.Name);
            source.Id = "Emp100";
            source.Age = 20;
            //Reflection
          //  source.GetType().GetMethod("Fun").Invoke(source, new Object[] { });
          //SouceType is IDynamicMetaObjectProvider

        }

        public void Method()
        {
            var names;

            
            //projection Queries 
            var  result = from item in names
                                         select new { Name = item, Length = item.Length };
            
            foreach(var obj in result)
            {
                
            }
            var newResult= from item in names
                           select new { UpperCase = item.ToUpper(),LowerCase=item.ToLower(), Length = item.Length };



            //Anonymous Type
            var obj = new {Name="Tom",Age=30};
            
        }
    }

    
}
