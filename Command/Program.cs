using System;
using System.Collections.Generic;

// Інтерфейс команди
interface ICommand
{
    void Execute();
}

// Конкретна команда
class EnrollCommand : ICommand
{
    private Student student;

    public EnrollCommand(Student student)
    {
        this.student = student;
    }

    public void Execute()
    {
        student.EnrollInCourse();
    }
}

// Одержувач (Receiver) - реальний об'єкт, який виконує операцію
class Student
{
    private string name;

    public Student(string name)
    {
        this.name = name;
    }

    public void EnrollInCourse()
    {
        Console.WriteLine($"{name} enrolled in a course.");
    }
}

// Об'єкт, який викликає команди
class Registrar
{
    private List<ICommand> commands = new List<ICommand>();

    public void AddCommand(ICommand command)
    {
        commands.Add(command);
    }

    public void ProcessCommands()
    {
        foreach (var command in commands)
        {
            command.Execute();
        }
        commands.Clear();
    }
}

class Program
{
    static void Main()
    {
        // Створюємо студента та команду для запису на курс
        Student john = new Student("John");
        ICommand enrollCommand = new EnrollCommand(john);

        // Створюємо реєстратора та передаємо йому команду
        Registrar registrar = new Registrar();
        registrar.AddCommand(enrollCommand);

        // Обробляємо команди
        registrar.ProcessCommands();
    }
}