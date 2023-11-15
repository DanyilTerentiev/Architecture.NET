using Lab5;

public class WeekSchedule
{
    public Schedule? Monday { get; set; }

    public Schedule? Tuesday { get; set; }
    
    public Schedule? Wednesday { get; set; }

    public Schedule? Thursday { get; set; }

    public Schedule? Friday { get; set; }

    public Schedule? Saturday { get; set; }

    public override string ToString()
    {
        return $"Monday: {Monday}\n, Tuesday: {Tuesday}, Wednesday: {Wednesday}, Thursday: {Thursday}, Friday: {Friday}, Saturday: {Saturday}";
    }
}