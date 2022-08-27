using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Reflection;
using System.Runtime.Serialization.Formatters;

namespace FileR_W
{
    class FileRW
    {
        public static void FileWrite(string path, string str)
        {
            //如果该文件存在，则删除它
            if (File.Exists(path))
            {
                File.Delete(path);
            }

            //创建文件
            //using FileStream fs=File.Create(path);
            FileStream fs = File.Create(path);
            AddText(fs, str);
            fs.Dispose();
            //fs.Flush();             //清除此流的缓冲区，使得所有缓冲数据都写入到文件中
        }

        public static string FileRead(string path)
        {
            FileStream fs = File.OpenRead(path);
            byte[] info = new byte[fs.Length];
            fs.Read(info, 0, info.Length);
            string str = Encoding.UTF8.GetString(info);
            return str;
        }

        public static void AddText(FileStream fs, string v)
        {
            //char[] chars=v.ToCharArray();
            byte[] info = new UTF8Encoding(true).GetBytes(v);
            fs.Seek(0, SeekOrigin.Begin);            //Seek(long offset,System.IO.SeekOrigin origin)
                                                     //offset:相对于origin,指针从此处开始      origin:规定起始位置
                                                     //origin => 流的开始位置:Begin | 流的当前位置:Current | 流的结束位置:End
            fs.Write(info, 0, info.Length);           //Write(ReadOnlySpan<byte> buffer)将<buffer>的内容复制到当前文件流
                                                      //Write(Byte[],offset,count)将Byte[]数组中的内容写入到当前文件流
                                                      //offset:从数组中开始读取的位置    count:从数组中读取的长度
        }

        //public static List<grade2> N = new List<grade2>();

        //public static void SaveCSV(grade2 N,string filePath)
        //{

        //    //N.Add(new grade2 { Name = "Tom", Score = 38 });
        //    //N.Add(new grade2 { Name = "Ava", Score = 76 });
        //    //N.Add(new grade2 { Name = "Mia", Score = 23 });
        //    //N.Add(new grade2 { Name = "Jom", Score = 87 });
            
        //    //foreach (FieldInfo item in )
        //    //{
        //    //    Console.WriteLine(item.Name/* + " " + item.GetValue(N[0])*/);
        //    //}

        //    FieldInfo[] fieldInfos = typeof(grade2).GetFields();
        //    foreach (var v in N)
        //    {
        //        foreach (FieldInfo fieldInfo in fieldInfos)
        //        {
        //            Console.WriteLine(fieldInfo.Name + ": " + fieldInfo.GetValue(v));
        //        }
        //    }

        //    FileInfo fi = new FileInfo(filePath);
        //    if (fi.Directory.Exists)
        //    {
        //        fi.Directory.Create();  //文件不存在，创建文件
        //    }

        //    FileStream fs = new FileStream(filePath, FileMode.Create, FileAccess.Write);
        //    StreamWriter sw = new StreamWriter(fs, Encoding.UTF8);

        //    //写入列名
        //    string data="";// NamePro[0].Name+","+ NamePro[1].Name;

        //    foreach (FieldInfo fieldInfo in fieldInfos)
        //    {
        //        data += fieldInfo.Name+",";
        //    }
        //    sw.WriteLine(data);

        //    //写入行数据
        //    string data2 = "";
        //    foreach (var v in N)
        //    {
        //        foreach (FieldInfo fieldInfo in fieldInfos)
        //        {
        //            data2 += fieldInfo.GetValue(v)+",";
        //        }
        //        sw.WriteLine(data2);
        //        data2 = "";
        //    }

        //    /*data = N[0].Name+","+ N[0].Score;
            
        //    data = N[1].Name + "," + N[1].Score;
        //    sw.WriteLine(data);
        //    data = N[2].Name + "," + N[2].Score;
        //    sw.WriteLine(data);*/

        //    sw.Close();
        //    fs.Close();
        //}

        //public struct grade2
        //{
        //    public string Name;
        //    public int Score;
        //}
        //public void Add(string name, int score)
        //{
        //    grade2 temp = new grade2();
        //    temp.Name = name;
        //    temp.Score = score;
        //    N.Add(temp);
        //}
    }
}
