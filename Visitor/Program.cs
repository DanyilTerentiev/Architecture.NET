using System;
using System.Collections.Generic;

// Елемент (Element)
interface IStudentElement
{
    void Accept(IVisitor visitor);
}

// Конкретний елемент (Concrete Element)
class ComputerScienceStudent : IStudentElement
{
    public void Accept(IVisitor visitor)
    {
        visitor.VisitComputerScienceStudent(this);
    }

    public void Code()
    {
        Console.WriteLine("Computer science student is coding.");
    }
}

// Конкретний елемент (Concrete Element)
class PhysicsStudent : IStudentElement
{
    public void Accept(IVisitor visitor)
    {
        visitor.VisitPhysicsStudent(this);
    }

    public void Experiment()
    {
        Console.WriteLine("Physics student is conducting an experiment.");
    }
}

// Відвідувач (Visitor)
interface IVisitor
{
    void VisitComputerScienceStudent(ComputerScienceStudent student);
    void VisitPhysicsStudent(PhysicsStudent student);
}

// Конкретний відвідувач (Concrete Visitor)
class Professor : IVisitor
{
    public void VisitComputerScienceStudent(ComputerScienceStudent student)
    {
        Console.WriteLine("Professor evaluates computer science student's code.");
    }

    public void VisitPhysicsStudent(PhysicsStudent student)
    {
        Console.WriteLine("Professor reviews physics student's experiment results.");
    }
}

class Program
{
    static void Main()
    {
        // Створюємо студентів різних спеціальностей
        ComputerScienceStudent csStudent = new ComputerScienceStudent();
        PhysicsStudent physicsStudent = new PhysicsStudent();

        // Створюємо відвідувача
        Professor professor = new Professor();

        // Студенти приймають відвідувача
        csStudent.Accept(professor);
        physicsStudent.Accept(professor);
    }
}