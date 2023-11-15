using Lab5.Interfaces;

namespace Lab5.Builders;

public class StudentBuilder : IStudentBuilder
{
    private Student _student = new Student();

    private readonly WeekScheduleBuilder _weekScheduleBuilder = new WeekScheduleBuilder();

    public IStudentBuilder Reset()
    {
        _student = new Student();
        return this;
    }

    public IStudentBuilder WithName(string name)
    {
        _student.Name = name;
        return this;
    }

    public IStudentBuilder WithAge(int age)
    {
        _student.Age = age;
        return this;
    }

    public IStudentBuilder WithCourse(int course)
    {
        _student.Course = course;
        return this;
    }

    public IStudentBuilder WithWeekSchedule(Action<WeekScheduleBuilder> buildAction)
    {
        buildAction(_weekScheduleBuilder);
        _student.WeekSchedule = _weekScheduleBuilder.Build();
        return this;
    }

    public Student Build()
    {
        return _student;
    }
}