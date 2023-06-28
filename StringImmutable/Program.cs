using System;

namespace StringAsImmutable
{
    public class A
    {
        public int a = 5;
        public string s = "Hello";
        private int pInt = 15;

        private string _secretPsw = "SuperSecret";

        public A(A org)
        {
            a = org.a;
            s = org.s;
            pInt = org.pInt;
            _secretPsw = org._secretPsw;
        }
        public A() { }

        public void GeneratePsw()
        {
            _secretPsw = "NewSuperSecretPsw";
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            var a1 = new A();
            var a2 = new A();
            a1.a = 1;
            a2.a = 2;

            a1 = a2;
            a2.a = 5;
            Console.WriteLine(a1.a);    //5
            Console.WriteLine(a2.a);    //5

            var s1 = "Hello One";
            var s2 = "Hello Two";

            s1 = s2;
            s2 = "Hello Five";
            Console.WriteLine();
            Console.WriteLine(s1);      //Hello Two
            Console.WriteLine(s2);      //Hello Five

            var i1 = 1;
            var i2 = 2;
            i1 = i2;
            i2 = 5;
            Console.WriteLine();
            Console.WriteLine(i1);      //2
            Console.WriteLine(i2);      //5

        }
    }
}
