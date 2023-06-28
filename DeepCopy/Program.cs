using System;

namespace DeepCopy
{
    class Program
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


        static void Main(string[] args)
        {
            A[] myAArray1 = new A[5];
            for (int i = 0; i < myAArray1.Length; i++)
            {
                myAArray1[i] = new A();
            }

            //Shallow copy
            Console.WriteLine("Shallow copy");
            A[] myAArray2 = myAArray1;

            myAArray2[1].a = 3;
            Console.WriteLine(myAArray1[1].a);
            Console.WriteLine(myAArray2[1].a);
 
            myAArray1[1].a = 15;
            Console.WriteLine(myAArray1[1].a);
            Console.WriteLine(myAArray2[1].a);

            //Deep copy
            Console.WriteLine("\nDeep copy");
            myAArray2 = new A[5];
            for (int i = 0; i < myAArray2.Length; i++)
            {
                myAArray2[i] = new A(myAArray1[i]);
            }

            myAArray2[1].a = 100;
            Console.WriteLine(myAArray1[1].a);
            Console.WriteLine(myAArray2[1].a);

            myAArray1[1].a = 150;
            Console.WriteLine(myAArray1[1].a);
            Console.WriteLine(myAArray2[1].a);



        }
    }
}
