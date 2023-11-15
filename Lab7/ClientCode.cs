using Lab7.Adapter;
using Lab7.MyCode;
using Lab7.ThirdPartyLibrary;

var ukrStudent = new UkrainianStudent { FirstName = "Danyil", LastName = "Terentiev", Age = 19, Grade = 100 };
var internationalDep = new InternationalRelationsDepartment();
/* Problem
Cannot do so, cause our grade does not fit to the department method

internationalDep.EnrollInUniversity("Berlin Universität", ukrStudent.Grade); */

/* Solution
Creation of an adapter which converts grade into readable format for a department */
IDepartmentAdapter adapter = new DepartmentAdapter(internationalDep);

adapter.EnrollInUniversity("Berlin Universität", ukrStudent);
