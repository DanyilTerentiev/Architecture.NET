// var marketPlace = new MarketPlace();
//
// marketPlace.ProductReceived();
//
// marketPlace.ProductReleased();
// class ProviderCommunication
// {
//     public void Receive() => Console.WriteLine("Received product from producer");
//
//     public void Payment() => Console.WriteLine("Payment method with the producer");
// }
//
// class Site
// {
//     public void Placement() => Console.WriteLine("Placement on the site");
//
//     public void Delete() => Console.WriteLine("Deleted from the site");
// }
//
// class Database
// {
//     public void Insert() => Console.WriteLine("Inserted row into the db");
//
//     public void Delete() => Console.WriteLine("Deleted row from the database");
// }
//
// class MarketPlace
// {
//     private readonly ProviderCommunication _providerCommunication = new();
//
//     private readonly Site _site = new();
//
//     private readonly Database _database = new();
//
//     public void ProductReceived()
//     {
//         _providerCommunication.Receive();
//         _site.Placement();
//         _database.Insert();
//     }
//
//     public void ProductReleased()
//     {
//         _providerCommunication.Payment();
//         _site.Delete();
//         _database.Delete();
//     }
// }

var facade = new Facade();
var student = new Person{ Name = "Danya Pupkin", Age = 20 };
var university = new University{ Name = "Bursa", Rating = 1};
facade.EnrollInUniversity(university, student);

class Person
{
    public string Name { get; set; } = null!;

    public int Age { get; set; }
}

class Database
{
    public void InsertRow(Person person) =>
        Console.WriteLine($"{person.Name} with age: {person.Age} was inserted into db");
    
    public void DeleteRow(Person person) =>
        Console.WriteLine($"{person.Name} with age: {person.Age} was deleted from db");
}

class University
{
    public string Name { get; set; }

    public int Rating { get; set; }
}

class Site
{
    public void LeaveRequest(string university, string name) =>
        Console.WriteLine($"Your request will be reviewed for this university: {university}");
}

class Facade
{
    private Database _database = new Database();

    private Site _site = new Site();
    
    public void EnrollInUniversity(University university, Person person)
    {
        _site.LeaveRequest(university.Name, person.Name);
        
        _database.InsertRow(person);
        
        Console.WriteLine($"You, {person.Name}, are enrolled in the {university.Name}");
    }
}