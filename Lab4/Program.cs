using System;

// Abstract classes for students and teachers
abstract class Person
{
    public string Name { get; set; }
    public int Age { get; set; }
}

class Student : Person
{
    public string Major { get; set; }
}

class Teacher : Person
{
    public string Department { get; set; }
}

// Abstract factory for creating students and teachers
interface UniversityFactory
{
    Student CreateStudent();
    Teacher CreateTeacher();
}

// Concrete factory for creating students and teachers in the arts field
class ArtsUniversityFactory : UniversityFactory
{
    public Student CreateStudent()
    {
        return new Student { Major = "Fine Arts" };
    }

    public Teacher CreateTeacher()
    {
        return new Teacher { Department = "Art History" };
    }
}

// Concrete factory for creating students and teachers in the science field
class ScienceUniversityFactory : UniversityFactory
{
    public Student CreateStudent()
    {
        return new Student { Major = "Computer Science" };
    }

    public Teacher CreateTeacher()
    {
        return new Teacher { Department = "Physics" };
    }
}

class Program
{
    static void Main()
    {
        UniversityFactory factory;

        // Choose a factory to create students and teachers in the arts field
        factory = new ArtsUniversityFactory();

        Student artsStudent = factory.CreateStudent();
        Teacher artsTeacher = factory.CreateTeacher();

        Console.WriteLine("Student in Arts University: Major - " + artsStudent.Major);
        Console.WriteLine("Teacher in Arts University: Department - " + artsTeacher.Department);

        // Choose a factory to create students and teachers in the science field
        factory = new ScienceUniversityFactory();

        Student scienceStudent = factory.CreateStudent();
        Teacher scienceTeacher = factory.CreateTeacher();

        Console.WriteLine("Student in Science University: Major - " + scienceStudent.Major);
        Console.WriteLine("Teacher in Science University: Department - " + scienceTeacher.Department);
    }
}
