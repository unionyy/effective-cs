// See https://aka.ms/new-console-template for more information
Example.Test(new MyDerived());
Example.Test(new MyImplement());
Example.Test((new MyMulti() as MyBase));


public class MyBase{}

public interface IMyInterface{}

public class MyDerived : MyBase{}

public class MyImplement : IMyInterface{}

public class MyMulti : MyBase, IMyInterface{}

public class Example
{
    public static void Test(MyBase b)
    {
        Console.WriteLine("MyBase");
    }
    public static void Test(IMyInterface obj)
    {
        Console.WriteLine("IMyInterface");
    }
    
    public static void Test<T>(T obj)
    {
        Console.WriteLine(obj.ToString());
    }
}