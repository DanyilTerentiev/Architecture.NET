using System;
using System.Collections.Generic;

// Інтерфейс спостерігача
interface IObserver
{
    void Update(string news);
}

// Конкретний спостерігач (студент)
class Student : IObserver
{
    public string Name { get; private set; }

    public Student(string name)
    {
        Name = name;
    }

    public void Update(string news)
    {
        Console.WriteLine($"{Name} received news: {news}");
    }
}

// Предмет подій (викладач)
class Professor
{
    private List<IObserver> observers = new List<IObserver>();

    public void AddObserver(IObserver observer)
    {
        observers.Add(observer);
    }

    public void RemoveObserver(IObserver observer)
    {
        observers.Remove(observer);
    }

    public void NotifyObservers(string news)
    {
        foreach (var observer in observers)
        {
            observer.Update(news);
        }
    }

    public void PublishNews(string news)
    {
        Console.WriteLine($"Professor publishes news: {news}");
        NotifyObservers(news);
    }
}

class Program
{
    static void Main()
    {
        // Створюємо викладача
        Professor professor = new Professor();

        // Створюємо студентів-спостерігачів
        Student john = new Student("John");
        Student jane = new Student("Jane");
        Student bob = new Student("Bob");

        // Додаємо студентів як спостерігачів
        professor.AddObserver(john);
        professor.AddObserver(jane);
        professor.AddObserver(bob);

        // Викладач публікує новини, і всі спостерігачі отримують їх
        professor.PublishNews("Midterm exams next week!");

        // Видаляємо студента Bob як спостерігача
        professor.RemoveObserver(bob);

        // Викладач публікує нові новини, і лише John і Jane отримують їх
        professor.PublishNews("Additional class on Friday!");

        // Виводимо повідомлення про події для перевірки
        Console.WriteLine("\nObserver pattern demonstration completed.");
    }
}