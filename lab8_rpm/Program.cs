using lab8_rpm.Components;
using lab8_rpm.Documents;
using lab8_rpm.Mediators;

namespace lab8_rpm;

internal class Program
{
    static void Main(string[] args)
    {
        var printer = new Printer();
        var queue = new PrintQueue();
        var logger = new Logger();
        var dispatcher = new Dispatcher();

        var mediator = new PrintSystemMediator(printer, queue, logger, dispatcher);

        var doc1 = new Document("Отчет");
        var doc2 = new Document("Договор");
        var doc3 = new Document("Счет");

        Console.WriteLine("===== ДОБАВЛЕНИЕ ДОКУМЕНТОВ =====");
        dispatcher.AddDocument(doc1);
        dispatcher.AddDocument(doc2);

        Console.WriteLine();
        Console.WriteLine("===== СЦЕНАРИЙ 1: УСПЕШНАЯ ПЕЧАТЬ =====");
        dispatcher.ProcessQueue();

        Console.WriteLine();
        Console.WriteLine("===== СЦЕНАРИЙ 2: ОШИБКА ПРИНТЕРА И ВОССТАНОВЛЕНИЕ =====");
        dispatcher.ConfigureFailureFor(doc2);
        dispatcher.ProcessQueue();

        Console.WriteLine();
        Console.WriteLine("Пробуем снова добавить документ с ошибкой в очередь:");
        doc2.AddToQueue();

        Console.WriteLine();
        Console.WriteLine("Чиним принтер и сбрасываем документ:");
        dispatcher.RepairPrinter();
        doc2.Reset();

        Console.WriteLine();
        Console.WriteLine("Повторно отправляем документ на печать:");
        dispatcher.AddDocument(doc2);
        dispatcher.ProcessQueue();

        Console.WriteLine();
        Console.WriteLine("===== СЦЕНАРИЙ 3: ПРОВЕРКА ФИНАЛЬНОГО СОСТОЯНИЯ =====");
        dispatcher.AddDocument(doc3);
        dispatcher.ProcessQueue();

        Console.WriteLine();
        Console.WriteLine("Пробуем заново напечатать уже готовый документ:");
        doc3.Print();

        Console.WriteLine();
        Console.WriteLine("Пробуем добавить уже готовый документ в очередь:");
        doc3.AddToQueue();

        Console.WriteLine();
        Console.WriteLine("===== ИТОГОВЫЕ СОСТОЯНИЯ =====");
        Console.WriteLine($"{doc1.Title} -> {doc1.CurrentState}");
        Console.WriteLine($"{doc2.Title} -> {doc2.CurrentState}");
        Console.WriteLine($"{doc3.Title} -> {doc3.CurrentState}");
    }
}