using CQRSwithBDD.Data;
using CQRSwithBDD.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace CQRSwithBDD.DomainModel.Commands
{
    public class DeleteCustomerCommandHandler : IRequestHandler<DeleteCustomerCommand, Customer>
    {
        private readonly ICustomerRepository _customerRepository;
        private CustomerDbContext _dbContext;
        private IMediator _mediator;
        public DeleteCustomerCommandHandler(ICustomerRepository customerRepository,
            CustomerDbContext dbContext,IMediator mediator)
        {
            _customerRepository = customerRepository;
            _dbContext = dbContext;
            _mediator = mediator;
        }

        public async Task<Customer> Handle(DeleteCustomerCommand request, CancellationToken cancellationToken)
        {
            var customer = _dbContext.Customers.SingleOrDefault(c=>c.Id==request.Id);
            customer.Active = false;
            Customer deletedCustomer = _customerRepository.UpdateCustomerInES(customer).Result;
            if (deletedCustomer != null)
            {
                //var result = await _customerRepository.UpdateReplayedCustomerInSql(deletedCustomer.Id);
                await _mediator.Publish(new CreateCustomerSyncEvent(deletedCustomer.Id), cancellationToken);
            }
            return deletedCustomer;
        }
    }
}
