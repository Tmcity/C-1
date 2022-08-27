using System.Reflection;
using System.Text;
using System.Windows.Markup;
using static FileR_W.FileRW;

namespace Score;

public class ScoreEntry
{

    /*private string Name2;
    private float Score2;
    public ScoreEntry(string n,float s)
    {
        Name2 = n;
        Score2 = s;
    }

    public ScoreEntry p2 = new ScoreEntry("2", 5);*/

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


    //private static List<grades> n = new List<grades>();

    public List<grades> N = new List<grades>();

    public void SaveCSV(string filePath)
    {

        //N.Add(new grade2 { Name = "Tom", Score = 38 });
        //N.Add(new grade2 { Name = "Ava", Score = 76 });
        //N.Add(new grade2 { Name = "Mia", Score = 23 });
        //N.Add(new grade2 { Name = "Jom", Score = 87 });

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
        string data = "";// NamePro[0].Name+","+ NamePro[1].Name;

        foreach (FieldInfo fieldInfo in fieldInfos)
        {
            data += fieldInfo.Name + ",";
        }
        sw.WriteLine(data);

        //写入行数据
        string data2 = "";
        foreach (var v in N)
        {
            foreach (FieldInfo fieldInfo in fieldInfos)
            {
                data2 += fieldInfo.GetValue(v) + ",";
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

    public int GitScore(string name)
    {
        int score = 0;
        bool flag=false;
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
            return score;
        }
        else
        {
            throw new Objectnotfound("找不到对象!");
        }
    }
}