using Lab7.MyCode;
using Lab7.ThirdPartyLibrary;

namespace Lab7.Adapter;

public class DepartmentAdapter : IDepartmentAdapter
{
    private readonly Dictionary<Func<int, bool>, string> _gradeDictionary = new()
    {
        { grade => grade >= 90, "A" },
        { grade => grade >= 80, "B" },
        { grade => grade >= 70, "C" },
        { grade => grade >= 60, "D" },
        { grade => grade >= 50, "E" },
        { grade => grade < 50, "F" },
    };
    
    private readonly InternationalRelationsDepartment _internationalRelationsDepartment;

    public DepartmentAdapter(InternationalRelationsDepartment internationalRelationsDepartment)
    {
        _internationalRelationsDepartment = internationalRelationsDepartment;
    }

    public void EnrollInUniversity(string universityName, UkrainianStudent ukrainianStudent)
    {
        var convertedGrade = _gradeDictionary.FirstOrDefault(pair => pair.Key(ukrainianStudent.Grade)).Value;
        if (convertedGrade != null)
        {
            var intSt = new InternationalStudent(ukrainianStudent.FirstName, ukrainianStudent.LastName,
                ukrainianStudent.Age, convertedGrade);
                
            _internationalRelationsDepartment.EnrollInUniversity(universityName, intSt);
        }
    }
}