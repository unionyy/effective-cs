using System;

class B
{
    protected B()
    {
        VFunc();
    }

    protected virtual void VFunc()
    {
        Console.WriteLine("VFunc in B");
    }
}

class Derived : B
{
    private readonly string msg = "Set by initializer";

    public Derived(string msg)
    {
        this.msg = msg;
    }

    protected override void VFunc()
    {
        Console.WriteLine(msg);
    }
}

abstract class B2
{
    protected B2()
    {
        VFunc();
    }

    protected abstract void VFunc();
}

class Derived2 : B2
{
    private readonly string msg = "Set by initializer";

    public Derived2(string msg)
    {
        this.msg = msg;
    }

    protected override void VFunc()
    {
        Console.WriteLine(msg);
    }
}