using UniversityManagmentSingleton;

// Subject instance
var subjects = new List<Subject> { new Subject() { Name = "Architecture", Mark = 100 } };

// Creation of first instance of Singleton Database
var studentDb = StudentDatabase.GetInstance;

var firstStudent = new Student() { Name = "Danyil", Surname = "Terentiev", Age = 19, Course = 3, Subjects = subjects };
var secondStudent = new Student() { Name = "Maksym", Surname = "Proskurniak", Age = 20, Course = 3, Subjects = subjects };

studentDb.AddStudent(firstStudent);

// Second instance even though that is the same object reference
var studentDb2 = StudentDatabase.GetInstance;
studentDb2.AddStudent(secondStudent);

// Check whether the studentDb2 has two records of students
foreach (var s in studentDb2.GetAllStudents())
{
    Console.WriteLine(s.ToString());
}

// Prototype Pattern
//Creating thirdStudent by using DeepCopy method
var thirdStudent = firstStudent.DeepCopy();
// Altering subject object
thirdStudent.Subjects.First().Name = "JAVA YIKES!!!";

Console.WriteLine($"First student - {firstStudent}");

Console.WriteLine($"Third student - {thirdStudent}");


