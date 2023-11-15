using Bridge.Interfaces;

namespace Bridge.Realizations;

public class ArchitectureClass : ITakeClasses
{
    public void TakeClass()
    {
        Console.WriteLine("Learning about World of Warcraft with aid of an abstract factory!");
    }

    public void DoPractical()
    {
        Console.WriteLine("Realising that adapter, proxy, decorator and bridge use same concept of composition!");
    }
}