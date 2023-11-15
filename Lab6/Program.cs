ObjectPool<Student> objPool = new ObjectPool<Student>();
    
Student obj = objPool.GetObject();
Console.WriteLine("First object assigned");
objPool.ReleaseObject(obj);
int count = objPool.Counter;
Console.WriteLine("First object released back into the pool");
Console.WriteLine("Current count of pool: " + count);
    
Student obj2 = objPool.GetObject() ;
Console.WriteLine("Second object assigned");
count = objPool.Counter;
Console.WriteLine("Current count of pool: " + count);
objPool.ReleaseObject(obj2);

public class ObjectPool<T> where T : new()
{
    private readonly List<T> _objectsList = new List<T>();

    public int Counter { get; private set; } = 0;
    
    private readonly int _maxObjects = 5;

    public T GetObject()
    {
        if (Counter > 0)
        {
            var objectItem = _objectsList[0];
            _objectsList.RemoveAt(0);
            Counter--;
            return objectItem;
        }

        T obj = new T();
        return obj;
    }

    public void ReleaseObject(T item)
    {
        if (Counter < _maxObjects)
        {
            _objectsList.Add(item);
            Counter++;
        }
    }
}

public class Student
{
    public string FirstName { get; set; } = null!;

    public string LastName { get; set; } = null!;

    public int Id { get; set; }
}