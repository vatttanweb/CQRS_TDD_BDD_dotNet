using CQRSwithBDD.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace CQRSwithBDD.DomainModel.Queries
{
    public class GetCustomerQueryHandler : IRequestHandler<GetCustomerQuery, Customer>
    {
        private readonly ICustomerRepository _customerRepository;
        public GetCustomerQueryHandler(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }
        public async Task<Customer> Handle(GetCustomerQuery request, CancellationToken cancellationToken)
        {
            var customer = await _customerRepository.GetCustomerAsync(request.Id);
            return customer;
        }
    }
}
