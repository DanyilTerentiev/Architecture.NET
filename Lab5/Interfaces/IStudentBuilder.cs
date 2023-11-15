namespace Lab5.Interfaces;

public interface IStudentBuilder
{
    IStudentBuilder Reset();

    IStudentBuilder WithName(string name);

    IStudentBuilder WithAge(int age);

    IStudentBuilder WithCourse(int course);

    IStudentBuilder WithWeekSchedule (Action<WeekScheduleBuilder> buildAction);

    Student Build();
}