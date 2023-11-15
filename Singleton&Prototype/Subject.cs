namespace UniversityManagmentSingleton;

public class Subject
{
    public string Name { get; set; }

    public int Mark { get; set; }

    public Subject DeepCopy()
    {
        return new Subject { Name = Name, Mark = Mark };
    }
    
    public override string ToString()
    {
        return $"\n{nameof(Name)}: {Name}, {nameof(Mark)}: {Mark}";
    }
}