using CQRSwithBDD.DomainModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CQRSwithBDD.Repositories
{
    public interface ICustomerRepository
    {
         Task<Customer> AddCustomerToESAsync(Customer customer);
        Task<Customer> AddReplayedCustomerToSql(Guid Id);
        Task<Customer> UpdateReplayedCustomerInSql(Guid Id);
        Task<Customer> UpdateCustomerInES(Customer customer);
        Task<Customer> GetCustomerAsync(Guid guid);
         void CreateConnection(string url);
        bool GetUniqueInEmail(string email);
        bool GetUniqueInFirstAndLastName(string firstName, string lastName, DateTime dateOfBirth);


    }

}
