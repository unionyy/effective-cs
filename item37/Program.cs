var answers = from number in AllNumbers()
    select number;

var smallNumbers = answers.Take(10);
foreach (var num in smallNumbers)
    Console.WriteLine(num);

// 무한 수행
var answers2 = from number in AllNumbers()
    where number < 10
    select number;

foreach (var num in answers2)
    Console.WriteLine(num);


// 무한 시퀀스
static IEnumerable<int> AllNumbers()
{
    var number = 0;
    while (number < int.MaxValue)
    {
        yield return number++;
    }
}