// First approach Object adapter


// IEmployeeService empService = new EmployeeService();
// var employees = empService.GetEmployees();
// IAnalyticsService analService = new AnalyticsService();
// analService.GenerateReport(employees); - Compilation error


// IEmployeeService employeeService = new EmployeeService();
// IAnalyticsAdapter adapter = new AnalyticsAdapter();
//
// adapter.ProcessEmployees(employeeService.GetEmployees());
// target interface
// public interface IAnalyticsAdapter
// {
//     void ProcessEmployees(List<Employee> employees);
// }

// adapter
// public class AnalyticsAdapter : IAnalyticsAdapter
// {
//     // Reference to the adaptee interface or class
//     private readonly IAnalyticsService _analyticsService;
//  
//     public AnalyticsAdapter(IAnalyticsService analyticsService)
//     {
//         _analyticsService = analyticsService;
//     } 
//     public void ProcessEmployees(List<Employee> employees)
//     {
//         var json = System.Text.Json.JsonSerializer.Serialize(employees);
//  
//         _analyticsService.GenerateReport(json);
//     }
// }

// Second approach - Class adapter

// public class AnalyticsAdapter : AnalyticsService, IAnalyticsAdapter
// {
//     public void ProcessEmployees(List<Employee> employees)
//     {
//         var json = System.Text.Json.JsonSerializer.Serialize(employees);
//         
//         GenerateReport(json);
//     }
// }
//
// public class Employee
// {
//     public Employee(int id, string name, decimal salary)
//     {
//         Id = id;
//         Name = name;
//         Salary = salary;
//     }
//
//     public int Id { get; set; }
//
//     public string Name { get; set; }
//
//     public decimal Salary { get; set; }
// }
//
// public interface IEmployeeService
// {
//     List<Employee> GetEmployees();
// }
//
// public class EmployeeService : IEmployeeService
// {
//     public List<Employee> GetEmployees()
//     {
//         return new List<Employee>()
//         {
//             new Employee(1, "James", 20000),
//             new Employee(2, "Peter", 30000),
//             new Employee(3, "David", 40000),
//             new Employee(4, "George", 50000)
//         };
//     }
// }
//
// public interface IAnalyticsService
// {
//     void GenerateReport(string json);
// }
//
// public class AnalyticsService : IAnalyticsService
// {
//     public void GenerateReport(string json)
//     {
//         // Process json to generate report.
//     }
// }