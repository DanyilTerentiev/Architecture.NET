using System;

// Контекст (Context)
class Student
{
    private IStudyStrategy studyStrategy;

    public Student(IStudyStrategy strategy)
    {
        studyStrategy = strategy;
    }

    public void SetStudyStrategy(IStudyStrategy strategy)
    {
        studyStrategy = strategy;
    }

    public void Study()
    {
        studyStrategy.Study();
    }
}

// Інтерфейс стратегії
interface IStudyStrategy
{
    void Study();
}

// Конкретна стратегія - вивчення за підручником
class TextbookStrategy : IStudyStrategy
{
    public void Study()
    {
        Console.WriteLine("Студент вивчає матеріал з підручника.");
    }
}

// Конкретна стратегія - вивчення відповідей
class CheatStrategy : IStudyStrategy
{
    public void Study()
    {
        Console.WriteLine("Студент вивчає відповіді.");
    }
}

class Program
{
    static void Main()
    {
        // Створюємо студента зі стратегією вивчення за підручником
        Student student = new Student(new TextbookStrategy());

        // Студент вивчає матеріал з підручника
        student.Study();

        // Змінюємо стратегію на вивчення відповідей
        student.SetStudyStrategy(new CheatStrategy());

        // Студент вивчає відповіді
        student.Study();
    }
}