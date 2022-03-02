// int[] numbers = { 0, 1, 2, 3, 4, 5 };

// var smallNumbers = from n in numbers
//     where n < 3
//     select n;

// var smallNumbers2 = numbers.Where(n => n < 5);

// var people = from e in employees
//     where e.Age > 30
//     orderby e.LastName, e.FirstName, e.Age
//     select e;

// // 위 쿼리는 다음과 같이 변환된다.
// var people = employees.Where(e => e.Age > 30).
//     OrderBy(e => e.LastName).
//     ThenBy(e => e.FirstName).
//     ThenBy(e => e.Age);

// var results = from e in employees
//     group e by e.Department into d
//     select new
//     {
//         Department = d.Key,
//         Size = d.Count()
//     };

// // 먼저 group into 구문이 중첩 쿼리로 변환된다.
// var results = from d in
//     from e in employees group e by e.Department
//     select new {
//         Department = d.Key,
//         Size = d.Count()
//     };

// // 이제 메서드 호출 구문으로 변환된다.
// var results = employees.GroupBy(e => e.Department).
//     Select(d => new { Department = d.Key, Size = d.Count() });

// int[] odds = { 1, 3, 5, 7 };
// int[] evens = { 2, 4, 6, 8 };

// var values = from oddNumber in odds
//     from evenNumber in evens
//     where oddNumber > evenNumber
//     select new
//     {
//         oddNumber,
//         evenNumber,
//         Sum = oddNumber + evenNumber
//     };

// // 위 쿼리는 다음과 같이 변환된다.
// var values = odds.SelectMany(oddNumber => evens,
//     (oddNumber, evenNumber) =>
//     new { oddNumber, evenNumber }).
//     Where(pair => pair.oddNumber > pair.evenNumber).
//     Select(pair => new {
//         pair.oddNumber,
//         pair.evenNumber,
//         Sum = pair.oddNumber + pair.evenNumber
//     });

// // 이해하기 쉽도록 SelectMany 메서드만 발췌
// odds.SelectMany(oddNumber => evens,
//     (oddNumber, evenNumber) =>
//     new { oddNumber, evenNumber });

var numbers = new int[] { 0, 1, 2, 3, 4, 5 };
var labels = new string[] { "0", "1", "2", "3", "4", "5" };

var query = from num in numbers
    join label in labels on num.ToString() equals label
    select new { num, label };

// 위 쿼리는 다음과 같이 변환된다.
var qeury = numbers.Join(labels, num => num.ToString(),
    label => label, (num, label) => new { num, label });

// into 절 사용
var groups = from p in projects
    join t in tasks on p equals t.Parent
    into projTasks
    select new { Project = p, projTasks };

// 위 쿼리는 다음과 같이 변환된다.
var groups = projects.GroupJoin(tasks,
    p => p, t => t.Parent,
    (p, projTasks ) => new { Project = p, TaskList = projTasks });