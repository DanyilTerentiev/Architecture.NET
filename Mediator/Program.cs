using System;
using System.Collections.Generic;

// Інтерфейс посередника
interface IMediator
{
    void SendMessage(string message, Colleague colleague);
}

// Колега (студент)
class Colleague
{
    private string name;
    private IMediator mediator;

    public Colleague(string name, IMediator mediator)
    {
        this.name = name;
        this.mediator = mediator;
    }

    public string Name
    {
        get { return name; }
    }

    public void Send(string message)
    {
        Console.WriteLine($"{name} sends message: {message}");
        mediator.SendMessage(message, this);
    }

    public void Receive(string message)
    {
        Console.WriteLine($"{name} receives message: {message}");
    }
}

// Конкретний посередник
class ConcreteMediator : IMediator
{
    private List<Colleague> colleagues = new List<Colleague>();

    public void Register(Colleague colleague)
    {
        colleagues.Add(colleague);
    }

    public void SendMessage(string message, Colleague colleague)
    {
        foreach (var col in colleagues)
        {
            if (col != colleague)
            {
                col.Receive(message);
            }
        }
    }
}

class Program
{
    static void Main()
    {
        // Створюємо посередника
        ConcreteMediator mediator = new ConcreteMediator();

        // Створюємо колег (студентів)
        Colleague john = new Colleague("John", mediator);
        Colleague jane = new Colleague("Jane", mediator);
        Colleague bob = new Colleague("Bob", mediator);

        // Реєструємо колег в посереднику
        mediator.Register(john);
        mediator.Register(jane);
        mediator.Register(bob);

        // Відправляємо повідомлення від одного з колег
        john.Send("Hey, guys! Let's meet in the library.");
    }
}