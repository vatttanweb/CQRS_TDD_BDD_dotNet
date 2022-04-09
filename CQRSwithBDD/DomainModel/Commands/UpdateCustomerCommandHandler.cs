using CQRSwithBDD.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace CQRSwithBDD.DomainModel.Commands
{
    public class UpdateCustomerCommandHandler : IRequestHandler<UpdateCustomerCommand, Customer>
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly IMediator _mediator;
        public UpdateCustomerCommandHandler(ICustomerRepository customerRepository,IMediator mediator)
        {
            _customerRepository = customerRepository;
            _mediator = mediator;
        }

        public async Task<Customer> Handle(UpdateCustomerCommand request, CancellationToken cancellationToken)
        {
            var customer = new Customer(request.Id,request.FirstName, request.LastName, request.DateOfBirth, request.PhoneNumber, request.Email, request.BankAccountNumber, true);
            Customer addedCustomer = _customerRepository.UpdateCustomerInES(customer).Result;
            if (addedCustomer != null)
            {
                //var result = await _customerRepository.UpdateReplayedCustomerInSql(addedCustomer.Id);
                await _mediator.Publish(new CreateCustomerSyncEvent(addedCustomer.Id), cancellationToken);
            }
            return addedCustomer;
        }
    }
}
