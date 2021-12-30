using System;

public struct MyStruct
        {
            public int a, b;
        }

public class Chapter2
{
    public MyStruct myStruct;
    public static void item12_memberInit() {
        Chapter2 c2 = new();
        Console.WriteLine(c2.myStruct.a);
    }
}
