namespace RandomNumberGenerator
{
    class RandomNumber
    {
        public static void Generator()
        {
            try
            {
                //=============================随机数生成=============================//

                int n;
                string[] k = new string[1000];
                int[] t = new int[1000];
                string m;

                Console.WriteLine("输入生成随机数的个数：");
                n = int.Parse(Console.ReadLine());
                Console.WriteLine("输入生成随机数的范围：");
                m = Console.ReadLine();
                k = m.Split("~");
                for (int i = 0; i < k.Length; i++)
                {
                    t[i] = int.Parse(k[i]);
                }

                Console.WriteLine("==========================");

                int[] a = new int[100];
                var r = new Random();
                for (int i = 1; i <= n; i++)
                {
                    a[i] = r.Next(t[0], t[1]);
                    Console.WriteLine("{0}{1}{2}", i, "|", a[i]);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("====================错误====================");
                Console.WriteLine("生成的随机数过多");
                Console.WriteLine("===========================================");
                Console.WriteLine(e);
            }
        }
    }
}
