using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace partialTest
{
    class Program
    {
        static void Main(string[] args)
        {
            var tb1 = new TestBase();
            var tb2 = new TestBase();
            var res = tb1 + tb2;
            
            var qwe = TestBase.OneHundred;
            var asd = TestBase.OneHundred;
            Console.WriteLine(qwe);
            Console.ReadKey();
        }
    }

    public class TestBase
    {
        private int _num;
        public static int operator +(TestBase tb1, TestBase tb2)
        {
            return tb1._num + tb2._num;
        }

        public const int OneHundred = 100;
        public virtual int Vmethod()
        {
            return 0;
        }
    }

    public class TestDerive : TestBase
    {
        public sealed override int Vmethod()
        {
            return 1;
        }
    }

    
    //Error CS0239  'TestSecondDerive.Vmethod()': cannot override inherited member 'TestDerive.Vmethod()' 
    //because it is sealed partialTest

    //public class TestSecondDerive : TestDerive
    //{
    //    public override int Vmethod()
    //    {
    //        return 2;
    //    }
    //}


    public partial class MyClass
    {
        public static int Qwe;
    }

    public partial class MyClass
    {
        public static int Asd;
    }
}
