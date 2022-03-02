using ConsoleExtensions;

Person person = new Person
{
    FirstName = "Uniony",
    LastName = "me"
};

Console.WriteLine(person.Format());

public sealed class Person
{
    public string FirstName
    {
        get; set;
    }
    public string LastName
    {
        get; set;
    }
}

// 좋지 않은 시작
// 확장 메서드를 이용하여 클래스를 확장함
namespace ConsoleExtensions
{
    public static class ConsoleReport
    {
        public static string Format(this Person target) =>
            target.FirstName + "." + target.LastName;
    }
}

namespace XmlExtenstion
{
    public static class XmlReport
    {
        public static string Format(this Person target)
        {
            // 생략
        }
    }
}

public static class PersonReports
{
    public static string FormatAsText(Person target) =>
        target.FirstName + "." + target.LastName;

    public static string FormatAsXml(Person target)
    {
        // 생략
    }
}