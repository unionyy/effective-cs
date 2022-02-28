IList<MyBase> a = new List<MyDerived>();
IList<MyDerived> a = new List<MyBase>();

// IComparable<MyDerived> a = new MyBase(1) as IComparable<MyBase>;
// IComparable<MyBase> b = new MyDerived(1) as IComparable<MyDerived>;

// IEnumerable<MyDerived> a = MyBase.GetEnumerable();
// IEnumerable<MyBase> b = MyDerived.GetMyDerivedEnumerable();


public class MyBase : IComparable<MyBase>
{
    protected int num;

    public MyBase(int num)
    {
        this.num = num;
    }

    public static IEnumerable<MyBase> GetEnumerable()
    {
        for (var i = 0; i < 10; i++)
            yield return new MyBase(i);
    }

    public int CompareTo(MyBase other) =>
        num.CompareTo(other.num);
}

public class MyDerived : MyBase, IComparable<MyDerived>
{
    public MyDerived(int num)
    : base(num)
    {
    }
    public static IEnumerable<MyDerived> GetMyDerivedEnumerable()
    {
        for (var i = 0; i < 10; i++)
            yield return new MyDerived(i);
    }

    public int CompareTo(MyDerived other) =>
        num.CompareTo(other.num);
}