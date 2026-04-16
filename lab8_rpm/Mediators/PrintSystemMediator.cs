using lab8_rpm.Components;
using lab8_rpm.Core;
using lab8_rpm.Documents;
using lab8_rpm.States;

namespace lab8_rpm.Mediators;

public class PrintSystemMediator : IMediator
{
    private readonly Printer _printer;
    private readonly PrintQueue _queue;
    private readonly Logger _logger;

    public PrintSystemMediator(
        Printer printer,
        PrintQueue queue,
        Logger logger,
        Dispatcher dispatcher)
    {
        _printer = printer;
        _queue = queue;
        _logger = logger;

        _printer.SetMediator(this);
        _queue.SetMediator(this);
        _logger.SetMediator(this);
        dispatcher.SetMediator(this);
    }

    public void Notify(Colleague sender, string ev, Document? document = null)
    {
        switch (ev)
        {
            case "AddToQueue":
                if (document == null) return;
                _queue.EnqueueItem(document);
                break;

            case "Enqueued":
                if (document == null) return;
                _logger.WriteMessage($"Документ '{document.Title}' помещен в очередь.");
                break;

            case "RequestPrint":
                if (document == null) return;
                document.SetState(new PrintingState());
                _logger.WriteMessage($"Начата печать '{document.Title}'.");
                _printer.StartPrint(document);
                break;

            case "ProcessQueue":
                if (_queue.IsEmpty)
                {
                    _logger.WriteMessage("Очередь пуста.");
                    return;
                }

                var nextDoc = _queue.DequeueItem();
                nextDoc.SetMediator(this);
                nextDoc.Print();
                break;

            case "PrintSuccess":
                if (document == null) return;
                document.CompletePrinting();
                _logger.WriteMessage($"Успешно напечатан '{document.Title}'.");
                break;

            case "PrintFailed":
                if (document == null) return;
                document.FailPrinting();
                _logger.WriteMessage($"ОШИБКА печати '{document.Title}'.");
                break;

            case "RepairPrinter":
                _printer.Repair();
                _logger.WriteMessage("Принтер отремонтирован.");
                break;

            case "FailThisDocument":
                if (document == null) return;
                _printer.SetFailureForDocument(document.Title);
                _logger.WriteMessage($"Для документа '{document.Title}' будет сымитирована ошибка печати.");
                break;

            default:
                _logger.WriteMessage($"Неизвестное событие: {ev}");
                break;
        }
    }
}