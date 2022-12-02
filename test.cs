using System.Linq.Expressions;

namespace Overload;

public class test
{
    public static int Test(int m)
    {
        return 1;
    }
    public static int Test(float m)
    {
        return 2;
    }
    public static int Test(string m)
    {
        return 3;
    }
    public static int Test(char m)
    {
        return 4;
    }

    static T Test3<T>(List<T> nums) where T : struct
    {
        T sum = default;
        foreach (dynamic item in nums)
        {
            sum += item;
        }
        return sum;
    }

    public static void TestMain()
    {
        for(int i=0; i<3; i++)
        {
            Console.WriteLine("√");
        }

        DerivedClass md = new DerivedClass();
        DerivedClass2 md1 = new DerivedClass2(2);
      //BaseClass md1 = new DerivedClass2(2);

        md.GetNum();
        md1.GetNum();
        md.Test();
    }
}

interface Test233
{
    void Test();
    enum Test2 { }
}

abstract public class BaseClass:Test233
{
    int num;

    public BaseClass()
    {
        num = 0;
    }

    public BaseClass(int i)
    {
        num = i;
    }

    public virtual void GetNum()
    {
        Console.WriteLine(this.num);
    }

    public void Test()
    {
        Console.WriteLine(Test2.A);
    }
    enum Test2
    {
        A,
        B,
        C,
        D,
    }
}

public class DerivedClass : BaseClass
{
    //这个构造函数将调用BaseClass.BaseClass()
    public DerivedClass() : base()
    {
    }

    //这个构造函数将调用BaseClass.BaseClass(int i)
    public DerivedClass(int i) : base(i)
    {
    }
}
public class DerivedClass2 : BaseClass
{
    public DerivedClass2(int i) : base(i)
    {
    }
    public override void GetNum()
    {
        Console.WriteLine(base.GetNum);
    }
}