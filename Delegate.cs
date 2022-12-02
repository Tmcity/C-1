using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using static Delegator.Delegate;
[assembly: InternalsVisibleTo("Delegator.Delegate")]

namespace Delegator
{
    class Delegate
    {
        public delegate int testDelegator(int num1,int num2);
        public delegate void formattedOutput(string str);
        public delegate T Transformer<T>(T input);

        //===========================================================//

        public static testDelegator Max = delegate (int a,int b)
        {
            if(a > b)
            {
                return a;
            }
            else if(a < b)
            {
                return b;
            }
            else
            {
                return 0;
            }
        };

        public static testDelegator Min = delegate (int a, int b)
        {
            if (a > b)
            {
                return b;
            }
            else if (a < b)
            {
                return a;
            }
            else
            {
                return 0;
            }
        };      //匿名方法

        public static void Transform<T>(T[] values,Transformer<T> t)
        {
            for(int i=0;i<values.Length;i++)
            {
                values[i]=t(values[i]);
            }
        }

        //public static void Transform<T>(T[] values,Func<T,T> transformer)
        //{
        //    for (int i = 0; i < values.Length; i++)
        //    {
        //        values[i] = transformer(values[i]);
        //    }
        //}

        public static void Output<T>(T str,formattedOutput f)
        {
            string newstr = str.ToString();
            f(newstr);
        }

        //===========================================================//

        public static int Square(int n)
        {
            return n*n;
        }
        public static void Fput<T>(T str)
        {
            Console.WriteLine(str);
            Console.WriteLine("==========");
        }
        public static void NumbersDetermine(int num1,int num2, testDelegator del)
        {

            Output(del(num1, num2),Fput);
            
            int[] numbers = { 2, 3, 4, 5 };
            var squaredNumbers = numbers.Select(x => x * x);
            Output(string.Join(" ", squaredNumbers),Fput);


            var list= new List<int>() {1,2,3};
            var list2 = list.FindAll(x=>x>1);
            list2.ForEach(x => Output(x,Fput));
        }

    }



    //interface ISubscriber
    //{
    //    public void SetBz(bz Bz,int i);
    //    public void ReadBz(bz Bz);
    //}
    class bs
    {
        public string name;
        public bs(string name)
        {
            this.name = name;
        }

        //public List<ISubscriber> Subscribers=new List<ISubscriber>();

        public void SendBz(bz Bz)
        {
            int i = 1;
            foreach(Action<bz,int,string> DS in DSubscribe.GetInvocationList())
            {
                DS(Bz,i,this.name);
                i++;
            }
            //Subscribers.ForEach(Sub => Sub.SetBz(Bz,i));
        }

        //public delegate void DSubscriber(bz Bz);
        //public event DSubscriber Ds;
        public event Action<bz,int,string> DSubscribe;

    }
    class Subscriber1// : ISubscriber
        {
        public string name;
        public Subscriber1(string name)
        {
            this.name = name;
        }
        public bz Bz;
        public int i;
        public string str;
        public void SetBz(bz Bz,int i,string str)
        {
            this.Bz = Bz;
            this.i = i;
            this.str = str;
        }
        public void ReadBz(bz Bz)
        {
            Output($"{i}#一个叫{name}的男人读到出版社{str}标题为{Bz.Title}的{Bz.content}",Fput);
        }
    }
    class Subscriber2// : ISubscriber
    {
        public string name;
        public Subscriber2(string name)
        {
            this.name = name;
        }
        public bz Bz;
        public int i;
        public string str;
        public void SetBz(bz Bz, int i, string str)
        {
            this.Bz = Bz;
            this.i = i;
            this.str = str;
        }
        public void ReadBz(bz Bz)
        {
            Output($"{i}#一个叫{name}的女人读到出版社{str}标题为{Bz.Title}的{this.Bz.content}", Fput);
        }
    }
    public class bz
    {
        public string Title { get; set; }
        public string content { get; set; }
    }

    class Release
    {
        public static void Send()
        {

            Subscriber1 A = new Subscriber1("A");
            Subscriber1 B = new Subscriber1("B");
            Subscriber2 C= new Subscriber2("C");
            Subscriber2 D= new Subscriber2("D");

            var bs1 = new bs("Tmcity");
            bz Bz = new bz { Title = "新闻", content = "一个新闻" };

            bs1.DSubscribe+=A.SetBz;
            bs1.DSubscribe+=B.SetBz;
            bs1.DSubscribe+=C.SetBz;
            bs1.DSubscribe+=D.SetBz;

            //bs1.Subscribers.Add(A);
            //bs1.Subscribers.Add(B);
            //bs1.Subscribers.Add(C);
            //bs1.Subscribers.Add(D);

            bs1.SendBz(Bz);

            A.ReadBz(Bz);
            B.ReadBz(Bz);
            C.ReadBz(Bz);
            D.ReadBz(Bz);

            //bs1.Subscribers.ForEach(Sub => Sub.ReadBz(Bz));
        }
    }
}
