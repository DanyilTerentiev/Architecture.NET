using Bridge.Interfaces;

namespace Bridge.Abstractions;

public class TarasykHavrylets : Student
{
    public override void Learn()
    {
        Console.WriteLine("Learns dev ops");
        TakeClasses.TakeClass();
    }

    public TarasykHavrylets(ITakeClasses takeClasses, string firstName, string lastName) : base(takeClasses, firstName, lastName)
    {
    }
}