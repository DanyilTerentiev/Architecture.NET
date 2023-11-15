namespace Flyweight;

using System;
using System.Collections.Generic;

// Интерфейс для легковесных объектов (Flyweight)
interface IStudent
{
    void DisplayInformation();
}

// Конкретный легковесный объект (ConcreteFlyweight)
class Student : IStudent
{
    public string Name { get; private set; }
    public int Age { get; private set; }

    public Student(string name, int age)
    {
        Name = name;
        Age = age;
    }

    public void DisplayInformation()
    {
        Console.WriteLine($"Student: {Name}, Age: {Age}");
    }
}

// Фабрика легковесных объектов (FlyweightFactory)
class StudentFactory
{
    private Dictionary<string, IStudent> students = new Dictionary<string, IStudent>();

    public IStudent GetStudent(string name, int age)
    {
        string key = $"{name}_{age}";

        if (!students.ContainsKey(key))
        {
            // Если объект с заданными параметрами не существует, создаем новый
            students[key] = new Student(name, age);
        }

        return students[key];
    }
}

class Program
{
    static void Main()
    {
        // Использование легковесных объектов через фабрику
        StudentFactory studentFactory = new StudentFactory();

        IStudent student1 = studentFactory.GetStudent("John", 20);
        IStudent student2 = studentFactory.GetStudent("Jane", 22);
        IStudent student3 = studentFactory.GetStudent("John", 20); // Используем существующий объект

        // Вывод информации о студентах
        student1.DisplayInformation();
        student2.DisplayInformation();
        student3.DisplayInformation();

        // Проверка, что объекты совпадают
        Console.WriteLine($"student1 == student3: {ReferenceEquals(student1, student3)}");
    }
}