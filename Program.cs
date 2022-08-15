// ReSharper disable RedundantUsingDirective
using File;
using Fibonacci;
using static File.FileReading;
using static Fibonacci.GitFib;
using System.Text;
using System.Diagnostics;
using Delay;
using RandomNumberGenerator;
using LfCMref;
using CharacterToLnteger;
// ReSharper disable CheckNamespace

namespace Program
{

    class HelloWorld
    {

        static void Main()
        {
            int select;
            
            Console.WriteLine("请选择所要使用的功能:");
            var nameList = new List<string>();
            if (nameList == null) throw new ArgumentNullException(nameof(nameList));
            nameList.Add("1.文件读写");
            nameList.Add("2.斐波那契数列");
            nameList.Add("3.延迟对比");
            nameList.Add("4.随机数生成");
            nameList.Add("5.交换数字位置");
            nameList.Add("6.使用ref传递变量");
            nameList.Add("7.字符串转整数");

            foreach (var variable in nameList)
            {
                Console.WriteLine(variable);
            }
            Console.WriteLine("==========");
            select = int.Parse(Console.ReadLine() ?? string.Empty);
            Console.WriteLine("==========");
            
            if (select==1)
            {
                //==============================文件读取==============================//
                string path;

                Console.WriteLine("输入需要统计的路径:");
                path = Console.ReadLine()!;

                Console.WriteLine("共有{0}个文件,{1}个文件夹", Total(path, true), Total(path, false));
            }
            else if (select == 2)
            {
                //=============================斐波那契数列=============================//
                int n;
                Console.WriteLine("输入需要计算的个数:");
                n = int.Parse(Console.ReadLine() ?? string.Empty);
                Console.WriteLine("==========");
                for (int i = 1; i <= n; i++)
                {
                    Console.WriteLine(Fib(i));
                }
                //Console.WriteLine("第{0}个数是{1}", n, Fib(n));
            }
            else if (select == 3)
            {
                //==============================延迟对比==============================//
                Test.DelayTest();
            }
            else if (select == 4)
            {
                //=============================随机数生成==============================//
                RandomNumber.Generator();
            }
            else if (select == 5)
            {
                //=============================交换数字位置=============================//
                PileOfStuff.IntSwish();
            }
            else if (select == 6)
            {
                //============================使用ref传递变量============================//
                PileOfStuff.AddAfterAnyCharacter(Console.ReadLine());
            }
            else if (select == 7)
            {
                //============================字符串转整数============================//
                Conversion.Convert();
            }
            else
            {
                Console.WriteLine("输入错误，请重新输入");
            }

        }
    }
}