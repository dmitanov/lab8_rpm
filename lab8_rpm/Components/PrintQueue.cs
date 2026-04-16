using lab8_rpm.Core;
using System;
using System.Collections.Generic;
using System.Text;
using lab8_rpm.Documents;

namespace lab8_rpm.Components
{
    public class PrintQueue : Colleague
    {
        private readonly Queue<Document> _items = new();

        public bool IsEmpty => _items.Count == 0;
        public int Count => _items.Count;

        public void EnqueueItem(Document document)
        {
            _items.Enqueue(document);
            GetMediatorOrThrow().Notify(this, "Enqueued", document);
        }

        public Document DequeueItem()
        {
            if (IsEmpty)
                throw new InvalidOperationException("Очередь пуста.");

            return _items.Dequeue();
        }
    }
}
