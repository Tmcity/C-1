using System.IO;
using System.Reflection;
using System.Text;
using System.Windows.Markup;
using static FileR_W.FileRW;

namespace Score;

public class ScoreEntry
{
    public string School;
    public ScoreEntry(string school)
    {
        this.School = school;
    }

    public struct grades
    {

        public string Name;
        public int Score;

        /*public grades(string name,int Score)
        {
            this.Name = name;
            this.Score = Score;
        }*/

        public string GitName
        {
            get
            {
                return Name;
            }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException("value", "姓名不能为空！");
                }
                else
                {
                    this.Name = value;
                }
                
            }
        }
        public int GetScore { get => Score; set => Score = value; }
    }

    class Objectnotfound : Exception        //自定义异常
    {
        public Objectnotfound(string message) : base(message) { }
    }


    public List<grades> N = new List<grades>();

    public void SaveCSV(string filePath)
    {
        //foreach (FieldInfo item in )
        //{
        //    Console.WriteLine(item.Name/* + " " + item.GetValue(N[0])*/);
        //}
        FieldInfo[] fieldInfos = typeof(grades).GetFields();
        foreach (var v in N)
        {
            foreach (FieldInfo fieldInfo in fieldInfos)
            {
                Console.WriteLine(fieldInfo.Name + ": " + fieldInfo.GetValue(v));
            }
        }

        FileInfo fi = new FileInfo(filePath);
        if (fi.Directory.Exists)
        {
            fi.Directory.Create();  //文件不存在，创建文件
        }

        FileStream fs = new FileStream(filePath, FileMode.Create, FileAccess.Write);
        StreamWriter sw = new StreamWriter(fs, Encoding.UTF8);

        //写入列名
        string data = "";
        bool isEnd=false;
        foreach (FieldInfo fieldInfo in fieldInfos)
        {
            if (isEnd == false)
            {
                data += fieldInfo.Name + ",";
                isEnd = true;
            }
            else
            {
                data += fieldInfo.Name;
            }
        }
        sw.WriteLine(data);

        //写入行数据
        string data2 = "";
        foreach (var v in N)
        {
            isEnd = false;
            foreach (FieldInfo fieldInfo in fieldInfos)
            {
                if (isEnd == false)
                {
                    data2 += fieldInfo.GetValue(v) + ",";
                    isEnd = true;
                }
                else
                {
                    data2 += fieldInfo.GetValue(v);
                }
            }
            sw.WriteLine(data2);

            data2 = "";
        }

        sw.Close();
        fs.Close();
    }

    public void Add(string name, int score)
    {
        grades temp= new grades();
        temp.GitName=name;
        temp.GetScore=score;
        N.Add(temp);
    }

    public int GitScore(string filePath,string name)
    {
        int score = 0;

        if (N.Any() == true)
        {
            bool flag = false;
            foreach (grades i in N)
            {
                if (i.GitName == name)
                {
                    score = i.GetScore;
                    flag = true;
                    break;
                }
            }
            if (flag)
            {
                Console.WriteLine("从内存中找到成绩单");
                Console.WriteLine("==========");
                return score;
            }
            else
            {
                throw new Objectnotfound("找不到对象!");
            }
        }
        else
        {
            string[] nameStr=ReadCSV(filePath).Item1;
            string[] scoreStr=ReadCSV(filePath).Item2;

            bool flag = false;
            for(int i=0; i < nameStr.Length; i++)
            {
                if (nameStr[i] == name)
                {
                    score = int.Parse(scoreStr[i]);
                    flag = true;
                    break;
                }
            }
            if (flag)
            {
                Console.WriteLine("从文件中读取到成绩单");
                Console.WriteLine("==========");
                return score;
            }
            else
            {
                throw new Objectnotfound("找不到对象!");
            }
        }
    }

    public (string[],string[]) ReadCSV(string filePath)
    {
        string[] formsStr = File.ReadAllLines(filePath);
        string[] nameStr=new string[formsStr.Length-1];
        string[] scoreStr = new string[formsStr.Length - 1];
        int ii = 0;
        bool isFirstname = false;

        foreach (string fS in formsStr)
        {
            string[] lineStr=fS.Split(',');
            if (lineStr[0] == "Name")
            {
                isFirstname = true;
            }
            else if (lineStr[0] == "Score")
            {
                break;
            }
            else
            {
                if (isFirstname == true)
                {
                    nameStr[ii] = lineStr[0];
                    scoreStr[ii] = lineStr[1];
                }
                else
                {
                    nameStr[ii] = lineStr[1];
                    scoreStr[ii] = lineStr[0];
                }
                ii++;
            }
        }

        return (nameStr, scoreStr);

    }

}