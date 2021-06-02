using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataCoueUnitTestLib
{
    public class BaseTestAttribute : System.Attribute
    {
        private string name, description;
        public BaseTestAttribute() { }
        public BaseTestAttribute(string name, string description)
        {
            this.name = name;
            this.Description = description;
        }
        public string Name
        {
            get { return this.name; }
            set { this.name = value; }
        }


        public string Description { get => description; set => description = value; }
    }

    [AttributeUsage(AttributeTargets.Class)]
    public class TestFixtureAttribute:BaseTestAttribute
    {
        public TestFixtureAttribute() { }
        public TestFixtureAttribute(string name, string description) : base(name, description) { }
    }
    [AttributeUsage(AttributeTargets.Method)]
    public class TestAttribute : BaseTestAttribute
    {
        public TestAttribute() { }
        public TestAttribute(string name, string description) : base(name, description) { }
    }


    public class Assert
    {
        public static void AreEqual(int actual,int expected)
        {
            ///
        }
    }
}
