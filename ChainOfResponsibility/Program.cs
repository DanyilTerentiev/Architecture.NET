using System;

// Інтерфейс обробника
interface IRequestHandler
{
    void HandleRequest(int request);
    void SetSuccessor(IRequestHandler successor); // Додано метод для встановлення наступника
}

// Конкретний обробник
class ConcreteHandler : IRequestHandler
{
    private IRequestHandler successor;
    private int threshold;

    public ConcreteHandler(int threshold)
    {
        this.threshold = threshold;
    }

    public void SetSuccessor(IRequestHandler successor)
    {
        this.successor = successor;
    }

    public void HandleRequest(int request)
    {
        if (request <= threshold)
        {
            // Обробити запит
            Console.WriteLine($"Запит {request} оброблено ConcreteHandler з порогом {threshold}");
        }
        else if (successor != null)
        {
            // Передати запит наступному обробнику в ланцюжку
            successor.HandleRequest(request);
        }
    }
}

// Клієнтський клас
class Client
{
    static void Main()
    {
        // Створюємо обробники
        IRequestHandler handler1 = new ConcreteHandler(10);
        IRequestHandler handler2 = new ConcreteHandler(20);
        IRequestHandler handler3 = new ConcreteHandler(30);

        // Встановлюємо порядок у ланцюжку
        handler1.SetSuccessor(handler2);
        handler2.SetSuccessor(handler3);

        // Передаємо запит по ланцюжку, починаючи з першого обробника
        handler1.HandleRequest(25);
    }
}
