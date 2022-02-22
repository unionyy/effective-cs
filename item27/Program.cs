using FooEx;

MyType t = new MyType();
t.Marker = 1;
t.NextMarker();
Console.WriteLine(t.Marker);

public interface IFoo
{
    int Marker { get; set; }
}

public class MyType : IFoo
{
    public int Marker { get; set; }
}


namespace FooEx
{
    public static class FooExtenstions
    {
        public static void NextMarker(this IFoo thing) =>
            thing.Marker += 1;
    }
}
