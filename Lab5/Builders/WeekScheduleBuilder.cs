using Lab5;
using Lab5.Interfaces;

public class WeekScheduleBuilder : IWeekScheduleBuilder
{
    private WeekSchedule _weekSchedule = new();
    
    public IWeekScheduleBuilder Reset()
    {
        _weekSchedule = new WeekSchedule();
        return this;
    }

    public IWeekScheduleBuilder WithMonday(Schedule schedule)
    {
        _weekSchedule.Monday = schedule;
        return this;
    }

    public IWeekScheduleBuilder WithTuesday(Schedule schedule)
    {
        _weekSchedule.Tuesday = schedule;
        return this;    
    }

    public IWeekScheduleBuilder WithWednesday(Schedule schedule)
    {
        _weekSchedule.Wednesday = schedule;
        return this;
    }

    public IWeekScheduleBuilder WithThursday(Schedule schedule)
    {
        _weekSchedule.Thursday = schedule;
        return this;
    }

    public IWeekScheduleBuilder WithFriday(Schedule schedule)
    {
        _weekSchedule.Friday = schedule;
        return this;
    }

    public IWeekScheduleBuilder WithSaturday(Schedule schedule)
    {
        _weekSchedule.Saturday = schedule;
        return this;
    }

    public WeekSchedule Build()
    {
        return _weekSchedule;
    }
}