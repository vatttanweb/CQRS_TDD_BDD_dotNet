using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CQRSwithBDD.DomainModel.Commands
{
    public class DeleteCustomerCommand : IRequest<Customer>
    {
        public DeleteCustomerCommand(Guid id)
        {
            Id = id;
        }
        public Guid Id { get; }
    }
}
