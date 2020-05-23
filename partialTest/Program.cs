using System;

namespace partialTest
{
    internal class Program
    {
        private static void Main()
        {
            var qwe = TestBase.OneHundred;
            Console.WriteLine(qwe);
            Console.ReadKey();
        }
    }

    public class TestBase
    {
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
