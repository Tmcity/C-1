using FileTotal;
using Fibonacci;
using static FileTotal.FileReading;
using static Fibonacci.GitFib;
using System.Text;
using System.Diagnostics;
using Delay;
using RandomNumberGenerator;
using LfCMref;
using CharacterToLnteger;
using Score;
using Overload;
using System.ComponentModel;
using FileR_W;
using Delegator;
using static Delegator.Delegate;

namespace Program
{

    class CustomError : Exception        //自定义异常
    {
        public CustomError(string message) : base(message) { }
    }

    class HelloWorld
    {

        static void Main()
        {
            int select;
            
            Console.WriteLine("请选择所要使用的功能:");
            var nameList = new List<string>();
            if (nameList == null) throw new ArgumentNullException(nameof(nameList));
            nameList.Add("1.文件统计");
            nameList.Add("2.斐波那契数列");
            nameList.Add("3.延迟对比");
            nameList.Add("4.随机数生成");
            nameList.Add("5.交换数字位置");
            nameList.Add("6.使用ref传递变量");
            nameList.Add("7.字符串转整数");
            nameList.Add("8.分数管理系统");
            nameList.Add("9.方法的重载");
            nameList.Add("10.文件读写");
            nameList.Add("11.委托");

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
                //===========================使用ref传递变量============================//
                PileOfStuff.AddAfterAnyCharacter(Console.ReadLine());
            }
            else if (select == 7)
            {
                //=============================字符串转整数=============================//
                Conversion.Convert();       //或者使用int.Parse()
            }
            else if (select == 8)
            {
                //=============================分数管理系统=============================//
                try
                {
                    List <ScoreEntry> Class=new List<ScoreEntry>();
                    Class.Add(new ScoreEntry("Class1"));
                    Class.Add(new ScoreEntry("Class2"));
                    Class.Add(new ScoreEntry("Class3"));
                    Class.Add(new ScoreEntry("Class4"));
                    Class.Add(new ScoreEntry("Class5"));
                    int num;
                    string SchoolName;
                    Console.WriteLine("录入成绩选择1，查询成绩选择2");
                    string a = Console.ReadLine();
                    if (a == "1")
                    {
                        Console.WriteLine("请输入班级:");
                        Console.WriteLine("==========");
                        SchoolName = Console.ReadLine();
                        bool flag = false;
                        foreach(ScoreEntry va in Class)
                        {
                            if (SchoolName == va.School)
                            {
                                Console.WriteLine("==========");
                                Console.WriteLine("请输入要录入的人数:");
                                Console.WriteLine("==========");
                                num = int.Parse(Console.ReadLine());
                                Console.WriteLine("==========");
                                for (int i = 0; i < num; i++)
                                {
                                    Console.WriteLine("请输入第{0}个人的名字:", i + 1);
                                    string n = Console.ReadLine();
                                    Console.WriteLine("请输入第{0}个人的分数:", i + 1);
                                    int s = int.Parse(Console.ReadLine());
                                    Console.WriteLine("==========");
                                    flag = true;
                                    va.Add(n,s);
                                }
                                va.SaveCSV("F:\\桌面\\" + SchoolName + ".csv");
                                Console.WriteLine($"分数已导出到: F:\\桌面\\{SchoolName}.csv");
                                Console.WriteLine("==========");
                            }
                        }
                        if (flag == false)
                        {
                            throw new CustomError("找不到班级！");
                        }
                        
                    }
                    else if(a == "2")
                    {
                        Console.WriteLine("请输入学校:");
                        Console.WriteLine("==========");
                        SchoolName = Console.ReadLine();
                        bool flag2 = false;
                        foreach (ScoreEntry va in Class)
                        {
                            if (SchoolName == va.School)
                            {
                                Console.WriteLine("==========");
                                Console.WriteLine("输入所要查询的学生:");
                                Console.WriteLine("==========");
                                string name = Console.ReadLine();
                                Console.WriteLine("==========");
                                Console.WriteLine("分数为{0}", va.GitScore($"F:\\桌面\\{SchoolName}.csv",name));
                                flag2= true;
                            }
                        }
                        if (flag2 == false)
                        {
                            throw new CustomError("找不到班级！");
                        }
                    }
                }
                catch(Exception ex)
                {
                    // 让用户知道出了什么问题
                    Console.WriteLine("===========================");
                    Console.WriteLine("分数读取错误");
                    Console.WriteLine(ex.Message);
                    Console.WriteLine("===========================");
                }
            }
            else if (select == 9)
            {
                //==============================方法的重载=============================//
                int t1 =1;
                float t2=2.6f;
                string t3="第三";
                char t4='四';

                test.TestMain();
                Console.WriteLine("选择测试类型:");
                Console.WriteLine("1.int 2.float 3.string 4.char");
                int temp = int.Parse(Console.ReadLine());

                if (temp==1)
                {
                    Console.WriteLine(test.Test(t1));
                }
                if (temp == 2)
                {
                    Console.WriteLine(test.Test(t2));
                }
                if (temp == 3)
                {
                    Console.WriteLine(test.Test(t3));
                }
                if (temp == 4)
                {
                    Console.WriteLine(test.Test(t4));

                }
            }
            else if (select == 10)
            {
                //==============================文件读取=============================//
                string pachstr,str;
                pachstr=Console.ReadLine();
                str=Console.ReadLine();
                FileRW.FileWrite(pachstr, str);
                //FileRW.SaveCSV(pachstr);
                Console.WriteLine(FileRW.FileRead(pachstr));
            }
            else if(select == 11)
            {
                //================================委托===============================//
                int num1,num2;
                Output("输入要对比的两个数字:",Fput);
                num1= int.Parse(Console.ReadLine());
                num2= int.Parse(Console.ReadLine());
                Output("选择对比模式: Max、Min", Fput);
                string str = Console.ReadLine();
                if (str == "Max")
                {
                    NumbersDetermine(num1, num2, Max);
                }
                else if (str == "Min")
                {
                    NumbersDetermine(num1, num2, Min);
                }
                int[] ints = { 1, 3, 5, 7 };
                Transform(ints, Square);
                foreach(var v in ints)
                {
                    Output(v,Fput);
                }
                Release.Send();

            }
            else if(select == 99)
            {
                int k = 1;
                int j = (++k) + (++k);
                Console.WriteLine(j);
            }
            else
            {
                Console.WriteLine("输入错误，请重新输入");
            }

        }
    }
}