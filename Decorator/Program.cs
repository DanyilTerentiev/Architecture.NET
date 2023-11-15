// using System.Text;
//
// var universitySystem = new UniversitySystem();
//
// var logging = new LoggingUniversitySystemDecorator(universitySystem);
//
// await logging.AddStudentToDb("Danya");
//
// var data = File.ReadAllText("mydb.txt");
//
// Console.WriteLine(data);
//
// interface IUniversitySystem
// {
//     Task AddStudentToDb(string studentName);
//
//     Task RemoveStudentFromDb(string studentName);
// }
//
// class UniversitySystem : IUniversitySystem
// {
//     private readonly string _path = "mydb.txt";
//     
//     public async Task AddStudentToDb(string studentName)
//     {
//         if(!File.Exists(_path)) 
//             File.Create(_path);
//         
//         await File.AppendAllTextAsync(_path, studentName + Environment.NewLine);
//     }
//
//     public async Task RemoveStudentFromDb(string studentName)
//     {
//         var content = await File.ReadAllLinesAsync(_path);
//
//         var newContent = content.Where(s => !s.Contains(studentName));
//
//         await File.WriteAllLinesAsync(_path, newContent);
//     }
// }
//
// class LoggingUniversitySystemDecorator : IUniversitySystem
// {
//     private readonly IUniversitySystem _universitySystem;
//
//     private string _path = "logging.txt";
//     
//     public LoggingUniversitySystemDecorator(IUniversitySystem universitySystem)
//     {
//         _universitySystem = universitySystem;
//     }
//
//     public async Task AddStudentToDb(string studentName)
//     {
//         string contents = $"{DateTime.Now.ToShortTimeString()}, {studentName} was added to the db" + Environment.NewLine;
//         await File.AppendAllTextAsync(_path, contents);
//         Console.WriteLine(contents);
//         await _universitySystem.AddStudentToDb(studentName);
//     }
//
//     public async Task RemoveStudentFromDb(string studentName)
//     {
//         await File.AppendAllTextAsync(_path, $"{DateTime.Now.ToShortTimeString()}, {studentName} was removed from the db" + Environment.NewLine);
//         
//         await _universitySystem.RemoveStudentFromDb(studentName);
//     }
// }
//
// class EncodingSystemDecorator : IUniversitySystem 
// {
//     private readonly IUniversitySystem _universitySystem;
//     
//     public EncodingSystemDecorator(IUniversitySystem universitySystem)
//     {
//         _universitySystem = universitySystem;
//     }
//
//     public async Task AddStudentToDb(string studentName)
//     {
//         var textBytes = Encoding.UTF8.GetBytes(studentName);
//
//         var base64String = Convert.ToBase64String(textBytes);
//         await _universitySystem.AddStudentToDb(base64String);
//     }
//
//     public async Task RemoveStudentFromDb(string studentName)
//     {
//         var textBytes = Encoding.UTF8.GetBytes(studentName);
//
//         var base64String = Convert.ToBase64String(textBytes);
//         await _universitySystem.RemoveStudentFromDb(base64String);
//     }
// }

// Console.WriteLine("Hello to the university service!\nEnter, please, student which you want to ");

var student = new Student { Name = "Dmytro Hutsuliak", Email = "dima@gmail.com", Phone = "0505555555" };

var uniS = new UniversityService();

var factory = new UniversityServiceFactory(uniS);

var expected = factory.CreateService(ServiceType.Combined);

expected.DropOff(student);

enum ServiceType
{
    Plain, Phone, Email, Combined
}

class Student
{
    public string Name { get; set; } = string.Empty;

    public string Phone { get; set; } = string.Empty;

    public string Email { get; set; } = string.Empty;
}

interface IDropOffUniversity
{
    void DropOff(Student student);
}

class UniversityService : IDropOffUniversity
{
    public void DropOff(Student student)
    {
        Console.WriteLine(student.Name + " was dropped off");
    }
}

class UniversityServiceMessagingDecorator : IDropOffUniversity
{
    private readonly IDropOffUniversity _dropOffUniversity;

    public UniversityServiceMessagingDecorator(IDropOffUniversity dropOffUniversity)
    {
        _dropOffUniversity = dropOffUniversity;
    }

    public void DropOff(Student student)
    {
        Console.WriteLine($"Sent message via phone: {student.Phone}");
        _dropOffUniversity.DropOff(student);
    }
}

class UniversityServiceEmailDecorator : IDropOffUniversity
{
    private readonly IDropOffUniversity _dropOffUniversity;

    public UniversityServiceEmailDecorator(IDropOffUniversity dropOffUniversity)
    {
        _dropOffUniversity = dropOffUniversity;
    }

    public void DropOff(Student student)
    {
        Console.WriteLine($"Sent message via email: {student.Email}");
        _dropOffUniversity.DropOff(student);
    }
}

class UniversityServiceFactory
{
    private readonly UniversityService _universityService;

    public UniversityServiceFactory(UniversityService universityService)
    {
        _universityService = universityService;
    }

    public IDropOffUniversity CreateService(ServiceType type)
    {
        IDropOffUniversity service;

        switch (type)
        {
            case ServiceType.Plain:
                service = _universityService;
                break;
            case ServiceType.Phone:
                service = new UniversityServiceMessagingDecorator(_universityService);
                break;
            case ServiceType.Email:
                service = new UniversityServiceEmailDecorator(_universityService);
                break;
            case ServiceType.Combined:
                service = new UniversityServiceEmailDecorator(new UniversityServiceMessagingDecorator(_universityService));
                break;
            default:
                throw new ArgumentOutOfRangeException(nameof(type), type, "Invalid service type");
        }

        return service;
    }
}

// interface IAddScores
// {
//     double AddScore(Student student, double scores);
// }
//
// class UniversityService : IAddScores
// {
//     public double AddScore(Student student, double scores)
//     {
//         Console.WriteLine($"{student.Name} received {scores}");
//         student.TotalScore += scores;
//
//     }
// }