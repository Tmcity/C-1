namespace CharacterToLnteger
{
    internal class Conversion
    {
        public static void Convert()
        {
            try
            {
                //=============================字符串转整数=============================//
                Console.WriteLine("输入字符串：");
                string m = Console.ReadLine();
                int N = 0;
                for (int i = 0; i < m.Length; i++)
                {
                    N = N * 10 + (m[i] - '0');
                }
                Console.WriteLine("转换后的整数为：{0}", N);
            }
            catch (Exception e)
            {
                Console.WriteLine("====================错误====================");
                Console.WriteLine("输入格式错误，请依次输入");
                Console.WriteLine("===========================================");
                Console.WriteLine(e);
            }

            //=============================字符转整型=============================//


            /*bool temp;
            string tempStr;

            Console.WriteLine("输入要转换的字符:");
            tempStr = Console.ReadLine();

            temp = int.TryParse(tempStr, out int k);
            Console.WriteLine($"转换结果:{temp},转换值:{k}");*/

        }
    }
}
