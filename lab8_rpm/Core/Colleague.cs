using System;
using System.Collections.Generic;
using System.Text;

namespace lab8_rpm.Core
{
    public abstract class Colleague
    {
        protected IMediator? Mediator;

        public void SetMediator(IMediator mediator)
        {
            Mediator = mediator;
        }

        protected IMediator GetMediatorOrThrow()
        {
            if (Mediator == null)
                throw new InvalidOperationException("Посредник не установлен.");

            return Mediator;
        }
    }
}
