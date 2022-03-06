if (!File.Exists("myFile.txt"))
{
    File.Open("myFile.txt", FileMode.Open);
}

public class DoesWorkThatMightFail
{
    public bool TryDoWork()
    {
        if (!TestConditions())
            return false;

        Work(); // 여전히 실패할 수 있지만 가능성은 낮다.

        return true;
    }


    // 매우 심각한 문제가 발생했을 때에 실패한다.
    public void DoWork()
    {
        Work(); // 예외를 발생시킬 수 있다.
    }
    private bool TestConditions()
    {
        // 본문 생략 (테스트 조건)
        return true;
    }
    private void Work()
    {
        // 세부 내용 생략 (임의의 작업 수행)
    }
}