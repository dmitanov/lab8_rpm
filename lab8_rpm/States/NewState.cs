using lab8_rpm.Documents;

namespace lab8_rpm.States;

public class NewState : IDocumentState
{
    public string Name => "New";

    public void Print(Document document)
    {
        document.NotifyMediator("RequestPrint");
    }

    public void AddToQueue(Document document)
    {
        document.NotifyMediator("AddToQueue");
    }

    public void CompletePrinting(Document document)
    {
        Console.WriteLine("[FSM: New] Нельзя завершить печать: документ еще не печатался.");
    }

    public void FailPrinting(Document document)
    {
        Console.WriteLine("[FSM: New] Нельзя получить ошибку печати: печать еще не начиналась.");
    }

    public void Reset(Document document)
    {
        Console.WriteLine("[FSM: New] Сброс не нужен: документ уже в состоянии New.");
    }
}
