using lab8_rpm.Documents;

namespace lab8_rpm.States;

public class ErrorState : IDocumentState
{
    public string Name => "Error";

    public void Print(Document document)
    {
        Console.WriteLine("[FSM: Error] Печать невозможна. Сначала выполните Reset().");
    }

    public void AddToQueue(Document document)
    {
        Console.WriteLine("[FSM: Error] Нельзя добавить в очередь. Сначала выполните Reset().");
    }

    public void CompletePrinting(Document document)
    {
        Console.WriteLine("[FSM: Error] Ошибка не устранена.");
    }

    public void FailPrinting(Document document)
    {
        Console.WriteLine("[FSM: Error] Документ уже находится в состоянии ошибки.");
    }

    public void Reset(Document document)
    {
        document.SetState(new NewState());
        Console.WriteLine("[FSM: Error -> New] Документ сброшен и снова готов к печати.");
    }
}