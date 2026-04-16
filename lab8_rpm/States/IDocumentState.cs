using lab8_rpm.Documents;

namespace lab8_rpm.States;

public interface IDocumentState
{
    string Name { get; }

    void Print(Document document);
    void AddToQueue(Document document);
    void CompletePrinting(Document document);
    void FailPrinting(Document document);
    void Reset(Document document);
}
