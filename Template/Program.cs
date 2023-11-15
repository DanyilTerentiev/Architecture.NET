namespace Template;

// Абстрактний клас, що визначає шаблонний метод
abstract class University
{
    // Шаблонний метод, який викликається для виконання деякого алгоритму
    public void Apply()
    {
        Console.WriteLine("1. Заповнення анкети.");
        Console.WriteLine("2. Оплата навчання.");
        AdditionalSteps();
        Console.WriteLine("4. Завершення процесу вступу.");
    }

    // Абстрактний метод, який повинен бути реалізований в конкретних класах-нащадках
    protected abstract void AdditionalSteps();
}

// Конкретний клас, що розширює шаблонний метод
class MedicalUniversity : University
{
    // Реалізація абстрактного методу
    protected override void AdditionalSteps()
    {
        Console.WriteLine("3. Проходження медичного огляду.");
    }
}

// Конкретний клас, що розширює шаблонний метод
class EngineeringUniversity : University
{
    // Реалізація абстрактного методу
    protected override void AdditionalSteps()
    {
        Console.WriteLine("3. Здача вступних іспитів з математики та фізики.");
    }
}

class Program
{
    static void Main()
    {
        // Вступ до медичного університету
        Console.WriteLine("Вступ до медичного університету:");
        University medicalUniversity = new MedicalUniversity();
        medicalUniversity.Apply();

        Console.WriteLine();

        // Вступ до технічного університету
        Console.WriteLine("Вступ до технічного університету:");
        University engineeringUniversity = new EngineeringUniversity();
        engineeringUniversity.Apply();
    }
}