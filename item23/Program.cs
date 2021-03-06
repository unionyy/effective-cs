// MyClass a = new MyClass(1);
// MyClass b = new MyClass(2);
// Example.Add<MyClass>(a, b);

MyClass2 a = new MyClass2(1);
MyClass2 b = new MyClass2(2);
Example.Add<MyClass2>(a, b, (left, right) => new MyClass2(left.value + right.value));

public class MyClass2
{
    public int value;

    public MyClass2(int value)
    {
        this.value = value;
    }
}

public class MyClass : IAdd<MyClass>
{
    int value;
    public MyClass(int value)
    {
        this.value = value;
    }
    public MyClass AddFunc(MyClass A)
    {
        return new MyClass(this.value + A.value);
    }
}
// AddFunc 메서드를 사용하 위해IAdd<T> 인터페이스 선언
public interface IAdd<T>
{
	T AddFunc(T A);
}

public static class Example
{
	public static T Add<T>(T left, T right) where T : IAdd<T>
    {
        return left.AddFunc(right);
    }

    public static T Add<T>(T left, T right, Func<T, T, T> AddFunc) =>
		AddFunc(left, right);
}