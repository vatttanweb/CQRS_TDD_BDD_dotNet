using CQRSwithBDD.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace CQRSwithBDD.DomainModel.Commands
{
    public class UpdateCustomerSyncEventHandler
    {
        private readonly ICustomerRepository _customerRepository;
        public UpdateCustomerSyncEventHandler(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }

        public async Task Handle(CreateCustomerSyncEvent notification, CancellationToken cancellationToken)
        {
            var result = await _customerRepository.UpdateReplayedCustomerInSql(notification.Id);
        }
    }
}
