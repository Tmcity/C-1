using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Delay
{
    class Test
    {
        public static void DelayTest()
        {
            //============================延迟对比==============================//

            Console.WriteLine("使用普通字符串累加100000字符的延迟为:");
            String str=string.Empty;      //8823

            Stopwatch sw1 = Stopwatch.StartNew();
            for (int i = 0; i< 100000; i++)
            {
                str+=i.ToString();
            }
            sw1.Stop();
            Console.WriteLine(sw1.ElapsedMilliseconds);
            
            Console.WriteLine("使用可变字符串累加100000字符的延迟为:");
            StringBuilder sb = new StringBuilder();     //3

            Stopwatch sw2 = Stopwatch.StartNew();
            for (int i = 0; i < 100000; i++)
            {

                sb.Append(i.ToString());
            }
            sw2.Stop();
            Console.WriteLine(sw2.ElapsedMilliseconds);
        }
    }
}
