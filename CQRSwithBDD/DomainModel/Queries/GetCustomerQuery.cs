using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CQRSwithBDD.DomainModel.Queries
{
    public class GetCustomerQuery : IRequest<Customer>
    {
        public Guid Id { get; set; }
    }
}
