using lab8_rpm.Documents;

namespace lab8_rpm.States;

public class DoneState : IDocumentState
{
    public string Name => "Done";

    public void Print(Document document)
    {
        Console.WriteLine("[FSM: Done] Документ уже напечатан. Это финальное состояние.");
    }

    public void AddToQueue(Document document)
    {
        Console.WriteLine("[FSM: Done] Нельзя добавить в очередь: документ уже напечатан.");
    }

    public void CompletePrinting(Document document)
    {
        Console.WriteLine("[FSM: Done] Печать уже завершена.");
    }

    public void FailPrinting(Document document)
    {
        Console.WriteLine("[FSM: Done] Ошибка невозможна: документ уже успешно напечатан.");
    }

    public void Reset(Document document)
    {
        Console.WriteLine("[FSM: Done] Сброс невозможен: состояние финальное.");
    }
}
