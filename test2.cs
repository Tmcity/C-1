using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test2
{
    class test2
    {
        public int a;
        public test2(int i) { a = i; }
    }

    class sptest
    {
        public static void sp()
        {
            test2 T2 =new test2(1);
            Console.WriteLine(T2.a);
        }
    }

}
