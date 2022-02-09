Customer c1 = new("d");
Customer c2 = new("b");
Console.WriteLine(c1.CompareTo(c2));

public struct Customer : IComparable<Customer>, IComparable
{
    private readonly string name;
    private readonly int revenue;

    public Customer(string name)
    {
        this.name = name;
        this.revenue = 1;
    }

    // IComparable<Customer> 멤버
    public int CompareTo(Customer other) => name.CompareTo(other.name);

    // IComparable 멤버
    int IComparable.CompareTo(object obj)
    {
        if (!(obj is Customer))
            throw new ArgumentException("Argument is not a Customer", "obj");

        Customer otherCustomer = (Customer)obj;

        return this.CompareTo(otherCustomer);
    }

    // 관계 연산자
    public static bool operator < (Customer left, Customer right) =>
        left.CompareTo(right) < 0;
    public static bool operator <= (Customer left, Customer right) =>
        left.CompareTo(right) <= 0;
    public static bool operator > (Customer left, Customer right) =>
        left.CompareTo(right) > 0;
    public static bool operator >= (Customer left, Customer right) =>
        left.CompareTo(right) >= 0;

    public static Comparison<Customer> CompareByRevenue =>
        (left, right) => left.revenue.CompareTo(right.revenue);

    private class RevenueComparer : IComparer<Customer>
    {
        // IComparer<Customer> 멤버
        int IComparer<Customer>.Compare(Customer left, Customer right) =>
            left.revenue.CompareTo(right.revenue);
    }

    private static Lazy<RevenueComparer> revComp =
        new Lazy<RevenueComparer>(() => new RevenueComparer());
    
    public static IComparer<Customer> RevenueCompare => revComp.Value;
}