using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CQRSwithBDD.DomainModel.Commands
{
    public class CreateCustomerSyncEvent : INotification
    {
        public CreateCustomerSyncEvent(Guid id)
        {
            Id = id;
        }
        public Guid Id { get; }
    }
}
