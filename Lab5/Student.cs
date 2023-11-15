public class Student
{
    public string Name { get; set; } = null!;

    public int Age { get; set; }

    public int Course { get; set; }

    public WeekSchedule WeekSchedule { get; set; }

    public override string ToString()
    {
        return $"Name: {Name}, Age: {Age}, Course: {Course}, WeekSchedule: {WeekSchedule}";
    }
}