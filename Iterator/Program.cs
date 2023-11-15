using System;
using System.Collections;

// Інтерфейс ітератора
interface IIterator
{
    bool HasNext();
    object Next();
}

// Інтерфейс агрегата
interface ICourseCollection
{
    IIterator CreateIterator();
}

// Конкретний ітератор
class CourseIterator : IIterator
{
    private CourseCollection collection;
    private int currentIndex = 0;

    public CourseIterator(CourseCollection collection)
    {
        this.collection = collection;
    }

    public bool HasNext()
    {
        return currentIndex < collection.Count;
    }

    public object Next()
    {
        if (HasNext())
        {
            object course = collection[currentIndex];
            currentIndex++;
            return course;
        }
        else
        {
            return null;
        }
    }
}

// Конкретний агрегат
class CourseCollection : ICourseCollection
{
    private ArrayList courses = new ArrayList();

    public void AddCourse(string courseName)
    {
        courses.Add(courseName);
    }

    public int Count
    {
        get { return courses.Count; }
    }

    public object this[int index]
    {
        get { return courses[index]; }
    }

    public IIterator CreateIterator()
    {
        return new CourseIterator(this);
    }
}

class Program
{
    static void Main()
    {
        // Створюємо колекцію курсів
        CourseCollection courseCollection = new CourseCollection();
        courseCollection.AddCourse("Mathematics");
        courseCollection.AddCourse("Physics");
        courseCollection.AddCourse("Computer Science");

        // Створюємо ітератор і перебираємо курси
        IIterator iterator = courseCollection.CreateIterator();
        while (iterator.HasNext())
        {
            string courseName = (string)iterator.Next();
            Console.WriteLine($"Enrolled in course: {courseName}");
        }
    }
}