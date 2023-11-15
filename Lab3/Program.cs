namespace Lab3.FactoryMethod
{
    public interface IUniversityAttendee
    {
        void Visit();
    }

    public class Lecturer : IUniversityAttendee
    {
        public void Visit()
        {
            Console.WriteLine("I'm visiting the university by car");
        }
    }

    public class Student : IUniversityAttendee
    {
        public void Visit()
        {
            Console.WriteLine("Ohh, I'm soo poor, can't afford any car");
        }
    }

    public abstract class AttendeeFactory
    {
        public abstract IUniversityAttendee CreateAttendee();
    }

    public sealed class LecturerAttendeeFactory : AttendeeFactory
    {
        public override IUniversityAttendee CreateAttendee()
        {
            return new Lecturer();
        }
    }

    public sealed class StudentAttendeeFactory : AttendeeFactory
    {
        public override IUniversityAttendee CreateAttendee()
        {
            return new Student();
        }
    }

    public class Client
    {
        public void Main()
        {
            Console.WriteLine("Lecturer creation");
            ClientCode(new LecturerAttendeeFactory());

            Console.WriteLine();

            Console.WriteLine("Student creation");
            ClientCode(new StudentAttendeeFactory());
        }

        public void ClientCode(AttendeeFactory attendeeFactory)
        {
            Console.WriteLine("I'm not aware what is creating right now, but I definitely know that is a factory");
            attendeeFactory.CreateAttendee().Visit();
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            new Client().Main();
        }
    }
}

