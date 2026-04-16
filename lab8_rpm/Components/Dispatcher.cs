using lab8_rpm.Core;
using System;
using System.Collections.Generic;
using System.Text;
using lab8_rpm.Documents;

namespace lab8_rpm.Components
{
    public class Dispatcher : Colleague
    {
        public void AddDocument(Document document)
        {
            document.SetMediator(GetMediatorOrThrow());
            document.AddToQueue();
        }

        public void ProcessQueue()
        {
            GetMediatorOrThrow().Notify(this, "ProcessQueue");
        }

        public void ConfigureFailureFor(Document document)
        {
            GetMediatorOrThrow().Notify(this, "FailThisDocument", document);
        }

        public void RepairPrinter()
        {
            GetMediatorOrThrow().Notify(this, "RepairPrinter");
        }
    }
}
