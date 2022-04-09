using CQRSwithBDD.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace CQRSwithBDD.DomainModel.Commands
{
    public class CustomerSyncWithSqlHandler : INotificationHandler<CreateCustomerSyncEvent>
    {
        private readonly ICustomerRepository _customerRepository;
        public CustomerSyncWithSqlHandler(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }

        public async Task Handle(CreateCustomerSyncEvent notification, CancellationToken cancellationToken)
        {
            var result = await _customerRepository.AddReplayedCustomerToSql(notification.Id);
        }

    }
}
