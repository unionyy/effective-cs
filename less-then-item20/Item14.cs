using System;
using System.Collections.Generic;

struct ImportantData
{
    int a, b;
}

public class Item14
{
	// 데이터 컬렉션
	private List<ImportantData> col1;
	
	// 인스턴스 변수
	public string name;

	public Item14() :
		this(0, "")
	{
	}

	public Item14(int initialCount) :
		this(initialCount, string.Empty)
	{
	}

    public Item14(string name) :
        this(0, name)
    {
    }

	public Item14(int initialCount, string name)
	{
        Console.WriteLine(initialCount);
		col1 = (initialCount > 0) ?
			new List<ImportantData>(initialCount) :
			new List<ImportantData>();

		this.name = name;
	}
}

public class Item14_2
{
	// 데이터 컬렉션
	private List<ImportantData> col1;
	
	// 인스턴스 변수
	public string name;

	public Item14_2() :
		this(0, string.Empty)
	{
	}

	public Item14_2(int initialCount = 0, string name = "")
	{
        Console.WriteLine(initialCount);
		col1 = (initialCount > 0) ?
			new List<ImportantData>(initialCount) :
			new List<ImportantData>();

		this.name = name;
	}
}
