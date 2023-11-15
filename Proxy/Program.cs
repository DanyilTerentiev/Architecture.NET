using System;

// Common interface for the real object and proxy
interface IStudent
{
    void DisplayInformation();
}

// Real object (RealSubject)
class RealStudent : IStudent
{
    private string name;
    private int age;

    public RealStudent(string name, int age)
    {
        this.name = name;
        this.age = age;
        Console.WriteLine($"RealStudent object created for {name}");
    }

    public void DisplayInformation()
    {
        Console.WriteLine($"Student: {name}, Age: {age}");
    }
}

// Proxy object
class StudentProxy : IStudent
{
    private RealStudent _realStudent;
    private readonly string name;
    private readonly int age;

    public StudentProxy(string name, int age)
    {
        this.name = name;
        this.age = age;
        Console.WriteLine($"StudentProxy object created for {name}");
    }

    public void DisplayInformation()
    {
        // Create the real object only when the method is called
        if (_realStudent == null)
        {
            _realStudent = new RealStudent(name, age);
        }

        // Access the real object through the proxy
        _realStudent.DisplayInformation();
    }
}

class Program
{
    static void Main()
    {
        // Use the proxy to access student information
        IStudent studentProxy = new StudentProxy("John", 20);

        // Display student information through the proxy
        studentProxy.DisplayInformation();

        // Second call, the RealStudent object is already created, the proxy does not create a new object
        studentProxy.DisplayInformation();
    }
}