using Lab5;
using Lab5.Builders;

var student = new StudentBuilder()
    .WithCourse(3)
    .WithAge(19)
    .WithName("Danyil Terentiev")
    .WithWeekSchedule(builder =>
    {
        builder.WithMonday(new Schedule() { First = "Math", Second = "Architecture" });
        builder.WithTuesday(new Schedule() { Fourth = ".NET development" });
        builder.WithTuesday(new Schedule() { Second = "History" });
    })
    .Build();

Console.WriteLine(student);