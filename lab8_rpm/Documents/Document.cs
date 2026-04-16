using lab8_rpm.Core;
using lab8_rpm.States;

namespace lab8_rpm.Documents;

public class Document : Colleague
{
    public string Title { get; }
    private IDocumentState State { get; set; }

    public string CurrentState => State.Name;

    public Document(string title)
    {
        Title = title;
        State = new NewState();
    }

    public void SetState(IDocumentState state)
    {
        State = state;
    }

    public void NotifyMediator(string ev)
    {
        GetMediatorOrThrow().Notify(this, ev, this);
    }

    public void Print() => State.Print(this);
    public void AddToQueue() => State.AddToQueue(this);
    public void CompletePrinting() => State.CompletePrinting(this);
    public void FailPrinting() => State.FailPrinting(this);
    public void Reset() => State.Reset(this);
}
