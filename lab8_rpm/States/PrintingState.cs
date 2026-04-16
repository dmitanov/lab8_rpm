using lab8_rpm.Documents;

namespace lab8_rpm.States;

public class PrintingState : IDocumentState
{
    public string Name => "Printing";

    public void Print(Document document)
    {
        Console.WriteLine("[FSM: Printing] Документ уже печатается.");
    }

    public void AddToQueue(Document document)
    {
        Console.WriteLine("[FSM: Printing] Нельзя добавить документ в очередь повторно, он уже печатается.");
    }

    public void CompletePrinting(Document document)
    {
        document.SetState(new DoneState());
        Console.WriteLine("[FSM: Printing -> Done] Документ успешно напечатан.");
    }

    public void FailPrinting(Document document)
    {
        document.SetState(new ErrorState());
        Console.WriteLine("[FSM: Printing -> Error] Во время печати произошла ошибка.");
    }

    public void Reset(Document document)
    {
        Console.WriteLine("[FSM: Printing] Нельзя сбросить документ во время печати.");
    }
}