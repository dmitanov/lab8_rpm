using System;
using System.Collections.Generic;
using System.Text;
using lab8_rpm.Documents;

namespace lab8_rpm.Core
{
    public interface IMediator
    {
        void Notify(Colleague sender, string ev, Document? document = null);
    }
}
