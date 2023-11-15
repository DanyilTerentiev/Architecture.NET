using Bridge.Interfaces;

namespace Bridge.Abstractions;

public class DmytroHutsuliak : Student
{
    public override void Learn()
    {
        Console.WriteLine("П'є терновецьке у пившнюсі");
    }

    public DmytroHutsuliak(ITakeClasses takeClasses, string firstName, string lastName) : base(takeClasses, firstName, lastName)
    {
    }
}