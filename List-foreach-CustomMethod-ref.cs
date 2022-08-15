using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LfCMref
{
    class PileOfStuff
    {

        public static void Swish1(List<int> a)
        {
            int temp;
            temp = a[0];
            a[0] = a[1];
            a[1] = temp;

        }
        public static void Swish2(ref string? m)
        {
            m += "233";
        }

        public static void IntSwish()
        {
            //======================列表、foreach、自定义方法、ref=====================//


            try
            {
                var list = new List<int>();

                for (int i = 0; i < 2; i++)
                {
                    list.Add(int.Parse(Console.ReadLine()));
                }

                Swish1(list);

                foreach (var va in list)
                {
                    Console.WriteLine(va);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("====================错误====================");
                Console.WriteLine("输入格式错误，请依次输入");
                Console.WriteLine("===========================================");
                Console.WriteLine(e);
            }

        }

        public static void AddAfterAnyCharacter(string? m)
        {
            //======================列表、foreach、自定义方法、ref=====================//

            Swish2(ref m);
            Console.WriteLine("传递到函数后的字符串为:" + m);
            m += "HE";
            Console.WriteLine("直接进行修改后的字符串为:" + m);
        }
    }
}
