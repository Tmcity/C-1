using System.Text;

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
            using (FileStream fs = File.Create(path))
            {
                AddText(fs, str);
            }
            //fs.Dispose();
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
    }
}
