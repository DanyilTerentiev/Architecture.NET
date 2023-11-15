namespace Lab7.ThirdPartyLibrary;

public class InternationalRelationsDepartment
{
    public void EnrollInUniversity(string universityName, InternationalStudent student)
    {
        if (student.Grade.ToLower() != "a")
        {
            Console.WriteLine("Sorry, but your score is not high enough to enrol on this course");
        }
        else
            Console.WriteLine("Congratulations, {1}! You are enrolled in a {0}", universityName, student.FirstName + " " + student.LastName);
    }
}