using System;

// Контекст (Context)
class Student
{
    private State currentState;

    public Student()
    {
        // Початковий стан - звичайний студент
        currentState = new RegularState();
    }

    public void SetState(State state)
    {
        currentState = state;
    }

    public void Study()
    {
        currentState.Study(this);
    }

    public void Relax()
    {
        currentState.Relax(this);
    }
}

// Інтерфейс стану
interface State
{
    void Study(Student student);
    void Relax(Student student);
}

// Конкретний стан - звичайний студент
class RegularState : State
{
    public void Study(Student student)
    {
        Console.WriteLine("Студент вивчає матеріал.");
    }

    public void Relax(Student student)
    {
        Console.WriteLine("Студент відпочиває.");
    }
}

// Конкретний стан - студент на екзамені
class ExamState : State
{
    public void Study(Student student)
    {
        Console.WriteLine("Студент наполегливо вивчає для екзамену.");
    }

    public void Relax(Student student)
    {
        Console.WriteLine("Студент занадто напружений, щоб відпочивати.");
    }
}

class Program
{
    static void Main()
    {
        // Створюємо студента
        Student student = new Student();

        // Студент вивчає та відпочиває в звичайному стані
        student.Study();
        student.Relax();

        // Змінюємо стан на екзаменаційний
        student.SetState(new ExamState());

        // Студент вивчає та відпочиває в екзаменаційному стані
        student.Study();
        student.Relax();
    }
}