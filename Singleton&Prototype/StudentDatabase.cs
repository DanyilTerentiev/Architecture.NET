namespace UniversityManagmentSingleton;

public class StudentDatabase
{
    private List<Student> _students;

    private static StudentDatabase _instance = null!;
    
    private StudentDatabase()
    {
        _students = new List<Student>();
    }

    public static StudentDatabase GetInstance
    {
        get
        {
            if (_instance is null)
            {
                _instance = new StudentDatabase();
            }

            return _instance;
        }
    }

    public void AddStudent(Student student)
    {
        _students.Add(student);
    }

    public List<Student> GetAllStudents()
    {
        return _students;
    }
}