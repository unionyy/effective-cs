var myList = new IntList();
myList.Add(42);
myList.Add(2);
myList.WriteLog();

var list2 = new List<int>();
list2.Add(13);
list2.Add(2);
list2.WriteLog();

foreach(var item in myList)
{
    Console.WriteLine(item);
}
myList.ToArray();
var en = myList.GetEnumerator();

Console.WriteLine(en.Current);
en.MoveNext();
Console.WriteLine(en.Current);

var en2 = list2.GetEnumerator();
Console.WriteLine(en2.Current);
en2.MoveNext();
Console.WriteLine(en2.Current);

public class IntList : List<int>
{
    public void MyMethod()
    {
        Console.WriteLine("!");
    }
}

public static class ListExtends
{
    public static void WriteLog(this IEnumerable<int> ints)
    {
        Console.WriteLine("write");
    }
}