namespace Lab5.Interfaces;

public interface IWeekScheduleBuilder
{
    IWeekScheduleBuilder Reset();

    WeekSchedule Build();

    IWeekScheduleBuilder WithMonday(Schedule schedule);

    IWeekScheduleBuilder WithTuesday(Schedule schedule);

    IWeekScheduleBuilder WithWednesday(Schedule schedule);
    
    IWeekScheduleBuilder WithThursday(Schedule schedule);

    IWeekScheduleBuilder WithFriday(Schedule schedule);

    IWeekScheduleBuilder WithSaturday(Schedule schedule);
}