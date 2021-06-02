using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalculatorLibTestCasesLib
{

    [DataCoueUnitTestLib.TestFixtureAttribute("Calculator Test Cases","Set Of Calculator Method Tests")]
    public class CalculatorTestS
    {
        
        [DataCoueUnitTestLib.TestAttribute(Name ="Add Test",Description ="Add Method Value Test")]
        public void Given_ValidInputs_When_Add_Invoked_Then_AssertValidResult()
        {
            CalculatorLib.Calculator _calculator = new CalculatorLib.Calculator();
            int actual=_calculator.Add(10, 20);
          DataCoueUnitTestLib.Assert.AreEqual(actual,30);

        }
    }
}
