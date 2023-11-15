using Bridge.Interfaces;

namespace Bridge.Abstractions;

public class Student
{
    public Student(ITakeClasses takeClasses, string firstName, string lastName)
    {
        TakeClasses = takeClasses;
        FirstName = firstName;
        LastName = lastName;
    }

    public string FirstName { get; set; } = null!;

    public string LastName { get; set; } = null!;
    
    protected readonly ITakeClasses TakeClasses;

    public virtual void Learn()
    {
        Console.WriteLine($"{FirstName} {LastName} learns");
        TakeClasses.TakeClass();
        TakeClasses.DoPractical();
    }
}