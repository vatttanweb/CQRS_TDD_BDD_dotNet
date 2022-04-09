using CQRSwithBDD.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace CQRSwithBDD.DomainModel.Commands
{
    public class CreateCustomerCommandHandler : IRequestHandler<CreateCustomerCommand, Customer>
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly IMediator _mediator;
        public CreateCustomerCommandHandler(ICustomerRepository customerRepository,IMediator mediator)
        {
            _customerRepository = customerRepository;
            _mediator = mediator;
        }
        public async Task<Customer> Handle(CreateCustomerCommand request, CancellationToken cancellationToken)
        {
            var customer = new CustomerDbValidationProxy(_customerRepository,
                request.Id,
                request.FirstName,request.LastName,request.DateOfBirth,
                request.PhoneNumber, request.Email,
                request.BankAccountNumber,true).customer;
            Customer addedCustomer = _customerRepository.AddCustomerToESAsync(customer).Result;
            if (addedCustomer != null)
            {
                await _mediator.Publish(new CreateCustomerSyncEvent(addedCustomer.Id), cancellationToken);
                //var result = await _customerRepository.AddReplayedCustomerToSql(addedCustomer.Id);
            }
            return addedCustomer;
        }
        }
    }
