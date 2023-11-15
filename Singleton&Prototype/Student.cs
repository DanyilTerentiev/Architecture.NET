namespace UniversityManagmentSingleton;

public class Student
{
    public string Name { get; set; } = null!;

    public string Surname { get; set; } = null!;

    public decimal Age { get; set; }

    public int Course { get; set; }

    public ICollection<Subject> Subjects { get; set; } = null!;

    // Base implementation of C# Clone
    public Student ShallowCopy()
    {
        return (Student) MemberwiseClone();
    }

    // My implementation
    public Student DeepCopy()
    {
        Student student = new Student
            { Name = Name, Surname = Surname, Age = Age, Course = Course };
        
        if (Subjects == null) return student;
        
        var subjects = new List<Subject>();
        
        foreach (var subject in Subjects)
        {
            subjects.Add(subject.DeepCopy());
        }
        
        student.Subjects = subjects;

        return student;
    }

    public override string ToString()
    {
        var result =  $"{nameof(Name)}: {Name}, {nameof(Surname)}: {Surname}, {nameof(Age)}: {Age}, {nameof(Course)}: {Course}, {nameof(Subjects)}:";

        if (Subjects == null) return result;
        foreach (var subject in Subjects)
        {
            result += subject.ToString();
        }

        return result;
    }
}