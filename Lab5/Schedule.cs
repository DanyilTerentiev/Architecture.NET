namespace Lab5;

public class Schedule
{
    public string First { get; set; } = null!;

    public string Second { get; set; } = null!;

    public string Third { get; set; } = null!;

    public string Fourth { get; set; } = null!;

    public string Fifth { get; set; } = null!;

    public override string ToString()
    {
        return $"First: {First}, Second: {Second}, Third: {Third}, Fourth: {Fourth}, Fifth: {Fifth}";
    }
}

