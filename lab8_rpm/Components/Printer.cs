using lab8_rpm.Core;
using System;
using System.Collections.Generic;
using System.Text;
using lab8_rpm.Documents;

namespace lab8_rpm.Components
{
    public class Printer : Colleague
    {
        private readonly HashSet<string> _failForDocuments = new(StringComparer.OrdinalIgnoreCase);
        private bool _isBroken;

        public void SetFailureForDocument(string title)
        {
            _failForDocuments.Add(title);
        }

        public void Repair()
        {
            _isBroken = false;
            Console.WriteLine("[Принтер] Принтер починен и готов к работе.");
        }

        public void StartPrint(Document document)
        {
            if (_failForDocuments.Contains(document.Title))
            {
                _isBroken = true;
            }

            Console.WriteLine($"[Принтер] Физическая печать '{document.Title}'...");

            if (_isBroken)
            {
                Console.WriteLine("[Принтер] Произошла ошибка печати.");
                _failForDocuments.Remove(document.Title);
                GetMediatorOrThrow().Notify(this, "PrintFailed", document);
            }
            else
            {
                GetMediatorOrThrow().Notify(this, "PrintSuccess", document);
            }
        }
    }
}
