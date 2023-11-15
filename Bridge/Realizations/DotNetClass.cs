using Bridge.Interfaces;

namespace Bridge.Realizations;

public class DotNetClass : ITakeClasses
{
    public void TakeClass()
    {
        Console.WriteLine("Sit just for a minute turns into a fucking hour and a half");
    }

    public void DoPractical()
    {
        Console.WriteLine("Failing in trying to complete one practical assignment in one class");
    }
}