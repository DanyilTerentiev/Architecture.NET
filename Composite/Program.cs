using Composite;

var university = new University("Chnu");

var faculty = new Faculty("IFTKN");

var department = new Department("Software Development");
var faculty2 = new Faculty("German");
faculty2.Add(new Department("Germanistic"));
faculty.Add(department);

university.Add(faculty);

university.Add(faculty2);
university.Display();

namespace Composite
{
    public abstract class UniversityUnit
    {
        protected string Name { get; set; }

        public UniversityUnit(string name)
        {
            Name = name;
        }

        public abstract void Display();

        public abstract void Add(UniversityUnit unit);

        public abstract void Remove(UniversityUnit unit);
    }

    public class Department : UniversityUnit
    {
        public Department(string name) : base(name)
        {
        }

        public override void Display()
        {
            Console.WriteLine($"Department name: {Name}");
        }

        public override void Add(UniversityUnit unit)
        {
            Console.WriteLine("Cannot add any unit to the department");
        }

        public override void Remove(UniversityUnit unit)
        {
            Console.WriteLine("Cannot remove any unit from the department");
        }
    }

    public class University : UniversityUnit
    {
        private List<UniversityUnit> _universityUnits = new();
    
        public University(string name) : base(name)
        {
        }

        public override void Display()
        {
            Console.WriteLine($"University name: {Name}");

            foreach (var unit in _universityUnits)
            {
                unit.Display();
            }
        }

        public override void Add(UniversityUnit unit)
        {
            _universityUnits.Add(unit);
        }

        public override void Remove(UniversityUnit unit)
        {
            _universityUnits.Remove(unit);
        }
    }

    public class Faculty : UniversityUnit
    {
        private List<UniversityUnit> _universityUnits = new();
    
        public Faculty(string name) : base(name)
        {
        }

        public override void Display()
        {
            Console.WriteLine($"Faculty name: {Name}");
        
            foreach (var unit in _universityUnits)
            {
                unit.Display();
            }
        }

        public override void Add(UniversityUnit unit)
        {
            _universityUnits.Add(unit);
        }

        public override void Remove(UniversityUnit unit)
        {
            _universityUnits.Remove(unit);
        }
    }
}