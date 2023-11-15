using System;
using System.Collections.Generic;

// Об'єкт, який потрібно зберегти (Originator)
class Student
{
    public string Name { get; set; }
    public int Age { get; set; }

    public Student(string name, int age)
    {
        Name = name;
        Age = age;
    }

    // Створюємо знімок (Memento) стану об'єкта
    public StudentMemento CreateMemento()
    {
        return new StudentMemento(Name, Age);
    }

    // Відновлюємо стан об'єкта з знімка
    public void SetMemento(StudentMemento memento)
    {
        Name = memento.Name;
        Age = memento.Age;
    }

    public void DisplayInformation()
    {
        Console.WriteLine($"Student: {Name}, Age: {Age}");
    }
}

// Знімок стану об'єкта (Memento)
class StudentMemento
{
    public string Name { get; private set; }
    public int Age { get; private set; }

    public StudentMemento(string name, int age)
    {
        Name = name;
        Age = age;
    }
}

// Опікун (Caretaker)
class StudentCaretaker
{
    private Stack<StudentMemento> mementos = new Stack<StudentMemento>();

    public void SaveMemento(StudentMemento memento)
    {
        mementos.Push(memento);
    }

    public StudentMemento RestoreMemento()
    {
        if (mementos.Count > 0)
        {
            return mementos.Pop();
        }
        else
        {
            return null;
        }
    }
}

class Program
{
    static void Main()
    {
        // Створюємо студента
        Student john = new Student("John", 20);
        john.DisplayInformation();

        // Створюємо опікуна
        StudentCaretaker caretaker = new StudentCaretaker();

        // Зберігаємо поточний стан студента
        caretaker.SaveMemento(john.CreateMemento());

        // Змінюємо стан студента
        john.Name = "John Doe";
        john.Age = 21;
        john.DisplayInformation();

        // Відновлюємо попередній стан студента
        StudentMemento previousState = caretaker.RestoreMemento();
        if (previousState != null)
        {
            john.SetMemento(previousState);
            john.DisplayInformation();
        }
        else
        {
            Console.WriteLine("No previous state available.");
        }
    }
}
