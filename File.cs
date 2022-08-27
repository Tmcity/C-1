using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileTotal
{
    class FileReading
    {
        //=============================文件读取==============================//

        public static long Total(string path, bool isdir/*,string filePath*/)
        {
            long fileTif = 0;
            long dirTif = 0;
            try
            {
                // 创建一个StreamReader的实例以从文件中读取数据。

                //StreamReader sr = new StreamReader(filePath);
                //string line;

                string[] file = Directory.GetFiles(path);
                string[] dirs = Directory.GetDirectories(path);

                // 读取并显示文件中的每一行，直到达到文件的末尾。

                //while ((line = sr.ReadLine()) != null)
                //{
                //    Console.WriteLine(line);
                //}

                fileTif += file.Length;
                dirTif += dirs.Length;

                foreach (var VARIABLE in dirs)
                {
                    fileTif += Total(VARIABLE, isdir);
                    dirTif += Total(VARIABLE, isdir);
                }
            }
            catch (Exception e)
            {
                // 让用户知道出了什么问题
                Console.WriteLine("===========================");
                Console.WriteLine("文件读取错误");
                Console.WriteLine(e.Message);
                Console.WriteLine("===========================");
            }

            if (isdir == true)
            {
                return fileTif;
            }
            else if (isdir == false)
            {
                return dirTif;
            }
            else
            {
                return 0;
            }
        }
    }
}
